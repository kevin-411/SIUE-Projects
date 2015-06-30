Public Class TicTacToe
    Dim turn As Boolean 'boolean to determine who's turn it is T=O and F=X
    Dim intArray(0 To 8) As Integer 'array of integers to represent all the boxes 0=empty 1=X 2=O
    Private Sub BoxLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxLabel1.Click, BoxLabel1.EnabledChanged
        If (intArray(0) = 0 And playAgainButton.Visible = False) Then 'tests to see if box has been used or a winner has been established
            If turn = True Then                                    'then tests to see who's turn it is and changes labels and updates array
                BoxLabel1.Text = "O"                                'repeats this for all 9 buttons and each call Win Subroutine
                TitleLabel1.Text = "X's, it's your turn"
                turn = False
                intArray(0) = 2
            ElseIf turn = False Then
                BoxLabel1.Text = "X"
                TitleLabel1.Text = "O's, it's your turn"
                turn = True
                intArray(0) = 1
            End If
        End If
        Call Win()
    End Sub
    Private Sub BoxLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxLabel2.Click
        If (intArray(1) = 0 And playAgainButton.Visible = False) Then
            If turn = True Then
                BoxLabel2.Text = "O"
                TitleLabel1.Text = "X's, it's your turn"
                turn = False
                intArray(1) = 2
            ElseIf turn = False Then
                BoxLabel2.Text = "X"
                TitleLabel1.Text = "O's, it's your turn"
                turn = True
                intArray(1) = 1
            End If
        End If
            Call Win()
    End Sub
    Private Sub BoxLabel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxLabel3.Click
        If (intArray(2) = 0 And playAgainButton.Visible = False) Then
            If turn = True Then
                BoxLabel3.Text = "O"
                TitleLabel1.Text = "X's, it's your turn"
                turn = False
                intArray(2) = 2
            ElseIf turn = False Then
                BoxLabel3.Text = "X"
                TitleLabel1.Text = "O's, it's your turn"
                turn = True
                intArray(2) = 1
            End If
        End If
        Call Win()
    End Sub
    Private Sub BoxLabel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxLabel4.Click
        If (intArray(3) = 0 And playAgainButton.Visible = False) Then
            If turn = True Then
                BoxLabel4.Text = "O"
                TitleLabel1.Text = "X's, it's your turn"
                turn = False
                intArray(3) = 2
            ElseIf turn = False Then
                BoxLabel4.Text = "X"
                TitleLabel1.Text = "O's, it's your turn"
                turn = True
                intArray(3) = 1
            End If
        End If
        Call Win()
    End Sub
    Private Sub BoxLabel5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxLabel5.Click
        If (intArray(4) = 0 And playAgainButton.Visible = False) Then
            If turn = True Then
                BoxLabel5.Text = "O"
                TitleLabel1.Text = "X's, it's your turn"
                turn = False
                intArray(4) = 2
            ElseIf turn = False Then
                BoxLabel5.Text = "X"
                TitleLabel1.Text = "O's, it's your turn"
                turn = True
                intArray(4) = 1
            End If
        End If
        Call Win()
    End Sub
    Private Sub BoxLabel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxLabel6.Click
        If (intArray(5) = 0 And playAgainButton.Visible = False) Then
            If turn = True Then
                BoxLabel6.Text = "O"
                TitleLabel1.Text = "X's, it's your turn"
                turn = False
                intArray(5) = 2
            ElseIf turn = False Then
                BoxLabel6.Text = "X"
                TitleLabel1.Text = "O's, it's your turn"
                turn = True
                intArray(5) = 1
            End If
        End If
        Call Win()
    End Sub
    Private Sub BoxLabel7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxLabel7.Click
        If (intArray(6) = 0 And playAgainButton.Visible = False) Then
            If turn = True Then
                BoxLabel7.Text = "O"
                TitleLabel1.Text = "X's, it's your turn"
                turn = False
                intArray(6) = 2
            ElseIf turn = False Then
                BoxLabel7.Text = "X"
                TitleLabel1.Text = "O's, it's your turn"
                turn = True
                intArray(6) = 1
            End If
        End If
        Call Win()
    End Sub
    Private Sub BoxLabel8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxLabel8.Click
        If (intArray(7) = 0 And playAgainButton.Visible = False) Then
            If turn = True Then
                BoxLabel8.Text = "O"
                TitleLabel1.Text = "X's, it's your turn"
                turn = False
                intArray(7) = 2
            ElseIf turn = False Then
                BoxLabel8.Text = "X"
                TitleLabel1.Text = "O's, it's your turn"
                turn = True
                intArray(7) = 1
            End If
        End If
        Call Win()
    End Sub
    Private Sub BoxLabel9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxLabel9.Click
        If (intArray(8) = 0 And playAgainButton.Visible = False) Then
            If turn = True Then
                BoxLabel9.Text = "O"
                TitleLabel1.Text = "X's, it's your turn"
                turn = False
                intArray(8) = 2
            ElseIf turn = False Then
                BoxLabel9.Text = "X"
                TitleLabel1.Text = "O's, it's your turn"
                turn = True
                intArray(8) = 1
            End If
        End If
        Call Win()
    End Sub
    Private Sub Win()
        If (intArray(4) = intArray(0) And intArray(4) = intArray(8)) Then
            If intArray(4) = 1 Then
                TitleLabel1.Text = "X's Win"
                BoxLabel1.ForeColor = Color.Red 'Checks for all the possibilities of a win for each letter,
                BoxLabel5.ForeColor = Color.Red 'then changes the colors of winning boxes and makes play again
                BoxLabel9.ForeColor = Color.Red 'button visible.
                playAgainButton.Visible = True
            ElseIf intArray(4) = 2 Then
                TitleLabel1.Text = "O's Win"
                BoxLabel1.ForeColor = Color.Red
                BoxLabel5.ForeColor = Color.Red
                BoxLabel9.ForeColor = Color.Red
                playAgainButton.Visible = True
            End If
        End If
        If (intArray(4) = intArray(2) And intArray(4) = intArray(6)) Then
            If intArray(4) = 1 Then
                TitleLabel1.Text = "X's Win"
                BoxLabel3.ForeColor = Color.Red
                BoxLabel5.ForeColor = Color.Red
                BoxLabel7.ForeColor = Color.Red
                playAgainButton.Visible = True
            ElseIf intArray(4) = 2 Then
                TitleLabel1.Text = "O's Win"
                BoxLabel3.ForeColor = Color.Red
                BoxLabel5.ForeColor = Color.Red
                BoxLabel7.ForeColor = Color.Red
                playAgainButton.Visible = True
            End If
        End If
        If (intArray(4) = intArray(1) And intArray(4) = intArray(7)) Then
            If intArray(4) = 1 Then
                TitleLabel1.Text = "X's Win"
                BoxLabel2.ForeColor = Color.Red
                BoxLabel5.ForeColor = Color.Red
                BoxLabel8.ForeColor = Color.Red
                playAgainButton.Visible = True
            ElseIf intArray(4) = 2 Then
                TitleLabel1.Text = "O's Win"
                BoxLabel2.ForeColor = Color.Red
                BoxLabel5.ForeColor = Color.Red
                BoxLabel8.ForeColor = Color.Red
                playAgainButton.Visible = True
            End If
        End If
        If (intArray(4) = intArray(3) And intArray(4) = intArray(5)) Then
            If intArray(4) = 1 Then
                TitleLabel1.Text = "X's Win"
                BoxLabel4.ForeColor = Color.Red
                BoxLabel5.ForeColor = Color.Red
                BoxLabel6.ForeColor = Color.Red
                playAgainButton.Visible = True
            ElseIf intArray(4) = 2 Then
                TitleLabel1.Text = "O's Win"
                BoxLabel4.ForeColor = Color.Red
                BoxLabel5.ForeColor = Color.Red
                BoxLabel6.ForeColor = Color.Red
                playAgainButton.Visible = True
            End If
        End If
        If (intArray(3) = intArray(0) And intArray(3) = intArray(6)) Then
            If intArray(3) = 1 Then
                TitleLabel1.Text = "X's Win"
                BoxLabel1.ForeColor = Color.Red
                BoxLabel4.ForeColor = Color.Red
                BoxLabel7.ForeColor = Color.Red
                playAgainButton.Visible = True
            ElseIf intArray(3) = 2 Then
                TitleLabel1.Text = "O's Win"
                BoxLabel1.ForeColor = Color.Red
                BoxLabel4.ForeColor = Color.Red
                BoxLabel7.ForeColor = Color.Red
                playAgainButton.Visible = True
            End If
        End If
        If (intArray(5) = intArray(2) And intArray(5) = intArray(8)) Then
            If intArray(5) = 1 Then
                TitleLabel1.Text = "X's Win"
                BoxLabel3.ForeColor = Color.Red
                BoxLabel6.ForeColor = Color.Red
                BoxLabel9.ForeColor = Color.Red
                playAgainButton.Visible = True
            ElseIf intArray(5) = 2 Then
                TitleLabel1.Text = "O's Win"
                BoxLabel3.ForeColor = Color.Red
                BoxLabel6.ForeColor = Color.Red
                BoxLabel9.ForeColor = Color.Red
                playAgainButton.Visible = True
            End If
        End If
        If (intArray(1) = intArray(0) And intArray(1) = intArray(2)) Then
            If intArray(1) = 1 Then
                TitleLabel1.Text = "X's Win"
                BoxLabel1.ForeColor = Color.Red
                BoxLabel2.ForeColor = Color.Red
                BoxLabel3.ForeColor = Color.Red
                playAgainButton.Visible = True
            ElseIf intArray(1) = 2 Then
                TitleLabel1.Text = "O's Win"
                BoxLabel1.ForeColor = Color.Red
                BoxLabel2.ForeColor = Color.Red
                BoxLabel3.ForeColor = Color.Red
                playAgainButton.Visible = True
            End If
        End If
        If (intArray(7) = intArray(6) And intArray(7) = intArray(8)) Then
            If intArray(7) = 1 Then
                TitleLabel1.Text = "X's Win"
                BoxLabel7.ForeColor = Color.Red
                BoxLabel8.ForeColor = Color.Red
                BoxLabel9.ForeColor = Color.Red
                playAgainButton.Visible = True
            ElseIf intArray(7) = 2 Then
                TitleLabel1.Text = "O's Win"
                BoxLabel7.ForeColor = Color.Red
                BoxLabel8.ForeColor = Color.Red
                BoxLabel9.ForeColor = Color.Red
                playAgainButton.Visible = True
            End If
        End If
        If Not BoxLabel1.Text = "" And
           Not BoxLabel2.Text = "" And
           Not BoxLabel3.Text = "" And
           Not BoxLabel4.Text = "" And
           Not BoxLabel5.Text = "" And
           Not BoxLabel6.Text = "" And
           Not BoxLabel7.Text = "" And
           Not BoxLabel8.Text = "" And
           Not BoxLabel9.Text = "" And
           playAgainButton.Visible = False Then 'Checks for Cat game
            TitleLabel1.Text = "Cat Game!"
            playAgainButton.Visible = True
        End If
    End Sub
    Private Sub playAgainButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles playAgainButton.Click
        BoxLabel1.Text = ""
        BoxLabel2.Text = ""
        BoxLabel3.Text = ""
        BoxLabel4.Text = ""
        BoxLabel5.Text = ""
        BoxLabel6.Text = ""
        BoxLabel7.Text = ""
        BoxLabel8.Text = ""
        BoxLabel9.Text = ""
        BoxLabel1.ForeColor = Color.Black
        BoxLabel2.ForeColor = Color.Black
        BoxLabel3.ForeColor = Color.Black
        BoxLabel4.ForeColor = Color.Black
        BoxLabel5.ForeColor = Color.Black
        BoxLabel6.ForeColor = Color.Black
        BoxLabel7.ForeColor = Color.Black
        BoxLabel8.ForeColor = Color.Black
        BoxLabel9.ForeColor = Color.Black
        turn = False
        TitleLabel1.Text = "X's, it's your turn"
        playAgainButton.Visible = False
        For index As Integer = 0 To 8
            intArray(index) = 0
        Next
    End Sub

End Class
