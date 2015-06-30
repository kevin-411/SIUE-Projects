Public Class LoginForm2

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If Form1.test = "update game" Then
            Dim oForm As Form3
            oForm = New Form3()
            oForm.Show()
            oForm = Nothing
            Me.Close()
        ElseIf Form1.test = "kathy" Then
            Kathy()
            Dim oForm As Form2
            oForm = New Form2()
            oForm.Show()
            oForm = Nothing
            Me.Close()
        ElseIf Form1.test = "update admin" Then
            Dim oForm As Form4
            oForm = New Form4()
            oForm.Show()
            oForm = Nothing
            Me.Close()
        End If
        Me.Close()
    End Sub

    Private Sub Kathy()
        Form2.ComboBox1.Items.Item(0) = True
        Form2.NumericUpDown1.Value = 1


    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
