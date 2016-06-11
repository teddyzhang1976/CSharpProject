Imports System.Linq

Public Class LinqSample
    Public Sub Sample(ByVal persons As Person())
        Dim query = From p In persons _
                    Where p.Lastname = "Test" _
                    Order By p.Firstname Descending _
                    Select p

    End Sub


End Class
