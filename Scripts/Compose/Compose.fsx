let elementAt = ((<<) List.last) << List.take

[1;2;3;4]       |> elementAt 4 |> ((=) 4)   |> printfn "%A"