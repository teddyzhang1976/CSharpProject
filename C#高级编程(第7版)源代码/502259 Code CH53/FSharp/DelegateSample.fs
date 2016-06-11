namespace Wrox.ProCSharp.Languages

type DemoDelegate = delegate of int -> unit

type Demo() as this =
    static member Foo(x : int) = 
        printfn "Foo %d" x
    
    member this.Bar(x : int) =
        printfn "Bar %d" x



