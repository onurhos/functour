namespace Types

module CommonTypes =

    open Result

    type Currency = 
        | Dollar
        | Ruble
        | Tl

    type MoneyCreateError = 
        | MoneyValueShouldNotBeNegative

    type Money = private Money of (decimal * Currency)
    module Money =
        let create ( value:decimal, currency:Currency ) = 
            if  value < 0m then
                Error MoneyValueShouldNotBeNegative
            else
                Ok (value, currency)

        let value (Money money) = 
            fst money

        let currency (Money money) = 
            snd money

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