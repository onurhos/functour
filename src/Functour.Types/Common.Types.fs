namespace Types

module CommonTypes =

    open System

    type Id = private Id of Guid
    module Id =
        let create guid = 
            if  guid = Guid.Empty then
                Error "Guid should not be empty"
            else
                Ok (Id guid)

        let value (Id id) = 
            id

    type Currency = 
        | Dollar
        | Ruble
        | Tl

    type Money = private Money of (decimal * Currency)
    module Money =
        let create ( value:decimal, currency:Currency ) = 
            if  value <= 0m then
                Error "Money value must be required"
            else
                Ok (value, currency)

        let value (Money money) = 
            money

    type Name50 = private Name50 of string
    module Name50 =
        let create (str:string) = 
            let MaxValue = 50
            if  str.Length > MaxValue then
                Error "Name should be 50 characters long."
            else
                Ok(Name50 str)

        let value (Name50 name) = 
            name

    type Name100 = private Name100 of string
    module Name100 =
        let create (str:string) = 
            let MaxValue = 100
            if  str.Length > MaxValue then
                Error "Name should be 100 characters long."
            else
                Ok(Name100 str)

        let value (Name100 name) = 
            name