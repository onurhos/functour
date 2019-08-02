module CommonTypesTests

open Xunit
open FsUnit.Xunit
open Types.CommonTypes
open TestHelpers

[<Theory>]
[<InlineData("")>]
[<InlineData(" ")>]
[<InlineData("a")>]
[<InlineData("@")>]
[<InlineData("@a")>]
[<InlineData(" @a")>]
[<InlineData("@a ")>]
[<InlineData("a@.")>]
[<InlineData("a@a.")>]
let ``creating an invalid email address should return validation error`` (emailString) =
    let emailCreateResult = Email.create emailString  
    let errorMatched = isErrorMatched emailCreateResult InvalidEmailFormat
    errorMatched |> should equal true