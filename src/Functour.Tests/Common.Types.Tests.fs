module CommonTypesTests

open Xunit
open FsUnit.Xunit
open Types.CommonTypes

[<Fact>]
let ``Creating A Money With Negative Value Should Fail`` () =
    let moneyResult = Money.create (-12.5m, Dollar)
    let matched = 
        match moneyResult with
        | Ok _ -> true
        | _ -> false
    matched |> should equal false

[<Fact>]
let ``Getting A Money Value Should Be Ok`` () =
    let expectedMoneyValue = 654.45m
    let expectedMoneyCurrency = Dollar
    let moneyResult = Money.create (expectedMoneyValue, expectedMoneyCurrency)
    let moneyValue = 
        match moneyResult with
        | Ok money -> money
        | _ -> (0m, expectedMoneyCurrency)
    fst moneyValue |> should equal expectedMoneyValue
    snd moneyValue |> should equal expectedMoneyCurrency
