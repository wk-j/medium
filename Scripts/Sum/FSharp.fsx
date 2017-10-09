let rec comb n l =
  match (n, l) with
  | (0, _) -> [[]]
  | (_, []) -> []
  | (n, x :: xs) ->
      let withX = List.map (fun l -> x :: l) (comb (n - 1) xs)
      let noX = comb n xs
      withX @ noX

[5;5;6;8;8;12;8;10] 
|> comb 5 
|> List.filter (List.sum >> (=) 40) 
|> printfn "%A"