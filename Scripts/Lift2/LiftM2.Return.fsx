module Option =
    let bind f  = function 
        | Some x -> f x 
        | _ -> None

module List = 
    let bind (f: 'a -> 'b list) (xlist: 'a list) =
        [for x in xlist do 
            for y in f x do yield y]

let inline instance1 (a:^a                         ) = 
    ( ^a                                : (static member instance: ^a                     -> _) (a          ))
let inline instance2 (a:^a,b:^b                    ) =                                                      
    ((^a or ^b                        ) : (static member instance: ^a* ^b                 -> _) (a,b        ))
let inline instance3 (a:^a,b:^b,c:^c               ) =                                                          
    ((^a or ^b or ^c                  ) : (static member instance: ^a* ^b* ^c             -> _) (a,b,c      ))
let inline instance4 (a:^a,b:^b,c:^c,d:^d          ) =                                                          
    ((^a or ^b or ^c or ^d            ) : (static member instance: ^a* ^b* ^c* ^d         -> _) (a,b,c,d    ))
let inline instance5 (a:^a,b:^b,c:^c,d:^d,e:^e     ) =                                                          
    ((^a or ^b or ^c or ^d or ^e      ) : (static member instance: ^a* ^b* ^c* ^d* ^e     -> _) (a,b,c,d,e  ))
let inline instance6 (a:^a,b:^b,c:^c,d:^d,e:^e,f:^f) =                                   
    ((^a or ^b or ^c or ^d or ^e or ^f) : (static member instance: ^a* ^b* ^c* ^d* ^e* ^f -> _) (a,b,c,d,e,f))

type Inline = Inline with
    static member inline Instance (                            ) = fun (x:'x) -> instance1(          Unchecked.defaultof<'r>) x :'r
    static member inline Instance (a:'a                        ) = fun (x:'x) -> instance2(a        ,Unchecked.defaultof<'r>) x :'r
    static member inline Instance (a:'a, b:'b                  ) = fun (x:'x) -> instance3(a,b      ,Unchecked.defaultof<'r>) x :'r
    static member inline Instance (a:'a, b:'b, c:'c            ) = fun (x:'x) -> instance4(a,b,c    ,Unchecked.defaultof<'r>) x :'r
    static member inline Instance (a:'a, b:'b, c:'c, d:'d      ) = fun (x:'x) -> instance5(a,b,c,d  ,Unchecked.defaultof<'r>) x :'r
    static member inline Instance (a:'a, b:'b, c:'c, d:'d, e:'e) = fun (x:'x) -> instance6(a,b,c,d,e,Unchecked.defaultof<'r>) x :'r

type Return = Return with
    static member Instance (_: 'a list) = fun x -> [x]
    static member Instance (_: 'a option) = Some 

let inline return' x = Inline.Instance Return x

type Bind = Bind with
    static member (>>=) (_, x:option<_>)    = fun f ->  Option.bind f x
    static member (>>=) (_, x:list<_>)      = fun f -> List.bind  f x

let result x = Choice1Of2 x

let inline (>>=) f x = Bind >>= f <| x
let inline liftM2 f m1 m2 = m1 >>= fun x1 -> m2 >>= fun x2 -> return' (f x1 x2)

let inline f1 i1 i2 = [i1 + i2]
let inline f2 o1 o2 = Some(o1 + o2)

//liftM2 f1 [1] [1;2]              |> printfn "%A"     // [2,3]
//liftM2 (+) (Some 1) (Some 2)      |> printfn "%A"     // Some 3
//liftM2 f2 (Some 1) None          |> printfn "%A"     // <null>


let ff1 x : double  = 100.0 

let ff2 x = 100. : double

