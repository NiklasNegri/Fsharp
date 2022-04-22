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



