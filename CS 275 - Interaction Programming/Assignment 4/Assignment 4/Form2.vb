Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox16.Text = "Oregon" Then
            Dialog1.Show()
        Else
            Me.Close()
        End If

    End Sub

    Private Sub ComboBox16_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox16.SelectedIndexChanged

    End Sub
End Class