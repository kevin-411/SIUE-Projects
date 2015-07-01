'File: Results.vb
'Date: 01/29/2013
'Name: Brian Olsen, Dustin Thomas, Denver Coladilla
'Course:  CS 321-001 - Human Computer Interaction
'Desc:This program displays the periodic table in a traditional layout. It allows students to click on a given element 
'to look closer at the properties of the element. The program also has a "quiz mode" that can ask the user certain
'information about elements and get graded.
'Instructions: Place both the Chemistry.mdb file and the Images folder and place them in the directory...
' "Project 321.1/bin/Debug/"
Imports System.Windows.Forms

Public Class Results

    Private ResultsArray As Integer()
    Dim answerLabels(8, 4) As Label
    Dim topicList() As String
    Dim labelHeight = 25
    Dim numericLabelWidth = 100
    Dim topicLabelWidth = 200
    Dim leftSpacing = 25
    Dim topSpacing = 110
    Dim rowSpacing = 40
    Dim formPadding = 200

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Results_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ResultsArray(21) = 0 AndAlso ResultsArray(22) = 0 Then
            MsgBox("No quiz questions were answered!", , "No Results To Display")
            Me.Close()
        End If
        topicList = {"Element Name", "Chemical Symbol", "Discoverer", "Discoverer Year", "Group Name", "Melting Point", "Boiling Point"}
        Dim answers As Integer = 0

        For x As Integer = 0 To 6
            answerLabels(x, 0) = New Label()
            If ResultsArray(x) <> 0 Then
                answerLabels(x, 0).Visible = True
                answerLabels(x, 0).Height = labelHeight
                answerLabels(x, 0).Width = topicLabelWidth
                answerLabels(x, 0).Top = topSpacing + answers * rowSpacing
                answerLabels(x, 0).Left = leftSpacing
                answerLabels(x, 0).Font = New Font("Modern No. 20", 14, FontStyle.Regular)
                Me.Controls.Add(answerLabels(x, 0))
                For y As Integer = 1 To 3
                    answerLabels(x, y) = New Label()
                    answerLabels(x, y).Font = New Font("Modern No. 20", 14, FontStyle.Regular)
                    answerLabels(x, y).Height = labelHeight
                    answerLabels(x, y).Width = numericLabelWidth
                    answerLabels(x, y).Top = topSpacing + answers * rowSpacing
                    answerLabels(x, y).Left = 75 + 150 * y
                    Me.Controls.Add(answerLabels(x, y))
                Next
                answerLabels(x, 1).Text = ResultsArray(7 + x)
                answerLabels(x, 2).Text = ResultsArray(14 + x)
                Dim Percent As Double = ((Convert.ToDouble(ResultsArray(x + 7)) / Convert.ToDouble((ResultsArray(x + 7)) + Convert.ToDouble((ResultsArray(x + 14)))))) * 100
                answerLabels(x, 3).Text = Format(Percent, "0.00") + "%"
                answers += 1
            End If
        Next


        'Totals Section
        answerLabels(7, 0) = New Label()
        answerLabels(7, 0).Visible = True
        answerLabels(7, 0).Height = labelHeight
        answerLabels(7, 0).Width = topicLabelWidth
        answerLabels(7, 0).Top = topSpacing + answers * rowSpacing
        answerLabels(7, 0).Left = leftSpacing
        answerLabels(7, 0).Font = New Font("Modern No. 20", 14, FontStyle.Regular)
        answerLabels(7, 0).Text = "Totals"
        Me.Controls.Add(answerLabels(7, 0))
        For y As Integer = 1 To 3
            answerLabels(7, y) = New Label()
            answerLabels(7, y).Font = New Font("Modern No. 20", 14, FontStyle.Regular)
            answerLabels(7, y).Height = labelHeight
            answerLabels(7, y).Width = numericLabelWidth
            answerLabels(7, y).Top = topSpacing + answers * rowSpacing
            answerLabels(7, y).Left = 75 + 150 * y
            Me.Controls.Add(answerLabels(7, y))
        Next
        answerLabels(7, 1).Text = ResultsArray(21)
        answerLabels(7, 2).Text = ResultsArray(22)
        Dim TotalPercent As Double = ((Convert.ToDouble(ResultsArray(21)) / Convert.ToDouble((ResultsArray(22)) + Convert.ToDouble((ResultsArray(7 + 14)))))) * 100
        answerLabels(7, 3).Text = Format(TotalPercent, "0.00") + "%"

        For y As Integer = 0 To 3
            answerLabels(7, y).Top += 20
        Next
        For x As Integer = 0 To 6
            If ResultsArray(x) <> 0 Then
                answerLabels(x, 0).Text = topicList(x)
            End If
        Next
        LineShape2.StartPoint = New Point(leftSpacing, topSpacing + answers * rowSpacing)
        LineShape2.EndPoint = New Point(575, topSpacing + answers * rowSpacing)
        Me.Height = (answers * rowSpacing) + formPadding
    End Sub
    Public Sub New(ByVal ResultsArray As Integer())
        InitializeComponent()
        Me.ResultsArray = ResultsArray
    End Sub
End Class
