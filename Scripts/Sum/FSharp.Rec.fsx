module List = 
    let cons h t = h :: t

let rec comb n l =
  match (n,l) with
  | (0, _) -> [[]]
  | (_, []) -> []
  | (n, x :: xs) -> 
    printfn "%A, %A :: %A" n x xs
    let withX = List.map (List.cons x) <| comb (n - 1) xs
    let noX = comb n xs
    let k = withX @ noX
    printfn "-- %A @ %A = %A" withX noX k
    k

[1;2;3;4;5] |> comb 3 |> printfn "\n\n%A"


// [[1; 2; 3]; [1; 2; 4]; [1; 2; 5]; [1; 3; 4]; [1; 3; 5]; [1; 4; 5]; [2; 3; 4]; [2; 3; 5]; [2; 4; 5]; [3; 4; 5]]
// [5;5;6;8;8;12;8;10] |> comb 5 |> List.filter (List.sum >> (=) 40) |> printfn "%A"