namespace Types

module Payment =

    type Currency = 
        | Dollar
        | Ruble
        | Tl

    type MoneyCreateError = 
        | MoneyValueShouldNotBeNegative

    type Money = private Money of (decimal * Currency)
    module Money =
        let create ( value:decimal, currency:Currency ) = 
            if  value < 0m then
                Error MoneyValueShouldNotBeNegative
            else
                Ok (value, currency)

        let value (Money money) = 
            fst money

        let currency (Money money) = 
            snd money

    type CardNumber = CardNumber of string
    type CreditCardType = Visa | MasterCard

    type CreditCardInfo = {
        CardType : CreditCardType
        CardNumber : CardNumber
    }

    type PaymentMethod = 
        | Cash
        | CreditCard of CreditCardInfo

    type Payment = {
        Amount : Money
        Method : PaymentMethod
    }

    type ConvertPaymentCurrency =
        Payment -> Currency -> Payment

    type PaymentError = 
        | CardTypeNotRecognized
        | PaymentRejected
        | PaymentProviderOffline
