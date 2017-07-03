module Option =
    let bind f opt = 
        match opt with
        | Some x -> f x 
        | _ -> None

module List = 
    let bind (f: 'a -> 'b list) (xlist: 'a list) =
        [for x in xlist do
            for y in f x do 
                yield y]

type Bind = Bind with
    static member (>>=) (_, x:option<_>)    = fun f -> Option.bind f x
    static member (>>=) (_, x:list<_>)      = fun f -> List.bind  f x

let inline (>>=) f x = Bind >>= f <| x
let inline liftM2 f m1 m2 = m1 >>= fun x1 -> m2 >>= fun x2 -> f x1 x2

let inline f1 i1 i2 = [i1 + i2]
let inline f2 o1 o2 = Some(o1 + o2)

liftM2 f1 [1] [1;2]              |> printfn "%A"     // [2,3]
liftM2 f2 (Some 1) (Some 2)      |> printfn "%A"     // Some 3
liftM2 f2 (Some 1) None          |> printfn "%A"     // <null>