Imports WindowsApplication1.CS434DataSet
Imports System.Text.RegularExpressions

Public Class InsertNewFacility
    Private isAirport As Boolean
    Private AIdString As String = "AirportId"
    Private generatedFId As String
    Private fids As New HashSet(Of Integer)
    Dim rows
    Public Sub New(ByVal isAirport As Boolean)
        InitializeComponent()
        Me.isAirport = isAirport
        If Not isAirport Then
            Me.MainLabel.Text = "New Amtrak Facility"
            Me.AirportIdLabel.Text = "Amtrak Id(*):"
            Me.NumTerminalsLabel.Text = "   Num Amtraks(*): "
            AIdString = "AmtrakId"
            rows = New AmtrakFacilityDataTable()
        Else
            rows = New AirportFacilityDataTable()
        End If
    End Sub
    Private Sub InsertNewFacility_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.FacilityTableTableAdapter.Fill(Me.CS434DataSet.FacilityTable)
        Me.LocationTableTableAdapter.Fill(Me.CS434DataSet.LocationTable)
        Me.HasLocationTableTableAdapter.Fill(Me.CS434DataSet.HasLocationTable)
        Me.AmtrakFacilityTableAdapter.Fill(Me.CS434DataSet.AmtrakFacility)
        Me.AirportFacilityTableAdapter.Fill(Me.CS434DataSet.AirportFacility)

        If isAirport Then
            rows = Me.AirportFacilityTableAdapter.GetData
        Else
            rows = Me.AmtrakFacilityTableAdapter.GetData
        End If
        For Each row In rows.Rows
            If Not stateComboBox.Items.Contains(row.State) Then
                stateComboBox.Items.Add(row.State)
            End If
        Next

        Dim facRows As FacilityTableDataTable = Me.FacilityTableTableAdapter.GetData()
        For Each row As FacilityTableRow In facRows.Select("FacilityId Like 'XX%'")
            fids.Add(Integer.Parse(row.FacilityId.Substring(2)))
        Next
        generateFId()
    End Sub

    Private Sub stateComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles stateComboBox.SelectedIndexChanged
        cityComboBox.SelectedItem = Nothing
        cityComboBox.Items.Clear()
        Dim cities
            cities = rows.Select("State = '" & stateComboBox.SelectedItem & "'")
        For Each row In cities
            If Not cityComboBox.Items.Contains(row.City) Then
                cityComboBox.Items.Add(row.City)
            End If
        Next
    End Sub
    Private Sub generateFId()
        generatedFId = ""
        For i = 0 To fids.Count
            If Not fids.Contains(i) Then
                generatedFId = "XX" + i.ToString("D7")
            End If
        Next
        FacilityIdTextBox.Text = generatedFId
    End Sub
    Private Function checkAId()
        If isAirport Then
            Dim table As AirportFacilityDataTable = Me.AirportFacilityTableAdapter.GetData
            Dim check() As DataRow = table.Select("AirportId = '" + AirportIdTextBox.Text + "'")
            If Not AirportIdTextBox.Text.Length = 3 OrElse Not check.Length = 0 Then
                Return True
            End If
            Return False
        Else
            Dim table As AmtrakFacilityDataTable = Me.AmtrakFacilityTableAdapter.GetData
            Dim check() As DataRow = table.Select("AmtrakId = '" + AirportIdTextBox.Text + "'")
            If Not AirportIdTextBox.Text.Length = 3 OrElse Not check.Length = 0 Then
                Return True
            End If
            Return False
        End If
    End Function
    Private Function ValidZip(ByVal cZip As String) As Boolean
        'Check if zip code is either NNNNN-NNNN, NNNNN, ANA NAN 
        Dim rZip As New Regex("^((\d{5}-\d{4})|(\d{5})|([A-Z]\d[A-Z]\s\d[A-Z]\d))$", RegexOptions.IgnorePatternWhitespace)
        If Not rZip.IsMatch(cZip) Then
            Return False
        End If

        Return True
    End Function
    Private Sub AddButton_Click(sender As System.Object, e As System.EventArgs) Handles AddButton.Click

        If stateComboBox.SelectedItem = Nothing OrElse cityComboBox.SelectedItem = Nothing Then
            MessageBox.Show("Please make sure to select a state and a city!!" _
                       , "State And City Left Blank", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim locationRows = New LocationTableDataTable
        locationRows = Me.LocationTableTableAdapter.GetData
        Dim locations = locationRows.Select("State = '" & stateComboBox.Text & "' AND City ='" & cityComboBox.Text & "'")
        Dim crsaCode As String = locations.GetValue(0).CRSA_Code
        For Each loc As DataRow In locations
            If loc.Item("Latitude") = LatitudeNumericChooser.Value AndAlso _
               loc.Item("Longitude") = LongitudeNumericChooser.Value Then
                MessageBox.Show("There is already a Facility at that exact location!! Please change Latitude and Longitude Values." _
           , "Duplicate Location", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

        Next
        Dim latitude As Double = rows.Select("State = '" & stateComboBox.Text & "' AND City ='" & cityComboBox.Text & "'").GetValue(0).Latitude
        Dim longitude As String = rows.Select("State = '" & stateComboBox.Text & "' AND City ='" & cityComboBox.Text & "'").GetValue(0).Longitude

                If checkAId() Then
                    MessageBox.Show("The " + AIdString + " is already in use or is not the correct length of 3 characters!!" _
                               , "INVALID ID", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                If Not ValidZip(ZipCodeTextBox.Text) Then
                    MessageBox.Show("The Zip Code you entered is invalid!!" _
                               , "Invalid Zip Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                If NameTextBox.Text = "" OrElse ZipCodeTextBox.Text = "" OrElse StreetTextBox.Text = "" Then
                    MessageBox.Show("There are fields left empty that must be filled out!! Please fill out all fields with a (*) next to them!!" _
                               , "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                Else
            Me.AirportFacilityTableAdapter.FacilityTableInsert(FacilityIdTextBox.Text, _
                WebsiteTextBox.Text, NameTextBox.Text, If(isAirport, 1, 8), DescriptionTextBox.Text)
            If isAirport Then
                Me.AirportFacilityTableAdapter.AirportTableInsert(AirportIdTextBox.Text, _
                    FacilityIdTextBox.Text, NumTerminalsNumericChooser.Value, DescriptionTextBox.Text)
            Else
                Me.AmtrakFacilityTableAdapter.AmtrakTableInsert(AirportIdTextBox.Text, _
                    FacilityIdTextBox.Text, NumTerminalsNumericChooser.Value, DescriptionTextBox.Text)
            End If
            Me.AirportFacilityTableAdapter.LocationTableInsert(crsaCode, LatitudeNumericChooser.Value, _
                LongitudeNumericChooser.Value, StreetTextBox.Text, cityComboBox.Text, stateComboBox.Text, ZipCodeTextBox.Text)
            Me.AirportFacilityTableAdapter.HasALocationTableInsert(FacilityIdTextBox.Text, crsaCode, _
                    LatitudeNumericChooser.Value, LongitudeNumericChooser.Value)
            MessageBox.Show("Successful Insertertion into the Database!" _
           , "Database Insertion!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If


    End Sub
End Class