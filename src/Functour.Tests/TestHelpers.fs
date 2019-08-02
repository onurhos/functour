module TestHelpers

let isErrorMatched (result:Result<_, 'ErrorType>) (expectedError:'ErrorType) =
    let errorFound =
        match result with 
        | Error error -> if error = expectedError then true else false
        | _ -> false
    errorFound
