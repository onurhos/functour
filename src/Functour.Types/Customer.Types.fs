namespace Types

module CustomerTypes =  

    open System
    open CommonTypes

    type CustomerId = private CustomerId of Guid
    module CustomerId =
        let create guid = if guid = Guid.Empty then Error "Guid should not be empty" else Ok (CustomerId guid)
        let value (CustomerId id) = id

    type Customer = { 
        Id: CustomerId; 
        FirstName: Name50;
        LastName: Name50;
    }