namespace EventSourcing

module EventStore = 

    type EventProducer<'Event> = 'Event list -> 'Event list

    type EventStore<'Event> = {
        Get : unit -> 'Event list
        Append : 'Event list -> unit
        Evolve : EventProducer<'Event> -> unit
    }

    type Msg<'Event> =
        | Get of AsyncReplyChannel<'Event list>
        | Append of 'Event list
        | Evolve of EventProducer<'Event>

    let initialize () : EventStore<'Event> =
        let history = []

        let mailbox =
            MailboxProcessor.Start(fun inbox ->
                let rec loop history =
                    async {
                    let! msg = inbox.Receive()
                    match msg with
                        | Get reply -> 
                            reply.Reply history
                            return! loop history

                        | Append events  ->
                            return! loop (history @ events)

                        | Evolve producer  ->
                            return! loop (history @ producer history)
                    }
    
                loop history
            )

        let append events =
            events
            |> Append
            |> mailbox.Post 

        let evolve producer =
            producer 
            |> Evolve 
            |> mailbox.Post

        {
            Get = fun () ->  mailbox.PostAndReply Get
            Append = append 
            Evolve = evolve
        }