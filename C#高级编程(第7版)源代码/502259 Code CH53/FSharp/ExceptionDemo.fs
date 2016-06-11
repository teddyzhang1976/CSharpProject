namespace Wrox.ProCSharp.Languages
open System
open System.IO

type ExceptionTest() as this =
    member this.Method(o : obj) =
        if o = null then
            raise(ArgumentException("error"))
    member this.Foo = 
        try
            try
                this.Method(null)
            with
                | :? ArgumentException as ex -> printfn "%s" ex.Message
                | :? IOException as ex -> printfn "%s" ex.Message
        finally
            printfn "finally"

//
//public void Method(Object o)
//{
//   if (o == null)
//      throw new ArgumentException("Error");
//}
//public void Foo()
//{
//   try
//   {
//      Method(null);
//   }
//   catch (ArgumentException ex)
//   { }
//   catch (Exception ex)
//   { }
//   finally
//   { }
//}
