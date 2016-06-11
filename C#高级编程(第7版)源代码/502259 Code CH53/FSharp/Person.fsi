#light

namespace Wrox.ProCSharp.Languages
  [<InterfaceAttribute ()>]
  type IDisplay =
    interface
      abstract member Display : unit -> unit
    end
    
  type public Person =
    class
      interface IDisplay
      public new : unit -> Person
      public new : firstName:string * lastName:string -> Person
      override ToString : unit -> string
      member public FirstName : string
      member public LastName : string
      member public FirstName : string with set
      member public LastName : string with set
    end

