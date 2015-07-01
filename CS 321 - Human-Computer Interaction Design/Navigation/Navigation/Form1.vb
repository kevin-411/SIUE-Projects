Imports Navigation
Public Class Form1
    Dim nav As New Navigation("305", "123")

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(1200, 500)
        nav.Location = New Point(0, 0)
        nav.Size = Me.Size
        Me.Controls.Add(nav)
    End Sub
End Class