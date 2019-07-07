namespace Types

module CustomerTypes =  

    open CommonTypes

    type CustomerId = CustomerId of Id

    type Customer = { 
        Id: CustomerId; 
        FirstName: Name50; 
        LastName: Name50;
    }