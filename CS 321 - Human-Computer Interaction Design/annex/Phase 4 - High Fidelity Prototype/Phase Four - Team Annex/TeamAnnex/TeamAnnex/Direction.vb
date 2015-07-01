Public Class Direction
    Dim floor, direction, distance, nodeType, x1, y1, x2, y2 As Integer
    Dim iSize As Size
    Dim strings() As String = New String() {"Continue straight for {0:D} feet.", "Turn Left.", "Turn Right.", "Use the {0} to get to floor {1:D}."}
    Dim selectedOverlay As Image 'copied picture box with the
    Dim semiTransPen As New Pen(Color.FromArgb(180, 255, 255, 0), 20) 'see through yellow
    Public Sub New(ByVal direction As Integer, ByVal nodeType As Integer, ByVal iSize As Size, ByVal floor As Integer _
                   , ByVal distance As Integer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
        Me.direction = direction
        Me.distance = distance
        Me.nodeType = nodeType
        Me.floor = floor
        Me.x1 = x1
        Me.y1 = y1
        Me.x2 = x2
        Me.y2 = y2
        Me.iSize = iSize
    End Sub
    Public Enum Direction_Key
        STRAIGHT
        LEFT
        RIGHT
        CHANGEFLOOR
        INVALID
    End Enum
    Public Enum Type_Key
        CLASSROOM
        OFFICE
        WALKWAY
        STAIRWAY
        ELEVATOR
        RESTROOM
        VENDINGMACHINE
    End Enum
    Public Sub addDistance(ByVal d As Integer)
        distance += d
    End Sub
    Public Sub updateNode2Location(ByVal x2 As Integer, ByVal y2 As Integer)
        Me.x2 = x2
        Me.y2 = y2
    End Sub
    Public Sub drawHighlightOverlay(ByRef img As Image)
        Using G = Graphics.FromImage(img)
            G.CompositingQuality = Drawing2D.CompositingQuality.GammaCorrected
            G.DrawLine(semiTransPen, x1, y1, x2, y2)
        End Using
    End Sub
    'Public Sub drawDestHighlight(ByRef img As Image, ByVal locations() As Integer)
    '    Using G = Graphics.FromImage(img)
    '        G.CompositingQuality = Drawing2D.CompositingQuality.GammaCorrected
    '        G.DrawRectangle(semiTransPen, locations(0), locations(1), locations(2), locations(3))
    '    End Using
    'End Sub
    Public Function generateDirection() As String
        Select Case Me.direction
            Case Direction_Key.STRAIGHT
                If distance < 140 Then
                    Return "Walk straight."
                End If
                Return String.Format(strings(0), distance)
            Case Direction_Key.LEFT
                Return strings(1)
            Case Direction_Key.RIGHT
                Return strings(2)
            Case Direction_Key.CHANGEFLOOR
                If Me.nodeType = Type_Key.STAIRWAY Then
                    Return String.Format(strings(3), "stairs", floor)
                Else
                    Return String.Format(strings(3), "elevator", floor)
                End If

        End Select
        Return String.Format(strings(0), distance / 4) 'Go straight for (distance) feet.

    End Function
    Public Function getDirection() As Integer
        Return direction
    End Function
    Public Function getFloor() As Integer
        Return floor
    End Function
    Public Function getNodeType() As Integer
        Return nodeType
    End Function
End Class
