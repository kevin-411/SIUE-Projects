Imports WindowsApplication1.CS434DataSet
Imports System.Text.RegularExpressions

Public Class UpdateDeleteCurrentFacility
    Private isAirport As Boolean
    Dim selectedRow As DataGridViewRow
    Dim rows
    Public Sub New(ByVal isAirport As Boolean, ByRef selectedRow As DataGridViewRow)
        InitializeComponent()
        Me.selectedRow = selectedRow
        Me.isAirport = isAirport
        If Not isAirport Then
            Me.MainLabel.Text = "Update/Delete Amtrak Facility"
            Me.AirportIdLabel.Text = "Amtrak Id:"
            Me.NumTerminalsLabel.Text = "   Num Amtraks: "
            AIdString = "AmtrakId"
            rows = New AmtrakFacilityDataTable()
        Else
            rows = New AirportFacilityDataTable()
        End If
    End Sub
    Private Sub setFields(ByVal row As DataGridViewRow)
        Dim fid = row.Cells(2).Value
        FacilityIdTextBox.Text = fid
        If isAirport Then
            AirportIdTextBox.Text = row.Cells(1).Value
        Else
            AirportIdTextBox.Text = row.Cells(1).Value
        End If
        NumTerminalsNumericChooser.Value = row.Cells(3).Value
        DescriptionTextBox.Text = row.Cells(10).Value
        WebsiteTextBox.Text = row.Cells(4).Value
        NameTextBox.Text = row.Cells(0).Value
        stateComboBox.SelectedIndex = stateComboBox.Items.IndexOf(row.Cells(8).Value)
        cityComboBox.SelectedIndex = cityComboBox.Items.IndexOf(row.Cells(7).Value)
        StreetTextBox.Text = row.Cells(6).Value
        ZipCodeTextBox.Text = row.Cells(9).Value
        LatitudeNumericChooser.Value = rows.Select("FacilityId = '" & fid & "'").GetValue(0).Latitude
        LongitudeNumericChooser.Value = rows.Select("FacilityId = '" & fid & "'").GetValue(0).Longitude

    End Sub
    Private Sub UpdateDeleteCurrentFacility_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
        setFields(selectedRow)
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
    Private Function ValidZip(ByVal cZip As String) As Boolean
        'Check if zip code is either NNNNN-NNNN, NNNNN, ANA NAN 
        Dim rZip As New Regex("^((\d{5}-\d{4})|(\d{5})|([A-Z]\d[A-Z]\s\d[A-Z]\d))$", RegexOptions.IgnorePatternWhitespace)
        If Not rZip.IsMatch(cZip) Then
            Return False
        End If

        Return True
    End Function
    Private Sub UpdateButton_Click(sender As System.Object, e As System.EventArgs) Handles UpdateButton.Click

        If stateComboBox.SelectedItem = Nothing OrElse cityComboBox.SelectedItem = Nothing Then
            MessageBox.Show("Please make sure to select a state and a city!!" _
                       , "State And City Left Blank", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim crsaCode As String = rows.Select("State = '" & stateComboBox.Text & "' AND City ='" & cityComboBox.Text & "'").GetValue(0).CRSA_Code

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

            Dim oldInfo As DataRow = rows.Select("FacilityId = '" & FacilityIdTextBox.Text & "'").GetValue(0)
            Dim oldCrsaCode As String = rows.Select("State = '" & oldInfo.Item("State") & "' AND City ='" & oldInfo.Item("City") & "'").GetValue(0).CRSA_Code
            Me.AirportFacilityTableAdapter.HasALocationTableDelete(FacilityIdTextBox.Text, oldCrsaCode, _
                    oldInfo.Item("Latitude"), oldInfo.Item("Longitude"))
            Me.AirportFacilityTableAdapter.LocationTableDelete(oldCrsaCode, oldInfo.Item("Latitude"), oldInfo.Item("Longitude"))
            Me.AirportFacilityTableAdapter.LocationTableInsert(crsaCode, LatitudeNumericChooser.Value, _
                           LongitudeNumericChooser.Value, StreetTextBox.Text, cityComboBox.Text, stateComboBox.Text, ZipCodeTextBox.Text)
            Me.AirportFacilityTableAdapter.HasALocationTableInsert(FacilityIdTextBox.Text, crsaCode, _
                    LatitudeNumericChooser.Value, LongitudeNumericChooser.Value)
            If isAirport Then
                Me.AirportFacilityTableAdapter.AirportTableUpdate(NumTerminalsNumericChooser.Value, DescriptionTextBox.Text, _
                                                                  AirportIdTextBox.Text, FacilityIdTextBox.Text)
            Else
                Me.AmtrakFacilityTableAdapter.AmtrakTableUpdate(NumTerminalsNumericChooser.Value, DescriptionTextBox.Text, _
                                                                AirportIdTextBox.Text, FacilityIdTextBox.Text)
            End If
            Me.AirportFacilityTableAdapter.FacilityTableUpdate(WebsiteTextBox.Text, NameTextBox.Text, If(isAirport, 1, 8), _
                                       DescriptionTextBox.Text, FacilityIdTextBox.Text)
            MessageBox.Show("Successful Update to the Database!" _
           , "Database Update!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If


    End Sub

    Private Sub DeleteButton_Click(sender As System.Object, e As System.EventArgs) Handles DeleteButton.Click
        Dim aid As String
        If isAirport Then
            aid = "Airport"
        Else
            aid = "Amtrak"
        End If
        Dim name As String = rows.Select("FacilityId = '" & FacilityIdTextBox.Text & "' AND " + aid + "Id ='" & AirportIdTextBox.Text & "'").GetValue(0).Name()
        Dim response As Integer = MessageBox.Show("You are about to delete record: " + vbCrLf _
                        + "Name: " + name + vbCrLf + "Facility Id: " + FacilityIdTextBox.Text + vbCrLf _
                        + aid + " Id: " + AirportIdTextBox.Text + vbCrLf + "Do you wish to continue?", _
                        "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If response = DialogResult.Yes Then
            Dim crsaCode As String = rows.Select("FacilityId = '" & FacilityIdTextBox.Text & "' AND State = '" & stateComboBox.Text & "' AND City ='" & cityComboBox.Text & "'").GetValue(0).CRSA_Code
            Dim latitude As Double = rows.Select("FacilityId = '" & FacilityIdTextBox.Text & "' AND State = '" & stateComboBox.Text & "' AND City ='" & cityComboBox.Text & "'").GetValue(0).Latitude
            Dim longitude As Double = rows.Select("FacilityId = '" & FacilityIdTextBox.Text & "' AND State = '" & stateComboBox.Text & "' AND City ='" & cityComboBox.Text & "'").GetValue(0).Longitude
            Me.AirportFacilityTableAdapter.HasALocationTableDelete(FacilityIdTextBox.Text, crsaCode, _
                    LatitudeNumericChooser.Value, LongitudeNumericChooser.Value)
            Me.AirportFacilityTableAdapter.LocationTableDelete(crsaCode, latitude, longitude)
            If isAirport Then
                Me.AirportFacilityTableAdapter.AirportTableDelete(AirportIdTextBox.Text, FacilityIdTextBox.Text)
            Else
                Me.AmtrakFacilityTableAdapter.AmtrakTableDelete(AirportIdTextBox.Text, FacilityIdTextBox.Text)
            End If
            Me.AirportFacilityTableAdapter.FacilityTableDelete(FacilityIdTextBox.Text)
            MessageBox.Show("Successful Delete from the Database!" _
            , "Database Deletion!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub
End Class