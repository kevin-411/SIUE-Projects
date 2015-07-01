<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InsertNewFacility
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
        Dim FacilityIdLabel As System.Windows.Forms.Label
        Dim DescriptionLabel As System.Windows.Forms.Label
        Dim WebsiteLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim CityLabel As System.Windows.Forms.Label
        Dim StateLabel As System.Windows.Forms.Label
        Dim StreetLabel As System.Windows.Forms.Label
        Dim ZipCodeLabel As System.Windows.Forms.Label
        Dim LatitudeLabel As System.Windows.Forms.Label
        Dim LongitudeLabel As System.Windows.Forms.Label
        Me.CS434DataSet = New WindowsApplication1.CS434DataSet()
        Me.AirportFacilityTableAdapter = New WindowsApplication1.CS434DataSetTableAdapters.AirportFacilityTableAdapter()
        Me.TableAdapterManager = New WindowsApplication1.CS434DataSetTableAdapters.TableAdapterManager()
        Me.AirportIdLabel = New System.Windows.Forms.Label()
        Me.AirportIdTextBox = New System.Windows.Forms.TextBox()
        Me.FacilityIdTextBox = New System.Windows.Forms.TextBox()
        Me.NumTerminalsLabel = New System.Windows.Forms.Label()
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.WebsiteTextBox = New System.Windows.Forms.TextBox()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.StreetTextBox = New System.Windows.Forms.TextBox()
        Me.ZipCodeTextBox = New System.Windows.Forms.TextBox()
        Me.MainLabel = New System.Windows.Forms.Label()
        Me.AddButton = New System.Windows.Forms.Button()
        Me.stateComboBox = New System.Windows.Forms.ComboBox()
        Me.cityComboBox = New System.Windows.Forms.ComboBox()
        Me.LatitudeNumericChooser = New System.Windows.Forms.NumericUpDown()
        Me.LongitudeNumericChooser = New System.Windows.Forms.NumericUpDown()
        Me.NumTerminalsNumericChooser = New System.Windows.Forms.NumericUpDown()
        Me.AmtrakFacilityTableAdapter = New WindowsApplication1.CS434DataSetTableAdapters.AmtrakFacilityTableAdapter()
        Me.HasLocationTableTableAdapter = New WindowsApplication1.CS434DataSetTableAdapters.HasLocationTableTableAdapter()
        Me.LocationTableTableAdapter = New WindowsApplication1.CS434DataSetTableAdapters.LocationTableTableAdapter()
        Me.FacilityTableTableAdapter = New WindowsApplication1.CS434DataSetTableAdapters.FacilityTableTableAdapter()
        FacilityIdLabel = New System.Windows.Forms.Label()
        DescriptionLabel = New System.Windows.Forms.Label()
        WebsiteLabel = New System.Windows.Forms.Label()
        NameLabel = New System.Windows.Forms.Label()
        CityLabel = New System.Windows.Forms.Label()
        StateLabel = New System.Windows.Forms.Label()
        StreetLabel = New System.Windows.Forms.Label()
        ZipCodeLabel = New System.Windows.Forms.Label()
        LatitudeLabel = New System.Windows.Forms.Label()
        LongitudeLabel = New System.Windows.Forms.Label()
        CType(Me.CS434DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LatitudeNumericChooser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LongitudeNumericChooser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumTerminalsNumericChooser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FacilityIdLabel
        '
        FacilityIdLabel.AutoSize = True
        FacilityIdLabel.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FacilityIdLabel.Location = New System.Drawing.Point(58, 57)
        FacilityIdLabel.Name = "FacilityIdLabel"
        FacilityIdLabel.Size = New System.Drawing.Size(76, 18)
        FacilityIdLabel.TabIndex = 3
        FacilityIdLabel.Text = "Facility Id:"
        '
        'DescriptionLabel
        '
        DescriptionLabel.AutoSize = True
        DescriptionLabel.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DescriptionLabel.Location = New System.Drawing.Point(52, 144)
        DescriptionLabel.Name = "DescriptionLabel"
        DescriptionLabel.Size = New System.Drawing.Size(82, 18)
        DescriptionLabel.TabIndex = 7
        DescriptionLabel.Text = "Description:"
        '
        'WebsiteLabel
        '
        WebsiteLabel.AutoSize = True
        WebsiteLabel.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        WebsiteLabel.Location = New System.Drawing.Point(71, 173)
        WebsiteLabel.Name = "WebsiteLabel"
        WebsiteLabel.Size = New System.Drawing.Size(63, 18)
        WebsiteLabel.TabIndex = 9
        WebsiteLabel.Text = "Website:"
        '
        'NameLabel
        '
        NameLabel.AutoSize = True
        NameLabel.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameLabel.Location = New System.Drawing.Point(70, 202)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(64, 18)
        NameLabel.TabIndex = 11
        NameLabel.Text = "Name(*):"
        '
        'CityLabel
        '
        CityLabel.AutoSize = True
        CityLabel.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CityLabel.Location = New System.Drawing.Point(80, 231)
        CityLabel.Name = "CityLabel"
        CityLabel.Size = New System.Drawing.Size(54, 18)
        CityLabel.TabIndex = 15
        CityLabel.Text = "City(*):"
        '
        'StateLabel
        '
        StateLabel.AutoSize = True
        StateLabel.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        StateLabel.Location = New System.Drawing.Point(71, 258)
        StateLabel.Name = "StateLabel"
        StateLabel.Size = New System.Drawing.Size(63, 18)
        StateLabel.TabIndex = 17
        StateLabel.Text = "State(*):"
        '
        'StreetLabel
        '
        StreetLabel.AutoSize = True
        StreetLabel.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        StreetLabel.Location = New System.Drawing.Point(66, 285)
        StreetLabel.Name = "StreetLabel"
        StreetLabel.Size = New System.Drawing.Size(68, 18)
        StreetLabel.TabIndex = 19
        StreetLabel.Text = "Street(*):"
        '
        'ZipCodeLabel
        '
        ZipCodeLabel.AutoSize = True
        ZipCodeLabel.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ZipCodeLabel.Location = New System.Drawing.Point(51, 314)
        ZipCodeLabel.Name = "ZipCodeLabel"
        ZipCodeLabel.Size = New System.Drawing.Size(83, 18)
        ZipCodeLabel.TabIndex = 21
        ZipCodeLabel.Text = "Zip Code(*):"
        '
        'LatitudeLabel
        '
        LatitudeLabel.AutoSize = True
        LatitudeLabel.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LatitudeLabel.Location = New System.Drawing.Point(52, 343)
        LatitudeLabel.Name = "LatitudeLabel"
        LatitudeLabel.Size = New System.Drawing.Size(82, 18)
        LatitudeLabel.TabIndex = 23
        LatitudeLabel.Text = "Latitude(*):"
        '
        'LongitudeLabel
        '
        LongitudeLabel.AutoSize = True
        LongitudeLabel.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LongitudeLabel.Location = New System.Drawing.Point(45, 369)
        LongitudeLabel.Name = "LongitudeLabel"
        LongitudeLabel.Size = New System.Drawing.Size(89, 18)
        LongitudeLabel.TabIndex = 25
        LongitudeLabel.Text = "Longitude(*):"
        '
        'CS434DataSet
        '
        Me.CS434DataSet.DataSetName = "CS434DataSet"
        Me.CS434DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AirportFacilityTableAdapter
        '
        Me.AirportFacilityTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager._1062594333_T_TRANSNET_FACILITY__TableAdapter = Nothing
        Me.TableAdapterManager.AirportTableTableAdapter = Nothing
        Me.TableAdapterManager.AmtrakTableTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
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
        'AirportIdLabel
        '
        Me.AirportIdLabel.AutoSize = True
        Me.AirportIdLabel.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AirportIdLabel.Location = New System.Drawing.Point(44, 86)
        Me.AirportIdLabel.Name = "AirportIdLabel"
        Me.AirportIdLabel.Size = New System.Drawing.Size(90, 18)
        Me.AirportIdLabel.TabIndex = 1
        Me.AirportIdLabel.Text = "Airport Id(*):"
        '
        'AirportIdTextBox
        '
        Me.AirportIdTextBox.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AirportIdTextBox.Location = New System.Drawing.Point(140, 86)
        Me.AirportIdTextBox.Name = "AirportIdTextBox"
        Me.AirportIdTextBox.Size = New System.Drawing.Size(117, 23)
        Me.AirportIdTextBox.TabIndex = 2
        '
        'FacilityIdTextBox
        '
        Me.FacilityIdTextBox.Enabled = False
        Me.FacilityIdTextBox.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FacilityIdTextBox.Location = New System.Drawing.Point(140, 57)
        Me.FacilityIdTextBox.Name = "FacilityIdTextBox"
        Me.FacilityIdTextBox.Size = New System.Drawing.Size(117, 23)
        Me.FacilityIdTextBox.TabIndex = 4
        '
        'NumTerminalsLabel
        '
        Me.NumTerminalsLabel.AutoSize = True
        Me.NumTerminalsLabel.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumTerminalsLabel.Location = New System.Drawing.Point(12, 114)
        Me.NumTerminalsLabel.Name = "NumTerminalsLabel"
        Me.NumTerminalsLabel.Size = New System.Drawing.Size(122, 18)
        Me.NumTerminalsLabel.TabIndex = 5
        Me.NumTerminalsLabel.Text = "Num Terminals(*):"
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DescriptionTextBox.Location = New System.Drawing.Point(140, 144)
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.Size = New System.Drawing.Size(224, 23)
        Me.DescriptionTextBox.TabIndex = 8
        '
        'WebsiteTextBox
        '
        Me.WebsiteTextBox.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WebsiteTextBox.Location = New System.Drawing.Point(140, 173)
        Me.WebsiteTextBox.Name = "WebsiteTextBox"
        Me.WebsiteTextBox.Size = New System.Drawing.Size(224, 23)
        Me.WebsiteTextBox.TabIndex = 10
        '
        'NameTextBox
        '
        Me.NameTextBox.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameTextBox.Location = New System.Drawing.Point(140, 202)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(224, 23)
        Me.NameTextBox.TabIndex = 12
        '
        'StreetTextBox
        '
        Me.StreetTextBox.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StreetTextBox.Location = New System.Drawing.Point(140, 285)
        Me.StreetTextBox.Name = "StreetTextBox"
        Me.StreetTextBox.Size = New System.Drawing.Size(224, 23)
        Me.StreetTextBox.TabIndex = 20
        '
        'ZipCodeTextBox
        '
        Me.ZipCodeTextBox.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZipCodeTextBox.Location = New System.Drawing.Point(140, 314)
        Me.ZipCodeTextBox.Name = "ZipCodeTextBox"
        Me.ZipCodeTextBox.Size = New System.Drawing.Size(117, 23)
        Me.ZipCodeTextBox.TabIndex = 22
        '
        'MainLabel
        '
        Me.MainLabel.AutoSize = True
        Me.MainLabel.Font = New System.Drawing.Font("Trebuchet MS", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainLabel.Location = New System.Drawing.Point(60, 9)
        Me.MainLabel.Name = "MainLabel"
        Me.MainLabel.Size = New System.Drawing.Size(278, 37)
        Me.MainLabel.TabIndex = 27
        Me.MainLabel.Text = "New Airport Facility"
        '
        'AddButton
        '
        Me.AddButton.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddButton.Location = New System.Drawing.Point(276, 369)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.Size = New System.Drawing.Size(108, 28)
        Me.AddButton.TabIndex = 28
        Me.AddButton.Text = "Add Facility"
        Me.AddButton.UseVisualStyleBackColor = True
        '
        'stateComboBox
        '
        Me.stateComboBox.FormattingEnabled = True
        Me.stateComboBox.Location = New System.Drawing.Point(140, 258)
        Me.stateComboBox.Name = "stateComboBox"
        Me.stateComboBox.Size = New System.Drawing.Size(117, 21)
        Me.stateComboBox.TabIndex = 29
        '
        'cityComboBox
        '
        Me.cityComboBox.FormattingEnabled = True
        Me.cityComboBox.Location = New System.Drawing.Point(140, 231)
        Me.cityComboBox.Name = "cityComboBox"
        Me.cityComboBox.Size = New System.Drawing.Size(117, 21)
        Me.cityComboBox.TabIndex = 30
        '
        'LatitudeNumericChooser
        '
        Me.LatitudeNumericChooser.DecimalPlaces = 4
        Me.LatitudeNumericChooser.Location = New System.Drawing.Point(140, 343)
        Me.LatitudeNumericChooser.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.LatitudeNumericChooser.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.LatitudeNumericChooser.Name = "LatitudeNumericChooser"
        Me.LatitudeNumericChooser.Size = New System.Drawing.Size(117, 20)
        Me.LatitudeNumericChooser.TabIndex = 31
        '
        'LongitudeNumericChooser
        '
        Me.LongitudeNumericChooser.DecimalPlaces = 4
        Me.LongitudeNumericChooser.Location = New System.Drawing.Point(140, 369)
        Me.LongitudeNumericChooser.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.LongitudeNumericChooser.Minimum = New Decimal(New Integer() {180, 0, 0, -2147483648})
        Me.LongitudeNumericChooser.Name = "LongitudeNumericChooser"
        Me.LongitudeNumericChooser.Size = New System.Drawing.Size(117, 20)
        Me.LongitudeNumericChooser.TabIndex = 32
        '
        'NumTerminalsNumericChooser
        '
        Me.NumTerminalsNumericChooser.Location = New System.Drawing.Point(140, 115)
        Me.NumTerminalsNumericChooser.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumTerminalsNumericChooser.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumTerminalsNumericChooser.Name = "NumTerminalsNumericChooser"
        Me.NumTerminalsNumericChooser.Size = New System.Drawing.Size(54, 20)
        Me.NumTerminalsNumericChooser.TabIndex = 33
        Me.NumTerminalsNumericChooser.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'AmtrakFacilityTableAdapter
        '
        Me.AmtrakFacilityTableAdapter.ClearBeforeFill = True
        '
        'HasLocationTableTableAdapter
        '
        Me.HasLocationTableTableAdapter.ClearBeforeFill = True
        '
        'LocationTableTableAdapter
        '
        Me.LocationTableTableAdapter.ClearBeforeFill = True
        '
        'FacilityTableTableAdapter
        '
        Me.FacilityTableTableAdapter.ClearBeforeFill = True
        '
        'InsertNewFacility
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(396, 411)
        Me.Controls.Add(Me.NumTerminalsNumericChooser)
        Me.Controls.Add(Me.LongitudeNumericChooser)
        Me.Controls.Add(Me.LatitudeNumericChooser)
        Me.Controls.Add(Me.cityComboBox)
        Me.Controls.Add(Me.stateComboBox)
        Me.Controls.Add(Me.AddButton)
        Me.Controls.Add(Me.MainLabel)
        Me.Controls.Add(Me.AirportIdLabel)
        Me.Controls.Add(Me.AirportIdTextBox)
        Me.Controls.Add(FacilityIdLabel)
        Me.Controls.Add(Me.FacilityIdTextBox)
        Me.Controls.Add(Me.NumTerminalsLabel)
        Me.Controls.Add(DescriptionLabel)
        Me.Controls.Add(Me.DescriptionTextBox)
        Me.Controls.Add(WebsiteLabel)
        Me.Controls.Add(Me.WebsiteTextBox)
        Me.Controls.Add(NameLabel)
        Me.Controls.Add(Me.NameTextBox)
        Me.Controls.Add(CityLabel)
        Me.Controls.Add(StateLabel)
        Me.Controls.Add(StreetLabel)
        Me.Controls.Add(Me.StreetTextBox)
        Me.Controls.Add(ZipCodeLabel)
        Me.Controls.Add(Me.ZipCodeTextBox)
        Me.Controls.Add(LatitudeLabel)
        Me.Controls.Add(LongitudeLabel)
        Me.Name = "InsertNewFacility"
        Me.Text = "New Facility"
        CType(Me.CS434DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LatitudeNumericChooser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LongitudeNumericChooser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumTerminalsNumericChooser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CS434DataSet As WindowsApplication1.CS434DataSet
    Friend WithEvents AirportFacilityTableAdapter As WindowsApplication1.CS434DataSetTableAdapters.AirportFacilityTableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.CS434DataSetTableAdapters.TableAdapterManager
    Friend WithEvents AirportIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FacilityIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents WebsiteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StreetTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ZipCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MainLabel As System.Windows.Forms.Label
    Friend WithEvents AirportIdLabel As System.Windows.Forms.Label
    Friend WithEvents NumTerminalsLabel As System.Windows.Forms.Label
    Friend WithEvents AddButton As System.Windows.Forms.Button
    Friend WithEvents stateComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents cityComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents LatitudeNumericChooser As System.Windows.Forms.NumericUpDown
    Friend WithEvents LongitudeNumericChooser As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumTerminalsNumericChooser As System.Windows.Forms.NumericUpDown
    Friend WithEvents AmtrakFacilityTableAdapter As WindowsApplication1.CS434DataSetTableAdapters.AmtrakFacilityTableAdapter
    Friend WithEvents HasLocationTableTableAdapter As WindowsApplication1.CS434DataSetTableAdapters.HasLocationTableTableAdapter
    Friend WithEvents LocationTableTableAdapter As WindowsApplication1.CS434DataSetTableAdapters.LocationTableTableAdapter
    Friend WithEvents FacilityTableTableAdapter As WindowsApplication1.CS434DataSetTableAdapters.FacilityTableTableAdapter
End Class
