#load "../../paket-files/eiriktsarpalis/TypeShape/src/TypeShape/TypeShape.fs"

type TestType = (int list * string option * string) * (bool * unit)
let value : TestType =  (([1..5], None, "42"), (false, ()))


let p1 = sprintf "%A" : TestType -> string
