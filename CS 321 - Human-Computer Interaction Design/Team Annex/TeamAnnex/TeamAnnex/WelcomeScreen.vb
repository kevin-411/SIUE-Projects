Public Class WelcomeScreen
    Public layoutPtr As FloorLayout
    Dim kioskSelectionPtr As KioskSelection
    Private needStartingKiosk As Boolean

    Public Sub New(ByRef layout As FloorLayout, ByVal needKiosk As Boolean)
        InitializeComponent()
        Me.SetDesktopLocation(0, 25)
        layoutPtr = layout
        needStartingKiosk = needKiosk
    End Sub

    Private Sub EnterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnterButton.Click
        Me.Visible = False
        layoutPtr.Visible = True
    End Sub

    Private Sub WelcomeScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If needStartingKiosk Then

            kioskSelectionPtr = New KioskSelection(Me)
            kioskSelectionPtr.ShowDialog()
        End If

    End Sub
End Class
