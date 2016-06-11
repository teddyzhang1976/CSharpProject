Public Enum Suit
    Heart
    Diamond
    Club
    Spade
End Enum



Module Module1

    Function GetColor(ByVal s As Suit) As String
        Dim color As String = Nothing
        Select Case s

            Case Suit.Heart And Suit.Diamond
                color = "Red"

            Case Suit.Spade And Suit.Club
                color = "Black"

            Case Else
                color = "unknown"


        End Select
        Return color
    End Function


    Sub Main()

        Dim i8 As Integer = 1
        Dim p As New PassingParameters
        p.ChangeVal(i8)
        Console.WriteLine(i8)


        Dim l4 As Long = Long.MaxValue
        Dim i4 As Integer
        i4 = l4


        Dim evd As New EventDemo()
        Dim subscr As New Subscriber()
        evd.FireEvent()

        AddHandler evd.DemoEvent, AddressOf subscr.Handler

        evd.FireEvent()


        Dim subscr2 As New Subscriber
        subscr2.Doit()




        Dim d As New Demo()
        Dim d1 As New DemoDelegate(AddressOf Demo.Foo)
        Dim d2 As New DemoDelegate(AddressOf d.Bar)
        Dim d3 As DemoDelegate = [Delegate].Combine(d1, d2)
        d3.Invoke(33)





        Dim s1 As Suit = Suit.Heart
        Dim col = GetColor(s1)
        Console.WriteLine(col)

        Dim count As Integer
        For count = 1 To 100 Step 1
            Console.WriteLine(count)
        Next

        Dim num As Integer = 0
        Do While (num < 3)
            Console.WriteLine(num)
            num += 1
        Loop


        Dim arr() As Integer = New Integer() {1, 2, 3}

        Dim num2 As Integer
        For Each num2 In arr
            Console.WriteLine(num2)
        Next






        Dim s2 As UShort
        Console.WriteLine(s2)
        Dim b As Boolean
        Dim c As Char

        Dim myc As Color
        myc = Color.Green

        Dim data As SomeData = Singleton.GetData()


        Dim i As Integer = 3

        If i = 3 Then
            '
        Else
            '
        End If

        Dim s3 As String = IIf(i < 3, "one", "two")
        Console.WriteLine(s3)

        Dim arr1 As Integer() = New Integer(0 To 2) {1, 2, 3}

        Dim arr2(0 To 2) As Integer







    End Sub

End Module
