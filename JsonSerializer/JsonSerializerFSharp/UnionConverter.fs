namespace UnionConverter

open Microsoft.FSharp.Reflection
open Newtonsoft.Json
open System

type UnionConverter() = 
    inherit JsonConverter()
    
    [<Literal>]
    let discriminator = "__Case"
    let primitives = Set [ JsonToken.Boolean; JsonToken.Date; JsonToken.Float; JsonToken.Integer; JsonToken.Null; JsonToken.String ]

    let writeValue (value:obj) (serializer:JsonSerializer) (writer : JsonWriter) =
        if value.GetType().IsPrimitive then writer.WriteValue value
        else serializer.Serialize(writer, value)

    let writeProperties fields serializer (writer : JsonWriter) = 
        fields |> Array.iteri (fun index value -> 
                      writer.WritePropertyName(sprintf "Item%d" index)
                      writeValue value serializer writer)
    
    let writeDiscriminator (name : string) (writer : JsonWriter) = 
        writer.WritePropertyName discriminator
        writer.WriteValue name

    override x.CanConvert(objectType) =
        //printfn "Checking %A" objectType
        
        FSharpType.IsUnion objectType &&
        // It seems that both option and list are implemented using discriminated unions, 
        // so tell json.net to ignore them and use different serializer
        not (FSharpType.IsRecord objectType) &&
        not (objectType.IsGenericType  && objectType.GetGenericTypeDefinition() = typedefof<list<_>>) &&
        not (objectType.IsGenericType  && objectType.GetGenericTypeDefinition() = typedefof<option<_>>)

    override x.WriteJson(writer, value, serializer) =
        //printfn "Writing %A" value
        let unionCases = FSharpType.GetUnionCases(value.GetType())
        let unionType = value.GetType()
        let case, fields = FSharpValue.GetUnionFields(value, unionType)
        let allCasesHaveValues = unionCases |> Seq.forall (fun c -> c.GetFields() |> Seq.length > 0)

        match unionCases.Length, fields, allCasesHaveValues with
        | 2, [||], false -> writer.WriteNull()
        | 1, [| singleValue |], _
        | 2, [| singleValue |], false -> writeValue singleValue serializer writer
        | 1, fields, _
        | 2, fields, false -> 
            writer.WriteStartObject()
            writeProperties fields serializer writer
            writer.WriteEndObject()
        | _ -> 
            writer.WriteStartObject()
            writeDiscriminator case.Name writer
            writeProperties fields serializer writer
            writer.WriteEndObject()

    override x.ReadJson(reader, destinationType, existingValue, serializer) =
        // Find all the parts for the current object to serialize
        // Will return an array of 
        //      (JsonToken, obj), (JsonToken, obj)
        // e.g. (PropertyName, "__Case"), (String, "Case1DU")
        //      (PropertyName, "Item1"), (Integer, 111)
        let parts = 
            if reader.TokenType <> JsonToken.StartObject then [| (JsonToken.Undefined, obj()), (reader.TokenType, reader.Value) |]
            else 
                reader |> Seq.unfold (fun reader -> 
                                         if reader.Read() then Some((reader.TokenType, reader.Value), reader)
                                         else None)
                |> Seq.takeWhile(fun (token, _) -> token <> JsonToken.EndObject)
                |> Seq.pairwise
                |> Seq.mapi (fun id value -> id, value)
                |> Seq.filter (fun (id, _) -> id % 2 = 0)
                |> Seq.map snd
                |> Seq.toArray

        // Read all the primitive values into a string array
        let primitiveValues = 
            parts
            |> Seq.filter (fun ((_, keyValue), _) -> keyValue <> (discriminator :> obj))
            |> Seq.map snd
            |> Seq.filter (fun (valueToken, _) -> primitives.Contains valueToken)
            |> Seq.map snd
            |> Seq.toArray
        
        // Find the case from all the union cases.
        let case = 
            let unionCases = FSharpType.GetUnionCases(destinationType)
            let unionCase =
                parts
                |> Seq.tryFind (fun ((_,keyValue), _) -> keyValue = (discriminator :> obj))
                |> Option.map (snd >> snd)
            match unionCase with
            | Some case -> unionCases |> Array.find (fun f -> f.Name :> obj = case)
            | None ->
                // implied union case
                match primitiveValues with
                | [| null |] -> unionCases |> Array.find(fun c -> c.GetFields().Length = 0)
                | _ -> unionCases |> Array.find(fun c -> c.GetFields().Length > 0)
        
        // Create the correctly typed values
        let typedValues = 
            case.GetFields()
            |> Seq.zip primitiveValues
            |> Seq.map (fun (value, propertyInfo) -> Convert.ChangeType(value, propertyInfo.PropertyType))
            |> Seq.toArray

        FSharpValue.MakeUnion(case, typedValues)
