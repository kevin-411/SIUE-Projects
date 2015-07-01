Public Class SingleFacultyView
    Dim instructor As String
    Dim currentRow As DataRow
    Dim facultyAndStaff As Faculty_Staff
    Dim origin As String
    Dim direct As Directions
    Dim roomNumber As String

    Public Sub New(ByVal selectedKiosk As String, ByVal name As String)
        InitializeComponent()
        'facultyAndStaff = facultyStaff
        instructor = name
        origin = selectedKiosk
        SingleFacultyView_Load()
    End Sub

    Private Sub SingleFacultyView_Load()
        Dim database As Database = New Database

        Dim facultyTable As DataTable = database.getFacultyTable

        For Each row As DataRow In facultyTable.Rows()
            If instructor = row.Item(database.Faculty_Key.NAME) Then
                currentRow = row
                InstName.Text = row.Item(database.Faculty_Key.NAME)
                If Not IsDBNull(row.Item(database.Faculty_Key.OFFICE)) Then
                    officeNo.Text = row.Item(database.Faculty_Key.OFFICE)
                Else
                    officeNo.Text = "N/A"
                End If

                PictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath & "\FacultyImages\" & row.Item(database.Faculty_Key.PICTURE))
                PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
                If Not IsDBNull(row.Item(database.Faculty_Key.OFFICE_HOURS)) Then
                    OfficeHours.Text = row.Item(database.Faculty_Key.OFFICE_HOURS)
                Else
                    OfficeHours.Text = "N/A"
                End If
                If Not IsDBNull(row.Item(database.Faculty_Key.EMAIL)) Then
                    email.Text = row.Item(database.Faculty_Key.EMAIL)
                Else
                    email.Text = "N/A"
                End If

                If Not IsDBNull(row.Item(database.Faculty_Key.PHONE_NUMBER)) Then
                    phoneNo.Text = row.Item(database.Faculty_Key.PHONE_NUMBER)
                Else
                    phoneNo.Text = "N/A"
                End If
                Dim classInfo As String = ""
                classInfo = (String.Format("{0, -8}{1,-15}{2,-9}{3,-10}{4,-5}", "Days", "Time", "Dept.", "Course", "Section"))
                ListBox1.Items.Add(classInfo)
                'If ListBox1.Items.Count = 1 Then
                '    ListBox1.Font = New Font("Courier New", 14.5, FontStyle.Underline)
                'End If
                For Each clazz As DataRow In database.getClassesTaughtByName(instructor).Rows
                    'If (Convert.ToDouble(Len(clazz.Item(database.ClassesTaughtBy_Key.DAYS)) = 3)) Then
                    '    classInfo = clazz.Item(database.ClassesTaughtBy_Key.DAYS) & "  "

                    'End If
                    'If (Convert.ToDouble(Len(clazz.Item(database.ClassesTaughtBy_Key.DAYS)) = 2)) Then
                    '    classInfo = clazz.Item(database.ClassesTaughtBy_Key.DAYS) & "   "

                    'End If

                    'If (Convert.ToDouble(Len(clazz.Item(database.ClassesTaughtBy_Key.DAYS)) = 1)) Then
                    '    classInfo = clazz.Item(database.ClassesTaughtBy_Key.DAYS) & "    "
                    'End If
                    'classInfo = clazz.Item(database.ClassesTaughtBy_Key.DAYS)
                    'classInfo += clazz.Item(database.ClassesTaughtBy_Key.TIME) & "   "
                    'classInfo += clazz.Item(database.ClassesTaughtBy_Key.DEPARTMENT) & "   "
                    'classInfo += clazz.Item(database.ClassesTaughtBy_Key.COURSE_NO) & "   "
                    'classInfo += clazz.Item(database.ClassesTaughtBy_Key.SECTION) & vbCrLf
                    classInfo = (String.Format("{0, -8}{1,-15}{2,-9}{3,-10}{4,-5}", clazz.Item(database.ClassesTaughtBy_Key.DAYS), clazz.Item(database.ClassesTaughtBy_Key.TIME), _
                                               clazz.Item(database.ClassesTaughtBy_Key.DEPARTMENT), clazz.Item(database.ClassesTaughtBy_Key.COURSE_NO), clazz.Item(database.ClassesTaughtBy_Key.SECTION)))
                    ListBox1.Items.Add(classInfo)
                Next
            End If
        Next

    End Sub

    Private Sub FloorLayoutButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
    End Sub

    Private Sub BackButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackButton.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        direct = New Directions(origin, officeNo.Text)
        direct.ShowDialog(Me)
    End Sub
End Class