let hasSubsetSum_Naive (numbers: int list) S =
  let rec hasSubsetSum (a: int list) lastSum =
    match a with 
      | [] -> false
      | x::rest -> 
        if lastSum + x = S then
          true
        elif lastSum + x > S then
          false
        else
          hasSubsetSum rest lastSum || hasSubsetSum rest (lastSum+x)
  
  hasSubsetSum numbers 0

let numbers = [5;5;6;8;8;12;8;10] 
let searchedSum = 40
hasSubsetSum_Naive numbers searchedSum |> printfn "%A"
