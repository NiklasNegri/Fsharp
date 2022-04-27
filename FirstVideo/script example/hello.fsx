open System

// run script by typing dotnet "fsi .\1HelloWorld\hello.fsx" in cli

printf "What is your name: "
let name = Console.ReadLine()
printfn "Hello %s" name
