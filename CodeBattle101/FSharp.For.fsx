open System.IO
open System.Linq
open System

let run data target = 
    let len = data |> List.length
    let mutable rs = 0L
    let mutable diff = Int64.MaxValue
    for i1 in [0..(len - 3)] do
        for i2 in [i1 + 1 .. (len - 2)] do
            for i3 in [(i2 + 1) .. (len - 1)] do
                let a1 = data.[i1]
                let a2 = data.[i2]
                let a3 = data.[i3]
                let p = a1 * a2 * a3
                let ff = abs(target - p)
                if ff < diff then
                    diff <- ff
                    rs <- p

    (rs, diff)

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
    let rs , _ = run data target
    printfn "%A"  rs

#time
//show exData    exTarget
//show smallData smallTarget
show largeData largeTarget
#time