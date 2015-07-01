Imports WindowsApplication1.CS434DataSet

Public Class POP

    Private Sub CBSABindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs) Handles CBSABindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CBSABindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.CS434DataSet)

    End Sub

    Private Sub POP_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CS434DataSet.PopulationTable' table. You can move, or remove it, as needed.
        Me.PopulationTableTableAdapter.Fill(Me.CS434DataSet.PopulationTable)
        'TODO: This line of code loads data into the 'CS434DataSet.CBSA' table. You can move, or remove it, as needed.
        Me.CBSATableAdapter.Fill(Me.CS434DataSet.CBSA)
        Dim RandomClass As New Random()
        Dim MedianHousingIncome As Integer
        Dim PerCapitaIncome As Integer
        Dim AvgTravelTime As Integer
        'MedianHousingIncome 51000 - 74000
        'Per Capita Income 27000 - 29000
        For Each row As PopulationTableRow In Me.PopulationTableTableAdapter.GetData
            MedianHousingIncome = RandomClass.Next(51000, 74000)
            PerCapitaIncome = RandomClass.Next(27000, 29000)
            AvgTravelTime = RandomClass.Next(30, 70)
            Me.PopulationTableTableAdapter.UpdateQuery(MedianHousingIncome, PerCapitaIncome, AvgTravelTime, row.CRSA_Code)
        Next

    End Sub
End Class