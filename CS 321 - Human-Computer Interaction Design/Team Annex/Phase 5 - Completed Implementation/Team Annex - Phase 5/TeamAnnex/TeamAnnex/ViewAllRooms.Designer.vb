<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAllRooms
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
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.officeButt = New System.Windows.Forms.Button()
        Me.labButt = New System.Windows.Forms.Button()
        Me.classButt = New System.Windows.Forms.Button()
        Me.PrevButton = New System.Windows.Forms.PictureBox()
        Me.NextButton = New System.Windows.Forms.PictureBox()
        Me.BackButton = New System.Windows.Forms.Button()
        CType(Me.PrevButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NextButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Red
        Me.Button6.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.SystemColors.Window
        Me.Button6.Location = New System.Drawing.Point(895, 480)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(167, 58)
        Me.Button6.TabIndex = 39
        Me.Button6.Text = "View Floorplan"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Red
        Me.Button5.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.Window
        Me.Button5.Location = New System.Drawing.Point(895, 416)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(167, 58)
        Me.Button5.TabIndex = 38
        Me.Button5.Text = "Faculty/Staff"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'officeButt
        '
        Me.officeButt.BackColor = System.Drawing.Color.Red
        Me.officeButt.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.officeButt.ForeColor = System.Drawing.SystemColors.Window
        Me.officeButt.Location = New System.Drawing.Point(895, 231)
        Me.officeButt.Name = "officeButt"
        Me.officeButt.Size = New System.Drawing.Size(167, 58)
        Me.officeButt.TabIndex = 36
        Me.officeButt.Tag = "Office"
        Me.officeButt.Text = "Offices"
        Me.officeButt.UseVisualStyleBackColor = False
        '
        'labButt
        '
        Me.labButt.BackColor = System.Drawing.Color.Red
        Me.labButt.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labButt.ForeColor = System.Drawing.SystemColors.Window
        Me.labButt.Location = New System.Drawing.Point(895, 167)
        Me.labButt.Name = "labButt"
        Me.labButt.Size = New System.Drawing.Size(167, 58)
        Me.labButt.TabIndex = 35
        Me.labButt.Tag = "Lab"
        Me.labButt.Text = "Labs"
        Me.labButt.UseVisualStyleBackColor = False
        '
        'classButt
        '
        Me.classButt.BackColor = System.Drawing.Color.White
        Me.classButt.Enabled = False
        Me.classButt.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.classButt.ForeColor = System.Drawing.Color.Red
        Me.classButt.Location = New System.Drawing.Point(895, 103)
        Me.classButt.Name = "classButt"
        Me.classButt.Size = New System.Drawing.Size(167, 58)
        Me.classButt.TabIndex = 34
        Me.classButt.Tag = "Classroom"
        Me.classButt.Text = "Classrooms"
        Me.classButt.UseVisualStyleBackColor = False
        '
        'PrevButton
        '
        Me.PrevButton.BackColor = System.Drawing.SystemColors.Window
        Me.PrevButton.BackgroundImage = Global.TeamAnnex.My.Resources.Resources.PreviousButton
        Me.PrevButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PrevButton.Location = New System.Drawing.Point(12, 544)
        Me.PrevButton.Name = "PrevButton"
        Me.PrevButton.Size = New System.Drawing.Size(167, 58)
        Me.PrevButton.TabIndex = 43
        Me.PrevButton.TabStop = False
        '
        'NextButton
        '
        Me.NextButton.BackColor = System.Drawing.SystemColors.Window
        Me.NextButton.BackgroundImage = Global.TeamAnnex.My.Resources.Resources.NextButton
        Me.NextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.NextButton.Location = New System.Drawing.Point(582, 544)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(167, 58)
        Me.NextButton.TabIndex = 42
        Me.NextButton.TabStop = False
        '
        'BackButton
        '
        Me.BackButton.BackColor = System.Drawing.Color.Red
        Me.BackButton.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BackButton.ForeColor = System.Drawing.SystemColors.Window
        Me.BackButton.Location = New System.Drawing.Point(895, 544)
        Me.BackButton.Name = "BackButton"
        Me.BackButton.Size = New System.Drawing.Size(167, 58)
        Me.BackButton.TabIndex = 44
        Me.BackButton.Text = "Back"
        Me.BackButton.UseVisualStyleBackColor = False
        '
        'ViewAllRooms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.TeamAnnex.My.Resources.Resources.SIUE_Engineering_background
        Me.ClientSize = New System.Drawing.Size(1074, 626)
        Me.Controls.Add(Me.BackButton)
        Me.Controls.Add(Me.PrevButton)
        Me.Controls.Add(Me.NextButton)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.officeButt)
        Me.Controls.Add(Me.labButt)
        Me.Controls.Add(Me.classButt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViewAllRooms"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ViewAllRooms"
        Me.TopMost = True
        CType(Me.PrevButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NextButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents officeButt As System.Windows.Forms.Button
    Friend WithEvents labButt As System.Windows.Forms.Button
    Friend WithEvents classButt As System.Windows.Forms.Button
    Friend WithEvents PrevButton As System.Windows.Forms.PictureBox
    Friend WithEvents NextButton As System.Windows.Forms.PictureBox
    Friend WithEvents BackButton As System.Windows.Forms.Button
End Class
