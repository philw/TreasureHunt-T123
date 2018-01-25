Module Module1

    Const BOARD_ROWS As Integer = 7
    Const BOARD_COLUMNS As Integer = 10

    Structure TLocation
        Dim Row As Integer
        Dim Column As Integer
    End Structure

    Sub Main()

        Dim Board(BOARD_ROWS - 1, BOARD_COLUMNS - 1) As Char
        Dim TreasureLocation As TLocation
        Dim GuessLocation As TLocation
        Dim Found As Boolean = False


        TreasureLocation = SetupGame(Board)

        Do While Not Found
            DisplayBoard(Board)
            GuessLocation = GetLocation()
            If GuessLocation.Column = TreasureLocation.Column And GuessLocation.Row = TreasureLocation.Row Then
                Board(GuessLocation.Row, GuessLocation.Column) = "X"
                Found = True
            Else
                Board(GuessLocation.Row, GuessLocation.Column) = "o"
            End If
        Loop

        DisplayBoard(Board)
        Console.WriteLine("You have found the treasure!")

        Console.ReadLine()


    End Sub

    Function SetupGame(ByRef Board(,) As Char) As TLocation

        Dim Location As TLocation
        Dim Rnd As New Random

        For Row = 0 To BOARD_ROWS - 1
            For Column = 0 To BOARD_COLUMNS - 1
                Board(Row, Column) = "."
            Next
        Next

        Location.Row = Rnd.Next(0, BOARD_ROWS)
        Location.Column = Rnd.Next(0, BOARD_COLUMNS)
        Board(Location.Row, Location.Column) = "G"

        Console.WriteLine(Location.Row & ", " & Location.Column)
        Console.ReadLine()

        Return Location

    End Function

    Sub DisplayBoard(ByRef Board(,) As Char)

        Console.Clear()
        Console.WriteLine("Treasure Hunt")
        Console.WriteLine()

        For Row = 0 To BOARD_ROWS - 1
            For Column = 0 To BOARD_COLUMNS - 1
                Select Case Board(Row, Column)
                    Case "G"
                        Console.Write(".")
                    Case Else
                        Console.Write(Board(Row, Column))
                End Select
            Next
            Console.WriteLine()
        Next
        Console.WriteLine()

    End Sub

    Function GetLocation() As TLocation

        Dim Location As TLocation

        'Console.Write("Enter row: ")
        'Location.Row = Console.ReadLine
        Location.Row = InputInteger("Enter row: ", 0, BOARD_ROWS - 1)

        'Console.Write("Enter column: ")
        'Location.Column = Console.ReadLine
        Location.Column = InputInteger("Enter column: ", 0, BOARD_COLUMNS - 1)

        Return Location

    End Function

    Function InputInteger(Prompt As String, MinimumValue As Integer, MaximumValue As Integer) As Integer
        Dim InputValue As Integer
        Dim Valid As Boolean = False

        Do While Not Valid
            Try
                Console.Write(Prompt)
                InputValue = Convert.ToInt32(Console.ReadLine())
                ' there has been no exception so we have an integer
                ' so is it in the right range
                If InputValue >= MinimumValue And InputValue <= MaximumValue Then
                    Valid = True
                End If
            Catch ex As Exception

            End Try
            If Not Valid Then
                Console.WriteLine("That is not a valid input")
            End If
        Loop

        Return InputValue
    End Function

End Module
