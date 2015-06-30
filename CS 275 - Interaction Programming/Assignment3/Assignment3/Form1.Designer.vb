<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TwentyOne
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
        Me.HandValueLbl = New System.Windows.Forms.Label()
        Me.HandPointsLbl = New System.Windows.Forms.Label()
        Me.TotalPointsLbl = New System.Windows.Forms.Label()
        Me.HandValuePts = New System.Windows.Forms.Label()
        Me.TotalPointsPts = New System.Windows.Forms.Label()
        Me.HandPointsPts = New System.Windows.Forms.Label()
        Me.Deal_HitBtn = New System.Windows.Forms.Button()
        Me.StayBtn = New System.Windows.Forms.Button()
        Me.CardImg1 = New System.Windows.Forms.PictureBox()
        Me.CardImg2 = New System.Windows.Forms.PictureBox()
        Me.CardImg3 = New System.Windows.Forms.PictureBox()
        Me.CardImg4 = New System.Windows.Forms.PictureBox()
        Me.CardImg5 = New System.Windows.Forms.PictureBox()
        Me.BustedLbl = New System.Windows.Forms.Label()
        CType(Me.CardImg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardImg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardImg3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardImg4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardImg5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HandValueLbl
        '
        Me.HandValueLbl.AutoSize = True
        Me.HandValueLbl.Font = New System.Drawing.Font("Playbill", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HandValueLbl.Location = New System.Drawing.Point(145, 153)
        Me.HandValueLbl.Name = "HandValueLbl"
        Me.HandValueLbl.Size = New System.Drawing.Size(149, 49)
        Me.HandValueLbl.TabIndex = 0
        Me.HandValueLbl.Text = "Hand Value"
        '
        'HandPointsLbl
        '
        Me.HandPointsLbl.AutoSize = True
        Me.HandPointsLbl.Font = New System.Drawing.Font("Playbill", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HandPointsLbl.Location = New System.Drawing.Point(12, 299)
        Me.HandPointsLbl.Name = "HandPointsLbl"
        Me.HandPointsLbl.Size = New System.Drawing.Size(156, 49)
        Me.HandPointsLbl.TabIndex = 1
        Me.HandPointsLbl.Text = "Hand Points"
        '
        'TotalPointsLbl
        '
        Me.TotalPointsLbl.AutoSize = True
        Me.TotalPointsLbl.Font = New System.Drawing.Font("Playbill", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalPointsLbl.Location = New System.Drawing.Point(280, 297)
        Me.TotalPointsLbl.Name = "TotalPointsLbl"
        Me.TotalPointsLbl.Size = New System.Drawing.Size(156, 49)
        Me.TotalPointsLbl.TabIndex = 2
        Me.TotalPointsLbl.Text = "Total Points"
        '
        'HandValuePts
        '
        Me.HandValuePts.BackColor = System.Drawing.SystemColors.ControlLight
        Me.HandValuePts.Font = New System.Drawing.Font("Playbill", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HandValuePts.Location = New System.Drawing.Point(300, 155)
        Me.HandValuePts.Name = "HandValuePts"
        Me.HandValuePts.Size = New System.Drawing.Size(108, 45)
        Me.HandValuePts.TabIndex = 3
        Me.HandValuePts.Text = "0"
        Me.HandValuePts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TotalPointsPts
        '
        Me.TotalPointsPts.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TotalPointsPts.Font = New System.Drawing.Font("Playbill", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalPointsPts.Location = New System.Drawing.Point(442, 301)
        Me.TotalPointsPts.Name = "TotalPointsPts"
        Me.TotalPointsPts.Size = New System.Drawing.Size(108, 45)
        Me.TotalPointsPts.TabIndex = 4
        Me.TotalPointsPts.Text = "1000"
        Me.TotalPointsPts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HandPointsPts
        '
        Me.HandPointsPts.BackColor = System.Drawing.SystemColors.ControlLight
        Me.HandPointsPts.Font = New System.Drawing.Font("Playbill", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HandPointsPts.Location = New System.Drawing.Point(167, 301)
        Me.HandPointsPts.Name = "HandPointsPts"
        Me.HandPointsPts.Size = New System.Drawing.Size(108, 45)
        Me.HandPointsPts.TabIndex = 5
        Me.HandPointsPts.Text = "0"
        Me.HandPointsPts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Deal_HitBtn
        '
        Me.Deal_HitBtn.Font = New System.Drawing.Font("Playbill", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Deal_HitBtn.Location = New System.Drawing.Point(121, 226)
        Me.Deal_HitBtn.Name = "Deal_HitBtn"
        Me.Deal_HitBtn.Size = New System.Drawing.Size(134, 42)
        Me.Deal_HitBtn.TabIndex = 7
        Me.Deal_HitBtn.Text = "Deal"
        Me.Deal_HitBtn.UseVisualStyleBackColor = True
        '
        'StayBtn
        '
        Me.StayBtn.Font = New System.Drawing.Font("Playbill", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StayBtn.Location = New System.Drawing.Point(323, 226)
        Me.StayBtn.Name = "StayBtn"
        Me.StayBtn.Size = New System.Drawing.Size(134, 42)
        Me.StayBtn.TabIndex = 8
        Me.StayBtn.Text = "Stay"
        Me.StayBtn.UseVisualStyleBackColor = True
        Me.StayBtn.Visible = False
        '
        'CardImg1
        '
        Me.CardImg1.Image = Global.Assignment3.My.Resources.Resources._55
        Me.CardImg1.ImageLocation = ""
        Me.CardImg1.InitialImage = Nothing
        Me.CardImg1.Location = New System.Drawing.Point(57, 22)
        Me.CardImg1.Name = "CardImg1"
        Me.CardImg1.Size = New System.Drawing.Size(72, 97)
        Me.CardImg1.TabIndex = 6
        Me.CardImg1.TabStop = False
        '
        'CardImg2
        '
        Me.CardImg2.Image = Global.Assignment3.My.Resources.Resources._55
        Me.CardImg2.ImageLocation = ""
        Me.CardImg2.InitialImage = Nothing
        Me.CardImg2.Location = New System.Drawing.Point(154, 22)
        Me.CardImg2.Name = "CardImg2"
        Me.CardImg2.Size = New System.Drawing.Size(72, 97)
        Me.CardImg2.TabIndex = 9
        Me.CardImg2.TabStop = False
        '
        'CardImg3
        '
        Me.CardImg3.Image = Global.Assignment3.My.Resources.Resources._55
        Me.CardImg3.ImageLocation = ""
        Me.CardImg3.InitialImage = Nothing
        Me.CardImg3.Location = New System.Drawing.Point(251, 22)
        Me.CardImg3.Name = "CardImg3"
        Me.CardImg3.Size = New System.Drawing.Size(72, 97)
        Me.CardImg3.TabIndex = 10
        Me.CardImg3.TabStop = False
        Me.CardImg3.Visible = False
        '
        'CardImg4
        '
        Me.CardImg4.Image = Global.Assignment3.My.Resources.Resources._55
        Me.CardImg4.ImageLocation = ""
        Me.CardImg4.InitialImage = Nothing
        Me.CardImg4.Location = New System.Drawing.Point(350, 22)
        Me.CardImg4.Name = "CardImg4"
        Me.CardImg4.Size = New System.Drawing.Size(72, 97)
        Me.CardImg4.TabIndex = 11
        Me.CardImg4.TabStop = False
        Me.CardImg4.Visible = False
        '
        'CardImg5
        '
        Me.CardImg5.Image = Global.Assignment3.My.Resources.Resources._55
        Me.CardImg5.ImageLocation = ""
        Me.CardImg5.InitialImage = Nothing
        Me.CardImg5.Location = New System.Drawing.Point(451, 22)
        Me.CardImg5.Name = "CardImg5"
        Me.CardImg5.Size = New System.Drawing.Size(72, 97)
        Me.CardImg5.TabIndex = 12
        Me.CardImg5.TabStop = False
        Me.CardImg5.Visible = False
        '
        'BustedLbl
        '
        Me.BustedLbl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.BustedLbl.Font = New System.Drawing.Font("Playbill", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BustedLbl.Location = New System.Drawing.Point(323, 223)
        Me.BustedLbl.Name = "BustedLbl"
        Me.BustedLbl.Size = New System.Drawing.Size(227, 45)
        Me.BustedLbl.TabIndex = 13
        Me.BustedLbl.Text = "BUSTED"
        Me.BustedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BustedLbl.Visible = False
        '
        'TwentyOne
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 357)
        Me.Controls.Add(Me.CardImg5)
        Me.Controls.Add(Me.CardImg4)
        Me.Controls.Add(Me.CardImg3)
        Me.Controls.Add(Me.CardImg2)
        Me.Controls.Add(Me.StayBtn)
        Me.Controls.Add(Me.Deal_HitBtn)
        Me.Controls.Add(Me.CardImg1)
        Me.Controls.Add(Me.HandPointsPts)
        Me.Controls.Add(Me.TotalPointsPts)
        Me.Controls.Add(Me.HandValuePts)
        Me.Controls.Add(Me.TotalPointsLbl)
        Me.Controls.Add(Me.HandPointsLbl)
        Me.Controls.Add(Me.HandValueLbl)
        Me.Controls.Add(Me.BustedLbl)
        Me.Name = "TwentyOne"
        Me.Text = "Twenty-One"
        CType(Me.CardImg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardImg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardImg3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardImg4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardImg5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HandValueLbl As System.Windows.Forms.Label
    Friend WithEvents HandPointsLbl As System.Windows.Forms.Label
    Friend WithEvents TotalPointsLbl As System.Windows.Forms.Label
    Friend WithEvents HandValuePts As System.Windows.Forms.Label
    Friend WithEvents TotalPointsPts As System.Windows.Forms.Label
    Friend WithEvents HandPointsPts As System.Windows.Forms.Label
    Friend WithEvents CardImg1 As System.Windows.Forms.PictureBox
    Friend WithEvents Deal_HitBtn As System.Windows.Forms.Button
    Friend WithEvents StayBtn As System.Windows.Forms.Button
    Friend WithEvents CardImg2 As System.Windows.Forms.PictureBox
    Friend WithEvents CardImg3 As System.Windows.Forms.PictureBox
    Friend WithEvents CardImg4 As System.Windows.Forms.PictureBox
    Friend WithEvents CardImg5 As System.Windows.Forms.PictureBox
    Friend WithEvents BustedLbl As System.Windows.Forms.Label

End Class
