namespace Types

module CommonTypes =

    open System
    open System.Text.RegularExpressions

    type NameValidationError = 
        | NameMaxLengthExceeded
        | NameShouldNotBeEmpty

    type Name50 = private Name50 of string
    module Name50 =
        let create (str:string) = 
            let MaxValue = 50        
            if  String.IsNullOrEmpty(str) then 
                Error NameShouldNotBeEmpty            
            else if  str.Length > MaxValue then
                Error NameMaxLengthExceeded
            else
                Ok(Name50 str)

        let value (Name50 name) = 
            name

    //  Name100

    type Name100 = private Name100 of string
    module Name100 =
        let create (str:string) = 
            let MaxValue = 100
            if  String.IsNullOrEmpty(str) then 
                Error NameShouldNotBeEmpty
            else if  str.Length > MaxValue then
                Error NameMaxLengthExceeded
            else
                Ok(Name100 str)

        let value (Name100 name) = 
            name

    //  Email

    type EmailValidationError =
        | InvalidEmailFormat
        | EmailMaxLengthExceeded

    type Email = private Email of string
    module Email =
        let create (str:string) = 
            let MaxValue = 250
            let regex = Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
            if  str.Length > MaxValue then
                Error EmailMaxLengthExceeded
            else if String.IsNullOrEmpty(str) || regex.IsMatch(str) = false then
                Error InvalidEmailFormat
            else
                Ok(Email str)

        let value (Email email) = 
            email