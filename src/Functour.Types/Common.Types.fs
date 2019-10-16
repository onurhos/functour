namespace Types

module ConstrainedType =

    open System
    open System.Text.RegularExpressions

    /// Create a constrained string using the constructor provided
    /// Return Error if input is null, empty, or length > maxLen
    let createString fieldName ctor maxLen str = 
        if String.IsNullOrWhiteSpace(str) then
            let msg = sprintf "%s must not be null or empty" fieldName 
            Error msg
        elif str.Length > maxLen then
            let msg = sprintf "%s must not be more than %i chars" fieldName maxLen 
            Error msg 
        else
            Ok (ctor str)

    /// Create a optional constrained string using the constructor provided
    /// Return None if input is null, empty. 
    /// Return error if length > maxLen
    /// Return Some if the input is valid
    let createStringOption fieldName ctor maxLen str = 
        if String.IsNullOrWhiteSpace(str) then
            Ok None
        elif str.Length > maxLen then
            let msg = sprintf "%s must not be more than %i chars" fieldName maxLen 
            Error msg 
        else
            Ok (ctor str |> Some)

    /// Create a constrained integer using the constructor provided
    /// Return Error if input is less than minVal or more than maxVal
    let createInt fieldName ctor minVal maxVal i = 
        if i < minVal then
            let msg = sprintf "%s: Must not be less than %i" fieldName minVal
            Error msg
        elif i > maxVal then
            let msg = sprintf "%s: Must not be greater than %i" fieldName maxVal
            Error msg
        else
            Ok (ctor i)

    /// Create a constrained decimal using the constructor provided
    /// Return Error if input is less than minVal or more than maxVal
    let createDecimal fieldName ctor minVal maxVal i = 
        if i < minVal then
            let msg = sprintf "%s: Must not be less than %M" fieldName minVal
            Error msg
        elif i > maxVal then
            let msg = sprintf "%s: Must not be greater than %M" fieldName maxVal
            Error msg
        else
            Ok (ctor i)

    /// Create a constrained decimal using the constructor provided
    /// Return Error if input is less than minVal or more than maxVal
    let createGuid fieldName ctor (i:Guid) = 
        if i = Guid.Empty then
            let msg = sprintf "%s: Must be a valid guid" fieldName
            Error msg
        else
            Ok (ctor i)

    /// Create a constrained string using the constructor provided
    /// Return Error if input is null. empty, or does not match the regex pattern
    let createLike fieldName ctor pattern str = 
        if String.IsNullOrWhiteSpace(str) then
            let msg = sprintf "%s: Must not be null or empty" fieldName 
            Error msg
        elif Regex.IsMatch(str,pattern) then
            Ok (ctor str)
        else
            let msg = sprintf "%s: '%s' must match the pattern '%s'" fieldName str pattern
            Error msg 

module Predicates = 
    
    /// Predicate that returns true on success
    let isOk = 
        function 
        | Ok _ -> true
        | Error _ -> false

    /// Predicate that returns true on failure
    let isError xR = 
        xR |> isOk |> not

    /// On success, return the value. On error, return a default value
    let ifError defaultVal = 
        function 
        | Ok x -> x
        | Error _ -> defaultVal

    /// On success, return the value. On error, throws exception
    let shouldOk = 
        function 
        | Ok x -> x
        | Error _ -> failwith "error"


module CommonTypes =

    open System
    open System.Text.RegularExpressions

    type Undefined = exn
    type AsyncValidationResponse<'a, 'b> = Async<Result<'a, 'b list>>

    type String5 = private String5 of string
    module String5 =

        let value (String5 str) = str

        let create fieldName str = 
            ConstrainedType.createString fieldName String5 5 str

        let createOption fieldName str = 
            ConstrainedType.createStringOption fieldName String5 5 str


    type String50 = private String50 of string
    module String50 =

        let value (String50 str) = str

        let create fieldName str = 
            ConstrainedType.createString fieldName String50 50 str

        let createOption fieldName str = 
            ConstrainedType.createStringOption fieldName String50 50 str

    type String100 = private String100 of string
    module String100 =

        let value (String100 str) = str

        let create fieldName str = 
            ConstrainedType.createString fieldName String100 100 str

        let createOption fieldName str = 
            ConstrainedType.createStringOption fieldName String100 100 str


    type EmailAddress = private EmailAddress of string
    module EmailAddress =

        let value (EmailAddress str) = str

        let create fieldName str = 
            let pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            ConstrainedType.createLike fieldName EmailAddress pattern str