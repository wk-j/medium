
let rec loop n = 
    if n > 0 then
        printfn "%d" n
        loop (n-1)

type ImperativeTimerCount() =
    let mutable count = 0
    // the event handler. The event args are ignored
    member this.handleEvent _ =
      count <- count + 1
      printfn "timer ticked with count %i" count

// create a handler class
let handler = new ImperativeTimerCount()

// register the handler method
let timerCount1 = createTimer 500 handler.handleEvent

// run the task now
Async.RunSynchronously timerCount1 