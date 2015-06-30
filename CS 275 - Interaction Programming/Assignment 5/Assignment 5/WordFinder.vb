Imports System.IO

Public Class WordFinder
    Dim fileName As String
    Dim currentAngle As String
    Dim findListCount As Integer
    Dim puzzleInUse As Boolean
    Dim win As Boolean
    Dim rows As Integer = 0
    Dim cols As Integer = 0
    Dim Puzzle(1, 1) As Label
    Private Sub OpenWordHuntFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenWordHuntFile.Click
        Dim result As DialogResult ' stores result of Open dialog
        result = fileChooser.ShowDialog
        fileName = fileChooser.FileName

        ' if user did not click Cancel, Load File
        If result <> Windows.Forms.DialogResult.Cancel Then
            ResetGame()
            LoadFile()
        End If
    End Sub
    Private Sub LoadFile()
        Dim fileReader As StreamReader = Nothing


        Try' open file for reading
            fileReader = New StreamReader(fileName)
            rows = fileReader.ReadLine()
            cols = fileReader.ReadLine()
            ReDim Puzzle(rows - 1, cols - 1)
            For i = 0 To rows - 1 Step 1
                For j = 0 To cols - 1 Step 1
                    Puzzle(i, j) = New Label()
                    Puzzle(i, j).Show()
                    Puzzle(i, j).Text = Convert.ToChar(fileReader.Read())
                    If (j = cols - 1) Then
                        fileReader.ReadLine()
                    End If
                    Puzzle(i, j).AutoSize = False
                    Puzzle(i, j).Height = 24
                    Puzzle(i, j).Width = 22
                    Puzzle(i, j).Top = ((24 * i) + 24)
                    Puzzle(i, j).Left = ((22 * j) + 12)
                    Puzzle(i, j).Font = New Font("Modern No. 20", 14, FontStyle.Regular)
                    Puzzle(i, j).TextAlign() = ContentAlignment.MiddleCenter
                    Me.Controls.Add(Puzzle(i, j))
                    AddHandler Puzzle(i, j).Click, AddressOf Puzzle_Click
                Next
            Next

            Do While Not fileReader.EndOfStream ' while not end of file
                FindListBox.Items.Add(fileReader.ReadLine())
                findListCount = findListCount + 1
            Loop
            FindListBox.CheckOnClick = False
            Me.Height = 24 * cols + 140
            Me.Width = 22 * rows + 70 + FindListBox.Width

        Catch ex As IOException
            MessageBox.Show("Cannot Read File", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally ' ensure that file gets closed
            If fileReader IsNot Nothing Then
                Try
                    fileReader.Close() ' close StreamReader
                Catch ex As IOException
                    MessageBox.Show("Error closing file", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Try
    End Sub

    Private Sub Puzzle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim tempAngle As String = "BADPLACEMENT"
        Dim countOfUsedIndeces As Integer = 0
        For i = 0 To rows - 1 Step 1
            For j = 0 To cols - 1 Step 1

                If sender.Equals(Puzzle(i, j)) AndAlso Not Puzzle(i, j).BackColor = Color.Green Then

                    For k = i - 1 To i + 1 Step 1
                        For l = j - 1 To j + 1 Step 1

                            If Not puzzleInUse Then
                                Puzzle(i, j).BackColor = Color.Green
                                puzzleInUse = True
                                k = i + 1
                                l = j + 1
                            ElseIf k >= 0 AndAlso l >= 0 AndAlso _
                                k <= rows - 1 AndAlso l <= cols - 1 AndAlso _
                                Puzzle(k, l).BackColor = Color.Green Then
                                tempAngle = Nothing

                                If i = k AndAlso Not l = j Then
                                    tempAngle = "HORIZONTAL"
                                    countOfUsedIndeces += 1
                                ElseIf j = l AndAlso Not k = i Then
                                    tempAngle = "VERTICAL"
                                    countOfUsedIndeces += 1
                                ElseIf i - j = k - l AndAlso Not i = k Then
                                    tempAngle = "ULDIAGONAL"
                                    countOfUsedIndeces += 1
                                ElseIf i + j = k + l AndAlso Not i = k Then
                                    tempAngle = "LLDIAGONAL"
                                    countOfUsedIndeces += 1
                                Else
                                    tempAngle = "BADPLACEMENT"
                                    k = i + 1
                                    l = j + 1

                                End If

                                If tempAngle = currentAngle Then
                                    Puzzle(i, j).BackColor = Color.Green
                                    CheckForWin()
                                    If Not (k = i + 1 AndAlso l = j + 1) Then
                                        puzzleInUse = True
                                    End If
                                ElseIf currentAngle = Nothing Then
                                    currentAngle = tempAngle
                                    Puzzle(i, j).BackColor = Color.Green
                                    CheckForWin()
                                    If Not (k = i + 1 AndAlso l = j + 1) Then
                                        puzzleInUse = True
                                    End If
                                End If
                            ElseIf tempAngle = "BADPLACEMENT" AndAlso (k = i + 1 AndAlso l = j + 1) Then
                                currentAngle = Nothing
                                ResetPuzzle()
                                Puzzle(i, j).BackColor = Color.Green
                                puzzleInUse = True
                            End If
                            If countOfUsedIndeces >= 2 Then
                                currentAngle = Nothing
                                ResetPuzzle()
                                Puzzle(i, j).BackColor = Color.Green
                                puzzleInUse = True
                            End If

                        Next 'end l for
                    Next 'end k for
                    i = rows - 1
                    j = cols - 1
                End If
            Next 'end j for
        Next ' end i for


    End Sub
    Private Sub CheckForWin()
        Dim check As String = Nothing
        For i = 0 To rows - 1 Step 1
            For j = 0 To cols - 1 Step 1
                If (Puzzle(i, j).BackColor = Color.Green) Then
                    check += Puzzle(i, j).Text()
                End If
            Next 'end j for
        Next ' end i for
        Dim recheck As String = StrReverse(check)
        For index = 0 To findListCount - 1 Step 1
            If (check = FindListBox.Items(index) OrElse recheck = FindListBox.Items(index)) AndAlso Not FindListBox.GetItemChecked(index) Then
                FindListBox.SetItemCheckState(index, CheckState.Checked)
                For i = 0 To rows - 1 Step 1
                    For j = 0 To cols - 1 Step 1
                        If (Puzzle(i, j).BackColor = Color.Green) Then
                            Puzzle(i, j).BackColor = Color.Empty
                            Puzzle(i, j).ForeColor = Color.Blue
                        End If
                    Next 'end j for
                Next ' end i for
                currentAngle = Nothing
                puzzleInUse = False
            End If
        Next
        If FindListBox.CheckedItems.Count = findListCount Then
            win = True
            winNotification.Show()
        End If

    End Sub
    Private Sub ResetPuzzle()
        For i = 0 To rows - 1 Step 1
            For j = 0 To cols - 1 Step 1
                Puzzle(i, j).BackColor = Color.Empty
            Next
        Next
        puzzleInUse = False
    End Sub
    Private Sub ResetGame()
        For i = 0 To rows - 1 Step 1
            For j = 0 To cols - 1 Step 1
                Me.Controls.Remove(Puzzle(i, j))
            Next
        Next
        System.Array.Clear(Puzzle, Puzzle.GetLowerBound(0), Puzzle.GetUpperBound(0))
        FindListBox.Items.Clear()
        puzzleInUse = False
        currentAngle = Nothing
        findListCount = 0

    End Sub

End Class
