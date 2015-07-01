'File: PeriodicTableForm.vb
'Date: 01/29/2013
'Name: Brian Olsen, Dustin Thomas, Denver Coladilla
'Course:  CS 321-001 - Human Computer Interaction
'Desc:This program displays the periodic table in a traditional layout. It allows students to click on a given element 
'to look closer at the properties of the element. The program also has a "quiz mode" that can ask the user certain
'information about elements and get graded.
'Instructions: Place both the Chemistry.mdb file and the Images folder and place them in the directory...
' "Project 321.1/bin/Debug/"
Imports System.Data.OleDb
Public Class PeriodicTableForm
#Region "TABLE CONSTANT GLOBALS"
    Dim PTableHeight = 10
    Dim PTableLength = 18
    Dim PeriodicTable(PTableHeight - 1, PTableLength - 1) As Button
    Dim TableCellHeight = 60
    Dim TableCellLength = 50
    Dim VerticalSpace = TableCellHeight / 2 + 20
    Dim HorizontalSpace = TableCellLength / 2
#End Region
#Region "DATABASE CONNECTION GLOBALS"
    Dim MDBConnection As OleDbConnection
    Dim dataSet As DataSet = New DataSet
    'made dataTable public
    Public dataTable As DataTable = New DataTable
    Dim dataAdapter As OleDbDataAdapter
    Dim toolTip As ToolTip = New ToolTip
#End Region
#Region "POPUP GLOBALS"
    Dim WithEvents popup As Form = New Form()
    Dim WithEvents modalPopup As Form = New Form()
    Dim nameGroupBox As GroupBox = New GroupBox()

    Dim picture As PictureBox = New PictureBox()
    Dim title As Label = New Label()
    Dim abbreviation As Label = New Label()
    Dim atomicNumber As Label = New Label()
    Dim atomicWeight As Label = New Label()
    Dim groupName As Label = New Label()
    Dim meltingPoint As Label = New Label()
    Dim boilingPoint As Label = New Label()
    Dim discoverer As Label = New Label()
    Dim discoveryLocation As Label = New Label()
    Dim discoveryYear As Label = New Label()
    Dim nameOrigin As Label = New Label()
    Dim instructions As Label = New Label()
    Dim picture1 As PictureBox = New PictureBox()
    Dim title1 As Label = New Label()
    Dim abbreviation1 As Label = New Label()
    Dim atomicNumber1 As Label = New Label()
    Dim atomicWeight1 As Label = New Label()
    Dim groupName1 As Label = New Label()
    Dim meltingPoint1 As Label = New Label()
    Dim boilingPoint1 As Label = New Label()
    Dim closeElement As Button = New Button()
    Dim closeElement1 As Button = New Button()
    Dim WithEvents settings As Button = New Button
