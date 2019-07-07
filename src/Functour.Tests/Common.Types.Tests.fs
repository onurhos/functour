module CommonTypesTests

open System
open Xunit
open Types.CommonTypes
open FsUnit.Xunit

[<Fact>]
let ``Creating Id With Empty Guid Should Fail`` () =
    let idResult = Id.create Guid.Empty
    let idCreateResult = 
        match idResult with 
        | Ok _ -> true
        | Error _ -> false
    idCreateResult |> should be False

[<Fact>]
let ``Creating Id With New Guid Should Return Ok And Value Should Be Set Correctly`` () =
    let guid = Guid.NewGuid()
    let idResult = Id.create guid
    let idCreateResult = 
        match idResult with 
        | Ok result -> (true, Id.value result)
        | Error _ -> (false, Guid.Empty)
    idCreateResult |> should equal (true, guid)
