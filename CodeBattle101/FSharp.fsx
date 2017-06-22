open System.IO
open System.Linq
open System

type Result = 
  { P : int64
    Diff : int64 }

let run (data: int64 list) target = 
    query 
      { for a1 in data do
        for a2 in data do
        for a3 in data do
        let p = a1 * a2 * a3
        let diff = abs(target - p)
        select { P = p; Diff = diff } } 
    |> Seq.sortBy (fun x -> x.Diff)
    |> Seq.head

let clean (x: string) = x.Trim() |> Int64.Parse

let exData  = [1L;2L;3L;4L;5L]
let exTarget = 25L

let smallTarget = 29592974112914L
let smallData = 
    File.ReadAllLines("CodeBattle101/SmallCase.txt").Select(clean)
    |> Seq.toList

let largeTarget = 30470556801191L
let largeData = 
    File.ReadAllLines("CodeBattle101/LargeCase.txt").Select(clean)
    |> Seq.groupBy(id) 
    |> Seq.map (fun (k, v) -> v.First())
    |> Seq.toList

let show data target = 
    let rs = run data target
    printfn "%A" rs.P

#time
show exData    exTarget
show smallData smallTarget
//run largeData largeTarget
#time