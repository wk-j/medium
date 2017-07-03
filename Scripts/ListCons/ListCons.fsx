let flip f x y = f y x
let cons x y = List<_>.Cons(x, y)
let rev xs = List.fold (flip cons) [] xs

let list = 100 :: [200;300]

list |> rev |> printfn "%A"      // [300; 200; 100] 