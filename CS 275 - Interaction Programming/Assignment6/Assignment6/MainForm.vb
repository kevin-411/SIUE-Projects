Imports System.IO
Public Class MainForm
    Dim fileName As String = "voteresults.txt"
    Dim statesCount As Integer = 0
    Dim States(50) As State
    Dim allowdraw As Boolean = False
    Dim demPercentage As Double
    Dim repPercentage As Double
    Dim demVotes As Integer
    Dim repVotes As Integer
    Dim totalVotes As Integer
    Dim demElectoral As Double
    Dim repElectoral As Double
    Dim totalElectoral As Double
    Public Structure State
        Public abbreviation As String
        Public electoralVotes As Integer
        Public demVotes As Integer
        Public repVotes As Integer
        Public totalVotes As Integer
        Public demPercentage As Double
        Public repPercentage As Double
        Public demElectoral As Integer
        Public repElectoral As Integer
    End Structure
    Private Sub LoadFile()
        Try ' open file for reading
            Dim fileReader As StreamReader = New StreamReader(fileName)
            DemocraticCandidateLbl.Text = fileReader.ReadLine()
            RepublicanCandidateLbl.Text = fileReader.ReadLine()
            DemocraticPicture.BackgroundImage = My.Resources.ResourceManager.GetObject(DemocraticCandidateLbl.Text)
            RepublicanPicture.BackgroundImage = My.Resources.ResourceManager.GetObject(RepublicanCandidateLbl.Text)
            Dim temp As String
            Do While Not fileReader.EndOfStream AndAlso statesCount <= 50 ' while not end of file
                temp = fileReader.ReadLine()
                Dim temparray() As String = temp.Split(vbTab)
                States(statesCount).abbreviation = temparray(0)
                stateChooser.Items.Add(States(statesCount).abbreviation)
                States(statesCount).electoralVotes = temparray(1)
                totalElectoral += States(statesCount).electoralVotes
                States(statesCount).demVotes = temparray(2)
                demVotes += States(statesCount).demVotes
                States(statesCount).repVotes = temparray(3)
                repVotes += States(statesCount).repVotes
                States(statesCount).totalVotes = States(statesCount).demVotes + States(statesCount).repVotes
                totalVotes += States(statesCount).totalVotes
                States(statesCount).demPercentage = (States(statesCount).demVotes / States(statesCount).totalVotes)
                States(statesCount).repPercentage = 1 - States(statesCount).demPercentage
                If States(statesCount).demPercentage > States(statesCount).repPercentage Then
                    States(statesCount).demElectoral = States(statesCount).electoralVotes
                    demElectoral += States(statesCount).demElectoral
                Else
                    States(statesCount).repElectoral = States(statesCount).electoralVotes
                    repElectoral += States(statesCount).repElectoral
                End If
                statesCount = statesCount + 1
            Loop
            demPercentage = (demVotes / totalVotes)
            repPercentage = 1 - demPercentage
            allowdraw = True
            RepElecVotesLbl.Visible = True
            DemElecVotesLbl.Visible = True
            ZeroLbl1.Visible = True
            ZeroLbl2.Visible = True
            TotalElectoralDemLbl.Text = totalElectoral
            TotalElectoralRepLbl.Text = totalElectoral
            Me.Invalidate()
            If demElectoral > repElectoral Then
                DemocraticLbl.Text = "(Winner)"
                RepublicanLbl.Text = "(Loser)"
            Else
                RepublicanLbl.Text = "(Winner)"
                DemocraticLbl.Text = "(Loser)"
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Draw(ByVal sender As Object,
    ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim graphicsObject As Graphics = e.Graphics()
        Dim square As New Rectangle(0, 0, 120, 120)
        Dim redbrush As New SolidBrush(Color.Red)
        Dim redpen As New Pen(redbrush, 1)
        Dim bluebrush As New SolidBrush(Color.Blue)
        Dim bluepen As New Pen(bluebrush, 1)
        'Main Pie
        If allowdraw Then
           
            square.Location = New Point(Me.Width() / 2 - (square.Width / 2), DemocraticPicture.Location.Y)
            graphicsObject.DrawArc(New Pen(Brushes.Black, 5), square, 0, 360)
            PieLbl.Visible = True
            graphicsObject.FillPie(bluebrush, square, 0, 360 * demPercentage)
            graphicsObject.FillPie(redbrush, square, 360 * demPercentage, 360 * repPercentage)
            Dim amount As Integer = Convert.ToInt32(200 * (demElectoral / totalElectoral))
            graphicsObject.FillRectangle(bluebrush, DemocraticPicture.Location.X + DemocraticPicture.Width + 10, DemocraticPicture.Location.Y + (200 - amount), 20, amount)
            amount = Convert.ToInt32(200 * (repElectoral / totalElectoral))
            graphicsObject.FillRectangle(redbrush, RepublicanPicture.Location.X - 30, DemocraticPicture.Location.Y + (200 - amount), 20, amount)

        End If
        If allowdraw AndAlso (stateChooser.SelectedIndex >= 0 AndAlso stateChooser.SelectedIndex <= 50) Then
            square.Location = New Point(Me.Width() / 2 - (square.Width / 2), StateResultsGroupBox.Location.Y)
            graphicsObject.DrawArc(New Pen(Brushes.Black, 5), square, 0, 360)
            graphicsObject.FillPie(bluebrush, square, 0, 360 * States(stateChooser.SelectedIndex).demPercentage)
            graphicsObject.FillPie(redbrush, square, 360 * States(stateChooser.SelectedIndex).demPercentage, 360 * States(stateChooser.SelectedIndex).repPercentage)
            If (States(stateChooser.SelectedIndex).demPercentage > States(stateChooser.SelectedIndex).repPercentage) Then
                ElectoralVotesWonPicture.BackgroundImage = DemocraticPicture.BackgroundImage
                ElectoralVotesWonLbl.Text = States(stateChooser.SelectedIndex).electoralVotes
                ElectoralVotesWonLbl.ForeColor = Color.Blue
            Else
                ElectoralVotesWonPicture.BackgroundImage = RepublicanPicture.BackgroundImage
                ElectoralVotesWonLbl.Text = States(stateChooser.SelectedIndex).electoralVotes
                ElectoralVotesWonLbl.ForeColor = Color.Red
            End If
        End If

    End Sub
    Private Sub DownBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownBtn.Click
        If Not StateLbl.Visible Then
            Me.Height += 200
            DownBtn.BackgroundImage = My.Resources.uparrow
            StateLbl.Visible = True
            stateChooser.Visible = True
            StateTagLbl.Visible = True
        Else
            Me.Height -= 200
            DownBtn.BackgroundImage = My.Resources.downarrow
            StateLbl.Visible = False
            stateChooser.Visible = False
            StateTagLbl.Visible = False
        End If
    End Sub
    Private Sub stateChooser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stateChooser.SelectedIndexChanged
        States(stateChooser.SelectedIndex).demPercentage = (States(stateChooser.SelectedIndex).demVotes / States(stateChooser.SelectedIndex).totalVotes)
        States(stateChooser.SelectedIndex).repPercentage = 1 - States(stateChooser.SelectedIndex).demPercentage
        Me.Invalidate()
        ElectoralVoteTextBox.Text = States(stateChooser.SelectedIndex).electoralVotes
        RepVoteTextBox.Text = States(stateChooser.SelectedIndex).repVotes
        DemVoteTextBox.Text = States(stateChooser.SelectedIndex).demVotes
        UpdateResultsBtn.Visible = False
    End Sub
    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim result As DialogResult ' stores result of Open dialog
        result = fileChooser.ShowDialog
        fileName = fileChooser.FileName

        ' if user did not click Cancel, Load File
        If result <> Windows.Forms.DialogResult.Cancel Then
            LoadFile()
            OpenToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Dim result As DialogResult ' stores result of Save dialog
        result = saveFileChooser.ShowDialog()
        fileName = saveFileChooser.FileName ' get specified file name
        If result <> Windows.Forms.DialogResult.Cancel Then
            Try
                Dim fileWriter As New StreamWriter(fileName)
                fileWriter.WriteLine(DemocraticCandidateLbl.Text)
                fileWriter.WriteLine(RepublicanCandidateLbl.Text)
                For i = 0 To statesCount - 1
                    fileWriter.Write(States(i).abbreviation.ToString())
                    fileWriter.Write(vbTab)
                    fileWriter.Write(States(i).electoralVotes.ToString())
                    fileWriter.Write(vbTab)
                    fileWriter.Write(States(i).demVotes.ToString())
                    fileWriter.Write(vbTab)
                    fileWriter.WriteLine(States(i).repVotes.ToString())
                Next
                fileWriter.Close()
            Catch ex As IOException
                MessageBox.Show("Error Opening File", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub DownBtn_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownBtn.MouseHover
        Dim mousey As ToolTip = New ToolTip()
        mousey.SetToolTip(DownBtn, "Show/Hide State Results")

    End Sub
    Private Sub TextBoxChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepVoteTextBox.TextChanged, DemVoteTextBox.TextChanged, ElectoralVoteTextBox.TextChanged
        UpdateResultsBtn.Visible = True
    End Sub
    Private Sub UpdateResultsBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateResultsBtn.Click
        If Not (ElectoralVoteTextBox.Text = Nothing) AndAlso Not (RepVoteTextBox.Text = Nothing) AndAlso Not (DemVoteTextBox.Text = Nothing) Then
            States(stateChooser.SelectedIndex).electoralVotes = ElectoralVoteTextBox.Text
            States(stateChooser.SelectedIndex).repVotes = RepVoteTextBox.Text
            States(stateChooser.SelectedIndex).demVotes = DemVoteTextBox.Text
            reset()
            stateChooser_Click(sender, e)
        End If
    End Sub
    Sub reset()
        totalElectoral = 0
        demVotes = 0
        repVotes = 0
        demElectoral = 0
        repElectoral = 0
        totalVotes = 0
        For i = 0 To statesCount - 1
            totalElectoral += States(i).electoralVotes
            demVotes += States(i).demVotes
            repVotes += States(i).repVotes
            States(i).totalVotes = States(i).demVotes + States(i).repVotes
            totalVotes += States(i).totalVotes
            States(i).demPercentage = (States(i).demVotes / States(i).totalVotes)
            States(i).repPercentage = 1 - States(i).demPercentage
            If States(i).demPercentage > States(i).repPercentage Then
                States(i).demElectoral = States(i).electoralVotes
                demElectoral += States(i).demElectoral
            Else
                States(i).repElectoral = States(i).electoralVotes
                repElectoral += States(i).repElectoral
            End If
        Next
        demPercentage = (demVotes / totalVotes)
        repPercentage = 1 - demPercentage
        allowdraw = True
        RepElecVotesLbl.Visible = True
        DemElecVotesLbl.Visible = True
        ZeroLbl1.Visible = True
        ZeroLbl2.Visible = True
        TotalElectoralDemLbl.Text = totalElectoral
        TotalElectoralRepLbl.Text = totalElectoral


        Me.Invalidate()
    End Sub
    Sub restart()
        reset()
        statesCount = 0
        If StateLbl.Visible Then
            Me.Height -= 200
            DownBtn.BackgroundImage = My.Resources.downarrow
            StateLbl.Visible = False
            stateChooser.Visible = False
            StateTagLbl.Visible = False
        End If
    End Sub
End Class
