using Domain;
using Microsoft.FSharp.Core;
using Microsoft.FSharp.Collections;
using System;
using Newtonsoft.Json;
using System.Diagnostics;

namespace JsonSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var myObject = new MyObject(
                100,
                SingleCaseUnion.NewSingleCaseUnion(12345),
                DiscriminatedUnion.NewCase1DU(111, "aaa"),
                ListModule.OfSeq(new[] {0, 1, 2, 3, 4, 5 }),
                MapModule.OfSeq(new[] { Tuple.Create("One", 1), Tuple.Create("Two", 2) }),
                Tuple.Create("Hello", "F# fans"),
                FSharpOption<string>.Some("Option1")
            );

            //var converters = new JsonConverter[0];
            var converters = new JsonConverter[] { new UnionConverter() };

            // Test a single serialize and deserialize
            var json = JsonConvert.SerializeObject(myObject, converters);
            var myNewObject = JsonConvert.DeserializeObject<MyObject>(json, converters);
            Console.WriteLine("Writing {0}", json);
            //Console.WriteLine("Objects are the same {0}", (myObject == myNewObject));

            var count = 10000;
            Duration(() => SerializeLoad(false, count, myObject, converters), count, "Serialize Default");
            Duration(() => DeserializeLoad(false, count, myObject, converters), count, "Deserialize Default");
            Duration(() => SerializeLoad(true, count, myObject, converters), count, "Serialize Custom");
            Duration(() => DeserializeLoad(true, count, myObject, converters), count, "Deserialize Custom");
        }

        private static void SerializeLoad(bool useConverter, int count, MyObject myObject, JsonConverter[] converters)
        {
            for (var i = 1; i < count; i++)
            {
                if (useConverter)
                    JsonConvert.SerializeObject(myObject, converters);
                else
                    JsonConvert.SerializeObject(myObject);
            }
        }

        private static void DeserializeLoad(bool useConverter, int count, MyObject myObject, JsonConverter[] converters)
        {
            var json = useConverter ? JsonConvert.SerializeObject(myObject, converters) : JsonConvert.SerializeObject(myObject);
            for (var i = 1; i < count; i++)
            {
                if (useConverter)
                    JsonConvert.DeserializeObject<MyObject>(json, converters);
                else
                    JsonConvert.DeserializeObject<MyObject>(json);
            }
        }

        private static void Duration(Action action, int count, string testName)
        {
            var timer = new Stopwatch();
            timer.Start();
            action();
            timer.Stop();
            Console.WriteLine("Elapsed time for {0}: {1}", testName, timer.ElapsedMilliseconds);
            Console.WriteLine("Operations per second for {0}: {1}", testName, ((float)(count * 1000) / (float)(timer.ElapsedMilliseconds)));
        }
    }
}
