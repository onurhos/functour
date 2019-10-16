namespace Types

module CustomerTypes =  

    open System
    open CommonTypes

    type BirthDate = BirthDate of DateTime

    type Gender =
        | Male of bool
        | Female of bool

    type CustomerValidationError = 
        | CustomerIdShouldNotBeEmpty

    [<Struct>]
    type CustomerId = private CustomerId of Guid
    module CustomerId =
        let value (CustomerId id) = id
        let create fieldName guid = 
            ConstrainedType.createGuid fieldName CustomerId guid

    type UnvalidatedCustomer = {
        FirstName: string
        MiddleName : string option
        LastName: string
        Email : string
        Gender : bool
        BirthDate : BirthDate
    }

    [<NoEquality; NoComparison>]
    type Customer = { 
        Id: CustomerId
        FirstName: String50
        MiddleName : String50 option
        LastName: String50
        Email : EmailAddress
        Gender : Gender
        BirthDate : BirthDate
    } 
    with
        override this.Equals(obj) =
            match obj with
            | :? Customer as v -> this.Id = v.Id
            | _ -> false
        override this.GetHashCode() =
            hash this.Id

    type CustomerCreatedEvent = {
        Customer: Customer
    }

    type ValidateCustomer =
        UnvalidatedCustomer -> AsyncValidationResponse<Customer, CustomerValidationError>

    type SaveCustomer =
        Customer -> unit