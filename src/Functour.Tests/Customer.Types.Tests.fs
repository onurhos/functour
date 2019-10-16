namespace Tests

module CustomerTypesTests = 

    open System
    open Xunit
    open FsUnit.Xunit
    open Types.CustomerTypes
    open Types.Predicates

    [<Fact>]
    let ``creating customer id with empty guid should be fail`` () =
        let expectedId = Guid.Empty
        let result = CustomerId.create "CustomerId" expectedId
        result |> isError |> should equal true

    [<Fact>]
    let ``creating and getting customer id should be ok`` () =
        let expectedId = Guid.NewGuid()
        let result = CustomerId.create "CustomerId" expectedId
        result |> isOk |> should equal true
        result |> shouldOk |> CustomerId.value |> should equal expectedId