Public Class Form1

    Dim selectedKiosk As Integer

    Public Sub New(ByVal kiosk As Integer)
        InitializeComponent()
        selectedKiosk = kiosk
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FloorLayout.Show()
    End Sub
End Class
