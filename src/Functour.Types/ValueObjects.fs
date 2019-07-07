namespace Types
open System

//  Common

type Undefined = exn

//  Currency

type Currency = 
    | Dollar
    | Ruble
    | Tl

//  Money

type Money = private Money of (decimal * Currency)
module Money =
    let create ( value:decimal, currency:Currency ) = 
        if  value <= 0m then
            failwith "Money value must be required"
        else
            Money (value, currency)

    let value (Money money) = 
        money

//  Name50

type Name50 = private Name50 of string
module Name50 =
    let create (str:string) = 
        let MaxValue = 50
        if  str.Length > MaxValue then
            failwithf "Name should be %d characters long." MaxValue
        else
            Name50 str
    
    let value (Name50 name) = 
        name

//  Person Id

type PersonId = private PersonId of Guid
module PersonId =
    let create guid = 
        if  guid = Guid.Empty then
            failwith "Guid should not be empty"
        else
            PersonId guid
        
    let value (PersonId personId) = 
        personId