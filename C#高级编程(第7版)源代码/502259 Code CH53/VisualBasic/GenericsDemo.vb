Public Class GenericsDemo
    Public Shared Sub UseGenerics()
        Dim intList As List(Of Integer) = New List(Of Integer)(3)
        intList.Add(1)
        intList.Add(2)
        intList.Add(3)

    End Sub
End Class



Public Class MyGeneric(Of T As IComparable(Of T))

    Private myList = New List(Of T)

    Public Sub Add(ByVal item As T)
        myList.Add(item)
    End Sub

    Public Sub Sort()
        myList.Sort()
    End Sub




End Class

 


