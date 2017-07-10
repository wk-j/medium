type Dup() =
    member this.Bind(xs, f) = List.collect f xs
    member this.Return x = x

let dup input = 
    let ins = Dup()
    ins { 
        let! x = input
        return [x; x]
    }

[1; 2; 3]         |> dup |> printfn "%A"  // [1; 1; 2; 2; 3; 3]
["A"; "B"; "C"]   |> dup |> printfn "%A"  // ["A"; "A"; "B"; "B"; "C"; "C"]