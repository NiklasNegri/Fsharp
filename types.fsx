open System

// F# does support OO-style classes  but generally
// "composable" type systems are used for most situations

// ===================
// record types aka "AND" types
// ===================

// immutable record definition
type Thing = { Id:int; Description:string }

// record construction
let aThing = { Id=1; Description="a thing" }

// copy a record using "with"
let anotherThing = { aThing with Id=2 }

let yetAnotherThing = { anotherThing with Description="yet another thing" }

let desc = yetAnotherThing.Description
