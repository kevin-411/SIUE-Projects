Public Class DatabaseUseExample
    'RUN ME BITCHES!!
    'IF YOU GUYS NEED THE DATA IN ANY OTHER WAY LET ME KNOW WHEN I GET BACK ON MONDAY AND I'LL DO MY BEST TO WRITE A NEW QUERY BEFORE THE INTERVIEWS
    Private Sub DatabaseUseExample_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim database As Database = New Database 'Our "Database Class
        Dim facultyTable As DataTable = database.getFacultyByDepartment("CS")
        Dim label As Label = New Label
        Dim pb As PictureBox = New PictureBox
        pb.Size = New Size(200, 200)
        pb.Location = New Point(0, 0)
        pb.SizeMode = PictureBoxSizeMode.StretchImage
        label.Size = New Size(550, 300)
        label.Location = New Point(200, 0)
        label.Font = New Font("Modern No. 20", 16)
        Dim name As String
        For Each row As DataRow In facultyTable.Rows()
            name = row.Item(database.Faculty_Key.NAME)
            If name = "William White" Then
                pb.Image = Image.FromFile(Application.StartupPath & "\FacultyImages\" & row.Item(database.Faculty_Key.PICTURE))
                label.Text = row.Item(database.Faculty_Key.NAME) & vbCrLf
                label.Text += row.Item(database.Faculty_Key.OFFICE) & vbCrLf
                label.Text += row.Item(database.Faculty_Key.OFFICE_HOURS) & vbCrLf
                label.Text += row.Item(database.Faculty_Key.PHONE_NUMBER) & vbCrLf
                label.Text += row.Item(database.Faculty_Key.EMAIL) & vbCrLf
                label.Text += row.Item(database.Faculty_Key.POSITION) & vbCrLf
                label.Text += "Below are all the classes offered by " & name & "." & vbCrLf
                For Each clazz As DataRow In database.getClassesTaughtByName(name).Rows
                    label.Text += clazz.Item(database.ClassesTaughtBy_Key.DEPARTMENT) & "   "
                    label.Text += clazz.Item(database.ClassesTaughtBy_Key.COURSE_NO) & "   "
                    label.Text += clazz.Item(database.ClassesTaughtBy_Key.SECTION) & "   "
                    label.Text += clazz.Item(database.ClassesTaughtBy_Key.DAYS) & "   "
                    label.Text += clazz.Item(database.ClassesTaughtBy_Key.TIME) & "   "
                    label.Text += clazz.Item(database.ClassesTaughtBy_Key.ROOM) & vbCrLf
                Next

            End If
        Next
        Me.Controls.Add(pb)
        Me.Controls.Add(label)

        Dim roomTable As DataTable = database.getRoomTable()
        Dim label2 As Label = New Label
        label2.Size = New Size(500, 500)
        label2.Location = New Point(200, 300)
        label2.Font = New Font("Modern No. 20", 16)
        For Each row As DataRow In roomTable.Rows()
            name = row.Item(database.Room_Key.ROOM_NO)
            If name = "EB1011" Then
                label2.Text = "Below are all the classes taken in room " & name & "." & vbCrLf
                label2.Text += name & "   "
                label2.Text += row.Item(database.Room_Key.TYPE) & "   "
                label2.Text += row.Item(database.Room_Key.FLOOR) & vbCrLf
                For Each clazz As DataRow In database.getClassesTaughtInRoom(name).Rows
                    label2.Text += clazz.Item(database.ClassesTaughtBy_Key.DEPARTMENT) & "   "
                    label2.Text += clazz.Item(database.ClassesTaughtBy_Key.COURSE_NO) & "   "
                    label2.Text += clazz.Item(database.ClassesTaughtBy_Key.SECTION) & "   "
                    label2.Text += clazz.Item(database.ClassesTaughtBy_Key.DAYS) & "   "
                    label2.Text += clazz.Item(database.ClassesTaughtBy_Key.TIME) & "   "
                    label2.Text += clazz.Item(database.ClassesTaughtBy_Key.ROOM) & vbCrLf
                Next

            End If
        Next
        Me.Controls.Add(label2)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim room As New RoomView("111", "EB1010")
        room.ShowDialog()
    End Sub
End Class