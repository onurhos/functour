namespace Types

module Result =

    let bind f result = 
        match result with
        | Ok success -> f success
        | Error error -> Error error

    let map f result =
        match result with 
        | Ok success -> Ok(f success)
        | Error error -> Error error

    let mapError f result =
        match result with
        | Ok success -> Ok success
        | Error error -> Error(f error)