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
        let! contetsA = downloadFile "source/a.txt"
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