module CustomerTypesTests

open System
open Xunit
open FsUnit.Xunit
open Types.CustomerTypes

[<Fact>]
let ``Creating And Getting Customer Id Should Be Ok`` () =
    let expectedCustomerIdValue = Guid.NewGuid()
    let customerCreateResult = CustomerId.create expectedCustomerIdValue
    let customerIdValue = 
        match customerCreateResult with
        | Ok customerId -> CustomerId.value customerId
        | _ -> Guid.Empty
    customerIdValue |> should equal expectedCustomerIdValue