#End Region
    Private Enum Item_Key
        NAME
        SYMBOL
        ATOMIC_NUMBER
        ATOMIC_WEIGHT
        GROUP_NAME
        SCHEMATIC_FILE
        MELTING_POINT
        BOILING_POINT
        DISCOVERER
        DISCOVERY_LOCATION
        DISCOVERY_YEAR
        NAME_ORIGIN
    End Enum
    Private Sub PeriodicTableForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadDatabase()
        Dim TableMap(,) As Integer = _
            New Integer(9, 17) {{7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9}, _
                                {2, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 7, 7, 7, 8, 9}, _
                                {2, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 5, 7, 7, 8, 9}, _
                                {2, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 6, 5, 5, 7, 8, 9}, _
                                {2, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 6, 6, 5, 5, 8, 9}, _
                                {2, 3, 10, 4, 4, 4, 4, 4, 4, 4, 4, 4, 6, 6, 6, 5, 8, 9}, _
                                {2, 3, 11, 4, 4, 4, 4, 4, 4, 4, 4, 4, 6, 6, 6, 6, 8, 9}, _
                                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, _
                                {0, 0, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 0}, _
                                {0, 0, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 0}}
        Dim ElementCount = 0
        Dim title As Label = New Label()
        Dim help As Label = New Label()
        Dim groupNames As GroupBox = New GroupBox()

        dataSet.Tables.Add(dataTable)
        dataAdapter = New OleDbDataAdapter("SELECT * FROM ElementTable", MDBConnection)
        dataAdapter.Fill(dataTable)

        For i = 0 To PTableHeight - 1
            For j = 0 To PTableLength - 1
                TablePlacementLogic(ElementCount + 1, i, j)
                If TableMap(i, j) > 0 Then
                    PeriodicTable(i, j) = New Button()
                    PeriodicTable(i, j).BackColor = applyColor(TableMap(i, j))
                    PeriodicTable(i, j).AutoSize = False
                    PeriodicTable(i, j).Height = TableCellHeight
                    PeriodicTable(i, j).Width = TableCellLength
                    PeriodicTable(i, j).Top = ((TableCellHeight * i) + VerticalSpace)
                    PeriodicTable(i, j).Left = ((TableCellLength * j) + HorizontalSpace)
                    PeriodicTable(i, j).Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular)
                    PeriodicTable(i, j).TextAlign = ContentAlignment.MiddleCenter
                    PeriodicTable(i, j).Text = ElementCount + 1 & vbCrLf & dataTable.Rows(ElementCount).Item(Item_Key.SYMBOL)
                    PeriodicTable(i, j).Tag = ElementCount
                    ElementCount += 1
                    Me.Controls.Add(PeriodicTable(i, j))
                    AddHandler PeriodicTable(i, j).Click, AddressOf Table_Click
                    AddHandler PeriodicTable(i, j).MouseHover, AddressOf Table_Hover
                    If i > 7 Then
                        PeriodicTable(i, j).Top -= 40
                    End If
                End If
            Next
        Next
        Me.Height = (TableCellHeight * (PTableHeight + 0.3)) + (VerticalSpace * 2)
        Me.Width = (TableCellLength * (PTableLength + 0.3)) + (HorizontalSpace * 2)
        Me.MaximizeBox = False
        popup.Tag = 0
        AddHandler closeElement.Click, AddressOf Close_Element
        AddHandler closeElement1.Click, AddressOf Close_Element

        title.Text = "The Periodic Table"
        title.AutoSize = True
        title.Font = New Font("Microsoft Sans Serif", 36, FontStyle.Bold)
        title.Top = 10
        Me.Controls.Add(title)
        title.Left = (Me.Width - title.Width) / 2

        help.Text = "Click on any element box to find out more information about the element."
        help.AutoSize = True
        help.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Bold)
        help.Top = title.Top + title.Height
        Me.Controls.Add(help)
        help.Left = (Me.Width - help.Width) / 2

        groupNames.Text = "Element Groups Color Legend"
        groupNames.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        groupNames.Height = 125
        groupNames.Width = 485
        groupNames.Top = Me.Controls(3).Top - 10
        groupNames.Left = Me.Controls(3).Left + Me.Controls(3).Width + 10
        SetGroupNames(groupNames)
        Me.Controls.Add(groupNames)

        settings.Height = 50
        settings.Width = 90
        settings.Text = "Quiz Mode"
        settings.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
        settings.Top = ((TableCellLength * (PTableHeight + 0.3)) + (VerticalSpace * 2))
        settings.Left = ((TableCellHeight * (PTableHeight + 0.3)) + (HorizontalSpace * 2) + 175)
        Me.Controls.Add(settings)
        MDBConnection.Close()
    End Sub
    Private Sub LoadDatabase()
        MDBConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & Application.StartupPath & "\Chemistry.mdb;")
        MDBConnection.Open()
    End Sub
    Private Sub TablePlacementLogic(ByVal elementNumber As Integer, ByRef i As Integer, ByRef j As Integer)
        If elementNumber = 57 Then
            i = 8
            j = 2
        ElseIf elementNumber = 72 Then
            i = 5
            j = 3
        ElseIf elementNumber = 89 Then
            i = 9
            j = 2
        ElseIf elementNumber = 104 Then
            i = 6
            j = 3
        ElseIf elementNumber = 119 Then
            i = 9
            j = 17
        End If
    End Sub
    Private Function applyColor(ByVal colorSelect As Integer)
        If colorSelect = 1 Then
            Return Color.Azure
        ElseIf colorSelect = 2 Then
            Return Color.LightPink
        ElseIf colorSelect = 3 Then
            Return Color.Bisque
        ElseIf colorSelect = 4 Then
            Return Color.MistyRose
        ElseIf colorSelect = 5 Then
            Return Color.PaleGoldenrod
        ElseIf colorSelect = 6 Then
            Return Color.LightGray
        ElseIf colorSelect = 7 Then
            Return Color.LightGreen
        ElseIf colorSelect = 8 Then
            Return Color.LightGoldenrodYellow
        ElseIf colorSelect = 9 Then
            Return Color.LightCyan
        ElseIf colorSelect = 10 Then
            Return Color.Linen
        ElseIf colorSelect = 11 Then
            Return Color.Pink
        End If

        Return Nothing
    End Function
    Private Sub SetGroupNames(ByRef groupNames As GroupBox)
        Dim panel As Panel = New Panel()
        Dim label As Label
        Dim textLabel As Label = New Label()
        Dim top As Integer = 5
        Dim left As Integer = groupName.Left + 10

        Dim groupNameMap() As Integer = {0, 2, 3, 20, 4, 12, -1, 8, 1, 56, 88}

        For i = 0 To 10
            If i = 5 Then
                top = 5
                left = groupNames.Width / 2 + 10
            ElseIf i = 6 Then
                i += 1
            End If
            label = New Label()
            textLabel = New Label()
            label.BackColor = applyColor(i + 1)
            label.AutoSize = False
            label.Width = 20
            label.Height = 11
            textLabel.AutoSize = True
            textLabel.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)
            textLabel.Text = dataTable.Rows(groupNameMap(i)).Item(Item_Key.GROUP_NAME)
            label.Top = top
            textLabel.Top = top - 7
            top += (10 + label.Height)
            label.Left = left
            textLabel.Left = left + label.Width + 10
            panel.Controls.Add(label)
            panel.Controls.Add(textLabel)
        Next

        panel.Dock = DockStyle.Fill
        groupNames.Controls.Add(panel)
    End Sub
    Private Sub Table_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim element As DataRow = dataTable.Rows(sender.Tag)

        If popup.Tag = 0 Then
            popup.Text = element.Item(Item_Key.NAME)
            picture.ImageLocation = Application.StartupPath & "\Images\" & element.Item(Item_Key.SCHEMATIC_FILE)
            picture.Size = New Size(275, 300)
            picture.SizeMode = PictureBoxSizeMode.StretchImage
            picture.BorderStyle = BorderStyle.Fixed3D
            popup.AutoSize = True
            picture.Top = 20
            picture.Left = 10

            closeElement.Left = picture.Left
            closeElement.Top = picture.Top + picture.Height + 10
            closeElement.Width = picture.Width
            closeElement.Text = "Close " & element.Item(Item_Key.NAME)
            closeElement.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            closeElement.Height = 35
            closeElement1.Tag = sender.Tag

            title.Text = element.Item(Item_Key.NAME)
            title.AutoSize = True
            title.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Bold)
            title.Top = 10
            title.Left = picture.Left + picture.Width + 10

            abbreviation.Text = "Abbreviation: " & element.Item(Item_Key.SYMBOL)
            abbreviation.AutoSize = True
            abbreviation.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            abbreviation.Top = title.Top + title.Height + 30
            abbreviation.Left = picture.Left + picture.Width + 10

            atomicNumber.Text = "Atomic Number: " & element.Item(Item_Key.ATOMIC_NUMBER)
            atomicNumber.AutoSize = True
            atomicNumber.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            atomicNumber.Top = abbreviation.Top + abbreviation.Height + 30
            atomicNumber.Left = picture.Left + picture.Width + 10

            If element.Item(Item_Key.ATOMIC_WEIGHT).Equals(System.DBNull.Value) Then
                atomicWeight.Text = "Atomic Weight: Not Listed"
            Else
                atomicWeight.Text = "Atomic Weight: " & element.Item(Item_Key.ATOMIC_WEIGHT)
            End If

            atomicWeight.AutoSize = True
            atomicWeight.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            atomicWeight.Top = atomicNumber.Top + atomicNumber.Height + 30
            atomicWeight.Left = picture.Left + picture.Width + 10

            groupName.Text = "Group Name: " & element.Item(Item_Key.GROUP_NAME)
            groupName.AutoSize = True
            groupName.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            groupName.Top = atomicWeight.Top + atomicWeight.Height + 30
            groupName.Left = picture.Left + picture.Width + 10

            If element.Item(Item_Key.MELTING_POINT).Equals(System.DBNull.Value) Then
                meltingPoint.Text = "Melting Point: Not Listed"
            Else
                meltingPoint.Text = "Melting Point: " & element.Item(Item_Key.MELTING_POINT)
            End If
            meltingPoint.AutoSize = True
            meltingPoint.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            meltingPoint.Top = groupName.Top + groupName.Height + 30
            meltingPoint.Left = picture.Left + picture.Width + 10

            If element.Item(Item_Key.BOILING_POINT).Equals(System.DBNull.Value) Then
                boilingPoint.Text = "Boiling Point: Not Listed"
            Else
                boilingPoint.Text = "Boiling Point: " & element.Item(Item_Key.BOILING_POINT)
            End If
            boilingPoint.AutoSize = True
            boilingPoint.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            boilingPoint.Top = meltingPoint.Top + meltingPoint.Height + 30
            boilingPoint.Left = picture.Left + picture.Width + 10

            If element.Item(Item_Key.DISCOVERER).Equals(System.DBNull.Value) Then
                discoverer.Text = "Discoverer: Not Listed"
            Else
                discoverer.Text = "Discoverer: " & element.Item(Item_Key.DISCOVERER)
            End If
            discoverer.AutoSize = True
            discoverer.MaximumSize = New Size(600, 250)
            discoverer.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            discoverer.Top = closeElement.Top + closeElement.Height + 30
            discoverer.Left = closeElement.Left
            popup.Controls.Add(discoverer)

            If element.Item(Item_Key.DISCOVERY_LOCATION).Equals(System.DBNull.Value) Then
                discoveryLocation.Text = "Discovery Location: Not Listed"
            Else
                discoveryLocation.Text = "Discovery Location: " & element.Item(Item_Key.DISCOVERY_LOCATION)
            End If
            discoveryLocation.AutoSize = True
            discoveryLocation.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            discoveryLocation.Top = discoverer.Top + discoverer.Height + 30
            discoveryLocation.Left = closeElement.Left
            popup.Controls.Add(discoveryLocation)

            If element.Item(Item_Key.DISCOVERY_YEAR).Equals(System.DBNull.Value) Then
                discoveryYear.Text = "Discovery Year: Not Listed"
            Else
                discoveryYear.Text = "Discovery Year: " & element.Item(Item_Key.DISCOVERY_YEAR)
            End If
            discoveryYear.AutoSize = True
            discoveryYear.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            If (discoveryLocation.Left + discoveryLocation.Width) > meltingPoint.Left Then
                discoveryYear.Top = discoveryLocation.Top + discoveryLocation.Height + 30
                discoveryYear.Left = discoveryLocation.Left
                nameOrigin.Top = discoveryYear.Top + discoveryYear.Height + 30
            Else
                discoveryYear.Top = discoveryLocation.Top
                discoveryYear.Left = meltingPoint.Left
                nameOrigin.Top = discoveryLocation.Top + discoveryLocation.Height + 30
            End If


            nameOrigin.Text = "Name Origin: " & element.Item(Item_Key.NAME_ORIGIN)
            nameOrigin.AutoSize = True
            nameOrigin.TextAlign = ContentAlignment.MiddleCenter
            nameOrigin.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            nameOrigin.Left = closeElement.Left
            nameOrigin.MaximumSize = New Size(600, 250)

            popup.Tag = 1
            AddControls()

            instructions.Text = "Click on another element box from the Periodic Table to compare it with the current element."
            instructions.TextAlign = ContentAlignment.MiddleCenter
            instructions.AutoSize = True
            instructions.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)
            instructions.Left = 0
            instructions.Top = nameOrigin.Top + nameOrigin.Height + 10
            instructions.MaximumSize = New Size(popup.Width, 200)
            popup.Controls.Add(instructions)

            popup.MaximizeBox = False
            popup.Height = instructions.Top + instructions.Height + 10
            popup.Width = 300
            modalPopup.Hide()
            popup.Show()

        ElseIf title.Text = element.Item(Item_Key.NAME) Then
            MessageBox.Show("You can not compare the same element to itself.", "Same Element", _
            MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk)
        ElseIf popup.Tag = 1 Then
            title1.Text = element.Item(Item_Key.NAME)
            title1.AutoSize = True
            title1.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Bold)
            title1.Top = 10
            title1.Left = popup.Width + 10

            abbreviation1.Text = "Abbreviation: " & element.Item(Item_Key.SYMBOL)
            abbreviation1.AutoSize = True
            abbreviation1.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            abbreviation1.Top = abbreviation.Top
            abbreviation1.Left = title1.Left

            atomicNumber1.Text = "Atomic Number: " & element.Item(Item_Key.ATOMIC_NUMBER)
            atomicNumber1.AutoSize = True
            atomicNumber1.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            atomicNumber1.Top = atomicNumber.Top
            atomicNumber1.Left = title1.Left

            If element.Item(Item_Key.ATOMIC_WEIGHT).Equals(System.DBNull.Value) Then
                atomicWeight1.Text = "Atomic Weight: Not Listed"
            Else
                atomicWeight1.Text = "Atomic Weight: " & element.Item(Item_Key.ATOMIC_WEIGHT)
            End If

            atomicWeight1.AutoSize = True
            atomicWeight1.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            atomicWeight1.Top = atomicWeight.Top
            atomicWeight1.Left = title1.Left

            groupName1.Text = "Group Name: " & element.Item(Item_Key.GROUP_NAME)
            groupName1.AutoSize = True
            groupName1.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            groupName1.Top = groupName.Top
            groupName1.Left = title1.Left
            modalPopup.Controls.Add(groupName1)

            If element.Item(Item_Key.MELTING_POINT).Equals(System.DBNull.Value) Then
                meltingPoint1.Text = "Melting Point: Not Listed"
            Else
                meltingPoint1.Text = "Melting Point: " & element.Item(Item_Key.MELTING_POINT)
            End If
            meltingPoint1.AutoSize = True
            meltingPoint1.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            meltingPoint1.Top = meltingPoint.Top
            meltingPoint1.Left = title1.Left

            If element.Item(Item_Key.BOILING_POINT).Equals(System.DBNull.Value) Then
                boilingPoint1.Text = "Boiling Point: Not Listed"
            Else
                boilingPoint1.Text = "Boiling Point: " & element.Item(Item_Key.BOILING_POINT)
            End If
            boilingPoint1.AutoSize = True
            boilingPoint1.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            boilingPoint1.Top = boilingPoint.Top
            boilingPoint1.Left = title1.Left

            modalPopup.Text = popup.Text & " compared with " & element.Item(Item_Key.NAME)
            picture1.ImageLocation = Application.StartupPath & "\Images\" & element.Item(Item_Key.SCHEMATIC_FILE)
            picture1.Size = picture.Size
            picture1.SizeMode = PictureBoxSizeMode.StretchImage
            picture1.BorderStyle = BorderStyle.Fixed3D
            picture1.Top = picture.Top


            If groupName1.Width > groupName.Width Then
                popup.Width += (groupName1.Width - groupName.Width) / 3
            End If

            modalPopup.Size = New Size(popup.Width * 2, 440)

            picture1.Left = modalPopup.Width - (picture1.Width + 20)

            closeElement1.Left = picture1.Left
            closeElement1.Top = picture1.Top + picture1.Height + 10
            closeElement1.Width = picture1.Width
            closeElement1.Text = "Close " & element.Item(Item_Key.NAME)
            closeElement1.Font = New Font("Microsoft Sans Serif", 16, FontStyle.Regular)
            closeElement1.Height = 35
            closeElement.Tag = sender.Tag

            popup.Hide()
            popup.Tag = 2
            AddControls()
            modalPopup.ShowDialog(Me)
            popup.BringToFront()
        End If
    End Sub
    Private Sub AddControls()
        If popup.Tag = 1 Then
            popup.Controls.Add(picture)
            popup.Controls.Add(closeElement)
            popup.Controls.Add(title)
            popup.Controls.Add(abbreviation)
            popup.Controls.Add(atomicNumber)
            popup.Controls.Add(atomicWeight)
            popup.Controls.Add(groupName)
            popup.Controls.Add(meltingPoint)
            popup.Controls.Add(boilingPoint)
            popup.Controls.Add(discoverer)
            popup.Controls.Add(discoveryLocation)
            popup.Controls.Add(discoveryYear)
            popup.Controls.Add(nameOrigin)

        ElseIf popup.Tag = 2 Then
            modalPopup.Controls.Add(picture)
            modalPopup.Controls.Add(closeElement)
            modalPopup.Controls.Add(title)
            modalPopup.Controls.Add(abbreviation)
            modalPopup.Controls.Add(atomicNumber)
            modalPopup.Controls.Add(atomicWeight)
            modalPopup.Controls.Add(groupName)
            modalPopup.Controls.Add(meltingPoint)
            modalPopup.Controls.Add(boilingPoint)
            modalPopup.Controls.Add(picture1)
            modalPopup.Controls.Add(title1)
            modalPopup.Controls.Add(abbreviation1)
            modalPopup.Controls.Add(atomicNumber1)
            modalPopup.Controls.Add(atomicWeight1)
            modalPopup.Controls.Add(groupName1)
            modalPopup.Controls.Add(closeElement1)
            modalPopup.Controls.Add(boilingPoint1)
            modalPopup.Controls.Add(meltingPoint1)
        End If
    End Sub
    Private Sub Table_Hover(ByVal sender As System.Object, ByVal e As System.EventArgs)
        toolTip.Show(dataTable.Rows(sender.Tag).Item(Item_Key.NAME), sender)
    End Sub
    Private Sub Close_Element(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If popup.Tag = 1 Then
            popup.Tag = 0
            popup.Hide()
        ElseIf popup.Tag = 2 Then
            Dim cControl As Button
            For Each cControl In Me.Controls
                If cControl.Tag = sender.Tag Then
                    popup.Tag = 0
                    cControl.PerformClick()
                    Exit For
                End If
            Next cControl
        End If
    End Sub
    Private Sub CloseForm(ByVal sender As System.Object, ByVal e As FormClosingEventArgs) Handles popup.FormClosing, modalPopup.FormClosing
        If popup.Tag = 1 AndAlso Not sender Is modalPopup Then
            e.Cancel = True
            Close_Element(sender, Nothing)
        ElseIf popup.Tag = 2 Then
            popup.Tag = 0
        End If
    End Sub
    Private Sub Settings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles settings.Click
        Dim NewSettings As New settings
        Dim ArrayOptions() As Boolean
        Dim ResultsArray() As Integer
        NewSettings.ShowDialog()
        If NewSettings.DialogResult = vbOK Then
            Me.Visible = False
            ArrayOptions = NewSettings.returnOptions()
            Dim NewQuiz As New Quiz(ArrayOptions)
            NewQuiz.ShowDialog()
            ResultsArray = NewQuiz.returnTally()
            Dim Results As New Results(ResultsArray)
            Results.ShowDialog()
            Me.Visible = True
        End If
    End Sub
    'Private Sub TestResultsForm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles settings.Click
    'Dim testres() As Integer = {1, 2, 3, 4, 5, 6, 7, 11, 22, 33, 44, 55, 66, 77, 111, 222, 333, 444, 555, 666, 777, 288, 2888}
    'Dim newResults As New Results(testres)
    '   newResults.ShowDialog()
    'End Sub
End Class
