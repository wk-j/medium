let filter = List.filter
let rec quick = function
    | [] -> []
    | x :: xs ->
        let p1 = xs |> filter (fun e -> e >= x)  |> quick
        let p2 = xs |> filter (fun e -> e < x) |> quick
        p1 @ [x] @ p2

[1;99;2;98;3;97;4;96;4;95;5;94]
|> quick
|> printfn "%A"

['a'; 'B'; 'C';'0']
|> quick
|> printfn "%A"