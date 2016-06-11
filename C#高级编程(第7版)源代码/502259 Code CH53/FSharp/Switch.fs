namespace Wrox.ProCSharp.Languages

type Suit =
| Heart = 0
| Diamond = 1
| Spade = 2
| Club = 3

type SuitTest = 
    static member GetColor(s : Suit) : string =
        match s with
        | Suit.Heart | Suit.Diamond -> "Red"
        | Suit.Spade | Suit.Club -> "Black" 
        | _ -> "Unknown color"
        
            



