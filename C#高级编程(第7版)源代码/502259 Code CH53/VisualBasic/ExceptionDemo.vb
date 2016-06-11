Public Class ExceptionDemo
    Public Sub ThrowMethod(ByVal o As Object)
        If o = Nothing Then
            Throw New ArgumentException("error")
        End If

    End Sub

    Public Sub Handler()
        Try
            ThrowMethod(Nothing)

        Catch ex As ArgumentException
            Console.WriteLine(ex.Message)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            Console.WriteLine("finally")
        End Try
    End Sub


End Class
