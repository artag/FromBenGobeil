// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open FSharpPlus

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let message = from "F#" // Call the function
    let message = String.replace "from" "to" message
    printfn "Hello world %s" message
    0 // return an integer exit code