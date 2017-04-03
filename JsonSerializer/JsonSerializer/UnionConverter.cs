using System;
using Newtonsoft.Json;
using Microsoft.FSharp.Core;
using JsonSerializer2 = Newtonsoft.Json.JsonSerializer;
using System.Linq;
using Microsoft.FSharp.Reflection;
using System.Collections.Generic;
using Microsoft.FSharp.Collections;

namespace JsonSerializer
{
    internal class UnionConverter : JsonConverter
    {
        [Literal]
        private const string discriminator = "__Case";
        private JsonToken[] primitives = new[] { JsonToken.Boolean, JsonToken.Date, JsonToken.Float, JsonToken.Integer, JsonToken.Null, JsonToken.String };

        private void WriteValue(object value, JsonSerializer2 serializer, JsonWriter writer)
        {
            if (value.GetType().IsPrimitive)
                writer.WriteValue(value);
            else
                serializer.Serialize(writer, value);
        }

        private void WriteProperties(object[] fields, JsonSerializer2 serializer, JsonWriter writer)
        {
            for (var i = 0; i < fields.Count(); i++)
            {
                writer.WritePropertyName(string.Format("Item{0}", i));
                WriteValue(fields[i], serializer, writer);
            }
        }

        private void WriteDiscriminator(string name, JsonWriter writer)
        {
            writer.WritePropertyName(discriminator);
            writer.WriteValue(name);
        }

        public override bool CanConvert(Type objectType)
        {
            return FSharpType.IsUnion(objectType, null) &&
            // It seems that both option and list are implemented using discriminated unions, 
            // so tell json.net to ignore them and use different serializer
            !(FSharpType.IsRecord(objectType, null)) &&
            !(objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(FSharpList<>)) &&
            !(objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(FSharpOption<>));
        }

        public override object ReadJson(JsonReader reader, Type destinationType, object existingValue, JsonSerializer2 serializer)
        {
            // Find all the parts for the current object to serialize
            // Will return an array of 
            //      (JsonToken, obj), (JsonToken, obj)
            // e.g. (PropertyName, "__Case"), (String, "Case1DU")
            //      (PropertyName, "Item1"), (Integer, 111)
            ((JsonToken jsonToken1, object theObject1) part1, (JsonToken jsonToken2, object theObject2) part2)[] parts;

            if (reader.TokenType != JsonToken.StartObject)
            {
                parts = new[] { ((JsonToken.Undefined, new object()), (reader.TokenType, reader.Value)) };
            }
            else
            {
                IEnumerable<(JsonToken jsonToken, object theObject)> ReadTokens()
                {
                    while (reader.Read())
                    {
                        yield return (reader.TokenType, reader.Value);
                    }
                }
                var tokens = ReadTokens()
                    .TakeWhile(x => x.jsonToken != JsonToken.EndObject)
                    .ToArray(); // ToArray to prevent double iteration on zip
                parts = tokens
                    .Zip(tokens.Skip(1), (y, z) => (y, z)) // Pairwise
                    .Select((item, index) => (index, item))
                    .Where((index) => index.Item1 % 2 == 0)
                    .Select((index) => index.Item2)
                    .ToArray();
            }

            // Read all the primitive values into a string array
            var primitiveValues = parts
                .Where(part => part.part1.theObject1.ToString() != discriminator)
                .Select(part => part.part2)
                .Where(part => primitives.Contains(part.jsonToken2))
                .Select(part => part.theObject2)
                .ToArray();

            var unionCases = FSharpType.GetUnionCases(destinationType, null);
            var unionCase = parts.FirstOrDefault(x => x.part1.theObject1.ToString() == discriminator).part2;
            UnionCaseInfo unionCaseInfo;

            // Find the case from all the union cases.
            if (unionCase.Equals((JsonToken.None, null)))
            {
                // implied union case
                if (primitiveValues.Any())
                    unionCaseInfo = unionCases.First(x => x.GetFields().Length > 0);
                else
                    unionCaseInfo = unionCases.First(x => x.GetFields().Length == 0);
            }
            else
                unionCaseInfo = unionCases.First(x => x.Name == unionCase.theObject2.ToString());

            // Create the correctly typed values
            var typedValues = unionCaseInfo.GetFields()
                .Zip(primitiveValues, (y, z) => (z, y))
                .Select(x => Convert.ChangeType(x.Item1, x.Item2.PropertyType))
                .ToArray();

            return FSharpValue.MakeUnion(unionCaseInfo, typedValues, null);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer2 serializer)
        {
            var unionCases = FSharpType.GetUnionCases(value.GetType(), null);
            var unionType = value.GetType();
            var fieldsTuple = FSharpValue.GetUnionFields(value, unionType, null);
            var caseinfo = fieldsTuple.Item1;
            var fields = fieldsTuple.Item2;
            var allCasesHaveValues = unionCases.Select(x => x.GetFields().Length > 0).Any();

            if (unionCases.Length == 2 && !fields.Any() && !allCasesHaveValues)
            {
                writer.WriteNull();
            }
            else if (unionCases.Length == 1 && fields.Count() == 1 ||
                    (unionCases.Length == 2 && fields.Count() == 1 && !allCasesHaveValues))
            {
                WriteValue(fields[0], serializer, writer);
            }
            else if (unionCases.Length == 1 ||
                    (unionCases.Length == 2 && !allCasesHaveValues))
            {
                writer.WriteStartObject();
                WriteProperties(fields, serializer, writer);
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteStartObject();
                WriteDiscriminator(caseinfo.Name, writer);
                WriteProperties(fields, serializer, writer);
                writer.WriteEndObject();
            }
        }
    }
}
