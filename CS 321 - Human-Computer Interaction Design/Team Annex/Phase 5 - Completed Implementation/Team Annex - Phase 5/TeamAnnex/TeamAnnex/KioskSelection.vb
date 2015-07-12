Public Class KioskSelection
    Private entrances(4) As String
    Dim welcomeScreenPtr As WelcomeScreen

    Dim fontz As New Font("Courier New", 16, FontStyle.Regular)

    Public Sub New(ByRef welcome As WelcomeScreen)
        InitializeComponent()
        welcomeScreenPtr = welcome
    End Sub

    Private Sub SubmitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmitButton.Click
        If ComboBox1.SelectedIndex <= 4 And ComboBox1.SelectedIndex >= 0 Then
            welcomeScreenPtr.layoutPtr.AssignKiosk(entrances(ComboBox1.SelectedIndex))
            Me.Dispose()
        End If

    End Sub

    Private Sub KioskSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        entrances = {"111", "019", "015", "025", "002"}
    End Sub
    Public Sub Disable_Close(ByVal sender As System.Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
    End Sub
End Class