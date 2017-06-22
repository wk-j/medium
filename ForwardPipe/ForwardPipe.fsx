open System

let double = (*) 2
let toString = sprintf "%010i"

100 |> double |> toString |> printfn "%s"    // 0000000200

