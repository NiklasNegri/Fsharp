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

// anonymous record construction -- type definitions not needed
// useful when sending JSON data for example

let aContact = {| Name="Scott"; Email="scott@example.com"; |}

// ==================
// discriminated unions aka "choice" types "OR" types
// ==================

// a PrimaryColor is Red OR Yellow OR Blue
type PrimaryColor = Red | Yellow | Blue

// you can assign a data type to each choice
type RGB = {R:int; G:string; B:bool}

type Color =
    | Primary of PrimaryColor
    | RGB of RGB
    | Name of string

// testing around
let aColor = Red
let bColor = { R=5; G="s"; B=true }
let cColor = Name "Purple"

// =================
// composing with types (like lego)
// =================

(*
Some requirements:

We accept three payment methods:
Cash, PayPal or Card

For Cash we dont need any extra information
For PayPal we need an email address
For Cards we need a card type and card number

How to implement this?
*)

module PaymentDomain =

    type EmailAddress = string
    type CardType = Visa | Mastercard
    type CardNumber = string

    type CreditCardInfo = {
        CardType : CardType
        CardNumber : CardNumber
    }
    type PaymentMethod =
        | Cash
        | PayPal of EmailAddress
        | Card of CreditCardInfo