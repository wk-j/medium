type Author() = 
    member val Name = "" with set,get 
    member val TwitterHandle = "" with set,get
    member val Company = "" with set,get

let list = [
    Author(Name = "A1", TwitterHandle = "T1", Company = null)
    Author(Name = "A2", TwitterHandle = "T1", Company = "C1")
    Author(Name = "A3", TwitterHandle = "T1", Company = "C1") ] 

let twitterHandles (authors : seq<Author>, company : string) = 
    authors
           |> Seq.filter(fun a -> a.Company = company)
           |> Seq.map(fun a -> a.TwitterHandle )
           |> Seq.filter (isNull >> not)

let s = Seq.ofList list

twitterHandles (s,"C1") |> printfn "%A"


let x = 100.0f : float32
let y = 100. : double

printfn "%A" double
printfn "%A" float
