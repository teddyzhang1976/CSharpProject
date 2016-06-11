namespace Wrox.ProCSharp.Languages
open System

type PassingParameters() as this =
   member this.Foo(i : int) = printfn "%d" i
   member this.Bar(i : int) : int = i * 2


