<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POP))
        Me.CS434DataSet = New WindowsApplication1.CS434DataSet()
        Me.CBSABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CBSATableAdapter = New WindowsApplication1.CS434DataSetTableAdapters.CBSATableAdapter()
        Me.TableAdapterManager = New WindowsApplication1.CS434DataSetTableAdapters.TableAdapterManager()
        Me.CBSABindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.CBSABindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.CBSADataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PopulationTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PopulationTableTableAdapter = New WindowsApplication1.CS434DataSetTableAdapters.PopulationTableTableAdapter()
        CType(Me.CS434DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CBSABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CBSABindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CBSABindingNavigator.SuspendLayout()
        CType(Me.CBSADataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopulationTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CS434DataSet
        '
        Me.CS434DataSet.DataSetName = "CS434DataSet"
        Me.CS434DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CBSABindingSource
        '
        Me.CBSABindingSource.DataMember = "CBSA"
        Me.CBSABindingSource.DataSource = Me.CS434DataSet
        '
        'CBSATableAdapter
        '
        Me.CBSATableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager._1062594333_T_TRANSNET_FACILITY__TableAdapter = Nothing
        Me.TableAdapterManager.AirportTableTableAdapter = Nothing
        Me.TableAdapterManager.AmtrakTableTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CBSATableAdapter = Me.CBSATableAdapter
        Me.TableAdapterManager.Facility_LocationsTableAdapter = Nothing
        Me.TableAdapterManager.FacilityTableTableAdapter = Nothing
        Me.TableAdapterManager.FerriesTableTableAdapter = Nothing
        Me.TableAdapterManager.HasAServiceTableTableAdapter = Nothing
        Me.TableAdapterManager.HasLocationTableTableAdapter = Nothing
        Me.TableAdapterManager.HasPlanesTableTableAdapter = Nothing
        Me.TableAdapterManager.HasRailCarTableTableAdapter = Nothing
        Me.TableAdapterManager.LocationTableTableAdapter = Nothing
        Me.TableAdapterManager.PlaneTableTableAdapter = Nothing
        Me.TableAdapterManager.PopulationTableTableAdapter = Me.PopulationTableTableAdapter
        Me.TableAdapterManager.RailCarTableTableAdapter = Nothing
        Me.TableAdapterManager.ServiceTableTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = WindowsApplication1.CS434DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CBSABindingNavigator
        '
        Me.CBSABindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.CBSABindingNavigator.BindingSource = Me.CBSABindingSource
        Me.CBSABindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.CBSABindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.CBSABindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.CBSABindingNavigatorSaveItem})
        Me.CBSABindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.CBSABindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.CBSABindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.CBSABindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.CBSABindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.CBSABindingNavigator.Name = "CBSABindingNavigator"
        Me.CBSABindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.CBSABindingNavigator.Size = New System.Drawing.Size(398, 25)
        Me.CBSABindingNavigator.TabIndex = 0
        Me.CBSABindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 15)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'CBSABindingNavigatorSaveItem
        '
        Me.CBSABindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CBSABindingNavigatorSaveItem.Image = CType(resources.GetObject("CBSABindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.CBSABindingNavigatorSaveItem.Name = "CBSABindingNavigatorSaveItem"
        Me.CBSABindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 23)
        Me.CBSABindingNavigatorSaveItem.Text = "Save Data"
        '
        'CBSADataGridView
        '
        Me.CBSADataGridView.AutoGenerateColumns = False
        Me.CBSADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CBSADataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.CBSADataGridView.DataSource = Me.CBSABindingSource
        Me.CBSADataGridView.Location = New System.Drawing.Point(12, 82)
        Me.CBSADataGridView.Name = "CBSADataGridView"
        Me.CBSADataGridView.Size = New System.Drawing.Size(346, 324)
        Me.CBSADataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "CBSA_Code"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CBSA_Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Location"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Location"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Population"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Population"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'PopulationTableBindingSource
        '
        Me.PopulationTableBindingSource.DataMember = "PopulationTable"
        Me.PopulationTableBindingSource.DataSource = Me.CS434DataSet
        '
        'PopulationTableTableAdapter
        '
        Me.PopulationTableTableAdapter.ClearBeforeFill = True
        '
        'POP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 418)
        Me.Controls.Add(Me.CBSADataGridView)
        Me.Controls.Add(Me.CBSABindingNavigator)
        Me.Name = "POP"
        Me.Text = "Form1"
        CType(Me.CS434DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CBSABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CBSABindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CBSABindingNavigator.ResumeLayout(False)
        Me.CBSABindingNavigator.PerformLayout()
        CType(Me.CBSADataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopulationTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CS434DataSet As WindowsApplication1.CS434DataSet
    Friend WithEvents CBSABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CBSATableAdapter As WindowsApplication1.CS434DataSetTableAdapters.CBSATableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.CS434DataSetTableAdapters.TableAdapterManager
    Friend WithEvents CBSABindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CBSABindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents CBSADataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PopulationTableTableAdapter As WindowsApplication1.CS434DataSetTableAdapters.PopulationTableTableAdapter
    Friend WithEvents PopulationTableBindingSource As System.Windows.Forms.BindingSource
End Class
