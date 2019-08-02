namespace Types

module rec HotelTypes = 

    open System
    open CommonTypes

    //  Hotels

    type HotelCreateError = 
        | HotelIdShouldNotBeEmpty

    type HotelId = private HotelId of Guid
    module HotelId =
        let create guid = if guid = Guid.Empty then Error HotelIdShouldNotBeEmpty else Ok (HotelId guid)
        let value (HotelId id) = id

    type Hotel = { 
        Id: HotelId
        Name: Name100
        Concepts : HotelConcept list
        Rooms : HotelRoom list
    }

    //  Hotel Rooms

    type HotelRoomCreateError = 
        | HotelRoomIdShouldNotBeEmpty

    type HotelRoomId = private HotelRoomId of Guid
    module HotelRoomId =
        let create guid = if guid = Guid.Empty then Error HotelRoomIdShouldNotBeEmpty else Ok (HotelRoomId guid)
        let value (HotelRoomId id) = id

    type HotelRoom = { 
        Id: HotelRoomId
        Name: Name100
    }

    //  Concepts

    type HotelConceptCreateError = 
        | HotelConceptIdShouldNotBeEmpty

    type HotelConceptId = private HotelConceptId of Guid
    module HotelConceptId =
        let create guid = if guid = Guid.Empty then Error HotelConceptIdShouldNotBeEmpty else Ok (HotelConceptId guid)
        let value (HotelConceptId id) = id

    type HotelConcept = { 
        Id: HotelConceptId
        Name: Name100
    }
