// Introducing "let something = something else"

let x = 42
// x is an immutable *value*
// everywhere you see "x" you can replace it with 42

// val x : int = 42
//       ^colon is for type annotations


// let is used to define functions as well

// a 2-parameter function
let add x y = x + y
//       ^ spaces between params
//                     ^ no return keyword


// test it
add 2 3
// ^    ^ spaces between params
//      (except when calling OO code like .NET library)

let square x =
    x * 2

let double x =
    let two = 2
    x * two

let squareAndDouble x =
    let y = square x
    double y // no return keyword


(*
How to convert from a C-style language to F#
    * change to "let ... =" for definitionns
    * indent how you normally would
    * delete the { }
    * delete "return"
    * delete semicolons
    * you often can delete type annotations as well!
*)

// C-style language
(*
int squareAndDouble(int x)
{
    var y = square(x);
    return double(y);
}

// converted to F#-style

let squareAndDouble x =
    let y = square x
    double y
*)

// instances where { } are used
// the curly bracers after async is a computation expression

let downloadManyFiles() =
    async {
        let! contentsA = downloadFile "source/a.txt"
        do! uploadFile contentsA "target/a.txt"
        return "OK"
    }

    // the ! after let is called "bang"
    // in an "async" computation expression:
    // let! is like "await"
    // do! is like "await void"

    (*
    computation expressions are used for:
    * async/task
    * queries (like query expressions in C#)
    * generation collections/enums
    * validation
    * error handling
    * testing
    * code generation
    * etc etc
    *)

// generate a sequence/enumerable

seq {
    yield! [1..10]
    for i in [1..10] do yield square i
}

// create a dummy db

let db =
    {| Student = [
        {| StudentId=1; Name="Alice" |}
        {| StudentId=2; Name="Bob"|}
    ] |}

// query the db

query {
    for student in db.Student do
    where (student.StudentId > 4)
    sortBy student.Name
    select student
}


// ===================================
// Introducting the pipeline operator
// ===================================

let add42 x = x + 42

// instead of
// let squareDoubleAdd42 x =
//      add42(double(square(x)))

let squareAndDouble42 x =
    x |> square |> double |> add42

(*
    feed x into square function then

                feed square functions output into double function then

                          feed that output into add42 function
*)

// Pipelines compared to LINQ

open System // open == "using"
open System.Linq 

[1..10]
    .Select(fun x -> x *2) // lambda syntax in F#
    .Where(fun x-> x <= 6)
    .Select(fun x -> String.Format($"x={x}"))
    .ToArray()

// LINQ is not really used in F# since its already built-in with the pipeline functions

[1..10]
|> List.map (fun x -> x * 2)
|> List.filter (fun x -> x <= 6)
|> List.map (sprintf "x=%i")

// pipelies are more flexible because you dont need
// extension methods, you can stick any function inside the pipeline if you wish

let product aList =
    List.fold (*) 1 aList

let logToConsole input =
    printfn "input=%i" input
    input

[1..10]
|> List.map (fun x -> x * 2)
|> List.filter (fun x -> x <= 6)
|> product
|> logToConsole

// as long as the output of the previous function matches the input of the upcoming function
// it works great, for example we are taking a list of integers, filtering out all entries
// that are less or equal to 6 and then sending them into the functions above which
// take an integer as an input and output an integer