Public Class KioskSelection

    Private Sub SubmitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmitButton.Click
        If ComboBox1.SelectedIndex <= 4 And ComboBox1.SelectedIndex >= 0 Then
            Dim welcome As New Form1(ComboBox1.SelectedIndex)
            welcome.ShowDialog()
        End If

    End Sub
End Class