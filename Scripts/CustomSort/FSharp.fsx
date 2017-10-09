let compare a1 a2 = 
    if a1 = a2 then 0 
    elif a1 > a2 then -1
    else 1

[1;2;3;4;5]
|> List.sortWith compare
|> printfn "%A"