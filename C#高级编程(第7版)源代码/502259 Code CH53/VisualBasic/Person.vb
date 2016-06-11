Public Interface IDisplay
    Sub Display()
End Interface


Public Class Person
    Implements IDisplay

    Public Sub Display() Implements IDisplay.Display

    End Sub

    Public Sub New()
        Me.New("unkwnown", "unknown")
    End Sub

    Public Sub New(ByVal firstname As String, ByVal lastname As String)
        Me.myFirstname = firstname

    End Sub
    Public Property Firstname()
        Get
            Return myFirstname
        End Get
        Set(ByVal value)
            myFirstname = value
        End Set
    End Property

    Public ReadOnly Property Name()
        Get
            Return myFirstname & " " & myLastname
        End Get
    End Property

    Private myFirstname As String

    Public Property Lastname()
        Get
            Return myLastname
        End Get
        Set(ByVal value)
            myLastname = value
        End Set
    End Property

    Private myLastname As String




End Class
