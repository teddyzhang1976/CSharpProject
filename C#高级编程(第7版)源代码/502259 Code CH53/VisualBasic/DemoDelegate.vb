Public Delegate Sub DemoDelegate(ByVal x As Integer)

Public Class Demo
    Public Shared Sub Foo(ByVal x As Integer)
        Console.WriteLine("Foo: {0}", x)
    End Sub
    Public Sub Bar(ByVal x As Integer)
        Console.WriteLine("Bar: {0}", x)
    End Sub
End Class




