namespace Types

module CustomerTypes =  

    open System
    open CommonTypes

    
    type PersonId = private PersonId of Guid
    module PersonId =
        let create guid = 
            if  guid = Guid.Empty then
                failwith "Guid should not be empty"
            else
                PersonId guid
        
        let value (PersonId personId) = 
            personId

    type Customer = { 
        Id: PersonId; 
        FirstName: Name50; 
        LastName: Name50; 
    }