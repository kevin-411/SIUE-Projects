Imports System.Data.OleDb

Public Class Database
    Dim DATABASE_FILENAME As String = "\EB.accdb"
    Private Function LoadDatabase(ByVal query As String) As DataTable 'Loads a particular database based off of a string
        Dim dataTable As DataTable = New DataTable
        Using MDBConnection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & DATABASE_FILENAME & "; Persist Security Info=False;")
            MDBConnection.Open()
            Dim MDBCommand As OleDbCommand = New OleDbCommand(query, MDBConnection)
            Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(MDBCommand)
            Try
                dataAdapter.Fill(dataTable)
            Catch
                Return New DataTable()
            End Try

            MDBConnection.Close()
        End Using
        Return dataTable
    End Function
    Public Function getFacultyTable() As DataTable
        Return LoadDatabase("SELECT * FROM Faculty")
    End Function
    Public Function getFacultyByDepartment(ByVal dept As String)
        Return LoadDatabase("SELECT * FROM Faculty Where Faculty.dept='" & dept & "'")
    End Function
    Public Function getFacultyByOfficeNumber(ByVal officeNumber As String)
        Return LoadDatabase("SELECT F.staffName FROM Faculty as F WHERE F.Office='" & officeNumber & "'")
    End Function
    Public Enum Faculty_Key
        NAME
        POSITION
        DEPARTMENT
        PICTURE
        IS_PROFESSOR
        OFFICE_HOURS
        PHONE_NUMBER
        WEBSITE
        EMAIL
        OFFICE
        CHAIR ' returns a boolean that determines if the faculty is the chair for his department
    End Enum
    Public Function getClassesTaughtByName(ByVal name As String) As DataTable
        Return LoadDatabase("SELECT * FROM ClassDetails WHERE instructor='" & name & "'")
    End Function
    Public Enum ClassesTaughtBy_Key
        DEPARTMENT
        COURSE_NO
        SECTION
        DAYS
        ROOM
        INSTRUCTOR
        FLOOR = 10
        TIME = 11
    End Enum
    Public Function getRoomTable() As DataTable
        Return LoadDatabase("SELECT * FROM Room")
    End Function
    Public Function getRoomsByType(ByVal type As String)
        Return LoadDatabase("SELECT * FROM Room Where Room.type='" & type & "'")
    End Function
    Public Enum Room_Key
        ROOM_NO
        TYPE = 2
        FLOOR = 3
    End Enum
    Public Function getClassesTaughtInRoom(ByVal roomNumber As String) As DataTable
        Return LoadDatabase("SELECT * FROM ClassDetails WHERE room='" & roomNumber & "'")
    End Function
    Public Function getLabAndDepartmentTitle(ByVal labNumber As String) As DataTable
        Return LoadDatabase("SELECT * " +
                            "FROM LabInfo As L WHERE L.room='" & labNumber & "'")
    End Function
    Public Enum Dept_Lab_Key
        DEPT
        LAB_ROOM_NO
        DEPT_OFFICE_NO
    End Enum
End Class
