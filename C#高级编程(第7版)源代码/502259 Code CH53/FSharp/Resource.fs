namespace Wrox.ProCSharp.Languages
open System

type Resource() as this =
    interface IDisposable with
        member this.Dispose() = printfn "release resource"
    member this.Foo() = printfn "foo"

    

