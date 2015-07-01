<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainFrm
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
        Dim DescriptionLabel As System.Windows.Forms.Label
        Dim DescriptionLabel1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainFrm))
        Me.CS434DataSet = New WindowsApplication1.CS434DataSet()
        Me.TableAdapterManager = New WindowsApplication1.CS434DataSetTableAdapters.TableAdapterManager()
        Me.AirportFacilityBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AirportFacilityTableAdapter = New WindowsApplication1.CS434DataSetTableAdapters.AirportFacilityTableAdapter()
        Me.AirportFacilityDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AmtrakFacilityBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AmtrakFacilityTableAdapter = New WindowsApplication1.CS434DataSetTableAdapters.AmtrakFacilityTableAdapter()
        Me.AmtrakFacilityDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AirportControlPanel = New System.Windows.Forms.Panel()
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.CityLabel = New System.Windows.Forms.Label()
        Me.StateLabel = New System.Windows.Forms.Label()
        Me.CityComboBox = New System.Windows.Forms.ComboBox()
        Me.StateComboBox = New System.Windows.Forms.ComboBox()
        Me.AirportFacilityBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MainFrmLbl = New System.Windows.Forms.Label()
        Me.AirportLbl = New System.Windows.Forms.Label()
        Me.StateLabel1 = New System.Windows.Forms.Label()
        Me.AmtrakLbl = New System.Windows.Forms.Label()
        Me.CityLabel1 = New System.Windows.Forms.Label()
        Me.CityComboBox1 = New System.Windows.Forms.ComboBox()
        Me.StateComboBox1 = New System.Windows.Forms.ComboBox()
        Me.AmtrakFacilityBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.AmtrakControlPanel = New System.Windows.Forms.Panel()
        Me.DescriptionTextBox1 = New System.Windows.Forms.TextBox()
        Me.NewAirportButton = New System.Windows.Forms.Button()
        Me.UpdateDeleteAirportButton = New System.Windows.Forms.Button()
        Me.UpdateDeleteAmtrakButton = New System.Windows.Forms.Button()
        Me.NewAmtrakButton = New System.Windows.Forms.Button()
        DescriptionLabel = New System.Windows.Forms.Label()
        DescriptionLabel1 = New System.Windows.Forms.Label()
        CType(Me.CS434DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AirportFacilityBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AirportFacilityDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmtrakFacilityBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmtrakFacilityDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AirportControlPanel.SuspendLayout()
        CType(Me.AirportFacilityBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AirportFacilityBindingNavigator.SuspendLayout()
        CType(Me.AmtrakFacilityBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AmtrakFacilityBindingNavigator.SuspendLayout()
        Me.AmtrakControlPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'DescriptionLabel
        '
        DescriptionLabel.AutoSize = True
        DescriptionLabel.Location = New System.Drawing.Point(471, 7)
        DescriptionLabel.Name = "DescriptionLabel"
        DescriptionLabel.Size = New System.Drawing.Size(63, 13)
        DescriptionLabel.TabIndex = 10
        DescriptionLabel.Text = "Description:"
        '
        'DescriptionLabel1
        '
        DescriptionLabel1.AutoSize = True
        DescriptionLabel1.Location = New System.Drawing.Point(472, 8)
        DescriptionLabel1.Name = "DescriptionLabel1"
        DescriptionLabel1.Size = New System.Drawing.Size(63, 13)
        DescriptionLabel1.TabIndex = 10
        DescriptionLabel1.Text = "Description:"
        '
        'CS434DataSet
        '
        Me.CS434DataSet.DataSetName = "CS434DataSet"
        Me.CS434DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager._1062594333_T_TRANSNET_FACILITY__TableAdapter = Nothing
        Me.TableAdapterManager.AirportTableTableAdapter = Nothing
        Me.TableAdapterManager.AmtrakTableTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CBSATableAdapter = Nothing
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.Facility_LocationsTableAdapter = Nothing
        Me.TableAdapterManager.FacilityTableTableAdapter = Nothing
        Me.TableAdapterManager.FerriesTableTableAdapter = Nothing
        Me.TableAdapterManager.HasAServiceTableTableAdapter = Nothing
        Me.TableAdapterManager.HasLocationTableTableAdapter = Nothing
        Me.TableAdapterManager.HasPlanesTableTableAdapter = Nothing
        Me.TableAdapterManager.HasRailCarTableTableAdapter = Nothing
        Me.TableAdapterManager.LocationTableTableAdapter = Nothing
        Me.TableAdapterManager.PlaneTableTableAdapter = Nothing
        Me.TableAdapterManager.PopulationTableTableAdapter = Nothing
        Me.TableAdapterManager.RailCarTableTableAdapter = Nothing
        Me.TableAdapterManager.ServiceTableTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = WindowsApplication1.CS434DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'AirportFacilityBindingSource
        '
        Me.AirportFacilityBindingSource.DataMember = "AirportFacility"
        Me.AirportFacilityBindingSource.DataSource = Me.CS434DataSet
        '
        'AirportFacilityTableAdapter
        '
        Me.AirportFacilityTableAdapter.ClearBeforeFill = True
        '
        'AirportFacilityDataGridView
        '
        Me.AirportFacilityDataGridView.AllowUserToAddRows = False
        Me.AirportFacilityDataGridView.AllowUserToDeleteRows = False
        Me.AirportFacilityDataGridView.AllowUserToResizeRows = False
        Me.AirportFacilityDataGridView.AutoGenerateColumns = False
        Me.AirportFacilityDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AirportFacilityDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn4})
        Me.AirportFacilityDataGridView.DataSource = Me.AirportFacilityBindingSource
        Me.AirportFacilityDataGridView.Location = New System.Drawing.Point(0, 89)
        Me.AirportFacilityDataGridView.MultiSelect = False
        Me.AirportFacilityDataGridView.Name = "AirportFacilityDataGridView"
        Me.AirportFacilityDataGridView.ReadOnly = True
        Me.AirportFacilityDataGridView.RowHeadersVisible = False
        Me.AirportFacilityDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.AirportFacilityDataGridView.Size = New System.Drawing.Size(1183, 220)
        Me.AirportFacilityDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Name"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "AirportId"
        Me.DataGridViewTextBoxColumn1.HeaderText = "AirportId"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "FacilityId"
        Me.DataGridViewTextBoxColumn2.HeaderText = "FacilityId"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "NumTerminals"
        Me.DataGridViewTextBoxColumn3.HeaderText = "NumTerminals"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Website"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Website"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "FacilityType"
        Me.DataGridViewTextBoxColumn8.HeaderText = "FacilityType"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Street"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Street"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "City"
        Me.DataGridViewTextBoxColumn10.HeaderText = "City"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "State"
        Me.DataGridViewTextBoxColumn11.HeaderText = "State"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "ZipCode"
        Me.DataGridViewTextBoxColumn13.HeaderText = "ZipCode"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Description"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 180
        '
        'AmtrakFacilityBindingSource
        '
        Me.AmtrakFacilityBindingSource.DataMember = "AmtrakFacility"
        Me.AmtrakFacilityBindingSource.DataSource = Me.CS434DataSet
        '
        'AmtrakFacilityTableAdapter
        '
        Me.AmtrakFacilityTableAdapter.ClearBeforeFill = True
        '
        'AmtrakFacilityDataGridView
        '
        Me.AmtrakFacilityDataGridView.AllowUserToAddRows = False
        Me.AmtrakFacilityDataGridView.AllowUserToDeleteRows = False
        Me.AmtrakFacilityDataGridView.AllowUserToResizeRows = False
        Me.AmtrakFacilityDataGridView.AutoGenerateColumns = False
        Me.AmtrakFacilityDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AmtrakFacilityDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewTextBoxColumn15})
        Me.AmtrakFacilityDataGridView.DataSource = Me.AmtrakFacilityBindingSource
        Me.AmtrakFacilityDataGridView.Location = New System.Drawing.Point(0, 352)
        Me.AmtrakFacilityDataGridView.MultiSelect = False
        Me.AmtrakFacilityDataGridView.Name = "AmtrakFacilityDataGridView"
        Me.AmtrakFacilityDataGridView.ReadOnly = True
        Me.AmtrakFacilityDataGridView.RowHeadersVisible = False
        Me.AmtrakFacilityDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.AmtrakFacilityDataGridView.Size = New System.Drawing.Size(1183, 220)
        Me.AmtrakFacilityDataGridView.TabIndex = 6
        Me.AmtrakFacilityDataGridView.Tag = "1"
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "Name"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "AmtrakId"
        Me.DataGridViewTextBoxColumn19.HeaderText = "AmtrakId"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "FacilityId"
        Me.DataGridViewTextBoxColumn14.HeaderText = "FacilityId"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "NumAmtraks"
        Me.DataGridViewTextBoxColumn20.HeaderText = "NumAmtraks"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "Website"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Website"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "FacilityType"
        Me.DataGridViewTextBoxColumn18.HeaderText = "FacilityType"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "Street"
        Me.DataGridViewTextBoxColumn23.HeaderText = "Street"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "City"
        Me.DataGridViewTextBoxColumn24.HeaderText = "City"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "State"
        Me.DataGridViewTextBoxColumn25.HeaderText = "State"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "ZipCode"
        Me.DataGridViewTextBoxColumn26.HeaderText = "ZipCode"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "Description"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 180
        '
        'AirportControlPanel
        '
        Me.AirportControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AirportControlPanel.Controls.Add(Me.DescriptionTextBox)
        Me.AirportControlPanel.Controls.Add(DescriptionLabel)
        Me.AirportControlPanel.Controls.Add(Me.CityLabel)
        Me.AirportControlPanel.Controls.Add(Me.StateLabel)
        Me.AirportControlPanel.Controls.Add(Me.CityComboBox)
        Me.AirportControlPanel.Controls.Add(Me.StateComboBox)
        Me.AirportControlPanel.Controls.Add(Me.AirportFacilityBindingNavigator)
        Me.AirportControlPanel.Location = New System.Drawing.Point(185, 56)
        Me.AirportControlPanel.Name = "AirportControlPanel"
        Me.AirportControlPanel.Size = New System.Drawing.Size(749, 27)
        Me.AirportControlPanel.TabIndex = 7
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.DescriptionTextBox.Location = New System.Drawing.Point(531, 3)
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.Size = New System.Drawing.Size(211, 20)
        Me.DescriptionTextBox.TabIndex = 11
        Me.DescriptionTextBox.Text = "Search for words in description..."
        '
        'CityLabel
        '
        Me.CityLabel.AutoSize = True
        Me.CityLabel.Location = New System.Drawing.Point(316, 6)
        Me.CityLabel.Name = "CityLabel"
        Me.CityLabel.Size = New System.Drawing.Size(27, 13)
        Me.CityLabel.TabIndex = 10
        Me.CityLabel.Text = "City:"
        '
        'StateLabel
        '
        Me.StateLabel.AutoSize = True
        Me.StateLabel.Location = New System.Drawing.Point(224, 6)
        Me.StateLabel.Name = "StateLabel"
        Me.StateLabel.Size = New System.Drawing.Size(35, 13)
        Me.StateLabel.TabIndex = 9
        Me.StateLabel.Text = "State:"
        '
        'CityComboBox
        '
        Me.CityComboBox.FormattingEnabled = True
        Me.CityComboBox.Location = New System.Drawing.Point(344, 4)
        Me.CityComboBox.Name = "CityComboBox"
        Me.CityComboBox.Size = New System.Drawing.Size(121, 21)
        Me.CityComboBox.TabIndex = 8
        '
        'StateComboBox
        '
        Me.StateComboBox.FormattingEnabled = True
        Me.StateComboBox.Location = New System.Drawing.Point(262, 3)
        Me.StateComboBox.Name = "StateComboBox"
        Me.StateComboBox.Size = New System.Drawing.Size(48, 21)
        Me.StateComboBox.TabIndex = 7
        '
        'AirportFacilityBindingNavigator
        '
        Me.AirportFacilityBindingNavigator.AddNewItem = Nothing
        Me.AirportFacilityBindingNavigator.BindingSource = Me.AirportFacilityBindingSource
        Me.AirportFacilityBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.AirportFacilityBindingNavigator.DeleteItem = Nothing
        Me.AirportFacilityBindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.AirportFacilityBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.AirportFacilityBindingNavigator.Location = New System.Drawing.Point(6, 1)
        Me.AirportFacilityBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.AirportFacilityBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.AirportFacilityBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.AirportFacilityBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.AirportFacilityBindingNavigator.Name = "AirportFacilityBindingNavigator"
        Me.AirportFacilityBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.AirportFacilityBindingNavigator.Size = New System.Drawing.Size(209, 25)
        Me.AirportFacilityBindingNavigator.TabIndex = 6
        Me.AirportFacilityBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
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
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'MainFrmLbl
        '
        Me.MainFrmLbl.AutoSize = True
        Me.MainFrmLbl.Font = New System.Drawing.Font("Trebuchet MS", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainFrmLbl.Location = New System.Drawing.Point(505, 13)
        Me.MainFrmLbl.Name = "MainFrmLbl"
        Me.MainFrmLbl.Size = New System.Drawing.Size(224, 35)
        Me.MainFrmLbl.TabIndex = 8
        Me.MainFrmLbl.Text = "Facility Tracker"
        '
        'AirportLbl
        '
        Me.AirportLbl.AutoSize = True
        Me.AirportLbl.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AirportLbl.Location = New System.Drawing.Point(12, 56)
        Me.AirportLbl.Name = "AirportLbl"
        Me.AirportLbl.Size = New System.Drawing.Size(167, 27)
        Me.AirportLbl.TabIndex = 9
        Me.AirportLbl.Text = "Airport Tracker"
        '
        'StateLabel1
        '
        Me.StateLabel1.AutoSize = True
        Me.StateLabel1.Location = New System.Drawing.Point(225, 8)
        Me.StateLabel1.Name = "StateLabel1"
        Me.StateLabel1.Size = New System.Drawing.Size(35, 13)
        Me.StateLabel1.TabIndex = 9
        Me.StateLabel1.Text = "State:"
        '
        'AmtrakLbl
        '
        Me.AmtrakLbl.AutoSize = True
        Me.AmtrakLbl.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AmtrakLbl.Location = New System.Drawing.Point(12, 316)
        Me.AmtrakLbl.Name = "AmtrakLbl"
        Me.AmtrakLbl.Size = New System.Drawing.Size(166, 27)
        Me.AmtrakLbl.TabIndex = 11
        Me.AmtrakLbl.Text = "Amtrak Tracker"
        '
        'CityLabel1
        '
        Me.CityLabel1.AutoSize = True
        Me.CityLabel1.Location = New System.Drawing.Point(317, 8)
        Me.CityLabel1.Name = "CityLabel1"
        Me.CityLabel1.Size = New System.Drawing.Size(27, 13)
        Me.CityLabel1.TabIndex = 10
        Me.CityLabel1.Text = "City:"
        '
        'CityComboBox1
        '
        Me.CityComboBox1.FormattingEnabled = True
        Me.CityComboBox1.Location = New System.Drawing.Point(345, 4)
        Me.CityComboBox1.Name = "CityComboBox1"
        Me.CityComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.CityComboBox1.TabIndex = 8
        '
        'StateComboBox1
        '
        Me.StateComboBox1.FormattingEnabled = True
        Me.StateComboBox1.Location = New System.Drawing.Point(263, 4)
        Me.StateComboBox1.Name = "StateComboBox1"
        Me.StateComboBox1.Size = New System.Drawing.Size(48, 21)
        Me.StateComboBox1.TabIndex = 7
        '
        'AmtrakFacilityBindingNavigator
        '
        Me.AmtrakFacilityBindingNavigator.AddNewItem = Nothing
        Me.AmtrakFacilityBindingNavigator.BindingSource = Me.AmtrakFacilityBindingSource
        Me.AmtrakFacilityBindingNavigator.CountItem = Me.ToolStripLabel1
        Me.AmtrakFacilityBindingNavigator.DeleteItem = Nothing
        Me.AmtrakFacilityBindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.AmtrakFacilityBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator3})
        Me.AmtrakFacilityBindingNavigator.Location = New System.Drawing.Point(6, 1)
        Me.AmtrakFacilityBindingNavigator.MoveFirstItem = Me.ToolStripButton1
        Me.AmtrakFacilityBindingNavigator.MoveLastItem = Me.ToolStripButton4
        Me.AmtrakFacilityBindingNavigator.MoveNextItem = Me.ToolStripButton3
        Me.AmtrakFacilityBindingNavigator.MovePreviousItem = Me.ToolStripButton2
        Me.AmtrakFacilityBindingNavigator.Name = "AmtrakFacilityBindingNavigator"
        Me.AmtrakFacilityBindingNavigator.PositionItem = Me.ToolStripTextBox1
        Me.AmtrakFacilityBindingNavigator.Size = New System.Drawing.Size(209, 25)
        Me.AmtrakFacilityBindingNavigator.TabIndex = 6
        Me.AmtrakFacilityBindingNavigator.Text = "BindingNavigator1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel1.Text = "of {0}"
        Me.ToolStripLabel1.ToolTipText = "Total number of items"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Move first"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Move previous"
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
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Move next"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Move last"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'AmtrakControlPanel
        '
        Me.AmtrakControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AmtrakControlPanel.Controls.Add(Me.DescriptionTextBox1)
        Me.AmtrakControlPanel.Controls.Add(DescriptionLabel1)
        Me.AmtrakControlPanel.Controls.Add(Me.CityLabel1)
        Me.AmtrakControlPanel.Controls.Add(Me.StateLabel1)
        Me.AmtrakControlPanel.Controls.Add(Me.CityComboBox1)
        Me.AmtrakControlPanel.Controls.Add(Me.StateComboBox1)
        Me.AmtrakControlPanel.Controls.Add(Me.AmtrakFacilityBindingNavigator)
        Me.AmtrakControlPanel.Location = New System.Drawing.Point(184, 316)
        Me.AmtrakControlPanel.Name = "AmtrakControlPanel"
        Me.AmtrakControlPanel.Size = New System.Drawing.Size(750, 30)
        Me.AmtrakControlPanel.TabIndex = 10
        '
        'DescriptionTextBox1
        '
        Me.DescriptionTextBox1.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.DescriptionTextBox1.Location = New System.Drawing.Point(532, 3)
        Me.DescriptionTextBox1.Name = "DescriptionTextBox1"
        Me.DescriptionTextBox1.Size = New System.Drawing.Size(211, 20)
        Me.DescriptionTextBox1.TabIndex = 12
        Me.DescriptionTextBox1.Text = "Search for words in description..."
        '
        'NewAirportButton
        '
        Me.NewAirportButton.Location = New System.Drawing.Point(940, 52)
        Me.NewAirportButton.Name = "NewAirportButton"
        Me.NewAirportButton.Size = New System.Drawing.Size(112, 30)
        Me.NewAirportButton.TabIndex = 12
        Me.NewAirportButton.Tag = "0"
        Me.NewAirportButton.Text = "New Airport..."
        Me.NewAirportButton.UseVisualStyleBackColor = True
        '
        'UpdateDeleteAirportButton
        '
        Me.UpdateDeleteAirportButton.Location = New System.Drawing.Point(1058, 53)
        Me.UpdateDeleteAirportButton.Name = "UpdateDeleteAirportButton"
        Me.UpdateDeleteAirportButton.Size = New System.Drawing.Size(112, 30)
        Me.UpdateDeleteAirportButton.TabIndex = 13
        Me.UpdateDeleteAirportButton.Tag = "0"
        Me.UpdateDeleteAirportButton.Text = "Update/Delete"
        Me.UpdateDeleteAirportButton.UseVisualStyleBackColor = True
        '
        'UpdateDeleteAmtrakButton
        '
        Me.UpdateDeleteAmtrakButton.Location = New System.Drawing.Point(1058, 318)
        Me.UpdateDeleteAmtrakButton.Name = "UpdateDeleteAmtrakButton"
        Me.UpdateDeleteAmtrakButton.Size = New System.Drawing.Size(112, 30)
        Me.UpdateDeleteAmtrakButton.TabIndex = 15
        Me.UpdateDeleteAmtrakButton.Tag = "1"
        Me.UpdateDeleteAmtrakButton.Text = "Update/Delete"
        Me.UpdateDeleteAmtrakButton.UseVisualStyleBackColor = True
        '
        'NewAmtrakButton
        '
        Me.NewAmtrakButton.Location = New System.Drawing.Point(940, 317)
        Me.NewAmtrakButton.Name = "NewAmtrakButton"
        Me.NewAmtrakButton.Size = New System.Drawing.Size(112, 30)
        Me.NewAmtrakButton.TabIndex = 14
        Me.NewAmtrakButton.Tag = "1"
        Me.NewAmtrakButton.Text = "New Amtrak..."
        Me.NewAmtrakButton.UseVisualStyleBackColor = True
        '
        'MainFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1183, 572)
        Me.Controls.Add(Me.UpdateDeleteAmtrakButton)
        Me.Controls.Add(Me.NewAmtrakButton)
        Me.Controls.Add(Me.UpdateDeleteAirportButton)
        Me.Controls.Add(Me.NewAirportButton)
        Me.Controls.Add(Me.AmtrakLbl)
        Me.Controls.Add(Me.AmtrakControlPanel)
        Me.Controls.Add(Me.AirportLbl)
        Me.Controls.Add(Me.MainFrmLbl)
        Me.Controls.Add(Me.AirportControlPanel)
        Me.Controls.Add(Me.AmtrakFacilityDataGridView)
        Me.Controls.Add(Me.AirportFacilityDataGridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "MainFrm"
        Me.Text = "Facility Tracker"
        CType(Me.CS434DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AirportFacilityBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AirportFacilityDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmtrakFacilityBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmtrakFacilityDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AirportControlPanel.ResumeLayout(False)
        Me.AirportControlPanel.PerformLayout()
        CType(Me.AirportFacilityBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AirportFacilityBindingNavigator.ResumeLayout(False)
        Me.AirportFacilityBindingNavigator.PerformLayout()
        CType(Me.AmtrakFacilityBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AmtrakFacilityBindingNavigator.ResumeLayout(False)
        Me.AmtrakFacilityBindingNavigator.PerformLayout()
        Me.AmtrakControlPanel.ResumeLayout(False)
        Me.AmtrakControlPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CS434DataSet As WindowsApplication1.CS434DataSet
    Friend WithEvents TableAdapterManager As WindowsApplication1.CS434DataSetTableAdapters.TableAdapterManager
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AirportFacilityBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AirportFacilityTableAdapter As WindowsApplication1.CS434DataSetTableAdapters.AirportFacilityTableAdapter
    Friend WithEvents AirportFacilityDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents AmtrakFacilityBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AmtrakFacilityTableAdapter As WindowsApplication1.CS434DataSetTableAdapters.AmtrakFacilityTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmtrakFacilityDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AirportControlPanel As System.Windows.Forms.Panel
    Friend WithEvents CityLabel As System.Windows.Forms.Label
    Friend WithEvents StateLabel As System.Windows.Forms.Label
    Friend WithEvents CityComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents StateComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents AirportFacilityBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MainFrmLbl As System.Windows.Forms.Label
    Friend WithEvents AirportLbl As System.Windows.Forms.Label
    Friend WithEvents StateLabel1 As System.Windows.Forms.Label
    Friend WithEvents AmtrakLbl As System.Windows.Forms.Label
    Friend WithEvents CityLabel1 As System.Windows.Forms.Label
    Friend WithEvents CityComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents StateComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents AmtrakFacilityBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AmtrakControlPanel As System.Windows.Forms.Panel
    Friend WithEvents NewAirportButton As System.Windows.Forms.Button
    Friend WithEvents UpdateDeleteAirportButton As System.Windows.Forms.Button
    Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DescriptionTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents UpdateDeleteAmtrakButton As System.Windows.Forms.Button
    Friend WithEvents NewAmtrakButton As System.Windows.Forms.Button

End Class
