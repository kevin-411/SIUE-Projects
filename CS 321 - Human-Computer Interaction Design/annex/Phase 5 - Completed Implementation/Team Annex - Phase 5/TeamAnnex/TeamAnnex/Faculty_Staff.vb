Public Class Faculty_Staff
    Dim floorLayoutPtr As FloorLayout
    Dim origin As String
    Dim instCount As Integer = 0
    Dim database As Database = New Database
    Dim instButton() As PictureBox = New PictureBox(14) {}
    Dim labels() As Label = New Label(14) {}
    Dim tempButt As New PictureBox
    Dim tempLab As New Label

    Public Sub New(ByRef layout As FloorLayout, ByVal selectedKiosk As String)
        InitializeComponent()
        floorLayoutPtr = layout
        origin = selectedKiosk
    End Sub


    Private Sub Faculty_Staff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ypos As Integer
        Dim xpos As Integer
        Dim lypos As Integer
        Dim lxpos As Integer

        'Dim array As DataRowCollection = (database.getRoomsByFloor(floorNum)).Rows()
        'Dim dataTable As DataTable = database.getRoomsByFloor(1)

        For y As Integer = 0 To 2
            ypos = y * 180 + 104
            
            For x As Integer = 0 To 4
                xpos = x * 176 + 17
                instButton(instCount) = New PictureBox()
                instButton(instCount).Location = New Point(xpos, ypos)
                instButton(instCount).Size = New Size(127, 108)

                'roomButton.Text = roomCount.ToString
                'roomButton.BackgroundImage = My.Resources.ClassButton
                'roomButton.BackgroundImageLayout = ImageLayout.Stretch
                Me.Controls.Add(instButton(instCount))
                instCount += 1
            Next
        Next

        instCount = 0
        For y As Integer = 0 To 2
            lypos = y * 180 + 232
            For x As Integer = 0 To 4
                lxpos = x * 176 + 20
                labels(instCount) = New Label()
                labels(instCount).Location = New Point(lxpos, lypos)
                labels(instCount).Size = New Size(127, 21)
                labels(instCount).TextAlign = ContentAlignment.MiddleCenter
                Me.Controls.Add(labels(instCount))
                instCount += 1
            Next
        Next
        ButtonLayout("CS")
    End Sub

    Public Sub ButtonLayout(ByVal dept As String)
        Dim dataTable As DataTable = database.getFacultyByDepartment(dept)

        'For Each row As DataRow In dataTable.Rows()
        '    If Convert.ToBoolean(row.Item(database.Faculty_Key.CHAIR)) Then
        '        instButton(0).Name = row.Item(database.Faculty_Key.NAME)
        '        instButton(0).Image = Image.FromFile(Application.StartupPath & "\FacultyImages\" & row.Item(database.Faculty_Key.PICTURE))
        '        instButton(0).SizeMode = PictureBoxSizeMode.Zoom
        '        instButton(0).Visible = True
        '        labels(0).Visible = True
        '        'End If
        '        labels(0).Text = row.Item(database.Faculty_Key.NAME)
        '        labels(0).Font = New System.Drawing.Font("Times New Roman", 12)
        '        labels(0).ForeColor = Color.Red
        '        labels(0).AutoSize = True
        '        AddHandler instButton(0).Click, AddressOf buttonClicked
        '    End If
        'Next
        For i As Integer = 0 To 14
            If dataTable.Rows.Count > i Then
                If dataTable.Rows(i).Item(database.Faculty_Key.CHAIR) Then
                    RemoveHandler instButton(0).Click, AddressOf buttonClicked
                    tempButt.Name = dataTable.Rows(0).Item(database.Faculty_Key.NAME)
                    tempButt.Image = Image.FromFile(Application.StartupPath & "\FacultyImages\" & dataTable.Rows(0).Item(database.Faculty_Key.PICTURE))
                    tempLab.Text = dataTable.Rows(0).Item(database.Faculty_Key.NAME)
                    instButton(0).Name = dataTable.Rows(i).Item(database.Faculty_Key.NAME)
                    instButton(0).Image = Image.FromFile(Application.StartupPath & "\FacultyImages\" & dataTable.Rows(i).Item(database.Faculty_Key.PICTURE))
                    instButton(0).SizeMode = PictureBoxSizeMode.Zoom
                    instButton(0).Visible = True
                    labels(i).Text = tempLab.Text
                    labels(i).Font = New System.Drawing.Font("Times New Roman", 12)
                    labels(i).ForeColor = Color.Red
                    'labels(i).AutoSize = True
                    labels(i).Visible = True
                    instButton(i).Name = tempButt.Name
                    instButton(i).Image = tempButt.Image
                    instButton(i).Visible = True
                    labels(i).Text = tempLab.Text
                    labels(0).Text = dataTable.Rows(i).Item(database.Faculty_Key.NAME) & vbCrLf & dataTable.Rows(i).Item(database.Faculty_Key.DEPARTMENT) & " Chair"
                    labels(0).Font = New System.Drawing.Font("Times New Roman", 12)
                    labels(0).ForeColor = Color.Red
                    labels(0).BackColor = Color.Yellow
                    labels(0).Size = New Size(135, 40)
                    'labels(0).AutoSize = True
                    labels(0).Visible = True
                    AddHandler instButton(0).Click, AddressOf buttonClicked
                    If Not i = 0 Then
                        AddHandler instButton(i).Click, AddressOf buttonClicked
                    End If

                Else
                    instButton(i).Name = dataTable.Rows(i).Item(database.Faculty_Key.NAME)
                    'If Not IsDBNull(dataTable.Rows(i).Item(database.Faculty_Key.PICTURE)) Then
                    instButton(i).Image = Image.FromFile(Application.StartupPath & "\FacultyImages\" & dataTable.Rows(i).Item(database.Faculty_Key.PICTURE))
                    instButton(i).SizeMode = PictureBoxSizeMode.Zoom
                    instButton(i).Visible = True
                    labels(i).Visible = True
                    'End If
                    labels(i).Text = dataTable.Rows(i).Item(database.Faculty_Key.NAME)
                    labels(i).Font = New System.Drawing.Font("Times New Roman", 12)
                    labels(i).ForeColor = Color.Red
                    'labels(i).AutoSize = True

                    AddHandler instButton(i).Click, AddressOf buttonClicked
                End If
            Else
                labels(i).Visible = False
                instButton(i).Visible = False


            End If
        Next
    End Sub

    Public Sub buttonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim view As New SingleFacultyView(origin, sender.Name)
        view.ShowDialog(Me)
    End Sub

    Private Sub FloorPlanButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FloorPlanButton.Click
        Me.Dispose()
    End Sub

    Private Sub BackButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackButton.Click
        Me.Dispose()
    End Sub

    Private Sub FloorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csButt.Click, meButt.Click, ceButt.Click, eceButt.Click, cnstButt.Click, imeButt.Click
        For i As Integer = 0 To 14
            RemoveHandler instButton(i).Click, AddressOf buttonClicked
        Next
        csButt.Enabled = True
        meButt.Enabled = True
        ceButt.Enabled = True
        eceButt.Enabled = True
        imeButt.Enabled = True
        cnstButt.Enabled = True
        csButt.BackColor = Color.Red
        csButt.ForeColor = Color.White
        meButt.BackColor = Color.Red
        meButt.ForeColor = Color.White
        ceButt.BackColor = Color.Red
        ceButt.ForeColor = Color.White
        eceButt.BackColor = Color.Red
        eceButt.ForeColor = Color.White
        imeButt.BackColor = Color.Red
        imeButt.ForeColor = Color.White
        cnstButt.BackColor = Color.Red
        cnstButt.ForeColor = Color.White
        sender.Enabled = False
        sender.BackColor = Color.White
        sender.ForeColor = Color.Red
        ButtonLayout(sender.Tag)
    End Sub

End Class