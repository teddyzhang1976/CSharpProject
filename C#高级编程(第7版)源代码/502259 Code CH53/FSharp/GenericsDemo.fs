namespace Wrox.ProCSharp.Languages
open System
open System.Collections.Generic

type GenericDemo() =
    static let intList =
        new List<int>()
    static member UseGenerics() =
        intList.Add(1)
        intList.Add(2)
        intList.Add(3)

type MyGeneric<'a> when 'a :> IComparable<'a>() as this =
    let list = new List<'a>()
    member this.Add(item : 'a) = list.Add(item)
    member this.Sort() = list.Sort()
    
 