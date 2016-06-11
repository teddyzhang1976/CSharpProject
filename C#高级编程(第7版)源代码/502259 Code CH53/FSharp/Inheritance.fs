namespace Wrox.ProCSharp.Languages

[<AbstractClass>]
type Base() as this =
    abstract Foo : unit -> unit
    default this.Foo() = printfn "Base.Foo"
    abstract Bar : unit -> unit
    
type Derived() as this =
    inherit Base()
    override this.Foo() = 
        base.Foo()
        printfn "Derived.Foo"
    override this.Bar() = printfn "Derived.Bar"
    
    

