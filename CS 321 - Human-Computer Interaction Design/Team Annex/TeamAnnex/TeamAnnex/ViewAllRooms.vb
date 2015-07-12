Public Class ViewAllRooms
    Dim floorLayoutPtr As FloorLayout
    Dim origin As String
    Dim currentRow As DataRow
    Dim roomCount As Integer = 0
    Dim database As Database = New Database
    Dim roomButton() As Button = New Button(19) {}
    Dim viewNext As Integer = 0
    Dim count As Integer = 0

    Private Sub ViewAllRooms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PrevButton.Enabled = False
        NextButton.Enabled = True
        Dim ypos As Integer
        Dim xpos As Integer

        'Dim array As DataRowCollection = (database.getRoomsByFloor(floorNum)).Rows()
        'Dim dataTable As DataTable = database.getRoomsByFloor(1)

        For y As Integer = 0 To 3
                ypos = y * 113 + 95
           
            For x As Integer = 0 To 4
                xpos = x * 157 + 12
                roomButton(roomCount) = New Button()
                roomButton(roomCount).Location = New Point(xpos, ypos)
                roomButton(roomCount).Size = New Size(110, 73)

                'roomButton.Text = roomCount.ToString
                'roomButton.BackgroundImage = My.Resources.ClassButton
                'roomButton.BackgroundImageLayout = ImageLayout.Stretch
                Me.Controls.Add(roomButton(roomCount))
                roomCount += 1
            Next
        Next
        ButtonLayout("Classroom")
    End Sub

    Public Sub ButtonLayout(ByVal roomType As String)
        Dim dataTable As DataTable = database.getRoomsByType(roomType)

        For i As Integer = 0 To 19
            If dataTable.Rows.Count > i + viewNext * 20 Then
                roomButton(i).Name = dataTable.Rows(i + viewNext * 20).Item(database.Room_Key.ROOM_NO)
                roomButton(i).BackgroundImage = My.Resources.ResourceManager.GetObject(String.Format("{0}", dataTable.Rows(i + viewNext * 20).Item(database.Room_Key.TYPE)) & "Button")
                roomButton(i).BackgroundImageLayout = ImageLayout.Stretch
                roomButton(i).Visible = True
                If roomType = "Office" Then
                    Dim office As DataTable = database.getFacultyByOfficeNumber(dataTable.Rows(i + viewNext * 20).Item(database.Room_Key.ROOM_NO))
                    If Not office.Rows.Count = 0 Then
                        roomButton(i).Text = dataTable.Rows(i + viewNext * 20).Item(database.Room_Key.ROOM_NO) & vbCrLf & office.Rows(0).Item(0)
                    Else
                        roomButton(i).Text = dataTable.Rows(i + viewNext * 20).Item(database.Room_Key.ROOM_NO)
                    End If
                Else
                    roomButton(i).Text = dataTable.Rows(i + viewNext * 20).Item(database.Room_Key.ROOM_NO)
                    If roomButton(i).Text = "EB1033" Then
                        roomButton(i).Text = dataTable.Rows(i + viewNext * 20).Item(database.Room_Key.ROOM_NO) & vbCrLf & "Auditorium"
                    End If
                End If
            Else
                roomButton(i).Visible = False
                NextButton.Enabled = False
            End If
            AddHandler roomButton(i).Click, AddressOf buttonClicked
        Next

        If labButt.Enabled = False And viewNext = 1 Then
            NextButton.Enabled = False
        ElseIf officeButt.Enabled = False And viewNext = 1 Then
            PrevButton.Enabled = True
        End If
    End Sub

    Public Sub buttonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim view As New RoomView(origin, sender.Name)
        view.ShowDialog()
    End Sub

    Public Sub New(ByRef layout As FloorLayout, ByVal selectedKiosk As String)
        InitializeComponent()
        floorLayoutPtr = layout
        origin = selectedKiosk
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Visible = False
        Dim facultyStaff As New Faculty_Staff(floorLayoutPtr, origin)
        facultyStaff.ShowDialog()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Dispose()
    End Sub

    Private Sub FloorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles labButt.Click, classButt.Click, officeButt.Click
        For i As Integer = 0 To 19
            RemoveHandler roomButton(i).Click, AddressOf buttonClicked
        Next
        viewNext = 0
        labButt.Enabled = True
        classButt.Enabled = True
        officeButt.Enabled = True
        NextButton.Enabled = True
        PrevButton.Enabled = False
        classButt.BackColor = Color.Red
        classButt.ForeColor = Color.White
        labButt.BackColor = Color.Red
        labButt.ForeColor = Color.White
        officeButt.BackColor = Color.Red
        officeButt.ForeColor = Color.White
        sender.BackColor = Color.White
        sender.ForeColor = Color.Red
        sender.Enabled = False
        'If sender.Tag >= 2 Then
        '    NextButton.Enabled = True
        'Else
        '    NextButton.Enabled = False
        'End If
        ButtonLayout(sender.Tag)
    End Sub

    Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextButton.Click
        For i As Integer = 0 To 19
            RemoveHandler roomButton(i).Click, AddressOf buttonClicked
        Next
        viewNext += 1
        PrevButton.Enabled = True
        If labButt.Enabled = False Then
            ButtonLayout("Lab")
        End If
        If officeButt.Enabled = False Then
            ButtonLayout("Office")
        End If

    End Sub

    Private Sub PrevButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrevButton.Click
        For i As Integer = 0 To 19
            RemoveHandler roomButton(i).Click, AddressOf buttonClicked
        Next
        For Each butt In roomButton
            butt.Visible = True
        Next
        NextButton.Enabled = True
        PrevButton.Enabled = False
        viewNext -= 1
        If labButt.Enabled = False Then
            ButtonLayout("Lab")
        End If
        If officeButt.Enabled = False Then
            ButtonLayout("Office")
        End If
    End Sub

    'Private Sub FirstFloor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    SecondFloor.Enabled = True
    '    FirstFloor.Enabled = False
    '    ThirdFloor.Enabled = True
    '    LowerLevel.Enabled = True
    '    ViewAll.Enabled = True
    '    ButtonLayout(1)
    'End Sub

    'Private Sub ThirdFloor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    For i As Integer = 0 To 19
    '        RemoveHandler roomButton(i).Click, AddressOf buttonClicked
    '    Next
    '    SecondFloor.Enabled = True
    '    FirstFloor.Enabled = True
    '    ThirdFloor.Enabled = False
    '    LowerLevel.Enabled = True
    '    ViewAll.Enabled = True
    '    NextButton.Enabled = True
    '    ButtonLayout(3)
    'End Sub

    'Private Sub LowerLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    For i As Integer = 0 To 19
    '        RemoveHandler roomButton(i).Click, AddressOf buttonClicked
    '    Next
    '    SecondFloor.Enabled = True
    '    FirstFloor.Enabled = True
    '    ThirdFloor.Enabled = True
    '    LowerLevel.Enabled = False
    '    ViewAll.Enabled = True
    '    ButtonLayout(0)
    'End Sub

    Private Sub BackButton_Click(sender As System.Object, e As System.EventArgs) Handles BackButton.Click
        Me.Dispose()
    End Sub
End Class
'sFSFD