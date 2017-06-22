#r "../packages/LinqOptimizer.FSharp/lib/LinqOptimizer.Core.dll"
#r "../packages/LinqOptimizer.FSharp/lib/LinqOptimizer.Base.dll"
#r "../packages/LinqOptimizer.FSharp/lib/LinqOptimizer.FSharp.dll"

open System.IO
open System.Linq
open System
open Nessos.LinqOptimizer.FSharp

type Result = 
  { P : int64
    Diff : int64 }

let run data target = 
    query 
      { for a1 in data do
        for a2 in data do
        for a3 in data do
        where (a1 <> a2 && a1 <> a3 && a2 <> a3)
        let p = a1 * a2 * a3
        let diff = abs(target - p)
        select { P = p; Diff = diff } } 
    |> Query.ofSeq
    |> Query.sortBy (fun x -> x.Diff)
    |> Query.take(1)
    |> Query.run
    |> Seq.head

let clean (x: string) = x.Trim() |> Int64.Parse

let exData  = [1L;2L;3L;4L;5L]
let exTarget = 25

let smallData = File.ReadAllLines("CodeBattle101/SmallCase.txt").Select(clean)
let smallTarget = 29592974112914L

let largeData = 
    File.ReadAllLines("CodeBattle101/LargeCase.txt").Select(clean)
    |> Seq.groupBy(id) 
    |> Seq.map (fun (k, v) -> v.First())

let largeTarget = 30470556801191L

#time
run (smallData.AsQueryable()) smallTarget |> printfn "%A"
//run (largeData.AsQueryable()) largeTarget |> printfn "%A"
#time