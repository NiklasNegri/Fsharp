// value types
// value types are immutable by default

// string
"new york"
// bool
true
// int
1
// tuple
(3.1, 1.0)
// list
["Learn F#";"Build App";"Profit!"]
// lambda / anonymous function
fun input -> input / 3


// value bindings
let city = "new york"
let fSharpIsAwesome = true
let todoList = ["Practice FSharp";"Practice Csharp"]

// update values
// city was not specified to be muteable, there fore this
city <-  "boston" // doesnt work

// add the mutable keyword when declaring a variable
let mutable mutableCity = "new york"
// then it works
mutableCity <- "boston"