let rec comb n l =
  match (n,l) with
  | (0,_) -> [[]]
  | (_,[]) -> []
  | (n,x :: xs) ->
      let useX = List.map (fun l -> x :: l) (comb (n - 1) xs)
      let noX = comb n xs
      useX @ noX

[5;5;6;8;8;12;8;10] 
|> comb 5 
|> List.filter (List.sum >> (=) 40) 
|> printfn "%A"
