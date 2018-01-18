#light                         "off"
type A(x:int) =
                class member 
val X = x with get,set end

A(100).X |> printfn "%A"