namespace Tests

module CommonTypesTests = 

    open Xunit
    open FsUnit.Xunit
    open Types.CommonTypes
    open Types.Predicates

    [<Theory>]
    [<InlineData("a@a.com")>]
    [<InlineData("mega@alt.net")>]
    let ``creating an valid email address should be ok`` (emailString) =
        let result = EmailAddress.create "Email" emailString
        result |> isOk |> should equal true
        shouldOk result |> EmailAddress.value |> should equal emailString

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
        let result = EmailAddress.create "Email" emailString
        result |> isError |> should equal true

    [<Theory>]
    [<InlineData("a")>]
    [<InlineData("aa")>]
    [<InlineData("aa1")>]
    [<InlineData("aa11")>]
    [<InlineData("aa112")>]
    let ``creating a string that does not exceed 5 characters should be ok`` (str) =
        let result = String5.create "Field" str
        result |> isOk |> should equal true
        shouldOk result |> String5.value |> should equal str

    [<Theory>]
    [<InlineData("abcdef")>]
    let ``creating a string longer than 5 characters returns validation error`` (str) =
        let result = String5.create "Field" str
        result |> isError |> should equal true