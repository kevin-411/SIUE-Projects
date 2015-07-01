<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Demographics
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
        Me.Label = New System.Windows.Forms.Label()
        Me.CBSACodeLabel = New System.Windows.Forms.Label()
        Me.PerCapitaIncomeLabel = New System.Windows.Forms.Label()
        Me.PopulationLabel = New System.Windows.Forms.Label()
        Me.MedianHousingIncomeLabel = New System.Windows.Forms.Label()
        Me.AvgTravelTimeLabel = New System.Windows.Forms.Label()
        Me.AvgTravelTimeLbl = New System.Windows.Forms.Label()
        Me.MedianHousingIncomeLbl = New System.Windows.Forms.Label()
        Me.PopulationLbl = New System.Windows.Forms.Label()
        Me.PerCapitaIncomeLbl = New System.Windows.Forms.Label()
        Me.CBSA_CodeLbl = New System.Windows.Forms.Label()
        Me.CS434DataSet = New WindowsApplication1.CS434DataSet()
        Me.PopulationTableTableAdapter = New WindowsApplication1.CS434DataSetTableAdapters.PopulationTableTableAdapter()
        Me.TableAdapterManager = New WindowsApplication1.CS434DataSetTableAdapters.TableAdapterManager()
        Me.LocationTableTableAdapter = New WindowsApplication1.CS434DataSetTableAdapters.LocationTableTableAdapter()
        CType(Me.CS434DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Font = New System.Drawing.Font("Trebuchet MS", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label.Location = New System.Drawing.Point(101, 26)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(191, 35)
        Me.Label.TabIndex = 0
        Me.Label.Text = "Demographics"
        '
        'CBSACodeLabel
        '
        Me.CBSACodeLabel.AutoSize = True
        Me.CBSACodeLabel.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBSACodeLabel.Location = New System.Drawing.Point(45, 81)
        Me.CBSACodeLabel.Name = "CBSACodeLabel"
        Me.CBSACodeLabel.Size = New System.Drawing.Size(159, 22)
        Me.CBSACodeLabel.TabIndex = 1
        Me.CBSACodeLabel.Text = "Region(CBSA) Code:"
        '
        'PerCapitaIncomeLabel
        '
        Me.PerCapitaIncomeLabel.AutoSize = True
        Me.PerCapitaIncomeLabel.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PerCapitaIncomeLabel.Location = New System.Drawing.Point(51, 243)
        Me.PerCapitaIncomeLabel.Name = "PerCapitaIncomeLabel"
        Me.PerCapitaIncomeLabel.Size = New System.Drawing.Size(153, 22)
        Me.PerCapitaIncomeLabel.TabIndex = 2
        Me.PerCapitaIncomeLabel.Text = "Per Capita Income:"
        '
        'PopulationLabel
        '
        Me.PopulationLabel.AutoSize = True
        Me.PopulationLabel.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PopulationLabel.Location = New System.Drawing.Point(107, 135)
        Me.PopulationLabel.Name = "PopulationLabel"
        Me.PopulationLabel.Size = New System.Drawing.Size(97, 22)
        Me.PopulationLabel.TabIndex = 3
        Me.PopulationLabel.Text = "Population:"
        '
        'MedianHousingIncomeLabel
        '
        Me.MedianHousingIncomeLabel.AutoSize = True
        Me.MedianHousingIncomeLabel.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MedianHousingIncomeLabel.Location = New System.Drawing.Point(12, 189)
        Me.MedianHousingIncomeLabel.Name = "MedianHousingIncomeLabel"
        Me.MedianHousingIncomeLabel.Size = New System.Drawing.Size(192, 22)
        Me.MedianHousingIncomeLabel.TabIndex = 4
        Me.MedianHousingIncomeLabel.Text = "Median Housing Income:"
        '
        'AvgTravelTimeLabel
        '
        Me.AvgTravelTimeLabel.AutoSize = True
        Me.AvgTravelTimeLabel.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AvgTravelTimeLabel.Location = New System.Drawing.Point(28, 297)
        Me.AvgTravelTimeLabel.Name = "AvgTravelTimeLabel"
        Me.AvgTravelTimeLabel.Size = New System.Drawing.Size(176, 22)
        Me.AvgTravelTimeLabel.TabIndex = 5
        Me.AvgTravelTimeLabel.Text = "Average Travel Time:"
        '
        'AvgTravelTimeLbl
        '
        Me.AvgTravelTimeLbl.AutoSize = True
        Me.AvgTravelTimeLbl.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AvgTravelTimeLbl.Location = New System.Drawing.Point(203, 297)
        Me.AvgTravelTimeLbl.Name = "AvgTravelTimeLbl"
        Me.AvgTravelTimeLbl.Size = New System.Drawing.Size(19, 22)
        Me.AvgTravelTimeLbl.TabIndex = 10
        Me.AvgTravelTimeLbl.Text = "0"
        '
        'MedianHousingIncomeLbl
        '
        Me.MedianHousingIncomeLbl.AutoSize = True
        Me.MedianHousingIncomeLbl.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MedianHousingIncomeLbl.Location = New System.Drawing.Point(203, 189)
        Me.MedianHousingIncomeLbl.Name = "MedianHousingIncomeLbl"
        Me.MedianHousingIncomeLbl.Size = New System.Drawing.Size(19, 22)
        Me.MedianHousingIncomeLbl.TabIndex = 9
        Me.MedianHousingIncomeLbl.Text = "0"
        '
        'PopulationLbl
        '
        Me.PopulationLbl.AutoSize = True
        Me.PopulationLbl.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PopulationLbl.Location = New System.Drawing.Point(203, 135)
        Me.PopulationLbl.Name = "PopulationLbl"
        Me.PopulationLbl.Size = New System.Drawing.Size(19, 22)
        Me.PopulationLbl.TabIndex = 8
        Me.PopulationLbl.Text = "0"
        '
        'PerCapitaIncomeLbl
        '
        Me.PerCapitaIncomeLbl.AutoSize = True
        Me.PerCapitaIncomeLbl.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PerCapitaIncomeLbl.Location = New System.Drawing.Point(203, 243)
        Me.PerCapitaIncomeLbl.Name = "PerCapitaIncomeLbl"
        Me.PerCapitaIncomeLbl.Size = New System.Drawing.Size(19, 22)
        Me.PerCapitaIncomeLbl.TabIndex = 7
        Me.PerCapitaIncomeLbl.Text = "0"
        '
        'CBSA_CodeLbl
        '
        Me.CBSA_CodeLbl.AutoSize = True
        Me.CBSA_CodeLbl.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBSA_CodeLbl.Location = New System.Drawing.Point(203, 81)
        Me.CBSA_CodeLbl.Name = "CBSA_CodeLbl"
        Me.CBSA_CodeLbl.Size = New System.Drawing.Size(19, 22)
        Me.CBSA_CodeLbl.TabIndex = 6
        Me.CBSA_CodeLbl.Text = "0"
        '
        'CS434DataSet
        '
        Me.CS434DataSet.DataSetName = "CS434DataSet"
        Me.CS434DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PopulationTableTableAdapter
        '
        Me.PopulationTableTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager._1062594333_T_TRANSNET_FACILITY__TableAdapter = Nothing
        Me.TableAdapterManager.AirportTableTableAdapter = Nothing
        Me.TableAdapterManager.AmtrakTableTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CBSATableAdapter = Nothing
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
        'LocationTableTableAdapter
        '
        Me.LocationTableTableAdapter.ClearBeforeFill = True
        '
        'Demographics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 347)
        Me.Controls.Add(Me.AvgTravelTimeLbl)
        Me.Controls.Add(Me.MedianHousingIncomeLbl)
        Me.Controls.Add(Me.PopulationLbl)
        Me.Controls.Add(Me.PerCapitaIncomeLbl)
        Me.Controls.Add(Me.CBSA_CodeLbl)
        Me.Controls.Add(Me.AvgTravelTimeLabel)
        Me.Controls.Add(Me.MedianHousingIncomeLabel)
        Me.Controls.Add(Me.PopulationLabel)
        Me.Controls.Add(Me.PerCapitaIncomeLabel)
        Me.Controls.Add(Me.CBSACodeLabel)
        Me.Controls.Add(Me.Label)
        Me.Name = "Demographics"
        Me.Text = "Demographics"
        CType(Me.CS434DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents CBSACodeLabel As System.Windows.Forms.Label
    Friend WithEvents PerCapitaIncomeLabel As System.Windows.Forms.Label
    Friend WithEvents PopulationLabel As System.Windows.Forms.Label
    Friend WithEvents MedianHousingIncomeLabel As System.Windows.Forms.Label
    Friend WithEvents AvgTravelTimeLabel As System.Windows.Forms.Label
    Friend WithEvents AvgTravelTimeLbl As System.Windows.Forms.Label
    Friend WithEvents MedianHousingIncomeLbl As System.Windows.Forms.Label
    Friend WithEvents PopulationLbl As System.Windows.Forms.Label
    Friend WithEvents PerCapitaIncomeLbl As System.Windows.Forms.Label
    Friend WithEvents CBSA_CodeLbl As System.Windows.Forms.Label
    Friend WithEvents CS434DataSet As WindowsApplication1.CS434DataSet
    Friend WithEvents PopulationTableTableAdapter As WindowsApplication1.CS434DataSetTableAdapters.PopulationTableTableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.CS434DataSetTableAdapters.TableAdapterManager
    Friend WithEvents LocationTableTableAdapter As WindowsApplication1.CS434DataSetTableAdapters.LocationTableTableAdapter
End Class
