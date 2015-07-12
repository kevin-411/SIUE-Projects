Public Class RoomView

    Dim roomNumber As String
    Dim currentRow As DataRow
    Dim origin As String
    Dim direct As Directions
    Public Sub New(ByVal selectedKiosk As String, ByVal number As String)
        InitializeComponent()
        origin = selectedKiosk
        roomNumber = number
        RoomView_Load()
    End Sub
    Private Sub RoomView_Load()
        Dim database As Database = New Database
        Dim roomTable As DataTable = database.getRoomTable()

        For Each row As DataRow In roomTable.Rows()
            If roomNumber = row.Item(database.Room_Key.ROOM_NO) Then
                currentRow = row
                RoomNumberLabel.Text = row.Item(database.Room_Key.ROOM_NO)
                RoomTypeLabel.Text = row.Item(database.Room_Key.TYPE)

                Dim classInfo As String = ""
                classInfo = (String.Format("{0, -6}{1,-13}{2,-7}{3,-8}{4,-8}{5,-20}", "Days", "Time", "Dept.", "Course", "Section", "Instructor"))
                ClassesListBox.Items.Add(classInfo)
                For Each clazz As DataRow In database.getClassesTaughtInRoom(roomNumber).Rows
                    'If (Convert.ToDouble(Len(clazz.Item(database.ClassesTaughtBy_Key.DAYS)) = 2)) Then
                    '    classInfo = clazz.Item(database.ClassesTaughtBy_Key.DAYS) & "   "

                    'End If

                    'If (Convert.ToDouble(Len(clazz.Item(database.ClassesTaughtBy_Key.DAYS)) = 1)) Then
                    '    classInfo = clazz.Item(database.ClassesTaughtBy_Key.DAYS) & "    "
                    'End If

                    'If (Convert.ToDouble(Len(clazz.Item(database.ClassesTaughtBy_Key.DAYS)) = 3)) Then
                    '    classInfo = clazz.Item(database.ClassesTaughtBy_Key.DAYS) & "  "
                    'End If

                    'classInfo += clazz.Item(database.ClassesTaughtBy_Key.TIME) & "   "
                    'classInfo += clazz.Item(database.ClassesTaughtBy_Key.DEPARTMENT) & "   "
                    'classInfo += clazz.Item(database.ClassesTaughtBy_Key.COURSE_NO) & "   "
                    'classInfo += clazz.Item(database.ClassesTaughtBy_Key.SECTION) & vbCrLf
                    classInfo = (String.Format("{0, -6}{1,-13}{2,-7}{3,-8}{4,-8}{5, -19}", clazz.Item(database.ClassesTaughtBy_Key.DAYS), clazz.Item(database.ClassesTaughtBy_Key.TIME), _
                                              clazz.Item(database.ClassesTaughtBy_Key.DEPARTMENT), clazz.Item(database.ClassesTaughtBy_Key.COURSE_NO), clazz.Item(database.ClassesTaughtBy_Key.SECTION), clazz.Item(database.ClassesTaughtBy_Key.INSTRUCTOR)))
                    ClassesListBox.Items.Add(classInfo)
                Next
                Dim labAndDeptTable As DataTable = database.getLabAndDepartmentTitle(roomNumber)
                Try
                    DepartmentLabel.Text = labAndDeptTable.Rows(0).Item(database.Dept_Lab_Key.DEPT)
                    DepartmentOfficeLabel.Text = labAndDeptTable.Rows(0).Item(database.Dept_Lab_Key.DEPT_OFFICE_NO)
                Catch
                End Try


            End If
        Next

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        direct = New Directions(origin, roomNumber)
        direct.ShowDialog()
    End Sub
End Class