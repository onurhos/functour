namespace Types

module rec HotelTypes = 

    open System
    open CommonTypes

    type HotelId = private HotelId of Guid
    module HotelId =
        let create guid = if guid = Guid.Empty then Error "Guid should not be empty" else Ok (HotelId guid)
        let value (HotelId id) = id

    type Hotel = { 
        Id: HotelId;
        Name: Name100;
        Concepts : HotelConcept list
    }

    type HotelConceptId = private HotelConceptId of Guid
    module HotelConceptId =
        let create guid = if guid = Guid.Empty then Error "Guid should not be empty" else Ok (HotelConceptId guid)
        let value (HotelConceptId id) = id

    type HotelConcept = { 
        Id: HotelConceptId;
        Name: Name50; 
    }