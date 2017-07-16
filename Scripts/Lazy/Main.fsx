open System
open System.Threading

let a = lazy( 1 + 1)
let b = lazy (2 + 2)

type Foo() = 
    let d = DateTime.Now.ToString("ss.fff") 
    member x.TimeItIs = d

let f1 = Foo()
let f2 = Foo()
let f3 = lazy(Foo())

printfn "%A" f1.TimeItIs
Thread.Sleep 1000

printfn "%A" f2.TimeItIs
Thread.Sleep 1000

printfn "%A" f3.Value.TimeItIs
Thread.Sleep 1000
