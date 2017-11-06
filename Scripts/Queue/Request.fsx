#r "../../packages/FSharp.Data/lib/net45/FSharp.Data.dll"

open FSharp.Data
open System
open System.Threading.Tasks

let task =  
    async {
        printfn "id = %A" System.Threading.Thread.CurrentThread.ManagedThreadId
    }

let loop  = 
    async {
        while true do
            task 
            |> Async.RunSynchronously
    }

let fetch = 
    async {
        loop
        |> List.replicate 1000
        |> Async.Parallel
        |> Async.RunSynchronously
        |> ignore
    }

Async.Start fetch
Console.ReadLine()