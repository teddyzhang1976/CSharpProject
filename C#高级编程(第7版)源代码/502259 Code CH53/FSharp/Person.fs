namespace Wrox.ProCSharp.Languages

open System

[<Interface>]
type IDisplay =
    abstract member Display : unit -> unit

type Person(firstName0 : string, lastName0 : string) as this = 
    let mutable firstName, lastName = firstName0, lastName0
    
    new () = Person("unknown", "unknown")
    
    member this.FirstName
        with get() = firstName
        and set(value) = firstName <- value
        
    member this.LastName
        with get() = lastName
        and set(value) = lastName <- value
       
    interface IDisplay with
        member this.Display () = Console.WriteLine("{0} {1}", this.FirstName, this.LastName)
        
    override this.ToString () = this.FirstName + " " + this.LastName

