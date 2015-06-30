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
        Me.DemocraticCandidateLbl = New System.Windows.Forms.Label()
        Me.RepublicanCandidateLbl = New System.Windows.Forms.Label()
        Me.MainLbl = New System.Windows.Forms.Label()
        Me.DemocraticLbl = New System.Windows.Forms.Label()
        Me.RepublicanLbl = New System.Windows.Forms.Label()
        Me.stateChooser = New System.Windows.Forms.ComboBox()
        Me.DownBtn = New System.Windows.Forms.Button()
        Me.RepublicanPicture = New System.Windows.Forms.PictureBox()
        Me.DemocraticPicture = New System.Windows.Forms.PictureBox()
        Me.StateLbl = New System.Windows.Forms.Label()
        Me.PieLbl = New System.Windows.Forms.Label()
        Me.StateTagLbl = New System.Windows.Forms.Label()
        Me.DemVoteLbl = New System.Windows.Forms.Label()
        Me.DemVoteTextBox = New System.Windows.Forms.TextBox()
        Me.RepVoteLbl = New System.Windows.Forms.Label()
        Me.RepVoteTextBox = New System.Windows.Forms.TextBox()
        Me.ElectoralVoteLbl = New System.Windows.Forms.Label()
        Me.ElectoralVoteTextBox = New System.Windows.Forms.TextBox()
        Me.DemElecVotesLbl = New System.Windows.Forms.Label()
        Me.RepElecVotesLbl = New System.Windows.Forms.Label()
        Me.TotalElectoralRepLbl = New System.Windows.Forms.Label()
        Me.TotalElectoralDemLbl = New System.Windows.Forms.Label()
        Me.ZeroLbl1 = New System.Windows.Forms.Label()
        Me.ZeroLbl2 = New System.Windows.Forms.Label()
        Me.MainMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.fileChooser = New System.Windows.Forms.OpenFileDialog()
        Me.StateResultsGroupBox = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ElectoralVotesWonLbl = New System.Windows.Forms.Label()
        Me.ElectoralVotesWonPicture = New System.Windows.Forms.PictureBox()
        Me.UpdateResultsBtn = New System.Windows.Forms.Button()
        Me.saveFileChooser = New System.Windows.Forms.SaveFileDialog()
        CType(Me.RepublicanPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DemocraticPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainMenu.SuspendLayout()
        Me.StateResultsGroupBox.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ElectoralVotesWonPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DemocraticCandidateLbl
        '
        Me.DemocraticCandidateLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DemocraticCandidateLbl.Location = New System.Drawing.Point(12, 55)
        Me.DemocraticCandidateLbl.Name = "DemocraticCandidateLbl"
        Me.DemocraticCandidateLbl.Size = New System.Drawing.Size(144, 37)
        Me.DemocraticCandidateLbl.TabIndex = 2
        Me.DemocraticCandidateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RepublicanCandidateLbl
        '
        Me.RepublicanCandidateLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RepublicanCandidateLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepublicanCandidateLbl.Location = New System.Drawing.Point(573, 55)
        Me.RepublicanCandidateLbl.Name = "RepublicanCandidateLbl"
        Me.RepublicanCandidateLbl.Size = New System.Drawing.Size(144, 37)
        Me.RepublicanCandidateLbl.TabIndex = 3
        Me.RepublicanCandidateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MainLbl
        '
        Me.MainLbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainLbl.Location = New System.Drawing.Point(170, 25)
        Me.MainLbl.Name = "MainLbl"
        Me.MainLbl.Size = New System.Drawing.Size(386, 46)
        Me.MainLbl.TabIndex = 4
        Me.MainLbl.Text = "Election Results"
        Me.MainLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DemocraticLbl
        '
        Me.DemocraticLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DemocraticLbl.Location = New System.Drawing.Point(12, 270)
        Me.DemocraticLbl.Name = "DemocraticLbl"
        Me.DemocraticLbl.Size = New System.Drawing.Size(136, 19)
        Me.DemocraticLbl.TabIndex = 5
        Me.DemocraticLbl.Text = "(Democratic)"
        Me.DemocraticLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RepublicanLbl
        '
        Me.RepublicanLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RepublicanLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepublicanLbl.Location = New System.Drawing.Point(575, 270)
        Me.RepublicanLbl.Name = "RepublicanLbl"
        Me.RepublicanLbl.Size = New System.Drawing.Size(139, 19)
        Me.RepublicanLbl.TabIndex = 6
        Me.RepublicanLbl.Text = "(Republican)"
        Me.RepublicanLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'stateChooser
        '
        Me.stateChooser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stateChooser.FormattingEnabled = True
        Me.stateChooser.Location = New System.Drawing.Point(299, 307)
        Me.stateChooser.Name = "stateChooser"
        Me.stateChooser.Size = New System.Drawing.Size(136, 21)
        Me.stateChooser.TabIndex = 8
        Me.stateChooser.Visible = False
        '
        'DownBtn
        '
        Me.DownBtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DownBtn.BackgroundImage = Global.Assignment6.My.Resources.Resources.downarrow
        Me.DownBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.DownBtn.Location = New System.Drawing.Point(321, 303)
        Me.DownBtn.Name = "DownBtn"
        Me.DownBtn.Size = New System.Drawing.Size(94, 28)
        Me.DownBtn.TabIndex = 7
        Me.DownBtn.UseVisualStyleBackColor = True
        '
        'RepublicanPicture
        '
        Me.RepublicanPicture.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RepublicanPicture.BackColor = System.Drawing.Color.Red
        Me.RepublicanPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.RepublicanPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.RepublicanPicture.Location = New System.Drawing.Point(578, 108)
        Me.RepublicanPicture.Name = "RepublicanPicture"
        Me.RepublicanPicture.Size = New System.Drawing.Size(136, 144)
        Me.RepublicanPicture.TabIndex = 1
        Me.RepublicanPicture.TabStop = False
        '
        'DemocraticPicture
        '
        Me.DemocraticPicture.BackColor = System.Drawing.Color.Blue
        Me.DemocraticPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.DemocraticPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DemocraticPicture.ImageLocation = ""
        Me.DemocraticPicture.Location = New System.Drawing.Point(12, 108)
        Me.DemocraticPicture.Name = "DemocraticPicture"
        Me.DemocraticPicture.Size = New System.Drawing.Size(136, 144)
        Me.DemocraticPicture.TabIndex = 0
        Me.DemocraticPicture.TabStop = False
        '
        'StateLbl
        '
        Me.StateLbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StateLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StateLbl.Location = New System.Drawing.Point(201, 258)
        Me.StateLbl.Name = "StateLbl"
        Me.StateLbl.Size = New System.Drawing.Size(325, 46)
        Me.StateLbl.TabIndex = 10
        Me.StateLbl.Text = "View State Results"
        Me.StateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.StateLbl.Visible = False
        '
        'PieLbl
        '
        Me.PieLbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PieLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PieLbl.Location = New System.Drawing.Point(282, 237)
        Me.PieLbl.Name = "PieLbl"
        Me.PieLbl.Size = New System.Drawing.Size(163, 15)
        Me.PieLbl.TabIndex = 11
        Me.PieLbl.Text = "(Overall Percentage)"
        Me.PieLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.PieLbl.Visible = False
        '
        'StateTagLbl
        '
        Me.StateTagLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StateTagLbl.Location = New System.Drawing.Point(238, 304)
        Me.StateTagLbl.Name = "StateTagLbl"
        Me.StateTagLbl.Size = New System.Drawing.Size(63, 24)
        Me.StateTagLbl.TabIndex = 12
        Me.StateTagLbl.Text = "State :"
        Me.StateTagLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.StateTagLbl.Visible = False
        '
        'DemVoteLbl
        '
        Me.DemVoteLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DemVoteLbl.Location = New System.Drawing.Point(18, 46)
        Me.DemVoteLbl.Name = "DemVoteLbl"
        Me.DemVoteLbl.Size = New System.Drawing.Size(176, 24)
        Me.DemVoteLbl.TabIndex = 13
        Me.DemVoteLbl.Text = "Democratic Votes :"
        Me.DemVoteLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DemVoteTextBox
        '
        Me.DemVoteTextBox.Location = New System.Drawing.Point(180, 50)
        Me.DemVoteTextBox.Name = "DemVoteTextBox"
        Me.DemVoteTextBox.Size = New System.Drawing.Size(103, 20)
        Me.DemVoteTextBox.TabIndex = 14
        '
        'RepVoteLbl
        '
        Me.RepVoteLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepVoteLbl.Location = New System.Drawing.Point(18, 80)
        Me.RepVoteLbl.Name = "RepVoteLbl"
        Me.RepVoteLbl.Size = New System.Drawing.Size(176, 24)
        Me.RepVoteLbl.TabIndex = 15
        Me.RepVoteLbl.Text = "Republican Votes :"
        Me.RepVoteLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RepVoteTextBox
        '
        Me.RepVoteTextBox.Location = New System.Drawing.Point(180, 84)
        Me.RepVoteTextBox.Name = "RepVoteTextBox"
        Me.RepVoteTextBox.Size = New System.Drawing.Size(103, 20)
        Me.RepVoteTextBox.TabIndex = 16
        '
        'ElectoralVoteLbl
        '
        Me.ElectoralVoteLbl.BackColor = System.Drawing.Color.Transparent
        Me.ElectoralVoteLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElectoralVoteLbl.Location = New System.Drawing.Point(0, 12)
        Me.ElectoralVoteLbl.Name = "ElectoralVoteLbl"
        Me.ElectoralVoteLbl.Size = New System.Drawing.Size(180, 24)
        Me.ElectoralVoteLbl.TabIndex = 17
        Me.ElectoralVoteLbl.Text = "State Electoral Votes :"
        Me.ElectoralVoteLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ElectoralVoteTextBox
        '
        Me.ElectoralVoteTextBox.Location = New System.Drawing.Point(180, 16)
        Me.ElectoralVoteTextBox.Name = "ElectoralVoteTextBox"
        Me.ElectoralVoteTextBox.Size = New System.Drawing.Size(103, 20)
        Me.ElectoralVoteTextBox.TabIndex = 18
        '
        'DemElecVotesLbl
        '
        Me.DemElecVotesLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DemElecVotesLbl.Location = New System.Drawing.Point(144, 67)
        Me.DemElecVotesLbl.Name = "DemElecVotesLbl"
        Me.DemElecVotesLbl.Size = New System.Drawing.Size(90, 38)
        Me.DemElecVotesLbl.TabIndex = 19
        Me.DemElecVotesLbl.Text = "Electoral Votes"
        Me.DemElecVotesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.DemElecVotesLbl.Visible = False
        '
        'RepElecVotesLbl
        '
        Me.RepElecVotesLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepElecVotesLbl.Location = New System.Drawing.Point(486, 67)
        Me.RepElecVotesLbl.Name = "RepElecVotesLbl"
        Me.RepElecVotesLbl.Size = New System.Drawing.Size(92, 38)
        Me.RepElecVotesLbl.TabIndex = 20
        Me.RepElecVotesLbl.Text = "Electoral Votes"
        Me.RepElecVotesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RepElecVotesLbl.Visible = False
        '
        'TotalElectoralRepLbl
        '
        Me.TotalElectoralRepLbl.BackColor = System.Drawing.Color.Transparent
        Me.TotalElectoralRepLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalElectoralRepLbl.Location = New System.Drawing.Point(510, 111)
        Me.TotalElectoralRepLbl.Name = "TotalElectoralRepLbl"
        Me.TotalElectoralRepLbl.Size = New System.Drawing.Size(37, 15)
        Me.TotalElectoralRepLbl.TabIndex = 21
        Me.TotalElectoralRepLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TotalElectoralDemLbl
        '
        Me.TotalElectoralDemLbl.BackColor = System.Drawing.Color.Transparent
        Me.TotalElectoralDemLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalElectoralDemLbl.Location = New System.Drawing.Point(173, 111)
        Me.TotalElectoralDemLbl.Name = "TotalElectoralDemLbl"
        Me.TotalElectoralDemLbl.Size = New System.Drawing.Size(46, 17)
        Me.TotalElectoralDemLbl.TabIndex = 23
        Me.TotalElectoralDemLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ZeroLbl1
        '
        Me.ZeroLbl1.Font = New System.Drawing.Font("Perpetua Titling MT", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZeroLbl1.Location = New System.Drawing.Point(185, 300)
        Me.ZeroLbl1.Name = "ZeroLbl1"
        Me.ZeroLbl1.Size = New System.Drawing.Size(10, 17)
        Me.ZeroLbl1.TabIndex = 24
        Me.ZeroLbl1.Text = "0"
        Me.ZeroLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ZeroLbl1.Visible = False
        '
        'ZeroLbl2
        '
        Me.ZeroLbl2.Font = New System.Drawing.Font("Perpetua Titling MT", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZeroLbl2.Location = New System.Drawing.Point(532, 300)
        Me.ZeroLbl2.Name = "ZeroLbl2"
        Me.ZeroLbl2.Size = New System.Drawing.Size(15, 21)
        Me.ZeroLbl2.TabIndex = 25
        Me.ZeroLbl2.Text = "0"
        Me.ZeroLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ZeroLbl2.Visible = False
        '
        'MainMenu
        '
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(726, 24)
        Me.MainMenu.TabIndex = 26
        Me.MainMenu.Text = "MainMenu"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'fileChooser
        '
        Me.fileChooser.Filter = "Text Files (*.txt)|*.txt"
        Me.fileChooser.InitialDirectory = ".\"
        '
        'StateResultsGroupBox
        '
        Me.StateResultsGroupBox.Controls.Add(Me.ElectoralVoteTextBox)
        Me.StateResultsGroupBox.Controls.Add(Me.ElectoralVoteLbl)
        Me.StateResultsGroupBox.Controls.Add(Me.RepVoteTextBox)
        Me.StateResultsGroupBox.Controls.Add(Me.RepVoteLbl)
        Me.StateResultsGroupBox.Controls.Add(Me.DemVoteTextBox)
        Me.StateResultsGroupBox.Controls.Add(Me.DemVoteLbl)
        Me.StateResultsGroupBox.Location = New System.Drawing.Point(12, 346)
        Me.StateResultsGroupBox.Name = "StateResultsGroupBox"
        Me.StateResultsGroupBox.Size = New System.Drawing.Size(289, 124)
        Me.StateResultsGroupBox.TabIndex = 27
        Me.StateResultsGroupBox.TabStop = False
        Me.StateResultsGroupBox.Text = "State Results"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ElectoralVotesWonLbl)
        Me.GroupBox1.Controls.Add(Me.ElectoralVotesWonPicture)
        Me.GroupBox1.Location = New System.Drawing.Point(437, 346)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(289, 124)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "State Electoral Votes"
        '
        'ElectoralVotesWonLbl
        '
        Me.ElectoralVotesWonLbl.AutoSize = True
        Me.ElectoralVotesWonLbl.Font = New System.Drawing.Font("Perpetua Titling MT", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElectoralVotesWonLbl.Location = New System.Drawing.Point(30, 27)
        Me.ElectoralVotesWonLbl.Name = "ElectoralVotesWonLbl"
        Me.ElectoralVotesWonLbl.Size = New System.Drawing.Size(0, 77)
        Me.ElectoralVotesWonLbl.TabIndex = 1
        '
        'ElectoralVotesWonPicture
        '
        Me.ElectoralVotesWonPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ElectoralVotesWonPicture.Location = New System.Drawing.Point(141, 19)
        Me.ElectoralVotesWonPicture.Name = "ElectoralVotesWonPicture"
        Me.ElectoralVotesWonPicture.Size = New System.Drawing.Size(136, 93)
        Me.ElectoralVotesWonPicture.TabIndex = 0
        Me.ElectoralVotesWonPicture.TabStop = False
        '
        'UpdateResultsBtn
        '
        Me.UpdateResultsBtn.Location = New System.Drawing.Point(12, 477)
        Me.UpdateResultsBtn.Name = "UpdateResultsBtn"
        Me.UpdateResultsBtn.Size = New System.Drawing.Size(289, 29)
        Me.UpdateResultsBtn.TabIndex = 29
        Me.UpdateResultsBtn.Text = "Update Results"
        Me.UpdateResultsBtn.UseVisualStyleBackColor = True
        Me.UpdateResultsBtn.Visible = False
        '
        'saveFileChooser
        '
        Me.saveFileChooser.Filter = "Text Files (*.txt)|*.txt"
        Me.saveFileChooser.InitialDirectory = ".\"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(726, 343)
        Me.Controls.Add(Me.UpdateResultsBtn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StateResultsGroupBox)
        Me.Controls.Add(Me.ZeroLbl2)
        Me.Controls.Add(Me.ZeroLbl1)
        Me.Controls.Add(Me.TotalElectoralDemLbl)
        Me.Controls.Add(Me.TotalElectoralRepLbl)
        Me.Controls.Add(Me.RepElecVotesLbl)
        Me.Controls.Add(Me.DemElecVotesLbl)
        Me.Controls.Add(Me.StateTagLbl)
        Me.Controls.Add(Me.PieLbl)
        Me.Controls.Add(Me.StateLbl)
        Me.Controls.Add(Me.stateChooser)
        Me.Controls.Add(Me.DownBtn)
        Me.Controls.Add(Me.RepublicanLbl)
        Me.Controls.Add(Me.DemocraticLbl)
        Me.Controls.Add(Me.MainLbl)
        Me.Controls.Add(Me.RepublicanCandidateLbl)
        Me.Controls.Add(Me.DemocraticCandidateLbl)
        Me.Controls.Add(Me.RepublicanPicture)
        Me.Controls.Add(Me.DemocraticPicture)
        Me.Controls.Add(Me.MainMenu)
        Me.MainMenuStrip = Me.MainMenu
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "2012 Voting Results"
        CType(Me.RepublicanPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DemocraticPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainMenu.ResumeLayout(False)
        Me.MainMenu.PerformLayout()
        Me.StateResultsGroupBox.ResumeLayout(False)
        Me.StateResultsGroupBox.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ElectoralVotesWonPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DemocraticPicture As System.Windows.Forms.PictureBox
    Friend WithEvents RepublicanPicture As System.Windows.Forms.PictureBox
    Friend WithEvents DemocraticCandidateLbl As System.Windows.Forms.Label
    Friend WithEvents RepublicanCandidateLbl As System.Windows.Forms.Label
    Friend WithEvents MainLbl As System.Windows.Forms.Label
    Friend WithEvents DemocraticLbl As System.Windows.Forms.Label
    Friend WithEvents RepublicanLbl As System.Windows.Forms.Label
    Friend WithEvents DownBtn As System.Windows.Forms.Button
    Friend WithEvents stateChooser As System.Windows.Forms.ComboBox
    Friend WithEvents StateLbl As System.Windows.Forms.Label
    Friend WithEvents PieLbl As System.Windows.Forms.Label
    Friend WithEvents StateTagLbl As System.Windows.Forms.Label
    Friend WithEvents DemVoteLbl As System.Windows.Forms.Label
    Friend WithEvents DemVoteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RepVoteLbl As System.Windows.Forms.Label
    Friend WithEvents RepVoteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ElectoralVoteLbl As System.Windows.Forms.Label
    Friend WithEvents ElectoralVoteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DemElecVotesLbl As System.Windows.Forms.Label
    Friend WithEvents RepElecVotesLbl As System.Windows.Forms.Label
    Friend WithEvents TotalElectoralRepLbl As System.Windows.Forms.Label
    Friend WithEvents TotalElectoralDemLbl As System.Windows.Forms.Label
    Friend WithEvents ZeroLbl1 As System.Windows.Forms.Label
    Friend WithEvents ZeroLbl2 As System.Windows.Forms.Label
    Friend WithEvents MainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fileChooser As System.Windows.Forms.OpenFileDialog
    Friend WithEvents StateResultsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ElectoralVotesWonLbl As System.Windows.Forms.Label
    Friend WithEvents ElectoralVotesWonPicture As System.Windows.Forms.PictureBox
    Friend WithEvents UpdateResultsBtn As System.Windows.Forms.Button
    Friend WithEvents saveFileChooser As System.Windows.Forms.SaveFileDialog

End Class
