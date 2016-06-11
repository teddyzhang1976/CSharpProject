// Learn more about F# at http://fsharp.net
module Wrox.ProCSharp.Languages.FSharpSample
open Wrox.ProCSharp.Languages
open System
open Wrox.ProCSharp.Languages.StringExtension

let st1 = Suit.Club
let c = SuitTest.GetColor(st1)
printfn "%s" c

let arr1 = [| 1; 2; 3 |]
let arr2 = [| for i in 1 .. 10 -> i |]
let arr3 : int array = Array.zeroCreate 20

printfn "%d" arr1.[0]



let x = 1

let pp = new PassingParameters()
pp.Foo(x)


let l4 : int64 = 33L
let i4 : int = int l4


// delegate demo

let d = Demo()
let d1 : DemoDelegate = new DemoDelegate(Demo.Foo)


let invokeDelegate (dlg : DemoDelegate) ( x : int) = 
    dlg.Invoke(x)
    
(invokeDelegate d1 33)

let d2 : DemoDelegate = new DemoDelegate(d.Bar)

// let dd1 : Delegate = upcast d1
let d11 = d1 :> Delegate
// let dd2 : Delegate = upcast d2
let d22 = d2 :> Delegate
//let arr = Array.create 2 dd1
//arr.[1] <- dd2
// let d3 : Delegate = Delegate.Combine(arr)
let d3 : Delegate = Delegate.Combine(d11, d22)

// let dd3 : DemoDelegate = downcast d3
let dd3 = d3 :?> DemoDelegate
(invokeDelegate dd3 44)



let rs =
    use r = new Resource()
    r.Foo()
    // r.Dispose called implicitly

let bar (r : Resource) =
    r.Foo()
    
using (new Resource()) bar
    
    
 








let p = Person()
p.FirstName <- "Tom"
p.LastName <- "Turbo"







//           int x = 1;
//           PassingParamters pp = new PassingParamters();
//           pp.ChangeVal(ref x);
