<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settings
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
        Me.boilingPointCheckBox = New System.Windows.Forms.CheckBox()
        Me.givenBox = New System.Windows.Forms.GroupBox()
        Me.exampleBox = New System.Windows.Forms.GroupBox()
        Me.exampleButton = New System.Windows.Forms.Button()
        Me.groupNameCheckBox = New System.Windows.Forms.CheckBox()
        Me.atomicNumbCheckBox = New System.Windows.Forms.CheckBox()
        Me.chemSymbCheckBox = New System.Windows.Forms.CheckBox()
        Me.givenInstructionLabel = New System.Windows.Forms.Label()
        Me.questionOptionBox = New System.Windows.Forms.GroupBox()
        Me.meltingPointCheckBox = New System.Windows.Forms.CheckBox()
        Me.questionGroupNameCheckBox = New System.Windows.Forms.CheckBox()
        Me.discoveryYearCheckBox = New System.Windows.Forms.CheckBox()
        Me.discovererCheckBox = New System.Windows.Forms.CheckBox()
        Me.chemicalSymbolCheckBox = New System.Windows.Forms.CheckBox()
        Me.elementNameCheckBox = New System.Windows.Forms.CheckBox()
        Me.quizQuestionLabel = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Length1RadioButton = New System.Windows.Forms.RadioButton()
        Me.Length2RadioButton = New System.Windows.Forms.RadioButton()
        Me.Length3RadioButton = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LengthBox = New System.Windows.Forms.GroupBox()
        Me.Length4RadioButton = New System.Windows.Forms.RadioButton()
        Me.givenBox.SuspendLayout()
        Me.exampleBox.SuspendLayout()
        Me.questionOptionBox.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.LengthBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'boilingPointCheckBox
        '
        Me.boilingPointCheckBox.AutoSize = True
        Me.boilingPointCheckBox.Location = New System.Drawing.Point(208, 63)
        Me.boilingPointCheckBox.Name = "boilingPointCheckBox"
        Me.boilingPointCheckBox.Size = New System.Drawing.Size(133, 28)
        Me.boilingPointCheckBox.TabIndex = 16
        Me.boilingPointCheckBox.Text = "Boiling Point"
        Me.boilingPointCheckBox.UseVisualStyleBackColor = True
        '
        'givenBox
        '
        Me.givenBox.Controls.Add(Me.exampleBox)
        Me.givenBox.Controls.Add(Me.groupNameCheckBox)
        Me.givenBox.Controls.Add(Me.atomicNumbCheckBox)
        Me.givenBox.Controls.Add(Me.chemSymbCheckBox)
        Me.givenBox.Controls.Add(Me.givenInstructionLabel)
        Me.givenBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.givenBox.Location = New System.Drawing.Point(14, 12)
        Me.givenBox.Name = "givenBox"
        Me.givenBox.Size = New System.Drawing.Size(724, 129)
        Me.givenBox.TabIndex = 18
        Me.givenBox.TabStop = False
        Me.givenBox.Text = "Given Information"
        '
        'exampleBox
        '
        Me.exampleBox.Controls.Add(Me.exampleButton)
        Me.exampleBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.exampleBox.Location = New System.Drawing.Point(617, 35)
        Me.exampleBox.Name = "exampleBox"
        Me.exampleBox.Size = New System.Drawing.Size(77, 88)
        Me.exampleBox.TabIndex = 19
        Me.exampleBox.TabStop = False
        Me.exampleBox.Text = "Preview"
        '
        'exampleButton
        '
        Me.exampleButton.Location = New System.Drawing.Point(13, 24)
        Me.exampleButton.Name = "exampleButton"
        Me.exampleButton.Size = New System.Drawing.Size(50, 60)
        Me.exampleButton.TabIndex = 15
        Me.exampleButton.Text = "18" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ar"
        Me.exampleButton.UseVisualStyleBackColor = True
        '
        'groupNameCheckBox
        '
        Me.groupNameCheckBox.AutoSize = True
        Me.groupNameCheckBox.Location = New System.Drawing.Point(435, 70)
        Me.groupNameCheckBox.Name = "groupNameCheckBox"
        Me.groupNameCheckBox.Size = New System.Drawing.Size(138, 28)
        Me.groupNameCheckBox.TabIndex = 18
        Me.groupNameCheckBox.Text = "Group Name"
        Me.groupNameCheckBox.UseVisualStyleBackColor = True
        '
        'atomicNumbCheckBox
        '
        Me.atomicNumbCheckBox.AutoSize = True
        Me.atomicNumbCheckBox.Location = New System.Drawing.Point(247, 70)
        Me.atomicNumbCheckBox.Name = "atomicNumbCheckBox"
        Me.atomicNumbCheckBox.Size = New System.Drawing.Size(161, 28)
        Me.atomicNumbCheckBox.TabIndex = 17
        Me.atomicNumbCheckBox.Text = "Atomic Number"
        Me.atomicNumbCheckBox.UseVisualStyleBackColor = True
        '
        'chemSymbCheckBox
        '
        Me.chemSymbCheckBox.AutoSize = True
        Me.chemSymbCheckBox.Location = New System.Drawing.Point(37, 70)
        Me.chemSymbCheckBox.Name = "chemSymbCheckBox"
        Me.chemSymbCheckBox.Size = New System.Drawing.Size(176, 28)
        Me.chemSymbCheckBox.TabIndex = 16
        Me.chemSymbCheckBox.Text = "Chemical Symbol"
        Me.chemSymbCheckBox.UseVisualStyleBackColor = True
        '
        'givenInstructionLabel
        '
        Me.givenInstructionLabel.AutoSize = True
        Me.givenInstructionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.givenInstructionLabel.Location = New System.Drawing.Point(6, 35)
        Me.givenInstructionLabel.Name = "givenInstructionLabel"
        Me.givenInstructionLabel.Size = New System.Drawing.Size(425, 24)
        Me.givenInstructionLabel.TabIndex = 6
        Me.givenInstructionLabel.Text = "Select the information to display on each element."
        '
        'questionOptionBox
        '
        Me.questionOptionBox.Controls.Add(Me.boilingPointCheckBox)
        Me.questionOptionBox.Controls.Add(Me.meltingPointCheckBox)
        Me.questionOptionBox.Controls.Add(Me.questionGroupNameCheckBox)
        Me.questionOptionBox.Controls.Add(Me.discoveryYearCheckBox)
        Me.questionOptionBox.Controls.Add(Me.discovererCheckBox)
        Me.questionOptionBox.Controls.Add(Me.chemicalSymbolCheckBox)
        Me.questionOptionBox.Controls.Add(Me.elementNameCheckBox)
        Me.questionOptionBox.Controls.Add(Me.quizQuestionLabel)
        Me.questionOptionBox.Enabled = False
        Me.questionOptionBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.questionOptionBox.Location = New System.Drawing.Point(14, 147)
        Me.questionOptionBox.Name = "questionOptionBox"
        Me.questionOptionBox.Size = New System.Drawing.Size(724, 146)
        Me.questionOptionBox.TabIndex = 17
        Me.questionOptionBox.TabStop = False
        Me.questionOptionBox.Text = " Quiz Questions"
        '
        'meltingPointCheckBox
        '
        Me.meltingPointCheckBox.AutoSize = True
        Me.meltingPointCheckBox.Location = New System.Drawing.Point(208, 94)
        Me.meltingPointCheckBox.Name = "meltingPointCheckBox"
        Me.meltingPointCheckBox.Size = New System.Drawing.Size(137, 28)
        Me.meltingPointCheckBox.TabIndex = 15
        Me.meltingPointCheckBox.Text = "Melting Point"
        Me.meltingPointCheckBox.UseVisualStyleBackColor = True
        '
        'questionGroupNameCheckBox
        '
        Me.questionGroupNameCheckBox.AutoSize = True
        Me.questionGroupNameCheckBox.Location = New System.Drawing.Point(567, 63)
        Me.questionGroupNameCheckBox.Name = "questionGroupNameCheckBox"
        Me.questionGroupNameCheckBox.Size = New System.Drawing.Size(138, 28)
        Me.questionGroupNameCheckBox.TabIndex = 14
        Me.questionGroupNameCheckBox.Text = "Group Name"
        Me.questionGroupNameCheckBox.UseVisualStyleBackColor = True
        '
        'discoveryYearCheckBox
        '
        Me.discoveryYearCheckBox.AutoSize = True
        Me.discoveryYearCheckBox.Location = New System.Drawing.Point(388, 63)
        Me.discoveryYearCheckBox.Name = "discoveryYearCheckBox"
        Me.discoveryYearCheckBox.Size = New System.Drawing.Size(155, 28)
        Me.discoveryYearCheckBox.TabIndex = 13
        Me.discoveryYearCheckBox.Text = "Discovery Year"
        Me.discoveryYearCheckBox.UseVisualStyleBackColor = True
        '
        'discovererCheckBox
        '
        Me.discovererCheckBox.AutoSize = True
        Me.discovererCheckBox.Location = New System.Drawing.Point(388, 94)
        Me.discovererCheckBox.Name = "discovererCheckBox"
        Me.discovererCheckBox.Size = New System.Drawing.Size(119, 28)
        Me.discovererCheckBox.TabIndex = 12
        Me.discovererCheckBox.Text = "Discoverer"
        Me.discovererCheckBox.UseVisualStyleBackColor = True
        '
        'chemicalSymbolCheckBox
        '
        Me.chemicalSymbolCheckBox.AutoSize = True
        Me.chemicalSymbolCheckBox.Location = New System.Drawing.Point(19, 94)
        Me.chemicalSymbolCheckBox.Name = "chemicalSymbolCheckBox"
        Me.chemicalSymbolCheckBox.Size = New System.Drawing.Size(176, 28)
        Me.chemicalSymbolCheckBox.TabIndex = 11
        Me.chemicalSymbolCheckBox.Text = "Chemical Symbol"
        Me.chemicalSymbolCheckBox.UseVisualStyleBackColor = True
        '
        'elementNameCheckBox
        '
        Me.elementNameCheckBox.AutoSize = True
        Me.elementNameCheckBox.Location = New System.Drawing.Point(19, 63)
        Me.elementNameCheckBox.Name = "elementNameCheckBox"
        Me.elementNameCheckBox.Size = New System.Drawing.Size(155, 28)
        Me.elementNameCheckBox.TabIndex = 10
        Me.elementNameCheckBox.Text = "Element Name"
        Me.elementNameCheckBox.UseVisualStyleBackColor = True
        '
        'quizQuestionLabel
        '
        Me.quizQuestionLabel.AutoSize = True
        Me.quizQuestionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quizQuestionLabel.Location = New System.Drawing.Point(6, 24)
        Me.quizQuestionLabel.Name = "quizQuestionLabel"
        Me.quizQuestionLabel.Size = New System.Drawing.Size(573, 24)
        Me.quizQuestionLabel.TabIndex = 9
        Me.quizQuestionLabel.Text = "Select the information you would like to be asked about an element."
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(595, 423)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 15
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Enabled = False
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Length1RadioButton
        '
        Me.Length1RadioButton.AutoSize = True
        Me.Length1RadioButton.Location = New System.Drawing.Point(19, 60)
        Me.Length1RadioButton.Name = "Length1RadioButton"
        Me.Length1RadioButton.Size = New System.Drawing.Size(122, 28)
        Me.Length1RadioButton.TabIndex = 11
        Me.Length1RadioButton.TabStop = True
        Me.Length1RadioButton.Text = "5 Elements"
        Me.Length1RadioButton.UseVisualStyleBackColor = True
        '
        'Length2RadioButton
        '
        Me.Length2RadioButton.AutoSize = True
        Me.Length2RadioButton.Location = New System.Drawing.Point(208, 60)
        Me.Length2RadioButton.Name = "Length2RadioButton"
        Me.Length2RadioButton.Size = New System.Drawing.Size(132, 28)
        Me.Length2RadioButton.TabIndex = 12
        Me.Length2RadioButton.TabStop = True
        Me.Length2RadioButton.Text = "10 Elements"
        Me.Length2RadioButton.UseVisualStyleBackColor = True
        '
        'Length3RadioButton
        '
        Me.Length3RadioButton.AutoSize = True
        Me.Length3RadioButton.Location = New System.Drawing.Point(388, 60)
        Me.Length3RadioButton.Name = "Length3RadioButton"
        Me.Length3RadioButton.Size = New System.Drawing.Size(132, 28)
        Me.Length3RadioButton.TabIndex = 13
        Me.Length3RadioButton.TabStop = True
        Me.Length3RadioButton.Text = "15 Elements"
        Me.Length3RadioButton.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(427, 24)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Please select the number of elements for the quiz."
        '
        'LengthBox
        '
        Me.LengthBox.Controls.Add(Me.Length4RadioButton)
        Me.LengthBox.Controls.Add(Me.Length3RadioButton)
        Me.LengthBox.Controls.Add(Me.Length2RadioButton)
        Me.LengthBox.Controls.Add(Me.Length1RadioButton)
        Me.LengthBox.Controls.Add(Me.Label6)
        Me.LengthBox.Enabled = False
        Me.LengthBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LengthBox.Location = New System.Drawing.Point(14, 299)
        Me.LengthBox.Name = "LengthBox"
        Me.LengthBox.Size = New System.Drawing.Size(724, 103)
        Me.LengthBox.TabIndex = 16
        Me.LengthBox.TabStop = False
        Me.LengthBox.Text = "Quiz Length"
        '
        'Length4RadioButton
        '
        Me.Length4RadioButton.AutoSize = True
        Me.Length4RadioButton.Location = New System.Drawing.Point(567, 60)
        Me.Length4RadioButton.Name = "Length4RadioButton"
        Me.Length4RadioButton.Size = New System.Drawing.Size(132, 28)
        Me.Length4RadioButton.TabIndex = 14
        Me.Length4RadioButton.TabStop = True
        Me.Length4RadioButton.Text = "20 Elements"
        Me.Length4RadioButton.UseVisualStyleBackColor = True
        '
        'settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 464)
        Me.Controls.Add(Me.givenBox)
        Me.Controls.Add(Me.questionOptionBox)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.LengthBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "settings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Quiz Options"
        Me.givenBox.ResumeLayout(False)
        Me.givenBox.PerformLayout()
        Me.exampleBox.ResumeLayout(False)
        Me.questionOptionBox.ResumeLayout(False)
        Me.questionOptionBox.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.LengthBox.ResumeLayout(False)
        Me.LengthBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents boilingPointCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents givenBox As System.Windows.Forms.GroupBox
    Friend WithEvents exampleBox As System.Windows.Forms.GroupBox
    Friend WithEvents exampleButton As System.Windows.Forms.Button
    Friend WithEvents groupNameCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents atomicNumbCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents chemSymbCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents givenInstructionLabel As System.Windows.Forms.Label
    Friend WithEvents questionOptionBox As System.Windows.Forms.GroupBox
    Friend WithEvents meltingPointCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents questionGroupNameCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents discoveryYearCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents discovererCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents chemicalSymbolCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents elementNameCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents quizQuestionLabel As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Length1RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Length2RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Length3RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LengthBox As System.Windows.Forms.GroupBox
    Friend WithEvents Length4RadioButton As System.Windows.Forms.RadioButton

End Class
