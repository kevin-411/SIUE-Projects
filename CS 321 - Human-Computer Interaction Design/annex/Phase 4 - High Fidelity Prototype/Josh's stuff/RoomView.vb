Public Class RoomView

    Dim roomNumber As String
    Dim currentRow As DataRow

    Public Sub New(ByVal number As String)
        InitializeComponent()
        roomNumber = number
        'Me.RoomView_Load()
    End Sub

    Private Sub RoomView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim database As Database = New Database


        Dim roomTable As DataTable = database.getRoomTable()

        For Each row As DataRow In roomTable.Rows()
            If roomNumber = row.Item(database.Room_Key.ROOM_NO) Then
                currentRow = row
                RoomNumberLabel.Text = row.Item(database.Room_Key.ROOM_NO)
                RoomTypeLabel.Text = row.Item(database.Room_Key.TYPE)

                Dim classInfo As String = ""

                For Each clazz As DataRow In database.getClassesTaughtInRoom(roomNumber).Rows
                    classInfo = clazz.Item(database.ClassesTaughtBy_Key.DAYS) & "   "
                    classInfo += clazz.Item(database.ClassesTaughtBy_Key.TIME) & "   "
                    classInfo += clazz.Item(database.ClassesTaughtBy_Key.DEPARTMENT) & "   "
                    classInfo += clazz.Item(database.ClassesTaughtBy_Key.COURSE_NO) & "   "
                    classInfo += clazz.Item(database.ClassesTaughtBy_Key.SECTION) & vbCrLf

                    ClassesListBox.Items.Add(classInfo)
                Next
            End If
        Next

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Dispose()
    End Sub
End Class