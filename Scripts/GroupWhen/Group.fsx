
open System

module Seq =
  /// Iterates over elements of the input sequence and groups adjacent elements.
  /// A new group is started when the specified predicate holds about the element
  /// of the sequence (and at the beginning of the iteration).
  ///
  /// For example: 
  ///    Seq.groupWhen isOdd [3;3;2;4;1;2] = seq [[3]; [3; 2; 4]; [1; 2]]
  let groupWhen f (input:seq<_>) = seq {
    use en = input.GetEnumerator()
    let running = ref true
    let mutable index = -1
    
    // Generate a group starting with the current element. Stops generating
    // when it founds element such that 'f en.Current' is 'true'
    let rec group() = 
      [ yield en.Current
        if en.MoveNext() then
          index <- index + 1
          if not (f en.Current index) then yield! group() 
        else running := false ]
    
    if en.MoveNext() then
      index <- index + 1
      // While there are still elements, start a new group
      while running.Value do
        yield group() |> Seq.ofList }

[3;3;2;4;1;2] |> Seq.groupWhen (fun n i -> n%2 = 1) |> Seq.toList |> printfn "%A"
[3;3;2;4;1;2] |> Seq.groupWhen (fun n i -> i % 3 = 0) |> Seq.toList |> printfn "%A"

let bin = Convert.ToString(100, 2).PadLeft(32,  '0')
bin.ToCharArray() |> Seq.groupWhen (fun _ i -> i % 8 = 0) |> Seq.toList |> printfn "%A"