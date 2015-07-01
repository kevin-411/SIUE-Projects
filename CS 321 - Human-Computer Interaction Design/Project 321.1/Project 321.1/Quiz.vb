'File: Quiz.vb
'Date: 01/29/2013
'Name: Brian Olsen, Dustin Thomas, Denver Coladilla
'Course:  CS 321-001 - Human Computer Interaction
'Desc:This program displays the periodic table in a traditional layout. It allows students to click on a given element 
'to look closer at the properties of the element. The program also has a "quiz mode" that can ask the user certain
'information about elements and get graded.
'Instructions: Place both the Chemistry.mdb file and the Images folder and place them in the directory...
' "Project 321.1/bin/Debug/"
Imports System.Windows.Forms

Public Class Quiz

    Private TableCellHeight = 60
    Private TableCellLength = 50
    Private defaultText As String = "" & vbCrLf & ""
    Private exampleFont As Font = New Font("Modern No. 20", 14, FontStyle.Regular)

    Dim elt As Integer = 0
    Dim eltName As Integer = 0
    Dim symbol As Integer = 1
    Dim number As Integer = 2
    Dim groupName As Integer = 4
    Dim meltingPoint As Integer = 6
    Dim boilingPoint As Integer = 7
    Dim discoverer As Integer = 8
    Dim discoveringYear As Integer = 10
    Dim numberOfQuestions As Integer = 0
    Dim ElementDisplayOptions() As Boolean = {0, 0, 0}
    Dim Unknown As String = "Not Listed"
    Private tempTally() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    '                                 0  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17
    '                                          0  1  2  3  4  5  6
    Private tallyArray() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    Dim Random As System.Random
    Dim randArray() As Integer = {0, 0, 0, 0}
    Dim answerelt As Integer = 0
    Dim WithEvents newQuestion As Form = New Form()
    Dim QuizQuestion = 0

    Public Sub New(ByVal OptionArray As Boolean())
        InitializeComponent()
        Random = New System.Random(CType(System.DateTime.Now.Millisecond, Integer))
        For x As Integer = 0 To 2
            ElementDisplayOptions(x) = OptionArray(x)
        Next
        For x As Integer = 0 To 6
            tallyArray(x) = Convert.ToInt32(OptionArray(x + 3))
        Next
        If OptionArray(10) Then
            numberOfQuestions = 5
        ElseIf OptionArray(11) Then
            numberOfQuestions = 10
        ElseIf OptionArray(12) Then
            numberOfQuestions = 15
        ElseIf OptionArray(13) Then
            numberOfQuestions = 20
        End If
        elementButton.Font = exampleFont
        elementButton.Text = defaultText
        elementButton.Height = TableCellHeight
        elementButton.Width = TableCellLength

        AddHandler ElementComboBox.SelectedIndexChanged, AddressOf AnswersSelected
        AddHandler ChemicalSymComboBox.SelectedIndexChanged, AddressOf AnswersSelected
        AddHandler GroupNameComboBox.SelectedIndexChanged, AddressOf AnswersSelected
        AddHandler MeltingPointComboBox.SelectedIndexChanged, AddressOf AnswersSelected
        AddHandler BoilingPointComboBox.SelectedIndexChanged, AddressOf AnswersSelected

    End Sub

    Private Sub Quiz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NextQuestion()
        eltCorrect.Visible = False
        symCorrect.Visible = False
        disCorrect.Visible = False
        dyCorrect.Visible = False
        gnCorrect.Visible = False
        mpCorrect.Visible = False
        bpCorrect.Visible = False

        eltIncorrect.Visible = False
        symIncorrect.Visible = False
        disIncorrect.Visible = False
        dyIncorrect.Visible = False
        gnIncorrect.Visible = False
        gnCorrect.Visible = False
        mpIncorrect.Visible = False
        bpIncorrect.Visible = False

        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label7.Visible = False

    End Sub
    Private Sub NextQuestion()
        ResetQuestions()

        If ElementDisplayOptions(0) AndAlso ElementDisplayOptions(1) Then
            elementButton.Text = PeriodicTableForm.dataTable.Rows(answerelt)(number) & vbCrLf & PeriodicTableForm.dataTable.Rows(answerelt)(symbol)
        ElseIf ElementDisplayOptions(0) Then

            elementButton.Text = vbCrLf & PeriodicTableForm.dataTable.Rows(answerelt)(symbol) & vbCrLf
        ElseIf ElementDisplayOptions(1) Then
            elementButton.Text = PeriodicTableForm.dataTable.Rows(answerelt)(number) & vbCrLf & vbCrLf
        End If
        If ElementDisplayOptions(2) = True Then
            x = PeriodicTableForm.dataTable.Rows(answerelt)(groupName)
            If PeriodicTableForm.dataTable.Rows(answerelt)(groupName) = "Basic Nonmetal" Then
                elementButton.BackColor = Color.SpringGreen
            ElseIf PeriodicTableForm.dataTable.Rows(answerelt)(groupName) = "Alkali Metal" Then
                elementButton.BackColor = Color.Yellow
            ElseIf PeriodicTableForm.dataTable.Rows(answerelt)(groupName) = "Alkaline Earth Metal" Then
                elementButton.BackColor = Color.PeachPuff
            ElseIf PeriodicTableForm.dataTable.Rows(answerelt)(groupName) = "Transition Metal" Then
                elementButton.BackColor = Color.Tan
            ElseIf PeriodicTableForm.dataTable.Rows(answerelt)(groupName) = "Post-Transition Metal" Then
                elementButton.BackColor = Color.PaleGoldenrod
            ElseIf PeriodicTableForm.dataTable.Rows(answerelt)(groupName) = "Metalloid" Then
                elementButton.BackColor = Color.LightGray
            ElseIf PeriodicTableForm.dataTable.Rows(answerelt)(groupName) = "Halogen" Then
                elementButton.BackColor = Color.LightGoldenrodYellow
            ElseIf PeriodicTableForm.dataTable.Rows(answerelt)(groupName) = "Noble Gas" Then
                elementButton.BackColor = Color.LightCyan
            ElseIf PeriodicTableForm.dataTable.Rows(answerelt)(groupName) = "Lanthanoid" Then
                elementButton.BackColor = Color.Khaki
            ElseIf PeriodicTableForm.dataTable.Rows(answerelt)(groupName) = "Actinoid" Then
                elementButton.BackColor = Color.Pink
            End If
        Else
            elementButton.BackColor = Color.WhiteSmoke
        End If

        If tallyArray(0) = 0 Then
            ElementComboBox.Enabled = False
            ElementComboBox.Visible = False
            ElementAnswer.Visible = True
        End If
        If tallyArray(1) = 0 Then
            ChemicalSymComboBox.Enabled = False
            ChemicalSymComboBox.Visible = False
            ChemicalSymAnswer.Visible = True
        End If
        If tallyArray(2) = 0 Then

            discovererUserAnswer.Enabled = False
            discovererUserAnswer.Visible = False
            Label6.Visible = True
            discovererName.Visible = True
            trueButton.Visible = False
            falseButton.Visible = False
        End If
        If tallyArray(3) = 0 Then
            yearTextBox.Enabled = False
            yearTextBox.Visible = False
            DiscoverYearLabel.Visible = False
            dYearLabel.Visible = True
            DYAnswer.Visible = True
        End If
        If tallyArray(4) = 0 Then
            GroupNameComboBox.Enabled = False
            GroupNameComboBox.Visible = False
            GNAnswer.Visible = True
        End If
        If tallyArray(5) = 0 Then
            MeltingPointComboBox.Enabled = False
            MeltingPointComboBox.Visible = False
            MPAnswer.Visible = True
        End If
        If tallyArray(6) = 0 Then
            BoilingPointComboBox.Enabled = False
            BoilingPointComboBox.Visible = False
            BPAnswer.Visible = True
        End If

        ElementAnswer.Text = PeriodicTableForm.dataTable.Rows(answerelt)(eltName)
        ChemicalSymAnswer.Text = PeriodicTableForm.dataTable.Rows(answerelt)(symbol)
        GNAnswer.Text = PeriodicTableForm.dataTable.Rows(answerelt)(groupName)
        BPAnswer.Text = PeriodicTableForm.dataTable.Rows(answerelt)(boilingPoint)
        MPAnswer.Text = PeriodicTableForm.dataTable.Rows(answerelt)(meltingPoint)
        DYAnswer.Text = PeriodicTableForm.dataTable.Rows(answerelt)(discoveringYear)
        discovererUserAnswer.Text = PeriodicTableForm.dataTable.Rows(answerelt)(discoverer)
        discovererName.Text = PeriodicTableForm.dataTable.Rows(answerelt)(discoverer)

        ElementComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(6)(eltName))
        ElementComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(76)(eltName))
        ElementComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(34)(eltName))
        ElementComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(answerelt)(eltName))

        ChemicalSymComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(6)(symbol))
        ChemicalSymComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(76)(symbol))
        ChemicalSymComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(34)(symbol))
        ChemicalSymComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(answerelt)(symbol))

        GroupNameComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(6)(groupName))
        GroupNameComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(76)(groupName))
        GroupNameComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(34)(groupName))
        GroupNameComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(answerelt)(groupName))

        MeltingPointComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(6)(meltingPoint))
        MeltingPointComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(76)(meltingPoint))
        MeltingPointComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(34)(meltingPoint))
        MeltingPointComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(answerelt)(meltingPoint))

        BoilingPointComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(6)(boilingPoint))
        BoilingPointComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(76)(boilingPoint))
        BoilingPointComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(34)(boilingPoint))
        BoilingPointComboBox.Items.Add(PeriodicTableForm.dataTable.Rows(answerelt)(boilingPoint))

        discovererUserAnswer.Text = PeriodicTableForm.dataTable.Rows(answerelt)(discoverer) & " discovered this element."

        CurrentQuestion = QuizQuestion + 1
        Me.QuestionNumber.Text = "Question #" + CurrentQuestion.ToString + " Out of " + numberOfQuestions.ToString
        AnswersSelected()
    End Sub

    Private Sub CheckAnswerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAnswerButton.Click
        checkAnswer()
        CheckAnswerButton.Enabled = False
        NextButton.Enabled = True
    End Sub
    Private Sub ResetQuestions()
        ElementComboBox.Items.Clear()
        ChemicalSymComboBox.Items.Clear()
        discovererUserAnswer.ResetText()
        yearTextBox.Clear()
        BoilingPointComboBox.Items.Clear()
        MeltingPointComboBox.Items.Clear()
        GroupNameComboBox.Items.Clear()
        ElementComboBox.ResetText()
        ChemicalSymComboBox.ResetText()
        discovererUserAnswer.ResetText()
        yearTextBox.ResetText()
        BoilingPointComboBox.ResetText()
        MeltingPointComboBox.ResetText()
        GroupNameComboBox.ResetText()
        eltCorrect.Visible = False
        symCorrect.Visible = False
        disCorrect.Visible = False
        dyCorrect.Visible = False
        gnCorrect.Visible = False
        mpCorrect.Visible = False
        bpCorrect.Visible = False

        eltIncorrect.Visible = False
        symIncorrect.Visible = False
        disIncorrect.Visible = False
        dyIncorrect.Visible = False
        gnIncorrect.Visible = False
        gnCorrect.Visible = False
        mpIncorrect.Visible = False
        bpIncorrect.Visible = False
        NextButton.Enabled = True

        ElementComboBox.Enabled = True
        ChemicalSymComboBox.Enabled = True
        discovererUserAnswer.Enabled = True
        yearTextBox.Enabled = True
        BoilingPointComboBox.Enabled = True
        MeltingPointComboBox.Enabled = True
        GroupNameComboBox.Enabled = True

        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label7.Visible = False

        trueButton.Enabled = True
        falseButton.Enabled = True
        trueButton.Checked = False
        falseButton.Checked = False

    End Sub
    Private Sub AnswersSelected()
        Dim done As Boolean = True
        If ElementComboBox.Enabled And ElementComboBox.SelectedIndex = -1 Then
            done = False
        End If
        If ChemicalSymComboBox.Enabled And ChemicalSymComboBox.SelectedIndex = -1 Then
            done = False
        End If
        If GroupNameComboBox.Enabled And GroupNameComboBox.SelectedIndex = -1 Then
            done = False
        End If
        If MeltingPointComboBox.Enabled And MeltingPointComboBox.SelectedIndex = -1 Then
            done = False
        End If
        If BoilingPointComboBox.Enabled And BoilingPointComboBox.SelectedIndex = -1 Then
            done = False
        End If

        If done = True Then
            CheckAnswerButton.Enabled = True

        Else
            CheckAnswerButton.Enabled = False

        End If
    End Sub

    Private Sub nextQ()
        QuizQuestion += 1

        If QuizQuestion < numberOfQuestions Then
            NextQuestion()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub checkAnswer()

        If ElementComboBox.Enabled Then
            If ElementComboBox.SelectedItem Is PeriodicTableForm.dataTable.Rows(answerelt)(eltName) Then

                eltCorrect.Visible = True
                ElementComboBox.Enabled = False
            Else

                eltIncorrect.Visible = True
                ElementComboBox.Enabled = False
                Label1.Text = PeriodicTableForm.dataTable.Rows(answerelt)(eltName)
                Label1.Visible = True
            End If
        End If
        If ChemicalSymComboBox.Enabled Then
            If ChemicalSymComboBox.SelectedItem Is PeriodicTableForm.dataTable.Rows(answerelt)(symbol) Then

                symCorrect.Visible = True
                ChemicalSymComboBox.Enabled = False
            Else

                symIncorrect.Visible = True
                ChemicalSymComboBox.Enabled = False
                Label2.Text = PeriodicTableForm.dataTable.Rows(answerelt)(symbol)
                Label2.Visible = True
            End If
        End If

        If GroupNameComboBox.Enabled Then
            If GroupNameComboBox.SelectedItem Is PeriodicTableForm.dataTable.Rows(answerelt)(groupName) Then
                gnCorrect.Visible = True
                GroupNameComboBox.Enabled = False

            Else

                gnIncorrect.Visible = True
                GroupNameComboBox.Enabled = False
                Label7.Text = PeriodicTableForm.dataTable.Rows(answerelt)(groupName)
                Label7.Visible = True
            End If
        End If

        If MeltingPointComboBox.Enabled Then
            If MeltingPointComboBox.SelectedItem.ToString = PeriodicTableForm.dataTable.Rows(answerelt)(meltingPoint).ToString Then

                mpCorrect.Visible = True
                MeltingPointComboBox.Enabled = False
            Else

                mpIncorrect.Visible = True
                MeltingPointComboBox.Enabled = False
                Label4.Text = PeriodicTableForm.dataTable.Rows(answerelt)(meltingPoint).ToString
                Label4.Visible = True
            End If
        End If

        If BoilingPointComboBox.Enabled Then
            If BoilingPointComboBox.SelectedItem.ToString = PeriodicTableForm.dataTable.Rows(answerelt)(boilingPoint).ToString Then


                bpCorrect.Visible = True
                BoilingPointComboBox.Enabled = False
            Else
                a = BoilingPointComboBox.SelectedItem
                b = PeriodicTableForm.dataTable.Rows(answerelt)(boilingPoint)

                bpIncorrect.Visible = True
                BoilingPointComboBox.Enabled = False
                Label3.Text = PeriodicTableForm.dataTable.Rows(answerelt)(boilingPoint).ToString
                Label3.Visible = True
            End If
        End If

        If discovererUserAnswer.Enabled Then
            If trueButton.Checked Then

                tempTally(2) += 1
                tempTally(14) += 1
                disCorrect.Visible = True
                discovererName.Enabled = False
                trueButton.Enabled = False
                falseButton.Enabled = False
            Else


                disIncorrect.Visible = True
                discovererUserAnswer.Enabled = False

                trueButton.Enabled = False
                falseButton.Enabled = False
            End If
        End If

        If yearTextBox.Enabled Then
            If yearTextBox.Text.ToString = PeriodicTableForm.dataTable.Rows(answerelt)(discoveringYear).ToString Then

                dyCorrect.Visible = True
                yearTextBox.Enabled = False
            Else

                dyIncorrect.Visible = True
                yearTextBox.Enabled = False
                Label5.Text = PeriodicTableForm.dataTable.Rows(answerelt)(discoveringYear).ToString
                Label5.Visible = True
            End If

        End If
        answerelt += 1

    End Sub

    Public Function returnTally()


        tallyArray(7) = tempTally(0)  'correct element name
        tallyArray(8) = tempTally(1)  'correct symbol
        tallyArray(9) = tempTally(2)  'correct discoverer
        tallyArray(10) = tempTally(3) 'correct discovering year
        tallyArray(11) = tempTally(4) 'correct groupname
        tallyArray(12) = tempTally(5) 'correct melting point
        tallyArray(13) = tempTally(6) 'correct boiling point

        tallyArray(14) = tempTally(7)  'incorrect element name
        tallyArray(15) = tempTally(8)  'incorrect symbol
        tallyArray(16) = tempTally(9)  'incorrect discoverer
        tallyArray(17) = tempTally(10) 'incorrect discovering year
        tallyArray(18) = tempTally(11) 'incorrect groupname
        tallyArray(19) = tempTally(12) 'incorrect melting point
        tallyArray(20) = tempTally(13) 'incorrect boiling point

        tallyArray(21) = tempTally(14) 'Total Correct
        tallyArray(22) = tempTally(15) 'Total Incorrect

        Return tallyArray
    End Function

    Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextButton.Click

        If ElementComboBox.Enabled Then
            If ElementComboBox.SelectedItem Is PeriodicTableForm.dataTable.Rows(answerelt)(eltName) Then

                tempTally(0) += 1
                tempTally(14) += 1

            Else
                tempTally(7) += 1
                tempTally(15) += 1

            End If
        End If
        If ChemicalSymComboBox.Enabled Then
            If ChemicalSymComboBox.SelectedItem Is PeriodicTableForm.dataTable.Rows(answerelt)(symbol) Then

                tempTally(1) += 1
                tempTally(14) += 1

            Else

                tempTally(8) += 1
                tempTally(15) += 1

            End If
        End If

        If GroupNameComboBox.Enabled Then
            If GroupNameComboBox.SelectedItem Is PeriodicTableForm.dataTable.Rows(answerelt)(groupName) Then
                tempTally(4) += 1
                tempTally(14) += 1

            Else

                tempTally(11) += 1
                tempTally(15) += 1
            End If
        End If

        If MeltingPointComboBox.Enabled Then
            If MeltingPointComboBox.SelectedItem.ToString = PeriodicTableForm.dataTable.Rows(answerelt)(meltingPoint).ToString Then

                tempTally(5) += 1
                tempTally(14) += 1

            Else

                tempTally(12) += 1
                tempTally(15) += 1
            End If
        End If

        If BoilingPointComboBox.Enabled Then
            If BoilingPointComboBox.SelectedItem.ToString = PeriodicTableForm.dataTable.Rows(answerelt)(boilingPoint).ToString Then

                tempTally(6) += 1
                tempTally(14) += 1

            Else
                a = BoilingPointComboBox.SelectedItem
                b = PeriodicTableForm.dataTable.Rows(answerelt)(boilingPoint)
                tempTally(13) += 1
                tempTally(15) += 1
            End If
        End If

        If discovererUserAnswer.Enabled Then
            If trueButton.Checked Then

                tempTally(2) += 1
                tempTally(14) += 1
            Else

                tempTally(9) += 1
                tempTally(15) += 1
            End If
        End If

        If yearTextBox.Enabled Then
            If yearTextBox.Text.ToString = PeriodicTableForm.dataTable.Rows(answerelt)(discoveringYear).ToString Then

                tempTally(3) += 1
                tempTally(14) += 1

            Else
                tempTally(10) += 1
                tempTally(15) += 1

            End If
        End If
        answerelt += 1
        nextQ()

    End Sub

    Private Sub exitQuiz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitQuiz.Click
        Me.Close()
    End Sub
End Class