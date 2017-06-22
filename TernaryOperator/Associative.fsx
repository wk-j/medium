
let p a x = 
    printfn "%s %d" a x
    (x + 1)

let q = p "1" >> p "2" >> p "3"


