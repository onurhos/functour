module CustomerTypesTests

open System
open Xunit
open Types.CommonTypes
open Types.CustomerTypes
open FsUnit.Xunit

[<Fact>]
let ``Creating A Customer Should Succeed`` () =
    let guid = Guid.NewGuid()
    let creationResultOfId = Id.create guid
    let customerId = 
        match creationResultOfId with 
            | Ok resultId -> CustomerId resultId
            | _ -> failwith "Error"
    
    let (CustomerId customerIdVal) = customerId
    Id.value customerIdVal |> should equal guid
