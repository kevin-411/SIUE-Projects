Public Class FloorLayout
    Dim selectedKiosk As String
    Dim kioskSelectionPtr As KioskSelection
    Dim welcomeScreenPtr As WelcomeScreen
    Dim extensionDisplayed As Boolean = False
    Dim currentFloor As Integer

    Public Sub AssignKiosk(ByVal kiosk As String)
        selectedKiosk = kiosk
        If (selectedKiosk = "111") Then
            currentFloor = 1
        Else
            currentFloor = 0
            LowerLevelButton_Click(New Object, EventArgs.Empty)
        End If

        loadMap()
    End Sub

    Private Sub loadMap()
        If currentFloor = 0 Then
            PictureBox1.Image = Image.FromFile(Application.StartupPath & "\FloorPlanImages\LowerLevel.jpg")
            If extensionDisplayed Then
                ExtensionPictureBox.Image = Image.FromFile(Application.StartupPath & "\FloorPlanImages\LowerLevel_Annex.jpg")
                ExtensionPictureBox.Visible = True
            Else
                ExtensionPictureBox.Visible = False
            End If
        ElseIf currentFloor = 1 Then
            PictureBox1.Image = Image.FromFile(Application.StartupPath & "\FloorPlanImages\FirstFloor.jpg")
            If extensionDisplayed Then
                ExtensionPictureBox.Image = Image.FromFile(Application.StartupPath & "\FloorPlanImages\FirstFloor_Annex.jpg")
                ExtensionPictureBox.Visible = True
            Else
                ExtensionPictureBox.Visible = False
            End If
        ElseIf currentFloor = 2 Then
            PictureBox1.Image = Image.FromFile(Application.StartupPath & "\FloorPlanImages\SecondFloor.jpg")
            If extensionDisplayed Then
                ExtensionPictureBox.Image = Image.FromFile(Application.StartupPath & "\FloorPlanImages\SecondFloor_Annex.jpg")
                ExtensionPictureBox.Visible = True
            Else
                ExtensionPictureBox.Visible = False
            End If
        Else
            PictureBox1.Image = Image.FromFile(Application.StartupPath & "\FloorPlanImages\ThirdFloor.jpg")
            If extensionDisplayed Then
                ExtensionPictureBox.Image = Image.FromFile(Application.StartupPath & "\FloorPlanImages\ThirdFloor_Annex.jpg")
                ExtensionPictureBox.Visible = True
            Else
                ExtensionPictureBox.Visible = False
            End If
        End If
    End Sub

    Private Sub FloorLayout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        welcomeScreenPtr = New WelcomeScreen(Me, True)
        welcomeScreenPtr.ShowDialog()
        LegendPictureBox.Image = Image.FromFile(Application.StartupPath & "\FloorPlanImages\Legend.png")
    End Sub

    Private Sub BuildingHoursButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuildingHoursButton.Click
        Me.Visible = False
        welcomeScreenPtr.Visible = True

    End Sub

    Private Sub LowerLevelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LowerLevelButton.Click
        currentFloor = 0
        loadMap()
        FirstFloorButton.Enabled = True
        SecondFloorButton.Enabled = True
        ThirdFloorButton.Enabled = True
        LowerLevelButton.Enabled = False
        FirstFloorButton.BackColor = Color.Red
        FirstFloorButton.ForeColor = Color.White
        SecondFloorButton.BackColor = Color.Red
        SecondFloorButton.ForeColor = Color.White
        ThirdFloorButton.BackColor = Color.Red
        ThirdFloorButton.ForeColor = Color.White
        LowerLevelButton.BackColor = Color.White
        LowerLevelButton.ForeColor = Color.Red
    End Sub

    Private Sub FirstFloorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FirstFloorButton.Click
        currentFloor = 1
        loadMap()
        FirstFloorButton.Enabled = False
        SecondFloorButton.Enabled = True
        ThirdFloorButton.Enabled = True
        LowerLevelButton.Enabled = True
        FirstFloorButton.BackColor = Color.White
        FirstFloorButton.ForeColor = Color.Red
        SecondFloorButton.BackColor = Color.Red
        SecondFloorButton.ForeColor = Color.White
        ThirdFloorButton.BackColor = Color.Red
        ThirdFloorButton.ForeColor = Color.White
        LowerLevelButton.BackColor = Color.Red
        LowerLevelButton.ForeColor = Color.White
    End Sub

    Private Sub SecondFloorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SecondFloorButton.Click
        currentFloor = 2
        loadMap()
        FirstFloorButton.Enabled = True
        SecondFloorButton.Enabled = False
        ThirdFloorButton.Enabled = True
        LowerLevelButton.Enabled = True
        FirstFloorButton.BackColor = Color.Red
        FirstFloorButton.ForeColor = Color.White
        SecondFloorButton.BackColor = Color.White
        SecondFloorButton.ForeColor = Color.Red
        ThirdFloorButton.BackColor = Color.Red
        ThirdFloorButton.ForeColor = Color.White
        LowerLevelButton.BackColor = Color.Red
        LowerLevelButton.ForeColor = Color.White
    End Sub

    Private Sub ThirdFloorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThirdFloorButton.Click
        currentFloor = 3
        loadMap()
        FirstFloorButton.Enabled = True
        SecondFloorButton.Enabled = True
        ThirdFloorButton.Enabled = False
        LowerLevelButton.Enabled = True
        FirstFloorButton.BackColor = Color.Red
        FirstFloorButton.ForeColor = Color.White
        SecondFloorButton.BackColor = Color.Red
        SecondFloorButton.ForeColor = Color.White
        ThirdFloorButton.BackColor = Color.White
        ThirdFloorButton.ForeColor = Color.Red
        LowerLevelButton.BackColor = Color.Red
        LowerLevelButton.ForeColor = Color.White
    End Sub

    Private Sub BuildingExtensionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuildingExtensionButton.Click
        extensionDisplayed = Not extensionDisplayed
        loadMap()
        If BuildingExtensionButton.Text = "Add Extension" Then
            BuildingExtensionButton.Text = "Remove Extension"
            BuildingExtensionButton.BackColor = Color.White
            BuildingExtensionButton.ForeColor = Color.Red
        Else
            BuildingExtensionButton.Text = "Add Extension"
            BuildingExtensionButton.BackColor = Color.Red
            BuildingExtensionButton.ForeColor = Color.White
        End If
    End Sub
    Private Sub Layout_Click(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles PictureBox1.Click
        'Dim str As String = "Hey you clicked me at (" & e.Location.X & "," & e.Location.Y & ")"
        'MsgBox(str, MsgBoxStyle.Information, "You clicked me mutha fucka!!")
        Dim roomNumber As String = New Navigation().getRoomNumber(e.X, e.Y, currentFloor)
        If Not roomNumber = "INVALID" Then
            Dim room As RoomView = New RoomView(selectedKiosk, roomNumber)
            room.ShowDialog(Me)
        End If
    End Sub

    Private Sub FacultyStaffButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacultyStaffButton.Click
        Dim facultyStaff As New Faculty_Staff(Me, selectedKiosk)
        facultyStaff.ShowDialog(Me)
    End Sub

    Private Sub ViewRoomsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewRoomsButton.Click
        Dim allRooms As New ViewAllRooms(Me, selectedKiosk)
        allRooms.ShowDialog(Me)
    End Sub
   
End Class