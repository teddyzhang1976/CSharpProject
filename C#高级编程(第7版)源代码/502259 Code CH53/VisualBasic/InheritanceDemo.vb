Public MustInherit Class Base

    Public Overridable Sub Foo()

    End Sub

    Public MustOverride Sub Bar()

End Class

Public Class Derived
    Inherits Base

    Public Overrides Sub Foo()
        MyBase.Foo()
    End Sub

    Public Overrides Sub Bar()

    End Sub
End Class
