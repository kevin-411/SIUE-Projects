Imports System.Data.OleDb

Public Class Database
    Dim DATABASE_FILENAME As String = "\EB.accdb"
    Private Function LoadDatabase(ByVal query As String) As DataTable 'Loads a particular database based off of a string
        Dim dataTable As DataTable = New DataTable
        Using MDBConnection As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & DATABASE_FILENAME & "; Persist Security Info=False;")
            MDBConnection.Open()
            Dim MDBCommand As OleDbCommand = New OleDbCommand(query, MDBConnection)
            Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(MDBCommand)
            dataAdapter.Fill(dataTable)
            MDBConnection.Close()
        End Using
        Return dataTable
    End Function
    Public Function getFacultyTable() As DataTable
        Return LoadDatabase("SELECT * FROM Faculty")
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
        FLOOR = 10
        TIME = 11
    End Enum
    Public Function getRoomTable() As DataTable
        Return LoadDatabase("SELECT * FROM Room")
    End Function
    Public Enum Room_Key
        ROOM_NO
        TYPE = 2
        FLOOR = 3
    End Enum
    Public Function getClassesTaughtInRoom(ByVal roomNumber As String) As DataTable
        Return LoadDatabase("SELECT * FROM ClassDetails WHERE room='" & roomNumber & "'")
    End Function
End Class
