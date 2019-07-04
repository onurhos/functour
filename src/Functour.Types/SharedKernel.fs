namespace Functour.Types

open System 

module SharedKernel =
        
    type Name = Name of string
    type PersonId = PersonId of Guid
    type Person = { Id:PersonId; FirstName:Name; LastName:Name }