let cons x y = x

let (|>>) a b =
    match a, b with
    | true , x ->  cons x
    | false , _ ->  id

1 < 2 |>> "Yes" <| "No" |> printfn "%A"   // "Yes"
