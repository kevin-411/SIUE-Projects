Imports System.Data.SqlClient
Public Class MainFrm
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AmtrakFacilityTableAdapter.Fill(Me.CS434DataSet.AmtrakFacility)
        Me.AirportFacilityTableAdapter.Fill(Me.CS434DataSet.AirportFacility)
        Dim states As HashSet(Of String) = New HashSet(Of String)()
        For Each row As DataRow In Me.AirportFacilityTableAdapter.GetData.Rows
            If Not states.Contains(row.Item("State")) Then
                StateComboBox.Items.Add(row.Item("State"))
                states.Add(row.Item("State"))
            End If
        Next
        states = New HashSet(Of String)()
        For Each row As DataRow In Me.AmtrakFacilityTableAdapter.GetData.Rows
            If Not states.Contains(row.Item("State")) Then
                StateComboBox1.Items.Add(row.Item("State"))
                states.Add(row.Item("State"))
            End If
        Next
    End Sub


    Private Sub StateComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles StateComboBox.SelectedIndexChanged
        CityComboBox.SelectedItem = Nothing
        CityComboBox.Items.Clear()
        AirportFacilityBindingSource.Filter = "State = '" & StateComboBox.SelectedItem & "'"
        Dim cities As HashSet(Of String) = New HashSet(Of String)()
        For Each row As DataGridViewRow In Me.AirportFacilityDataGridView.Rows
            If Not cities.Contains(row.DataBoundItem("City")) Then
                CityComboBox.Items.Add(row.DataBoundItem("City"))
                cities.Add(row.DataBoundItem("City"))
            End If
        Next
    End Sub

    Private Sub CityComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CityComboBox.SelectedIndexChanged
        AirportFacilityBindingSource.Filter = "State = '" & StateComboBox.SelectedItem & "' And City ='" & CityComboBox.SelectedItem & "'"
    End Sub

    Private Sub StateComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles StateComboBox1.SelectedIndexChanged
        CityComboBox1.SelectedItem = Nothing
        CityComboBox1.Items.Clear()
        AmtrakFacilityBindingSource.Filter = "State = '" & StateComboBox1.SelectedItem & "'"
        Dim cities As HashSet(Of String) = New HashSet(Of String)()
        For Each row As DataGridViewRow In Me.AmtrakFacilityDataGridView.Rows
            If Not cities.Contains(row.DataBoundItem("City")) Then
                CityComboBox1.Items.Add(row.DataBoundItem("City"))
                cities.Add(row.DataBoundItem("City"))
            End If
        Next
    End Sub

    Private Sub CityComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CityComboBox1.SelectedIndexChanged
        AmtrakFacilityBindingSource.Filter = "State = '" & StateComboBox1.SelectedItem & "' And City ='" & CityComboBox1.SelectedItem & "'"
    End Sub
    Private Sub DescriptionTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles DescriptionTextBox.TextChanged
        Dim str As String = DescriptionTextBox.Text

        If DescriptionTextBox.Text = "Search for words in description..." Then
            str = ""
        End If
        If StateComboBox.SelectedItem = Nothing AndAlso Not DescriptionTextBox.ForeColor = SystemColors.InactiveCaption Then
            AirportFacilityBindingSource.Filter = "Description Like '%" & str & "%'"
        ElseIf CityComboBox.SelectedItem = Nothing AndAlso Not DescriptionTextBox.ForeColor = SystemColors.InactiveCaption Then
            AirportFacilityBindingSource.Filter = "State = '" & StateComboBox.SelectedItem & "' And Description Like '%" & str & "%'"
        ElseIf Not DescriptionTextBox.ForeColor = SystemColors.InactiveCaption Then
            AirportFacilityBindingSource.Filter = "State = '" & StateComboBox.SelectedItem & "' And City ='" & CityComboBox.SelectedItem & _
                "' And Description Like '%" & str & "%'"
        End If

    End Sub
    Private Sub DescriptionTextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles DescriptionTextBox1.TextChanged
        Dim str As String = DescriptionTextBox1.Text

        If DescriptionTextBox1.Text = "Search for words in description..." Then
            str = ""
        End If
        If StateComboBox1.SelectedItem = Nothing AndAlso Not DescriptionTextBox1.ForeColor = SystemColors.InactiveCaption Then
            AmtrakFacilityBindingSource.Filter = "Description Like '%" & str & "%'"
        ElseIf CityComboBox.SelectedItem = Nothing AndAlso Not DescriptionTextBox1.ForeColor = SystemColors.InactiveCaption Then
            AmtrakFacilityBindingSource.Filter = "State = '" & StateComboBox1.SelectedItem & "' And Description Like '%" & str & "%'"
        ElseIf Not DescriptionTextBox.ForeColor = SystemColors.InactiveCaption Then
            AmtrakFacilityBindingSource.Filter = "State = '" & StateComboBox1.SelectedItem & "' And City ='" & CityComboBox1.SelectedItem & _
                "' And Description Like '%" & str & "%'"
        End If

    End Sub
    Private Sub DescriptionTextBox_Click(sender As System.Object, e As System.EventArgs) Handles DescriptionTextBox.Click, DescriptionTextBox1.Click
        If sender.Text = "Search for words in description..." Then
            sender.Text = ""
            sender.ForeColor = SystemColors.ActiveCaptionText
        End If
    End Sub
    Private Sub DescriptionTextBox_Leave(sender As System.Object, e As System.EventArgs) Handles DescriptionTextBox.Leave, DescriptionTextBox1.Leave
        If sender.Text = "" Then
            sender.Text = "Search for words in description..."
            sender.ForeColor = SystemColors.InactiveCaption
        End If
    End Sub
    Private Sub NewAirportButton_Click(sender As System.Object, e As System.EventArgs) Handles NewAirportButton.Click, NewAmtrakButton.Click
        Dim newFacility As InsertNewFacility
        If sender.Tag = 1 Then
            newFacility = New InsertNewFacility(False)
        Else
            newFacility = New InsertNewFacility(True)
        End If
        newFacility.ShowDialog(Me)
        Me.AmtrakFacilityTableAdapter.Fill(Me.CS434DataSet.AmtrakFacility)
        Me.AirportFacilityTableAdapter.Fill(Me.CS434DataSet.AirportFacility)
    End Sub
    Private Sub UpdateDeleteFacilityButton_Click(sender As System.Object, e As System.EventArgs) Handles UpdateDeleteAirportButton.Click, UpdateDeleteAmtrakButton.Click
        Dim updateFacility As UpdateDeleteCurrentFacility
        If sender.Tag = 1 Then
            updateFacility = New UpdateDeleteCurrentFacility(False, AmtrakFacilityDataGridView.SelectedRows.Item(0))

        Else
            updateFacility = New UpdateDeleteCurrentFacility(True, AirportFacilityDataGridView.SelectedRows.Item(0))
        End If
        updateFacility.ShowDialog(Me)
        Me.AmtrakFacilityTableAdapter.Fill(Me.CS434DataSet.AmtrakFacility)
        Me.AirportFacilityTableAdapter.Fill(Me.CS434DataSet.AirportFacility)
    End Sub

    Private Sub AirportFacilityDataGridView_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AirportFacilityDataGridView.CellDoubleClick, AmtrakFacilityDataGridView.CellDoubleClick
        Dim dems As Demographics
        If sender.Tag = 1 Then
            dems = New Demographics(AmtrakFacilityDataGridView.SelectedRows.Item(0))

        Else
            dems = New Demographics(AirportFacilityDataGridView.SelectedRows.Item(0))
        End If
        dems.ShowDialog(Me)

    End Sub
End Class