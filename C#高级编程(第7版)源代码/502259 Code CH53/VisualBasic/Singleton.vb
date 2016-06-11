Imports System
Imports System.Collections.Generic
Imports Message = System.Messaging

Namespace Wrox.ProCSharp.Languages
End Namespace


Public Class SomeData

End Class

Public Class Singleton
    Private Shared d As SomeData

    Public Shared Function GetData() As SomeData
        If d Is Nothing Then
            d = New SomeData()
        End If
        Return d

    End Function

End Class
