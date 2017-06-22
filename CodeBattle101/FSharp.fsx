#r "../packages/LinqOptimizer.FSharp/lib/LinqOptimizer.Core.dll"
#r "../packages/LinqOptimizer.FSharp/lib/LinqOptimizer.Base.dll"
#r "../packages/LinqOptimizer.FSharp/lib/LinqOptimizer.FSharp.dll"

open System.IO
open System.Linq
open System
open Nessos.LinqOptimizer.FSharp

[<Struct>]
type Result = { 
    P : int64
    Diff : int64
}

let run data target length = 
    let result = 
        query {
            for a1 in data do
            for a2 in data do
            for a3 in data do
            let p = a1 * a2 * a3
            let diff = abs(target - p)
            where (a1 <> a2 && a1 <> a3 && a2 <> a3)
            select { P = p; Diff = diff }
            //select (p, diff)
        } |> Query.ofSeq

    //let ans (p, diff) = p
    let ans { P = p } = p

    result
    //|> Seq.sortBy (fun (p, diff) -> diff) 
    |> Query.sortBy (fun x -> x.Diff)
    |> Query.take(1)
    |> Query.run
    //|> Seq.head
    |> printfn "%A"

let clean (x: string) = x.Trim() |> Int64.Parse

let exData  = [1L;2L;3L;4L;5L]
let exTarget = 25

let smallData = File.ReadAllLines("CodeBattle101/SmallCase.txt").Select(clean)
let smallTarget = 29592974112914L

let largeData = File.ReadAllLines("CodeBattle101/LargeCase.txt").Select(clean)
let largeTarget = 30470556801191L

//run (smallData.AsQueryable()) smallTarget 14
run (largeData.AsQueryable()) largeTarget 10