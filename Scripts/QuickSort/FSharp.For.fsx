let filter = List.filter
let rec quick = function
    | [] -> []
    | x :: xs ->
        [ for n xs when n < x -> n]
        // TODO
        // https://stackoverflow.com/questions/1888451/list-comprehension-in-f

[1;99;2;98;3;97;4;96;4;95;5;94]
|> quick
|> printfn "%A"