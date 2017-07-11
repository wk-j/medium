open System

type CommandLineInstruction<'a> = 
    | ReadLine of (string -> 'a)
    | WriteLine of string * 'a

type CommandLineProgram<'a> = 
    | Free of CommandLineInstruction<CommandLineProgram<'a>>
    | Pure of 'a

let program = 
    Free(WriteLine(
            "Please enter your name.",
                Free(ReadLine(
                        fun s -> Free(WriteLine(sprintf "Hello, %s!" s, Pure()))))))

let rec interpret = function
    | Pure x -> x
    | Free (ReadLine next) -> Console.ReadLine() |> next |> interpret
    | Free (WriteLine (s, next)) ->
        Console.WriteLine s
        next |> interpret

let pirvate mapI f = function
    | ReadLine next -> ReadLine (next >> f)
    | WriteLine (x, next) -> WriteLine(x, next |> f)

//program |> interpret