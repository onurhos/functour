namespace Types

module CustomerTypes =  

    open System
    open CommonTypes

    type CustomerValidationError = 
        | CustomerIdShouldNotBeEmpty

    type CustomerId = private CustomerId of Guid
    module CustomerId =
        let create guid = if guid = Guid.Empty then Error CustomerIdShouldNotBeEmpty else Ok (CustomerId guid)
        let value (CustomerId id) = id

    type UnvalidatedCustomer = {
        FirstName: string
        MiddleName : string option
        LastName: string
    }

    type Customer = { 
        Id: CustomerId
        FirstName: Name50
        MiddleName : Name50 option
        LastName: Name50
    }

    type ValidateCustomer =
        UnvalidatedCustomer -> Result<Customer, CustomerValidationError>

    type SaveCustomer =
        Customer -> unit