Imports WindowsApplication1.CS434DataSet

Public Class Demographics
    Dim rows As New LocationTableDataTable
    Public Sub New(ByVal selectedRow As DataGridViewRow)
        ' This call is required by the designer.
        InitializeComponent()
        'Me.LocationTableTableAdapter.Fill(Me.CS434DataSet.LocationTable)
        rows = Me.LocationTableTableAdapter.GetData

        Dim locRow As LocationTableRow = rows.Select("State ='" & selectedRow.Cells(8).Value() & "' AND City ='" & selectedRow.Cells(7).Value() & "'")(0)
        Dim popTable As PopulationTableDataTable = Me.PopulationTableTableAdapter.GetData
        Dim popRow As PopulationTableRow = popTable.Select("CRSA_Code = '" & locRow.CRSA_Code & "'")(0)
        If popRow.CRSA_Code = "NO_CBSA" Then
            CBSA_CodeLbl.Text = popRow.CRSA_Code
            PopulationLbl.Text = "N/A"
            MedianHousingIncomeLbl.Text = "N/A"
            PerCapitaIncomeLbl.Text = "N/A"
            AvgTravelTimeLbl.Text = "N/A"
            Return
        End If
        CBSA_CodeLbl.Text = popRow.CRSA_Code
        PopulationLbl.Text = popRow.Population
        MedianHousingIncomeLbl.Text = popRow.MedianHousingIncome
        PerCapitaIncomeLbl.Text = popRow.PerCapitalIncome
        AvgTravelTimeLbl.Text = popRow.AvgTravelTime


    End Sub
    Private Sub Demographics_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CS434DataSet.LocationTable' table. You can move, or remove it, as needed.
        Me.LocationTableTableAdapter.Fill(Me.CS434DataSet.LocationTable)
        'TODO: This line of code loads data into the 'CS434DataSet.PopulationTable' table. You can move, or remove it, as needed.
        Me.PopulationTableTableAdapter.Fill(Me.CS434DataSet.PopulationTable)

    End Sub
End Class