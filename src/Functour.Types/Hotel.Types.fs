namespace Types

module rec HotelTypes = 

    open CommonTypes

    type HotelId = HotelId of Id
    type HotelConceptId = HotelConceptId of Id

    type Hotel = { 
        Id: HotelId;
        Name: Name100;
        Concepts : HotelConcept list
    }

    type HotelConcept = { 
        Id: HotelConceptId;
        Name: Name50; 
    }