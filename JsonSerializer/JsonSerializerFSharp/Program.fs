open Domain
open UnionConverter
open Newtonsoft.Json

[<EntryPoint>]
let main argv = 
    
    let myObject = { 
        ID = 100
        MySingleCaseUnion = SingleCaseUnion 12345
        MyDiscriminatedUnion = Case1DU(111, "aaa")
        MyList = [0; 1; 2; 3; 4; 5]
        MyDictionary = [ ("One", 1); ("Two", 2) ] |> Map.ofSeq
        MyTuple = "Hello", "F# fans"
        MyOptionType = None //Some("Option1")
    }

    let converters : JsonConverter array = [|UnionConverter()|]
    
    // Test a single serialize and deserialize
    let json = JsonConvert.SerializeObject(myObject, converters)
    let myNewObject = JsonConvert.DeserializeObject<MyObject>(json, converters)
    printfn "Writing %s" json
    printfn "Objects are the same %A" (myObject = myNewObject)

    let duration theFunction count testName = 
        let timer = new System.Diagnostics.Stopwatch()
        timer.Start()
        let returnValue = theFunction()
        timer.Stop()
        printfn "Elapsed time for %s: %i" testName timer.ElapsedMilliseconds
        printfn "Operations per second for %s: %f" testName ((float)(count * 1000) / (float)(timer.ElapsedMilliseconds))
        returnValue  
    
    let count = 10000

    let serializeLoad useConverter = 
        for i in 1..count do
            if useConverter then
                ignore(JsonConvert.SerializeObject myObject, converters)
            else
                ignore(JsonConvert.SerializeObject myObject)

    let deserializeLoad useConverter = 
        let json = if useConverter then JsonConvert.SerializeObject(myObject, converters) else JsonConvert.SerializeObject(myObject)
        for i in 1..count do
            if useConverter then
                ignore(JsonConvert.DeserializeObject<MyObject>(json, converters))
            else
                ignore(JsonConvert.DeserializeObject<MyObject>(json))

    duration (fun() -> serializeLoad false) count "Serialize Default"
    duration (fun() -> deserializeLoad false) count "Deserialize Default"
    duration (fun() -> serializeLoad true) count "Serialize Custom"
    duration (fun() -> deserializeLoad true) count "Deserialize Custom"

    0 // return an integer exit code
