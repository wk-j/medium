#r "../../packages/FSharp.Data/lib/net45/FSharp.Data.dll"

open FSharp.Data


[<Literal>]
let Template = """{ "name": "x", "age": 0}"""

type Person = JsonProvider<Template>

let input = """{ "name": "wk", "age": 15 }"""
let data = Person.Parse(input)

data.Age  |> printfn "%A" // 15
data.Name |> printfn "%A" // "wk"
data.XXX  |> printfn "%A" // member 'XXX' is not defined






