open System.Collections.Generic
open System.Linq
open System

let list = [for x in 1L..10000000L do yield 1L] |> List 

let e = list :> IEnumerable<int64>
#time
e.Count()    |> printfn "%A"
#time

#time

#time
list.Count      |> printfn "%A"  
#time






"Hello, world!" |> printfn "%A"