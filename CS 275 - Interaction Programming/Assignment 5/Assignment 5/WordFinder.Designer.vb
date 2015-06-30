<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WordFinder
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
        Me.WordFinderMenu = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenWordHuntFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.fileChooser = New System.Windows.Forms.OpenFileDialog()
        Me.FindListBox = New System.Windows.Forms.CheckedListBox()
        Me.FindLabel = New System.Windows.Forms.Label()
        Me.WordFinderMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'WordFinderMenu
        '
        Me.WordFinderMenu.BackColor = System.Drawing.SystemColors.Control
        Me.WordFinderMenu.Font = New System.Drawing.Font("Modern No. 20", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WordFinderMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu})
        Me.WordFinderMenu.Location = New System.Drawing.Point(0, 0)
        Me.WordFinderMenu.Name = "WordFinderMenu"
        Me.WordFinderMenu.Size = New System.Drawing.Size(358, 24)
        Me.WordFinderMenu.TabIndex = 0
        Me.WordFinderMenu.Text = "MenuStrip1"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenWordHuntFile})
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(39, 20)
        Me.FileMenu.Text = "File"
        '
        'OpenWordHuntFile
        '
        Me.OpenWordHuntFile.Name = "OpenWordHuntFile"
        Me.OpenWordHuntFile.Size = New System.Drawing.Size(99, 22)
        Me.OpenWordHuntFile.Text = "Open"
        '
        'fileChooser
        '
        Me.fileChooser.Filter = "Word Hunt Files (*.hnt)|*.hnt"
        Me.fileChooser.InitialDirectory = ".\"
        '
        'FindListBox
        '
        Me.FindListBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FindListBox.Font = New System.Drawing.Font("Modern No. 20", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FindListBox.FormattingEnabled = True
        Me.FindListBox.Location = New System.Drawing.Point(230, 39)
        Me.FindListBox.Name = "FindListBox"
        Me.FindListBox.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.FindListBox.Size = New System.Drawing.Size(116, 289)
        Me.FindListBox.TabIndex = 2
        '
        'FindLabel
        '
        Me.FindLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FindLabel.Font = New System.Drawing.Font("Modern No. 20", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FindLabel.Location = New System.Drawing.Point(230, 8)
        Me.FindLabel.Name = "FindLabel"
        Me.FindLabel.Size = New System.Drawing.Size(115, 31)
        Me.FindLabel.TabIndex = 3
        Me.FindLabel.Text = "Find:"
        Me.FindLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'WordFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 347)
        Me.Controls.Add(Me.FindLabel)
        Me.Controls.Add(Me.FindListBox)
        Me.Controls.Add(Me.WordFinderMenu)
        Me.MainMenuStrip = Me.WordFinderMenu
        Me.Name = "WordFinder"
        Me.Text = "Word Hunt"
        Me.WordFinderMenu.ResumeLayout(False)
        Me.WordFinderMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WordFinderMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenWordHuntFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fileChooser As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FindListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents FindLabel As System.Windows.Forms.Label

End Class
