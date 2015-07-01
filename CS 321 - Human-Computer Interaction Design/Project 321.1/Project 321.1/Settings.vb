'File: Settings.vb
'Date: 01/29/2013
'Name: Brian Olsen, Dustin Thomas, Denver Coladilla
'Course:  CS 321-001 - Human Computer Interaction
'Desc:This program displays the periodic table in a traditional layout. It allows students to click on a given element 
'to look closer at the properties of the element. The program also has a "quiz mode" that can ask the user certain
'information about elements and get graded.
'Instructions: Place both the Chemistry.mdb file and the Images folder and place them in the directory...
' "Project 321.1/bin/Debug/"
Imports System.Windows.Forms

Public Class settings

    Private TableCellHeight = 60
    Private TableCellLength = 50
    Private defaultColor = Color.LightCyan
    Private defaultText As String = "18" & vbCrLf & "Ar"
    Private exampleFont As Font = New Font("Modern No. 20", 14, FontStyle.Regular)
    Private optionArray() As Boolean = New Boolean() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        exampleButton.Font = exampleFont
        exampleButton.BackColor = defaultColor
        exampleButton.Text = defaultText
        exampleButton.Height = TableCellHeight
        exampleButton.Width = TableCellLength
        chemSymbCheckBox.Checked = False
        atomicNumbCheckBox.Checked = False
        groupNameCheckBox.Checked = False
        AddHandler chemSymbCheckBox.CheckedChanged, AddressOf redrawExample
        AddHandler atomicNumbCheckBox.CheckedChanged, AddressOf redrawExample
        AddHandler groupNameCheckBox.CheckedChanged, AddressOf redrawExample
        AddHandler elementNameCheckBox.CheckedChanged, AddressOf QuizQuestions
        AddHandler chemicalSymbolCheckBox.CheckedChanged, AddressOf QuizQuestions
        AddHandler discovererCheckBox.CheckedChanged, AddressOf QuizQuestions
        AddHandler discoveryYearCheckBox.CheckedChanged, AddressOf QuizQuestions
        AddHandler questionGroupNameCheckBox.CheckedChanged, AddressOf QuizQuestions
        AddHandler meltingPointCheckBox.CheckedChanged, AddressOf QuizQuestions
        AddHandler boilingPointCheckBox.CheckedChanged, AddressOf QuizQuestions
        AddHandler Length1RadioButton.CheckedChanged, AddressOf QuizLength
        AddHandler Length2RadioButton.CheckedChanged, AddressOf QuizLength
        AddHandler Length3RadioButton.CheckedChanged, AddressOf QuizLength
        AddHandler Length4RadioButton.CheckedChanged, AddressOf QuizLength
        redrawExample()
    End Sub

    Private Sub redrawExample()

        If chemSymbCheckBox.Checked AndAlso atomicNumbCheckBox.Checked Then
            exampleButton.Text = defaultText
            Me.questionOptionBox.Enabled = True
        ElseIf chemSymbCheckBox.Checked Then
            Me.questionOptionBox.Enabled = True
            exampleButton.Text = vbCrLf & "Ar"
        ElseIf atomicNumbCheckBox.Checked Then
            Me.questionOptionBox.Enabled = True
            exampleButton.Text = "18" & vbCrLf & " "
        Else
            exampleButton.Text = ""
        End If
        If groupNameCheckBox.Checked Then
            exampleButton.BackColor = defaultColor
            Me.questionOptionBox.Enabled = True
        Else
            exampleButton.BackColor = Color.WhiteSmoke
        End If
        If Not (chemSymbCheckBox.Checked Or atomicNumbCheckBox.Checked Or groupNameCheckBox.Checked) Then
            exampleButton.Text = ""
            Me.OK_Button.Enabled = False
            Me.givenBox.Enabled = True
            Me.questionOptionBox.Enabled = False
            Me.LengthBox.Enabled = False
        End If
        If chemSymbCheckBox.Checked = True Then
            chemicalSymbolCheckBox.Enabled = False
        Else
            chemicalSymbolCheckBox.Enabled = True
        End If
        If groupNameCheckBox.Checked Then
            questionGroupNameCheckBox.Enabled = False
        Else
            questionGroupNameCheckBox.Enabled = True
        End If
        QuizQuestions()
    End Sub
    Private Sub QuizQuestions()
        If questionOptionBox.Enabled AndAlso (elementNameCheckBox.Checked = True Or chemicalSymbolCheckBox.Checked Or discovererCheckBox.Checked Or discoveryYearCheckBox.Checked Or questionGroupNameCheckBox.Checked Or meltingPointCheckBox.Checked Or boilingPointCheckBox.Checked) Then
            LengthBox.Enabled = True
        Else
            LengthBox.Enabled = False
            Me.OK_Button.Enabled = False
        End If
        If chemicalSymbolCheckBox.Checked = True Then
            chemSymbCheckBox.Enabled = False
        Else
            chemSymbCheckBox.Enabled = True
        End If
        If questionGroupNameCheckBox.Checked Then
            groupNameCheckBox.Enabled = False
        Else
            groupNameCheckBox.Enabled = True
        End If
        QuizLength()
    End Sub
    Private Sub QuizLength()
        If questionOptionBox.Enabled AndAlso (Length1RadioButton.Checked Or Length2RadioButton.Checked Or Length3RadioButton.Checked Or Length4RadioButton.Checked) Then
            Me.OK_Button.Enabled = True
        Else
            Me.OK_Button.Enabled = False
        End If
    End Sub

    Public Function returnOptions()
        'preview display
        optionArray(0) = chemSymbCheckBox.Checked
        optionArray(1) = atomicNumbCheckBox.Checked
        optionArray(2) = groupNameCheckBox.Checked
        'category questions
        optionArray(3) = elementNameCheckBox.Checked
        optionArray(4) = chemicalSymbolCheckBox.Checked
        optionArray(5) = discovererCheckBox.Checked
        optionArray(6) = discoveryYearCheckBox.Checked
        optionArray(7) = questionGroupNameCheckBox.Checked
        optionArray(8) = meltingPointCheckBox.Checked
        optionArray(9) = boilingPointCheckBox.Checked
        '# of questions
        optionArray(10) = Length1RadioButton.Checked
        optionArray(11) = Length2RadioButton.Checked
        optionArray(12) = Length3RadioButton.Checked
        optionArray(13) = Length4RadioButton.Checked
        Return optionArray
    End Function

    Private Sub OK_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
