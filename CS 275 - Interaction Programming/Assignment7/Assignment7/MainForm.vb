Public Class MainForm
    Private database As New BaseballDataContext() ' LINQ to SQL data context

    ' load data from database into DataGridView
    Private Sub DisplayTable_Load(ByVal sender As System.Object,
       ByVal e As System.EventArgs) Handles MyBase.Load

        ' use LINQ to order the data for display
        PlayerBindingSource.DataSource =
           From player In database.Players
           Order By player.PlayerID
           Select player
    End Sub ' DisplayTable_Load
    Private Sub submitBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submitBtn.Click
        'Clear the listbox for new search.
        PlayerListBox.Items.Clear()

        'Slides 86 and 87
        'Find players in the list with the last name entered in the lastNameTextBox.
        Dim players =
            From player In database.Players
            Where player.LastName = SubmitTextBox.Text.ToString
            Order By player.LastName, player.FirstName
            Select player.LastName, player.FirstName, player.BattingAverage

        'Slide 101
        'Add each player to the listbox.
        For Each player In players

            Dim playerName As String = player.FirstName + " " + player.LastName + " " + Convert.ToString(player.BattingAverage)
            PlayerListBox.Items.Add(playerName)
        Next
    End Sub


    ' save the changes into the database
    Private Sub BaseballBindingNavigatorSaveItem_Click(
       ByVal sender As System.Object, ByVal e As System.EventArgs) _
       Handles BaseballBindingNavigatorSaveItem.Click

        Validate() ' validate input fields
        PlayerBindingSource.EndEdit() ' indicate edits are complete
        database.SubmitChanges() ' write changes to database file
    End Sub ' AuthorBindingNavigatorSaveItem_Click
End Class
