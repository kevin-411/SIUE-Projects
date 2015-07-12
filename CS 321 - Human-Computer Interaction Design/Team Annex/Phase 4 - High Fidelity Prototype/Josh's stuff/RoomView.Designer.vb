<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RoomView
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
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoomNumberLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RoomTypeLabel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DepartmentLabel = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ClassesListBox = New System.Windows.Forms.ListBox()
        Me.DepartmentOfficeLabel = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Red
        Me.Button5.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.Window
        Me.Button5.Location = New System.Drawing.Point(904, 563)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(167, 58)
        Me.Button5.TabIndex = 11
        Me.Button5.Text = "Back"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.Window
        Me.Button1.Location = New System.Drawing.Point(904, 481)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(167, 58)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Get Directions"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(50, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 25)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Room Number:"
        '
        'RoomNumberLabel
        '
        Me.RoomNumberLabel.AutoSize = True
        Me.RoomNumberLabel.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoomNumberLabel.ForeColor = System.Drawing.Color.Red
        Me.RoomNumberLabel.Location = New System.Drawing.Point(203, 184)
        Me.RoomNumberLabel.Name = "RoomNumberLabel"
        Me.RoomNumberLabel.Size = New System.Drawing.Size(89, 25)
        Me.RoomNumberLabel.TabIndex = 14
        Me.RoomNumberLabel.Text = "EB 1010"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(77, 229)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 25)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Room Type:"
        '
        'RoomTypeLabel
        '
        Me.RoomTypeLabel.AutoSize = True
        Me.RoomTypeLabel.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoomTypeLabel.ForeColor = System.Drawing.Color.Red
        Me.RoomTypeLabel.Location = New System.Drawing.Point(203, 229)
        Me.RoomTypeLabel.Name = "RoomTypeLabel"
        Me.RoomTypeLabel.Size = New System.Drawing.Size(61, 25)
        Me.RoomTypeLabel.TabIndex = 16
        Me.RoomTypeLabel.Text = "Class"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(77, 271)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 25)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Department:"
        '
        'DepartmentLabel
        '
        Me.DepartmentLabel.AutoSize = True
        Me.DepartmentLabel.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepartmentLabel.ForeColor = System.Drawing.Color.Red
        Me.DepartmentLabel.Location = New System.Drawing.Point(203, 271)
        Me.DepartmentLabel.Name = "DepartmentLabel"
        Me.DepartmentLabel.Size = New System.Drawing.Size(50, 25)
        Me.DepartmentLabel.TabIndex = 18
        Me.DepartmentLabel.Text = "N/A"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(111, 347)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 25)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Classes:"
        '
        'ClassesListBox
        '
        Me.ClassesListBox.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClassesListBox.ForeColor = System.Drawing.Color.Red
        Me.ClassesListBox.FormattingEnabled = True
        Me.ClassesListBox.ItemHeight = 23
        Me.ClassesListBox.Location = New System.Drawing.Point(36, 375)
        Me.ClassesListBox.Name = "ClassesListBox"
        Me.ClassesListBox.Size = New System.Drawing.Size(826, 234)
        Me.ClassesListBox.TabIndex = 20
        '
        'DepartmentOfficeLabel
        '
        Me.DepartmentOfficeLabel.AutoSize = True
        Me.DepartmentOfficeLabel.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DepartmentOfficeLabel.ForeColor = System.Drawing.Color.Red
        Me.DepartmentOfficeLabel.Location = New System.Drawing.Point(203, 308)
        Me.DepartmentOfficeLabel.Name = "DepartmentOfficeLabel"
        Me.DepartmentOfficeLabel.Size = New System.Drawing.Size(50, 25)
        Me.DepartmentOfficeLabel.TabIndex = 22
        Me.DepartmentOfficeLabel.Text = "N/A"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(15, 308)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(182, 25)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Department Office:"
        '
        'RoomView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.TeamAnnex.My.Resources.Resources.SIUE_Engineering_background
        Me.ClientSize = New System.Drawing.Size(1076, 625)
        Me.Controls.Add(Me.DepartmentOfficeLabel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ClassesListBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DepartmentLabel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.RoomTypeLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RoomNumberLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RoomView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RoomView"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RoomNumberLabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RoomTypeLabel As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DepartmentLabel As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ClassesListBox As System.Windows.Forms.ListBox
    Friend WithEvents DepartmentOfficeLabel As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
