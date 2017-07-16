let fib n = 
    Seq.unfold (fun (first, second) -> Some (second, (second, second + first))) (1, 1)
    |> Seq.take n
    |> Seq.toList

fib 5 |> printfn "%A"       // [1; 2; 3; 5; 8]