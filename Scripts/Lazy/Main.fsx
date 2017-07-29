open System
open System.Threading

type Foo() = 
    let d = DateTime.Now.ToString("ss.fff") 
    member x.TimeItIs = d

let f1 = Foo()
let f2 = Foo()

let a = lazy(100 + 100)
let b = lazy(Foo())

printfn "%A" f1.TimeItIs
Thread.Sleep 1000

printfn "%A" f2.TimeItIs
Thread.Sleep 1000

printfn "%A" b.Value.TimeItIs
Thread.Sleep 1000
