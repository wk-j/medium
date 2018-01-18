
let (/.) ps f = f ps

let a x = x + 100;

let k = 200/.a

k |> printfn "%A"

