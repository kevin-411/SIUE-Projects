<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.PlayerDataGrid = New System.Windows.Forms.DataGridView()
        Me.PlayerIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FirstNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BattingAverageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlayerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BaseballBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BaseballBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.SubmitTextBox = New System.Windows.Forms.TextBox()
        Me.submitBtn = New System.Windows.Forms.Button()
        Me.LastNameLbl = New System.Windows.Forms.Label()
        Me.SearchGroup = New System.Windows.Forms.GroupBox()
        Me.PlayerLbl = New System.Windows.Forms.Label()
        Me.PlayerListBox = New System.Windows.Forms.ListBox()
        CType(Me.PlayerDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlayerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BaseballBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BaseballBindingNavigator.SuspendLayout()
        Me.SearchGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'PlayerDataGrid
        '
        Me.PlayerDataGrid.AutoGenerateColumns = False
        Me.PlayerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PlayerDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PlayerIDDataGridViewTextBoxColumn, Me.FirstNameDataGridViewTextBoxColumn, Me.LastNameDataGridViewTextBoxColumn, Me.BattingAverageDataGridViewTextBoxColumn})
        Me.PlayerDataGrid.DataSource = Me.PlayerBindingSource
        Me.PlayerDataGrid.Location = New System.Drawing.Point(0, 28)
        Me.PlayerDataGrid.Name = "PlayerDataGrid"
        Me.PlayerDataGrid.Size = New System.Drawing.Size(442, 372)
        Me.PlayerDataGrid.TabIndex = 0
        '
        'PlayerIDDataGridViewTextBoxColumn
        '
        Me.PlayerIDDataGridViewTextBoxColumn.DataPropertyName = "PlayerID"
        Me.PlayerIDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.PlayerIDDataGridViewTextBoxColumn.Name = "PlayerIDDataGridViewTextBoxColumn"
        '
        'FirstNameDataGridViewTextBoxColumn
        '
        Me.FirstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName"
        Me.FirstNameDataGridViewTextBoxColumn.HeaderText = "First Name"
        Me.FirstNameDataGridViewTextBoxColumn.Name = "FirstNameDataGridViewTextBoxColumn"
        '
        'LastNameDataGridViewTextBoxColumn
        '
        Me.LastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName"
        Me.LastNameDataGridViewTextBoxColumn.HeaderText = "Last Name"
        Me.LastNameDataGridViewTextBoxColumn.Name = "LastNameDataGridViewTextBoxColumn"
        '
        'BattingAverageDataGridViewTextBoxColumn
        '
        Me.BattingAverageDataGridViewTextBoxColumn.DataPropertyName = "BattingAverage"
        Me.BattingAverageDataGridViewTextBoxColumn.HeaderText = "Batting Avg"
        Me.BattingAverageDataGridViewTextBoxColumn.Name = "BattingAverageDataGridViewTextBoxColumn"
        '
        'PlayerBindingSource
        '
        Me.PlayerBindingSource.DataSource = GetType(Assignment7.Player)
        '
        'BaseballBindingNavigator
        '
        Me.BaseballBindingNavigator.AddNewItem = Me.ToolStripButton2
        Me.BaseballBindingNavigator.BindingSource = Me.PlayerBindingSource
        Me.BaseballBindingNavigator.CountItem = Me.ToolStripLabel1
        Me.BaseballBindingNavigator.DeleteItem = Me.ToolStripButton3
        Me.BaseballBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton6, Me.ToolStripButton7, Me.ToolStripSeparator3, Me.ToolStripButton2, Me.ToolStripButton3, Me.BaseballBindingNavigatorSaveItem})
        Me.BaseballBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.BaseballBindingNavigator.MoveFirstItem = Me.ToolStripButton4
        Me.BaseballBindingNavigator.MoveLastItem = Me.ToolStripButton7
        Me.BaseballBindingNavigator.MoveNextItem = Me.ToolStripButton6
        Me.BaseballBindingNavigator.MovePreviousItem = Me.ToolStripButton5
        Me.BaseballBindingNavigator.Name = "BaseballBindingNavigator"
        Me.BaseballBindingNavigator.PositionItem = Me.ToolStripTextBox1
        Me.BaseballBindingNavigator.Size = New System.Drawing.Size(661, 25)
        Me.BaseballBindingNavigator.TabIndex = 2
        Me.BaseballBindingNavigator.Text = "BindingNavigator1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Add new"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel1.Text = "of {0}"
        Me.ToolStripLabel1.ToolTipText = "Total number of items"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Delete"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Move first"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "Move previous"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AccessibleName = "Position"
        Me.ToolStripTextBox1.AutoSize = False
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(50, 23)
        Me.ToolStripTextBox1.Text = "0"
        Me.ToolStripTextBox1.ToolTipText = "Current position"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "Move next"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Move last"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BaseballBindingNavigatorSaveItem
        '
        Me.BaseballBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BaseballBindingNavigatorSaveItem.Image = CType(resources.GetObject("BaseballBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.BaseballBindingNavigatorSaveItem.Name = "BaseballBindingNavigatorSaveItem"
        Me.BaseballBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.BaseballBindingNavigatorSaveItem.Text = "Save Data"
        '
        'SubmitTextBox
        '
        Me.SubmitTextBox.Location = New System.Drawing.Point(4, 15)
        Me.SubmitTextBox.Name = "SubmitTextBox"
        Me.SubmitTextBox.Size = New System.Drawing.Size(126, 20)
        Me.SubmitTextBox.TabIndex = 3
        '
        'submitBtn
        '
        Me.submitBtn.Location = New System.Drawing.Point(136, 11)
        Me.submitBtn.Name = "submitBtn"
        Me.submitBtn.Size = New System.Drawing.Size(61, 26)
        Me.submitBtn.TabIndex = 1
        Me.submitBtn.Text = "Submit"
        Me.submitBtn.UseVisualStyleBackColor = True
        '
        'LastNameLbl
        '
        Me.LastNameLbl.AutoSize = True
        Me.LastNameLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LastNameLbl.Location = New System.Drawing.Point(6, 40)
        Me.LastNameLbl.Name = "LastNameLbl"
        Me.LastNameLbl.Size = New System.Drawing.Size(188, 13)
        Me.LastNameLbl.TabIndex = 5
        Me.LastNameLbl.Text = "Search by last name and click 'Submit'"
        '
        'SearchGroup
        '
        Me.SearchGroup.Controls.Add(Me.LastNameLbl)
        Me.SearchGroup.Controls.Add(Me.submitBtn)
        Me.SearchGroup.Controls.Add(Me.SubmitTextBox)
        Me.SearchGroup.Location = New System.Drawing.Point(448, 28)
        Me.SearchGroup.Name = "SearchGroup"
        Me.SearchGroup.Size = New System.Drawing.Size(208, 69)
        Me.SearchGroup.TabIndex = 6
        Me.SearchGroup.TabStop = False
        Me.SearchGroup.Text = "Search"
        '
        'PlayerLbl
        '
        Me.PlayerLbl.AutoSize = True
        Me.PlayerLbl.Location = New System.Drawing.Point(453, 107)
        Me.PlayerLbl.Name = "PlayerLbl"
        Me.PlayerLbl.Size = New System.Drawing.Size(41, 13)
        Me.PlayerLbl.TabIndex = 7
        Me.PlayerLbl.Text = "Players"
        '
        'PlayerListBox
        '
        Me.PlayerListBox.FormattingEnabled = True
        Me.PlayerListBox.Location = New System.Drawing.Point(461, 142)
        Me.PlayerListBox.Name = "PlayerListBox"
        Me.PlayerListBox.Size = New System.Drawing.Size(180, 225)
        Me.PlayerListBox.TabIndex = 8
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 400)
        Me.Controls.Add(Me.PlayerListBox)
        Me.Controls.Add(Me.PlayerLbl)
        Me.Controls.Add(Me.SearchGroup)
        Me.Controls.Add(Me.BaseballBindingNavigator)
        Me.Controls.Add(Me.PlayerDataGrid)
        Me.Name = "MainForm"
        Me.Text = "Baseball Statistics"
        CType(Me.PlayerDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlayerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BaseballBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BaseballBindingNavigator.ResumeLayout(False)
        Me.BaseballBindingNavigator.PerformLayout()
        Me.SearchGroup.ResumeLayout(False)
        Me.SearchGroup.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PlayerDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents fName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bAvg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BaseballBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BaseballBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents PlayerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SubmitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PlayerIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FirstNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BattingAverageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents submitBtn As System.Windows.Forms.Button
    Friend WithEvents LastNameLbl As System.Windows.Forms.Label
    Friend WithEvents SearchGroup As System.Windows.Forms.GroupBox
    Friend WithEvents PlayerLbl As System.Windows.Forms.Label
    Friend WithEvents PlayerListBox As System.Windows.Forms.ListBox

End Class
