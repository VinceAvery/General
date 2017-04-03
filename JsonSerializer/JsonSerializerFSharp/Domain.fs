namespace Domain

type SingleCaseUnion = SingleCaseUnion of int

type DiscriminatedUnion = 
| Case1DU of int * string
| Case2DU of int

type OptionType = Option<string>

type MyObject = { 
    ID : int
    MySingleCaseUnion : SingleCaseUnion
    MyDiscriminatedUnion : DiscriminatedUnion
    MyList : int list
    MyDictionary : Map<string, int>
    MyTuple: string * string
    MyOptionType : OptionType
}