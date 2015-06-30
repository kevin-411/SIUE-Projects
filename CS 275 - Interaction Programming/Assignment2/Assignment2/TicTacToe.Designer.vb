<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TicTacToe
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
        Me.TitleLabel1 = New System.Windows.Forms.Label()
        Me.BoxLabel1 = New System.Windows.Forms.Label()
        Me.BoxLabel2 = New System.Windows.Forms.Label()
        Me.BoxLabel3 = New System.Windows.Forms.Label()
        Me.BoxLabel6 = New System.Windows.Forms.Label()
        Me.BoxLabel5 = New System.Windows.Forms.Label()
        Me.BoxLabel4 = New System.Windows.Forms.Label()
        Me.BoxLabel9 = New System.Windows.Forms.Label()
        Me.BoxLabel8 = New System.Windows.Forms.Label()
        Me.BoxLabel7 = New System.Windows.Forms.Label()
        Me.playAgainButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TitleLabel1
        '
        Me.TitleLabel1.AutoSize = True
        Me.TitleLabel1.Font = New System.Drawing.Font("Poor Richard", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel1.Location = New System.Drawing.Point(23, 9)
        Me.TitleLabel1.Name = "TitleLabel1"
        Me.TitleLabel1.Size = New System.Drawing.Size(172, 31)
        Me.TitleLabel1.TabIndex = 0
        Me.TitleLabel1.Text = "X's, it's your turn"
        Me.TitleLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BoxLabel1
        '
        Me.BoxLabel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.BoxLabel1.Font = New System.Drawing.Font("Papyrus", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxLabel1.Location = New System.Drawing.Point(48, 65)
        Me.BoxLabel1.Name = "BoxLabel1"
        Me.BoxLabel1.Size = New System.Drawing.Size(37, 37)
        Me.BoxLabel1.TabIndex = 1
        Me.BoxLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxLabel2
        '
        Me.BoxLabel2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.BoxLabel2.Font = New System.Drawing.Font("Papyrus", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxLabel2.Location = New System.Drawing.Point(91, 65)
        Me.BoxLabel2.Name = "BoxLabel2"
        Me.BoxLabel2.Size = New System.Drawing.Size(37, 37)
        Me.BoxLabel2.TabIndex = 2
        Me.BoxLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxLabel3
        '
        Me.BoxLabel3.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.BoxLabel3.Font = New System.Drawing.Font("Papyrus", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxLabel3.Location = New System.Drawing.Point(134, 65)
        Me.BoxLabel3.Name = "BoxLabel3"
        Me.BoxLabel3.Size = New System.Drawing.Size(37, 37)
        Me.BoxLabel3.TabIndex = 3
        Me.BoxLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxLabel6
        '
        Me.BoxLabel6.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.BoxLabel6.Font = New System.Drawing.Font("Papyrus", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxLabel6.Location = New System.Drawing.Point(134, 111)
        Me.BoxLabel6.Name = "BoxLabel6"
        Me.BoxLabel6.Size = New System.Drawing.Size(37, 37)
        Me.BoxLabel6.TabIndex = 6
        Me.BoxLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxLabel5
        '
        Me.BoxLabel5.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.BoxLabel5.Font = New System.Drawing.Font("Papyrus", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxLabel5.Location = New System.Drawing.Point(91, 111)
        Me.BoxLabel5.Name = "BoxLabel5"
        Me.BoxLabel5.Size = New System.Drawing.Size(37, 37)
        Me.BoxLabel5.TabIndex = 5
        Me.BoxLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxLabel4
        '
        Me.BoxLabel4.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.BoxLabel4.Font = New System.Drawing.Font("Papyrus", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxLabel4.Location = New System.Drawing.Point(48, 111)
        Me.BoxLabel4.Name = "BoxLabel4"
        Me.BoxLabel4.Size = New System.Drawing.Size(37, 37)
        Me.BoxLabel4.TabIndex = 4
        Me.BoxLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxLabel9
        '
        Me.BoxLabel9.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.BoxLabel9.Font = New System.Drawing.Font("Papyrus", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxLabel9.Location = New System.Drawing.Point(134, 157)
        Me.BoxLabel9.Name = "BoxLabel9"
        Me.BoxLabel9.Size = New System.Drawing.Size(37, 37)
        Me.BoxLabel9.TabIndex = 9
        Me.BoxLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxLabel8
        '
        Me.BoxLabel8.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.BoxLabel8.Font = New System.Drawing.Font("Papyrus", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxLabel8.Location = New System.Drawing.Point(91, 157)
        Me.BoxLabel8.Name = "BoxLabel8"
        Me.BoxLabel8.Size = New System.Drawing.Size(37, 37)
        Me.BoxLabel8.TabIndex = 8
        Me.BoxLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BoxLabel7
        '
        Me.BoxLabel7.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.BoxLabel7.Font = New System.Drawing.Font("Papyrus", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxLabel7.Location = New System.Drawing.Point(48, 157)
        Me.BoxLabel7.Name = "BoxLabel7"
        Me.BoxLabel7.Size = New System.Drawing.Size(37, 37)
        Me.BoxLabel7.TabIndex = 7
        Me.BoxLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'playAgainButton
        '
        Me.playAgainButton.Location = New System.Drawing.Point(85, 214)
        Me.playAgainButton.Name = "playAgainButton"
        Me.playAgainButton.Size = New System.Drawing.Size(48, 40)
        Me.playAgainButton.TabIndex = 10
        Me.playAgainButton.Text = "Play Again?"
        Me.playAgainButton.UseVisualStyleBackColor = True
        Me.playAgainButton.Visible = False
        '
        'TicTacToe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(219, 266)
        Me.Controls.Add(Me.playAgainButton)
        Me.Controls.Add(Me.BoxLabel9)
        Me.Controls.Add(Me.BoxLabel8)
        Me.Controls.Add(Me.BoxLabel7)
        Me.Controls.Add(Me.BoxLabel6)
        Me.Controls.Add(Me.BoxLabel5)
        Me.Controls.Add(Me.BoxLabel4)
        Me.Controls.Add(Me.BoxLabel3)
        Me.Controls.Add(Me.BoxLabel2)
        Me.Controls.Add(Me.BoxLabel1)
        Me.Controls.Add(Me.TitleLabel1)
        Me.Name = "TicTacToe"
        Me.Text = "TicTacToe"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TitleLabel1 As System.Windows.Forms.Label
    Friend WithEvents BoxLabel1 As System.Windows.Forms.Label
    Friend WithEvents BoxLabel2 As System.Windows.Forms.Label
    Friend WithEvents BoxLabel3 As System.Windows.Forms.Label
    Friend WithEvents BoxLabel6 As System.Windows.Forms.Label
    Friend WithEvents BoxLabel5 As System.Windows.Forms.Label
    Friend WithEvents BoxLabel4 As System.Windows.Forms.Label
    Friend WithEvents BoxLabel9 As System.Windows.Forms.Label
    Friend WithEvents BoxLabel8 As System.Windows.Forms.Label
    Friend WithEvents BoxLabel7 As System.Windows.Forms.Label
    Friend WithEvents playAgainButton As System.Windows.Forms.Button
End Class
