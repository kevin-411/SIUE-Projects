Public Class Directions
    Inherits Form
    Dim navi As Navigation
    Dim origin As String
    Dim dest As String
    Dim currentIndex As Integer = 0
    Dim changeIndex As Integer = 0
    Dim floorPics() As PictureBox
    Dim lb As ListBox = New ListBox
    Dim back, backBack As Button
    Dim bigPic As PictureBox = New PictureBox
    Dim lilPic As PictureBox = New PictureBox
    Dim listDirections() As Direction
    Dim isflipped As Boolean = False
    Public Sub New(ByVal origin As String, ByVal dest As String)
        navi = New Navigation(origin, dest)
        bigPic.Image = navi.getPics()(0).Image.Clone
        lilPic.Image = navi.getPics()(1).Image.Clone
        listDirections = navi.getListDirections
        Me.dest = dest
        initializeVariables()
    End Sub
    Private Sub initializeVariables()
        resetHeight(625, 325, bigPic, lilPic)
        initializeButtons()
        intializeDirectionsListBox()
        bigPic.SizeMode = PictureBoxSizeMode.StretchImage
        lilPic.SizeMode = PictureBoxSizeMode.StretchImage
        lilPic.Location = New Point(0, lb.Height + 70)
        bigPic.Location = New Point(lb.Width, lb.Location.Y)
        Me.Controls.Add(bigPic)
        Me.Controls.Add(lilPic)
        Me.Size = New Size(lb.Width + bigPic.Width + 10, 650 + lb.Location.Y + 10)
        Me.Text = "Directions"
        Me.BackgroundImage = My.Resources.SIUE_Engineering_background
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Me.MaximizeBox = False
        Me.TopMost = True
    End Sub
    Private Sub initializeButtons()
        back = New Button()
        'backBack = New Button()
        back.Size = New Point(167, 58)
        'backBack.Size = New Point(167, 58)
        back.BackColor = Color.Red
        'backBack.BackColor = Color.Red
        back.Font = New Font("Times New Roman", 16)
        'backBack.Font = New Font("Times New Roman", 16)
        back.ForeColor = Color.White
        'backBack.ForeColor = Color.White
        back.Location = New Point(975, 350)
        'backBack.Location = New Point(1000, 225)
        back.Text = "Back"
        'backBack.Text = "View Floor Plan"
        Me.Controls.Add(back)
        'Me.Controls.Add(backBack)
        AddHandler back.Click, AddressOf Me.Close
        'AddHandler backBack.Click, AddressOf Me.Parent.Dispose
    End Sub
    Private Sub intializeDirectionsListBox()
        Dim count As Integer = 0
        lb.Size = New Size(lilPic.Width, 300)
        lb.Location = New Point(0, 95)
        lb.Font = New Font("Times New Roman", 16)
        For Each d In listDirections
            lb.Items.Add(d.generateDirection)
            If d.getNodeType = Direction.Type_Key.STAIRWAY OrElse d.getNodeType = Direction.Type_Key.ELEVATOR Then
                changeIndex = count
            End If
            count += 1
        Next
        If navi.isSameFloor Then
            lb.Height = bigPic.Height
        End If
        Me.Controls.Add(lb)
        AddHandler lb.SelectedIndexChanged, AddressOf switchPics
        lb.SetSelected(0, True)
    End Sub
    Private Sub switchPics()
        If currentIndex >= changeIndex AndAlso lb.SelectedIndex < changeIndex OrElse lb.SelectedIndex >= changeIndex AndAlso currentIndex < changeIndex Then
            Dim temp As Image = bigPic.Image
            bigPic.Image = lilPic.Image
            lilPic.Image = temp
            isflipped = Not isflipped
        End If
        currentIndex = lb.SelectedIndex
        If isflipped Then
            bigPic.Image = navi.getPics()(1).Image.Clone
            lilPic.Image = navi.getPics()(0).Image.Clone
        Else
            bigPic.Image = navi.getPics()(0).Image.Clone
            lilPic.Image = navi.getPics()(1).Image.Clone
        End If
        listDirections(currentIndex).drawHighlightOverlay(bigPic.Image)
    End Sub
    Sub resetHeight(ByVal h As Integer, ByVal h2 As Integer, ByRef pb As PictureBox, ByRef pb2 As PictureBox)
        Dim aspectRatio As Double = CDbl(pb.Image.Height / pb.Image.Width)
        pb.Height = h
        pb.Width = h / aspectRatio
        pb2.Height = h2
        pb2.Width = h2 / aspectRatio
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'Directions
        '
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Name = "Directions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)

    End Sub
End Class
