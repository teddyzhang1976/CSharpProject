Public Class EventDemo
    Public Event DemoEvent As DemoDelegate

    Public Sub FireEvent()
        RaiseEvent DemoEvent(44)
    End Sub

End Class

Public Class Subscriber
    Public WithEvents evd As EventDemo


    Public Sub Handler(ByVal x As Integer)
        Console.WriteLine("Handler {0}", x)
    End Sub

    'Public Sub Handler2(ByVal x As Integer) Handles EventDemo.DemoEvent

    'End Sub

    Public Sub handler2(ByVal x As Integer) Handles evd.DemoEvent
        Console.WriteLine("Handler2 {0}", x)

    End Sub

    Public Sub Doit()
        evd = New EventDemo()
        evd.FireEvent()
    End Sub


End Class


