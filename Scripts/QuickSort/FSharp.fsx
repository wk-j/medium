let filter = List.filter
let rec quick = function
    | [] -> []
    | x :: xs ->
        let p1 = quick <| filter (fun e -> e < x) xs
        let md = x ::    filter (fun e -> e = x) xs
        let p2 = quick <| filter (fun e -> e > x) xs
        p1 @ md @ p2

[1;99;2;98;3;97;4;96;4;95;5;94]
|> quick
|> printfn "%A"