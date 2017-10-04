let con a b = List.Cons(a,b)
let rec f = function
    | [] -> [[]]
    | x :: xs -> (f xs) @ (List.map (con x) (f xs))

f [2;45;67;119;1;14;299]
|> List.filter (List.sum >> ((>) 331))
|> List.filter (List.length >> ((<) 1))
|> printfn "%A"