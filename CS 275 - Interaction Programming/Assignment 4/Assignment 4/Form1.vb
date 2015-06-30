Public Class Form1
    Friend test As String
    Private Sub AddNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewToolStripMenuItem.Click
        PictureBox1.Image = My.Resources.FinalFactorKathy
        Dim oForm As Form2
        oForm = New Form2()
        oForm.Show()
        oForm = Nothing
        EditToolStripMenuItem.Enabled = True
    End Sub

    Private Sub UpdateGameResultsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateGameResultsToolStripMenuItem.Click
        test = "update game"
        SaveToolStripMenuItem.Enabled = True
        SaveAsToolStripMenuItem.Enabled = True
        PictureBox1.Image = My.Resources.FinalFactor
        Dim oForm As LoginForm2
        oForm = New LoginForm2()
        oForm.Show()
        oForm = Nothing

    End Sub

    Private Sub KathyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KathyToolStripMenuItem.Click
        test = "kathy"
        Dim oForm As LoginForm2
        oForm = New LoginForm2()
        oForm.Show()
        oForm = Nothing
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click

    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click

    End Sub

    Private Sub UpdateAdminAcctToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateAdminAcctToolStripMenuItem.Click
        test = "update admin"
        Dim oForm As LoginForm2
        oForm = New LoginForm2()
        oForm.Show()
        oForm = Nothing
    End Sub

    Private Sub ByPersonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByPersonToolStripMenuItem.Click
        If ByPersonToolStripMenuItem.Checked = False Then
            ByPersonToolStripMenuItem.Checked = True
            GroupBox2.Visible = True
        ElseIf ByPersonToolStripMenuItem.Checked = True Then
            ByPersonToolStripMenuItem.Checked = False
            GroupBox2.Visible = False
        End If

    End Sub

    Private Sub ChoicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChoicesToolStripMenuItem.Click
        If ChoicesToolStripMenuItem.Checked = False Then
            ChoicesToolStripMenuItem.Checked = True
            GroupBox1.Visible = True

        ElseIf ChoicesToolStripMenuItem.Checked = True Then
            ChoicesToolStripMenuItem.Checked = False
            GroupBox1.Visible = False
        End If
    End Sub
End Class