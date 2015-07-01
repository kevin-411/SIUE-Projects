<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Quiz
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Quiz))
        Me.elementButton = New System.Windows.Forms.Button()
        Me.ElementNameLabel = New System.Windows.Forms.Label()
        Me.BoilingPointLabel = New System.Windows.Forms.Label()
        Me.ChemicalSymbolLabel = New System.Windows.Forms.Label()
        Me.MeltingPointLabel = New System.Windows.Forms.Label()
        Me.DiscoverYearLabel = New System.Windows.Forms.Label()
        Me.GroupNameLabel = New System.Windows.Forms.Label()
        Me.Instruction = New System.Windows.Forms.Label()
        Me.QuestionNumber = New System.Windows.Forms.GroupBox()
        Me.discovererName = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dYearLabel = New System.Windows.Forms.Label()
        Me.falseButton = New System.Windows.Forms.RadioButton()
        Me.trueButton = New System.Windows.Forms.RadioButton()
        Me.discovererUserAnswer = New System.Windows.Forms.Label()
        Me.yearTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gnIncorrect = New System.Windows.Forms.PictureBox()
        Me.GNAnswer = New System.Windows.Forms.Label()
        Me.disIncorrect = New System.Windows.Forms.PictureBox()
        Me.dyIncorrect = New System.Windows.Forms.PictureBox()
        Me.DYAnswer = New System.Windows.Forms.Label()
        Me.mpIncorrect = New System.Windows.Forms.PictureBox()
        Me.MPAnswer = New System.Windows.Forms.Label()
        Me.bpIncorrect = New System.Windows.Forms.PictureBox()
        Me.BPAnswer = New System.Windows.Forms.Label()
        Me.symIncorrect = New System.Windows.Forms.PictureBox()
        Me.ChemicalSymAnswer = New System.Windows.Forms.Label()
        Me.eltIncorrect = New System.Windows.Forms.PictureBox()
        Me.gnCorrect = New System.Windows.Forms.PictureBox()
        Me.ElementAnswer = New System.Windows.Forms.Label()
        Me.disCorrect = New System.Windows.Forms.PictureBox()
        Me.GroupNameComboBox = New System.Windows.Forms.ComboBox()
        Me.dyCorrect = New System.Windows.Forms.PictureBox()
        Me.mpCorrect = New System.Windows.Forms.PictureBox()
        Me.bpCorrect = New System.Windows.Forms.PictureBox()
        Me.MeltingPointComboBox = New System.Windows.Forms.ComboBox()
        Me.symCorrect = New System.Windows.Forms.PictureBox()
        Me.BoilingPointComboBox = New System.Windows.Forms.ComboBox()
        Me.eltCorrect = New System.Windows.Forms.PictureBox()
        Me.ChemicalSymComboBox = New System.Windows.Forms.ComboBox()
        Me.ElementComboBox = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.CheckAnswerButton = New System.Windows.Forms.Button()
        Me.NextButton = New System.Windows.Forms.Button()
        Me.exitQuiz = New System.Windows.Forms.Button()
        Me.QuestionNumber.SuspendLayout()
        CType(Me.gnIncorrect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.disIncorrect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dyIncorrect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mpIncorrect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bpIncorrect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.symIncorrect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.eltIncorrect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gnCorrect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.disCorrect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dyCorrect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mpCorrect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bpCorrect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.symCorrect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.eltCorrect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'elementButton
        '
        Me.elementButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.elementButton.Location = New System.Drawing.Point(49, 41)
        Me.elementButton.Name = "elementButton"
        Me.elementButton.Size = New System.Drawing.Size(50, 60)
        Me.elementButton.TabIndex = 0
        Me.elementButton.UseVisualStyleBackColor = True
        '
        'ElementNameLabel
        '
        Me.ElementNameLabel.AutoSize = True
        Me.ElementNameLabel.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElementNameLabel.Location = New System.Drawing.Point(193, 24)
        Me.ElementNameLabel.Name = "ElementNameLabel"
        Me.ElementNameLabel.Size = New System.Drawing.Size(128, 21)
        Me.ElementNameLabel.TabIndex = 1
        Me.ElementNameLabel.Text = "Element Name:"
        '
        'BoilingPointLabel
        '
        Me.BoilingPointLabel.AutoSize = True
        Me.BoilingPointLabel.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoilingPointLabel.Location = New System.Drawing.Point(200, 139)
        Me.BoilingPointLabel.Name = "BoilingPointLabel"
        Me.BoilingPointLabel.Size = New System.Drawing.Size(121, 21)
        Me.BoilingPointLabel.TabIndex = 2
        Me.BoilingPointLabel.Text = "Boiling Point:"
        '
        'ChemicalSymbolLabel
        '
        Me.ChemicalSymbolLabel.AutoSize = True
        Me.ChemicalSymbolLabel.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChemicalSymbolLabel.Location = New System.Drawing.Point(173, 80)
        Me.ChemicalSymbolLabel.Name = "ChemicalSymbolLabel"
        Me.ChemicalSymbolLabel.Size = New System.Drawing.Size(148, 21)
        Me.ChemicalSymbolLabel.TabIndex = 3
        Me.ChemicalSymbolLabel.Text = "Chemical Symbol:"
        '
        'MeltingPointLabel
        '
        Me.MeltingPointLabel.AutoSize = True
        Me.MeltingPointLabel.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MeltingPointLabel.Location = New System.Drawing.Point(199, 198)
        Me.MeltingPointLabel.Name = "MeltingPointLabel"
        Me.MeltingPointLabel.Size = New System.Drawing.Size(122, 21)
        Me.MeltingPointLabel.TabIndex = 4
        Me.MeltingPointLabel.Text = "Melting Point:"
        '
        'DiscoverYearLabel
        '
        Me.DiscoverYearLabel.AutoSize = True
        Me.DiscoverYearLabel.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiscoverYearLabel.Location = New System.Drawing.Point(6, 316)
        Me.DiscoverYearLabel.Name = "DiscoverYearLabel"
        Me.DiscoverYearLabel.Size = New System.Drawing.Size(321, 21)
        Me.DiscoverYearLabel.TabIndex = 5
        Me.DiscoverYearLabel.Text = "This element was discovered in the year:"
        '
        'GroupNameLabel
        '
        Me.GroupNameLabel.AutoSize = True
        Me.GroupNameLabel.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupNameLabel.Location = New System.Drawing.Point(210, 256)
        Me.GroupNameLabel.Name = "GroupNameLabel"
        Me.GroupNameLabel.Size = New System.Drawing.Size(111, 21)
        Me.GroupNameLabel.TabIndex = 7
        Me.GroupNameLabel.Text = "Group Name:"
        '
        'Instruction
        '
        Me.Instruction.AutoSize = True
        Me.Instruction.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Instruction.Location = New System.Drawing.Point(12, 23)
        Me.Instruction.Name = "Instruction"
        Me.Instruction.Size = New System.Drawing.Size(495, 21)
        Me.Instruction.TabIndex = 8
        Me.Instruction.Text = "Fill in the correct answer for the missing element information."
        '
        'QuestionNumber
        '
        Me.QuestionNumber.Controls.Add(Me.discovererName)
        Me.QuestionNumber.Controls.Add(Me.Label6)
        Me.QuestionNumber.Controls.Add(Me.dYearLabel)
        Me.QuestionNumber.Controls.Add(Me.falseButton)
        Me.QuestionNumber.Controls.Add(Me.trueButton)
        Me.QuestionNumber.Controls.Add(Me.discovererUserAnswer)
        Me.QuestionNumber.Controls.Add(Me.yearTextBox)
        Me.QuestionNumber.Controls.Add(Me.Label7)
        Me.QuestionNumber.Controls.Add(Me.Label5)
        Me.QuestionNumber.Controls.Add(Me.Label4)
        Me.QuestionNumber.Controls.Add(Me.Label3)
        Me.QuestionNumber.Controls.Add(Me.Label2)
        Me.QuestionNumber.Controls.Add(Me.Label1)
        Me.QuestionNumber.Controls.Add(Me.gnIncorrect)
        Me.QuestionNumber.Controls.Add(Me.GNAnswer)
        Me.QuestionNumber.Controls.Add(Me.disIncorrect)
        Me.QuestionNumber.Controls.Add(Me.dyIncorrect)
        Me.QuestionNumber.Controls.Add(Me.DYAnswer)
        Me.QuestionNumber.Controls.Add(Me.mpIncorrect)
        Me.QuestionNumber.Controls.Add(Me.MPAnswer)
        Me.QuestionNumber.Controls.Add(Me.bpIncorrect)
        Me.QuestionNumber.Controls.Add(Me.BPAnswer)
        Me.QuestionNumber.Controls.Add(Me.symIncorrect)
        Me.QuestionNumber.Controls.Add(Me.ChemicalSymAnswer)
        Me.QuestionNumber.Controls.Add(Me.eltIncorrect)
        Me.QuestionNumber.Controls.Add(Me.gnCorrect)
        Me.QuestionNumber.Controls.Add(Me.ElementAnswer)
        Me.QuestionNumber.Controls.Add(Me.disCorrect)
        Me.QuestionNumber.Controls.Add(Me.GroupNameComboBox)
        Me.QuestionNumber.Controls.Add(Me.dyCorrect)
        Me.QuestionNumber.Controls.Add(Me.mpCorrect)
        Me.QuestionNumber.Controls.Add(Me.bpCorrect)
        Me.QuestionNumber.Controls.Add(Me.MeltingPointComboBox)
        Me.QuestionNumber.Controls.Add(Me.symCorrect)
        Me.QuestionNumber.Controls.Add(Me.BoilingPointComboBox)
        Me.QuestionNumber.Controls.Add(Me.eltCorrect)
        Me.QuestionNumber.Controls.Add(Me.ChemicalSymComboBox)
        Me.QuestionNumber.Controls.Add(Me.ElementComboBox)
        Me.QuestionNumber.Controls.Add(Me.ComboBox1)
        Me.QuestionNumber.Controls.Add(Me.elementButton)
        Me.QuestionNumber.Controls.Add(Me.ElementNameLabel)
        Me.QuestionNumber.Controls.Add(Me.GroupNameLabel)
        Me.QuestionNumber.Controls.Add(Me.BoilingPointLabel)
        Me.QuestionNumber.Controls.Add(Me.ChemicalSymbolLabel)
        Me.QuestionNumber.Controls.Add(Me.DiscoverYearLabel)
        Me.QuestionNumber.Controls.Add(Me.MeltingPointLabel)
        Me.QuestionNumber.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuestionNumber.Location = New System.Drawing.Point(16, 58)
        Me.QuestionNumber.Name = "QuestionNumber"
        Me.QuestionNumber.Size = New System.Drawing.Size(570, 431)
        Me.QuestionNumber.TabIndex = 9
        Me.QuestionNumber.TabStop = False
        Me.QuestionNumber.Text = "GroupBox1"
        '
        'discovererName
        '
        Me.discovererName.AutoSize = True
        Me.discovererName.Location = New System.Drawing.Point(327, 368)
        Me.discovererName.Name = "discovererName"
        Me.discovererName.Size = New System.Drawing.Size(64, 21)
        Me.discovererName.TabIndex = 64
        Me.discovererName.Text = "Label8"
        Me.discovererName.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(225, 368)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 21)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Discoverer:"
        Me.Label6.Visible = False
        '
        'dYearLabel
        '
        Me.dYearLabel.AutoSize = True
        Me.dYearLabel.Location = New System.Drawing.Point(188, 316)
        Me.dYearLabel.Name = "dYearLabel"
        Me.dYearLabel.Size = New System.Drawing.Size(133, 21)
        Me.dYearLabel.TabIndex = 62
        Me.dYearLabel.Text = "Discovery Year:"
        Me.dYearLabel.Visible = False
        '
        'falseButton
        '
        Me.falseButton.AutoSize = True
        Me.falseButton.Location = New System.Drawing.Point(192, 392)
        Me.falseButton.Name = "falseButton"
        Me.falseButton.Size = New System.Drawing.Size(70, 25)
        Me.falseButton.TabIndex = 61
        Me.falseButton.TabStop = True
        Me.falseButton.Text = "False"
        Me.falseButton.UseVisualStyleBackColor = True
        '
        'trueButton
        '
        Me.trueButton.AutoSize = True
        Me.trueButton.Location = New System.Drawing.Point(110, 392)
        Me.trueButton.Name = "trueButton"
        Me.trueButton.Size = New System.Drawing.Size(65, 25)
        Me.trueButton.TabIndex = 60
        Me.trueButton.TabStop = True
        Me.trueButton.Text = "True"
        Me.trueButton.UseVisualStyleBackColor = True
        '
        'discovererUserAnswer
        '
        Me.discovererUserAnswer.AutoSize = True
        Me.discovererUserAnswer.Location = New System.Drawing.Point(6, 368)
        Me.discovererUserAnswer.Name = "discovererUserAnswer"
        Me.discovererUserAnswer.Size = New System.Drawing.Size(64, 21)
        Me.discovererUserAnswer.TabIndex = 59
        Me.discovererUserAnswer.Text = "Label8"
        '
        'yearTextBox
        '
        Me.yearTextBox.Location = New System.Drawing.Point(327, 309)
        Me.yearTextBox.Name = "yearTextBox"
        Me.yearTextBox.Size = New System.Drawing.Size(65, 28)
        Me.yearTextBox.TabIndex = 58
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Green
        Me.Label7.Location = New System.Drawing.Point(328, 285)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 21)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "Label7"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(328, 340)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 21)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Label5"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(327, 227)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 21)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(327, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 21)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Label3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(327, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 21)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(328, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 21)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Label1"
        '
        'gnIncorrect
        '
        Me.gnIncorrect.Image = CType(resources.GetObject("gnIncorrect.Image"), System.Drawing.Image)
        Me.gnIncorrect.Location = New System.Drawing.Point(523, 255)
        Me.gnIncorrect.Name = "gnIncorrect"
        Me.gnIncorrect.Size = New System.Drawing.Size(32, 27)
        Me.gnIncorrect.TabIndex = 50
        Me.gnIncorrect.TabStop = False
        '
        'GNAnswer
        '
        Me.GNAnswer.AutoSize = True
        Me.GNAnswer.Location = New System.Drawing.Point(327, 256)
        Me.GNAnswer.Name = "GNAnswer"
        Me.GNAnswer.Size = New System.Drawing.Size(141, 21)
        Me.GNAnswer.TabIndex = 22
        Me.GNAnswer.Text = "Basic Non Metal"
        Me.GNAnswer.Visible = False
        '
        'disIncorrect
        '
        Me.disIncorrect.Image = CType(resources.GetObject("disIncorrect.Image"), System.Drawing.Image)
        Me.disIncorrect.Location = New System.Drawing.Point(268, 392)
        Me.disIncorrect.Name = "disIncorrect"
        Me.disIncorrect.Size = New System.Drawing.Size(32, 27)
        Me.disIncorrect.TabIndex = 49
        Me.disIncorrect.TabStop = False
        '
        'dyIncorrect
        '
        Me.dyIncorrect.Image = CType(resources.GetObject("dyIncorrect.Image"), System.Drawing.Image)
        Me.dyIncorrect.Location = New System.Drawing.Point(398, 310)
        Me.dyIncorrect.Name = "dyIncorrect"
        Me.dyIncorrect.Size = New System.Drawing.Size(32, 27)
        Me.dyIncorrect.TabIndex = 48
        Me.dyIncorrect.TabStop = False
        '
        'DYAnswer
        '
        Me.DYAnswer.AutoSize = True
        Me.DYAnswer.Location = New System.Drawing.Point(327, 316)
        Me.DYAnswer.Name = "DYAnswer"
        Me.DYAnswer.Size = New System.Drawing.Size(120, 21)
        Me.DYAnswer.TabIndex = 20
        Me.DYAnswer.Text = "Long time ago"
        Me.DYAnswer.Visible = False
        '
        'mpIncorrect
        '
        Me.mpIncorrect.Image = CType(resources.GetObject("mpIncorrect.Image"), System.Drawing.Image)
        Me.mpIncorrect.Location = New System.Drawing.Point(523, 197)
        Me.mpIncorrect.Name = "mpIncorrect"
        Me.mpIncorrect.Size = New System.Drawing.Size(32, 27)
        Me.mpIncorrect.TabIndex = 47
        Me.mpIncorrect.TabStop = False
        '
        'MPAnswer
        '
        Me.MPAnswer.AutoSize = True
        Me.MPAnswer.Location = New System.Drawing.Point(327, 198)
        Me.MPAnswer.Name = "MPAnswer"
        Me.MPAnswer.Size = New System.Drawing.Size(65, 21)
        Me.MPAnswer.TabIndex = 19
        Me.MPAnswer.Text = "testMP"
        Me.MPAnswer.Visible = False
        '
        'bpIncorrect
        '
        Me.bpIncorrect.Image = CType(resources.GetObject("bpIncorrect.Image"), System.Drawing.Image)
        Me.bpIncorrect.Location = New System.Drawing.Point(523, 138)
        Me.bpIncorrect.Name = "bpIncorrect"
        Me.bpIncorrect.Size = New System.Drawing.Size(32, 27)
        Me.bpIncorrect.TabIndex = 46
        Me.bpIncorrect.TabStop = False
        '
        'BPAnswer
        '
        Me.BPAnswer.AutoSize = True
        Me.BPAnswer.Location = New System.Drawing.Point(327, 139)
        Me.BPAnswer.Name = "BPAnswer"
        Me.BPAnswer.Size = New System.Drawing.Size(63, 21)
        Me.BPAnswer.TabIndex = 18
        Me.BPAnswer.Text = "testBP"
        Me.BPAnswer.Visible = False
        '
        'symIncorrect
        '
        Me.symIncorrect.Image = CType(resources.GetObject("symIncorrect.Image"), System.Drawing.Image)
        Me.symIncorrect.Location = New System.Drawing.Point(523, 79)
        Me.symIncorrect.Name = "symIncorrect"
        Me.symIncorrect.Size = New System.Drawing.Size(32, 27)
        Me.symIncorrect.TabIndex = 45
        Me.symIncorrect.TabStop = False
        '
        'ChemicalSymAnswer
        '
        Me.ChemicalSymAnswer.AutoSize = True
        Me.ChemicalSymAnswer.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChemicalSymAnswer.Location = New System.Drawing.Point(327, 80)
        Me.ChemicalSymAnswer.Name = "ChemicalSymAnswer"
        Me.ChemicalSymAnswer.Size = New System.Drawing.Size(52, 21)
        Me.ChemicalSymAnswer.TabIndex = 17
        Me.ChemicalSymAnswer.Text = "Symb"
        Me.ChemicalSymAnswer.Visible = False
        '
        'eltIncorrect
        '
        Me.eltIncorrect.Image = CType(resources.GetObject("eltIncorrect.Image"), System.Drawing.Image)
        Me.eltIncorrect.Location = New System.Drawing.Point(523, 23)
        Me.eltIncorrect.Name = "eltIncorrect"
        Me.eltIncorrect.Size = New System.Drawing.Size(32, 27)
        Me.eltIncorrect.TabIndex = 44
        Me.eltIncorrect.TabStop = False
        '
        'gnCorrect
        '
        Me.gnCorrect.Image = CType(resources.GetObject("gnCorrect.Image"), System.Drawing.Image)
        Me.gnCorrect.Location = New System.Drawing.Point(523, 250)
        Me.gnCorrect.Name = "gnCorrect"
        Me.gnCorrect.Size = New System.Drawing.Size(32, 32)
        Me.gnCorrect.TabIndex = 43
        Me.gnCorrect.TabStop = False
        '
        'ElementAnswer
        '
        Me.ElementAnswer.AutoSize = True
        Me.ElementAnswer.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElementAnswer.Location = New System.Drawing.Point(327, 24)
        Me.ElementAnswer.Name = "ElementAnswer"
        Me.ElementAnswer.Size = New System.Drawing.Size(81, 21)
        Me.ElementAnswer.TabIndex = 16
        Me.ElementAnswer.Text = "testName"
        Me.ElementAnswer.Visible = False
        '
        'disCorrect
        '
        Me.disCorrect.Image = CType(resources.GetObject("disCorrect.Image"), System.Drawing.Image)
        Me.disCorrect.Location = New System.Drawing.Point(268, 387)
        Me.disCorrect.Name = "disCorrect"
        Me.disCorrect.Size = New System.Drawing.Size(32, 32)
        Me.disCorrect.TabIndex = 42
        Me.disCorrect.TabStop = False
        '
        'GroupNameComboBox
        '
        Me.GroupNameComboBox.FormattingEnabled = True
        Me.GroupNameComboBox.Location = New System.Drawing.Point(327, 253)
        Me.GroupNameComboBox.Name = "GroupNameComboBox"
        Me.GroupNameComboBox.Size = New System.Drawing.Size(190, 29)
        Me.GroupNameComboBox.TabIndex = 15
        '
        'dyCorrect
        '
        Me.dyCorrect.Image = CType(resources.GetObject("dyCorrect.Image"), System.Drawing.Image)
        Me.dyCorrect.Location = New System.Drawing.Point(398, 305)
        Me.dyCorrect.Name = "dyCorrect"
        Me.dyCorrect.Size = New System.Drawing.Size(32, 32)
        Me.dyCorrect.TabIndex = 41
        Me.dyCorrect.TabStop = False
        '
        'mpCorrect
        '
        Me.mpCorrect.Image = CType(resources.GetObject("mpCorrect.Image"), System.Drawing.Image)
        Me.mpCorrect.Location = New System.Drawing.Point(523, 192)
        Me.mpCorrect.Name = "mpCorrect"
        Me.mpCorrect.Size = New System.Drawing.Size(32, 32)
        Me.mpCorrect.TabIndex = 40
        Me.mpCorrect.TabStop = False
        '
        'bpCorrect
        '
        Me.bpCorrect.Image = CType(resources.GetObject("bpCorrect.Image"), System.Drawing.Image)
        Me.bpCorrect.Location = New System.Drawing.Point(523, 133)
        Me.bpCorrect.Name = "bpCorrect"
        Me.bpCorrect.Size = New System.Drawing.Size(32, 32)
        Me.bpCorrect.TabIndex = 39
        Me.bpCorrect.TabStop = False
        '
        'MeltingPointComboBox
        '
        Me.MeltingPointComboBox.FormattingEnabled = True
        Me.MeltingPointComboBox.Location = New System.Drawing.Point(327, 195)
        Me.MeltingPointComboBox.Name = "MeltingPointComboBox"
        Me.MeltingPointComboBox.Size = New System.Drawing.Size(190, 29)
        Me.MeltingPointComboBox.TabIndex = 12
        '
        'symCorrect
        '
        Me.symCorrect.Image = CType(resources.GetObject("symCorrect.Image"), System.Drawing.Image)
        Me.symCorrect.Location = New System.Drawing.Point(523, 74)
        Me.symCorrect.Name = "symCorrect"
        Me.symCorrect.Size = New System.Drawing.Size(32, 32)
        Me.symCorrect.TabIndex = 38
        Me.symCorrect.TabStop = False
        '
        'BoilingPointComboBox
        '
        Me.BoilingPointComboBox.FormattingEnabled = True
        Me.BoilingPointComboBox.Location = New System.Drawing.Point(327, 136)
        Me.BoilingPointComboBox.Name = "BoilingPointComboBox"
        Me.BoilingPointComboBox.Size = New System.Drawing.Size(190, 29)
        Me.BoilingPointComboBox.TabIndex = 11
        '
        'eltCorrect
        '
        Me.eltCorrect.Image = CType(resources.GetObject("eltCorrect.Image"), System.Drawing.Image)
        Me.eltCorrect.Location = New System.Drawing.Point(523, 18)
        Me.eltCorrect.Name = "eltCorrect"
        Me.eltCorrect.Size = New System.Drawing.Size(32, 32)
        Me.eltCorrect.TabIndex = 37
        Me.eltCorrect.TabStop = False
        '
        'ChemicalSymComboBox
        '
        Me.ChemicalSymComboBox.FormattingEnabled = True
        Me.ChemicalSymComboBox.Location = New System.Drawing.Point(327, 77)
        Me.ChemicalSymComboBox.Name = "ChemicalSymComboBox"
        Me.ChemicalSymComboBox.Size = New System.Drawing.Size(190, 29)
        Me.ChemicalSymComboBox.TabIndex = 10
        '
        'ElementComboBox
        '
        Me.ElementComboBox.FormattingEnabled = True
        Me.ElementComboBox.Location = New System.Drawing.Point(327, 21)
        Me.ElementComboBox.Name = "ElementComboBox"
        Me.ElementComboBox.Size = New System.Drawing.Size(190, 29)
        Me.ElementComboBox.TabIndex = 9
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(327, 24)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(0, 29)
        Me.ComboBox1.TabIndex = 8
        '
        'CheckAnswerButton
        '
        Me.CheckAnswerButton.Location = New System.Drawing.Point(349, 495)
        Me.CheckAnswerButton.Name = "CheckAnswerButton"
        Me.CheckAnswerButton.Size = New System.Drawing.Size(75, 38)
        Me.CheckAnswerButton.TabIndex = 10
        Me.CheckAnswerButton.Text = "Check Answers"
        Me.CheckAnswerButton.UseVisualStyleBackColor = True
        '
        'NextButton
        '
        Me.NextButton.Location = New System.Drawing.Point(430, 495)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(75, 38)
        Me.NextButton.TabIndex = 11
        Me.NextButton.Text = "Next"
        Me.NextButton.UseVisualStyleBackColor = True
        '
        'exitQuiz
        '
        Me.exitQuiz.Location = New System.Drawing.Point(511, 495)
        Me.exitQuiz.Name = "exitQuiz"
        Me.exitQuiz.Size = New System.Drawing.Size(75, 38)
        Me.exitQuiz.TabIndex = 12
        Me.exitQuiz.Text = "Exit Quiz"
        Me.exitQuiz.UseVisualStyleBackColor = True
        '
        'Quiz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 544)
        Me.Controls.Add(Me.exitQuiz)
        Me.Controls.Add(Me.NextButton)
        Me.Controls.Add(Me.CheckAnswerButton)
        Me.Controls.Add(Me.QuestionNumber)
        Me.Controls.Add(Me.Instruction)
        Me.Name = "Quiz"
        Me.Text = "Quiz"
        Me.QuestionNumber.ResumeLayout(False)
        Me.QuestionNumber.PerformLayout()
        CType(Me.gnIncorrect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.disIncorrect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dyIncorrect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mpIncorrect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bpIncorrect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.symIncorrect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.eltIncorrect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gnCorrect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.disCorrect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dyCorrect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mpCorrect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bpCorrect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.symCorrect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.eltCorrect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents elementButton As System.Windows.Forms.Button
    Friend WithEvents ElementNameLabel As System.Windows.Forms.Label
    Friend WithEvents BoilingPointLabel As System.Windows.Forms.Label
    Friend WithEvents ChemicalSymbolLabel As System.Windows.Forms.Label
    Friend WithEvents MeltingPointLabel As System.Windows.Forms.Label
    Friend WithEvents DiscoverYearLabel As System.Windows.Forms.Label
    Friend WithEvents GroupNameLabel As System.Windows.Forms.Label
    Friend WithEvents Instruction As System.Windows.Forms.Label
    Friend WithEvents QuestionNumber As System.Windows.Forms.GroupBox
    Friend WithEvents ElementComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupNameComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents MeltingPointComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents BoilingPointComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ChemicalSymComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CheckAnswerButton As System.Windows.Forms.Button
    Friend WithEvents ElementAnswer As System.Windows.Forms.Label
    Friend WithEvents ChemicalSymAnswer As System.Windows.Forms.Label
    Friend WithEvents GNAnswer As System.Windows.Forms.Label
    Friend WithEvents DYAnswer As System.Windows.Forms.Label
    Friend WithEvents MPAnswer As System.Windows.Forms.Label
    Friend WithEvents BPAnswer As System.Windows.Forms.Label
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents gnIncorrect As System.Windows.Forms.PictureBox
    Friend WithEvents disIncorrect As System.Windows.Forms.PictureBox
    Friend WithEvents dyIncorrect As System.Windows.Forms.PictureBox
    Friend WithEvents mpIncorrect As System.Windows.Forms.PictureBox
    Friend WithEvents bpIncorrect As System.Windows.Forms.PictureBox
    Friend WithEvents symIncorrect As System.Windows.Forms.PictureBox
    Friend WithEvents eltIncorrect As System.Windows.Forms.PictureBox
    Friend WithEvents gnCorrect As System.Windows.Forms.PictureBox
    Friend WithEvents disCorrect As System.Windows.Forms.PictureBox
    Friend WithEvents dyCorrect As System.Windows.Forms.PictureBox
    Friend WithEvents mpCorrect As System.Windows.Forms.PictureBox
    Friend WithEvents bpCorrect As System.Windows.Forms.PictureBox
    Friend WithEvents symCorrect As System.Windows.Forms.PictureBox
    Friend WithEvents eltCorrect As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents yearTextBox As System.Windows.Forms.TextBox
    Friend WithEvents discovererUserAnswer As System.Windows.Forms.Label
    Friend WithEvents falseButton As System.Windows.Forms.RadioButton
    Friend WithEvents trueButton As System.Windows.Forms.RadioButton
    Friend WithEvents dYearLabel As System.Windows.Forms.Label
    Friend WithEvents discovererName As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents exitQuiz As System.Windows.Forms.Button
End Class
