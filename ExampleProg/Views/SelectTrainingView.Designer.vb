<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectTrainingView
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
        Me.SelectTrainingCancelButton = New System.Windows.Forms.Button()
        Me.ExplanationButton = New System.Windows.Forms.Button()
        Me.SubjectListBox = New System.Windows.Forms.ListBox()
        Me.CurriculumListBox = New System.Windows.Forms.ListBox()
        Me.KeyStageListBox = New System.Windows.Forms.ListBox()
        Me.SelectSubjectLabel = New System.Windows.Forms.Label()
        Me.SelectCurriculumLabel = New System.Windows.Forms.Label()
        Me.SelectKeyStageLabel = New System.Windows.Forms.Label()
        Me.ExplanationListBox = New System.Windows.Forms.ListBox()
        Me.SelectExplanationLabel = New System.Windows.Forms.Label()
        Me.TrainingTabControl = New System.Windows.Forms.TabControl()
        Me.SelectionTabPage = New System.Windows.Forms.TabPage()
        Me.ExplanationTabPage = New System.Windows.Forms.TabPage()
        Me.ExplanationTrainingTextBox = New System.Windows.Forms.TextBox()
        Me.ExplanationTitleLabel = New System.Windows.Forms.Label()
        Me.ExplanationLabel = New System.Windows.Forms.Label()
        Me.DemonstrationTabPage = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DemoPreviousButton = New System.Windows.Forms.Button()
        Me.DemoNextButton = New System.Windows.Forms.Button()
        Me.DemoDetailLabel = New System.Windows.Forms.Label()
        Me.DemoStepDetailsTextBox = New System.Windows.Forms.TextBox()
        Me.DemoAmountSteps = New System.Windows.Forms.Label()
        Me.DemoStepsLabel = New System.Windows.Forms.Label()
        Me.ImmitationTabPage = New System.Windows.Forms.TabPage()
        Me.ImmitationCheckButton = New System.Windows.Forms.Button()
        Me.ImmitationTextBox = New System.Windows.Forms.TextBox()
        Me.ImmitationDetailsGroupBoxLabel = New System.Windows.Forms.Label()
        Me.TrainingImmitationGuideLabel = New System.Windows.Forms.Label()
        Me.PracticeTabPage = New System.Windows.Forms.TabPage()
        Me.DemoButton = New System.Windows.Forms.Button()
        Me.ImmitationButton = New System.Windows.Forms.Button()
        Me.PracticeButton = New System.Windows.Forms.Button()
        Me.PracticeTitleLabel = New System.Windows.Forms.Label()
        Me.PracticeQuestionLabel = New System.Windows.Forms.Label()
        Me.DemoDetailGroupBoxLabel = New System.Windows.Forms.Label()
        Me.ImmitationDemoTextBox = New System.Windows.Forms.TextBox()
        Me.PracticeInputBox = New System.Windows.Forms.TextBox()
        Me.PracticeCheckButton = New System.Windows.Forms.Button()
        Me.PracticeAnswerLabel = New System.Windows.Forms.Label()
        Me.TrainingTabControl.SuspendLayout()
        Me.SelectionTabPage.SuspendLayout()
        Me.ExplanationTabPage.SuspendLayout()
        Me.DemonstrationTabPage.SuspendLayout()
        Me.ImmitationTabPage.SuspendLayout()
        Me.PracticeTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'SelectTrainingCancelButton
        '
        Me.SelectTrainingCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.SelectTrainingCancelButton.Location = New System.Drawing.Point(17, 299)
        Me.SelectTrainingCancelButton.Name = "SelectTrainingCancelButton"
        Me.SelectTrainingCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.SelectTrainingCancelButton.TabIndex = 6
        Me.SelectTrainingCancelButton.Text = "Cancel"
        Me.SelectTrainingCancelButton.UseVisualStyleBackColor = True
        '
        'ExplanationButton
        '
        Me.ExplanationButton.Enabled = False
        Me.ExplanationButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ExplanationButton.Location = New System.Drawing.Point(626, 299)
        Me.ExplanationButton.Name = "ExplanationButton"
        Me.ExplanationButton.Size = New System.Drawing.Size(87, 23)
        Me.ExplanationButton.TabIndex = 9
        Me.ExplanationButton.Text = "Explanation"
        Me.ExplanationButton.UseVisualStyleBackColor = True
        '
        'SubjectListBox
        '
        Me.SubjectListBox.BackColor = System.Drawing.Color.Black
        Me.SubjectListBox.ForeColor = System.Drawing.Color.White
        Me.SubjectListBox.FormattingEnabled = True
        Me.SubjectListBox.Location = New System.Drawing.Point(9, 19)
        Me.SubjectListBox.Name = "SubjectListBox"
        Me.SubjectListBox.Size = New System.Drawing.Size(673, 43)
        Me.SubjectListBox.TabIndex = 10
        '
        'CurriculumListBox
        '
        Me.CurriculumListBox.BackColor = System.Drawing.Color.Black
        Me.CurriculumListBox.Enabled = False
        Me.CurriculumListBox.ForeColor = System.Drawing.Color.White
        Me.CurriculumListBox.FormattingEnabled = True
        Me.CurriculumListBox.Location = New System.Drawing.Point(9, 82)
        Me.CurriculumListBox.Name = "CurriculumListBox"
        Me.CurriculumListBox.Size = New System.Drawing.Size(673, 43)
        Me.CurriculumListBox.TabIndex = 11
        '
        'KeyStageListBox
        '
        Me.KeyStageListBox.BackColor = System.Drawing.Color.Black
        Me.KeyStageListBox.Enabled = False
        Me.KeyStageListBox.ForeColor = System.Drawing.Color.White
        Me.KeyStageListBox.FormattingEnabled = True
        Me.KeyStageListBox.Location = New System.Drawing.Point(9, 144)
        Me.KeyStageListBox.Name = "KeyStageListBox"
        Me.KeyStageListBox.Size = New System.Drawing.Size(673, 43)
        Me.KeyStageListBox.TabIndex = 12
        '
        'SelectSubjectLabel
        '
        Me.SelectSubjectLabel.AutoSize = True
        Me.SelectSubjectLabel.ForeColor = System.Drawing.Color.White
        Me.SelectSubjectLabel.Location = New System.Drawing.Point(6, 3)
        Me.SelectSubjectLabel.Name = "SelectSubjectLabel"
        Me.SelectSubjectLabel.Size = New System.Drawing.Size(79, 13)
        Me.SelectSubjectLabel.TabIndex = 13
        Me.SelectSubjectLabel.Text = "Select Subject:"
        '
        'SelectCurriculumLabel
        '
        Me.SelectCurriculumLabel.AutoSize = True
        Me.SelectCurriculumLabel.ForeColor = System.Drawing.Color.White
        Me.SelectCurriculumLabel.Location = New System.Drawing.Point(6, 66)
        Me.SelectCurriculumLabel.Name = "SelectCurriculumLabel"
        Me.SelectCurriculumLabel.Size = New System.Drawing.Size(92, 13)
        Me.SelectCurriculumLabel.TabIndex = 14
        Me.SelectCurriculumLabel.Text = "Select Curriculum:"
        '
        'SelectKeyStageLabel
        '
        Me.SelectKeyStageLabel.AutoSize = True
        Me.SelectKeyStageLabel.ForeColor = System.Drawing.Color.White
        Me.SelectKeyStageLabel.Location = New System.Drawing.Point(6, 128)
        Me.SelectKeyStageLabel.Name = "SelectKeyStageLabel"
        Me.SelectKeyStageLabel.Size = New System.Drawing.Size(92, 13)
        Me.SelectKeyStageLabel.TabIndex = 15
        Me.SelectKeyStageLabel.Text = "Select Key Stage:"
        '
        'ExplanationListBox
        '
        Me.ExplanationListBox.BackColor = System.Drawing.Color.Black
        Me.ExplanationListBox.Enabled = False
        Me.ExplanationListBox.ForeColor = System.Drawing.Color.White
        Me.ExplanationListBox.FormattingEnabled = True
        Me.ExplanationListBox.Location = New System.Drawing.Point(9, 206)
        Me.ExplanationListBox.Name = "ExplanationListBox"
        Me.ExplanationListBox.Size = New System.Drawing.Size(673, 43)
        Me.ExplanationListBox.TabIndex = 16
        '
        'SelectExplanationLabel
        '
        Me.SelectExplanationLabel.AutoSize = True
        Me.SelectExplanationLabel.ForeColor = System.Drawing.Color.White
        Me.SelectExplanationLabel.Location = New System.Drawing.Point(6, 190)
        Me.SelectExplanationLabel.Name = "SelectExplanationLabel"
        Me.SelectExplanationLabel.Size = New System.Drawing.Size(98, 13)
        Me.SelectExplanationLabel.TabIndex = 17
        Me.SelectExplanationLabel.Text = "Select Explanation:"
        '
        'TrainingTabControl
        '
        Me.TrainingTabControl.Controls.Add(Me.SelectionTabPage)
        Me.TrainingTabControl.Controls.Add(Me.ExplanationTabPage)
        Me.TrainingTabControl.Controls.Add(Me.DemonstrationTabPage)
        Me.TrainingTabControl.Controls.Add(Me.ImmitationTabPage)
        Me.TrainingTabControl.Controls.Add(Me.PracticeTabPage)
        Me.TrainingTabControl.Location = New System.Drawing.Point(17, 12)
        Me.TrainingTabControl.Name = "TrainingTabControl"
        Me.TrainingTabControl.SelectedIndex = 0
        Me.TrainingTabControl.Size = New System.Drawing.Size(696, 281)
        Me.TrainingTabControl.TabIndex = 18
        '
        'SelectionTabPage
        '
        Me.SelectionTabPage.BackColor = System.Drawing.Color.Black
        Me.SelectionTabPage.Controls.Add(Me.SelectSubjectLabel)
        Me.SelectionTabPage.Controls.Add(Me.ExplanationListBox)
        Me.SelectionTabPage.Controls.Add(Me.SelectExplanationLabel)
        Me.SelectionTabPage.Controls.Add(Me.SubjectListBox)
        Me.SelectionTabPage.Controls.Add(Me.SelectCurriculumLabel)
        Me.SelectionTabPage.Controls.Add(Me.KeyStageListBox)
        Me.SelectionTabPage.Controls.Add(Me.SelectKeyStageLabel)
        Me.SelectionTabPage.Controls.Add(Me.CurriculumListBox)
        Me.SelectionTabPage.ForeColor = System.Drawing.Color.White
        Me.SelectionTabPage.Location = New System.Drawing.Point(4, 22)
        Me.SelectionTabPage.Name = "SelectionTabPage"
        Me.SelectionTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SelectionTabPage.Size = New System.Drawing.Size(688, 255)
        Me.SelectionTabPage.TabIndex = 0
        Me.SelectionTabPage.Text = "Selection"
        '
        'ExplanationTabPage
        '
        Me.ExplanationTabPage.BackColor = System.Drawing.Color.Black
        Me.ExplanationTabPage.Controls.Add(Me.ExplanationTrainingTextBox)
        Me.ExplanationTabPage.Controls.Add(Me.ExplanationTitleLabel)
        Me.ExplanationTabPage.Controls.Add(Me.ExplanationLabel)
        Me.ExplanationTabPage.ForeColor = System.Drawing.Color.White
        Me.ExplanationTabPage.Location = New System.Drawing.Point(4, 22)
        Me.ExplanationTabPage.Name = "ExplanationTabPage"
        Me.ExplanationTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.ExplanationTabPage.Size = New System.Drawing.Size(688, 255)
        Me.ExplanationTabPage.TabIndex = 1
        Me.ExplanationTabPage.Text = "Explanation"
        '
        'ExplanationTrainingTextBox
        '
        Me.ExplanationTrainingTextBox.BackColor = System.Drawing.Color.Black
        Me.ExplanationTrainingTextBox.ForeColor = System.Drawing.Color.White
        Me.ExplanationTrainingTextBox.Location = New System.Drawing.Point(9, 48)
        Me.ExplanationTrainingTextBox.Multiline = True
        Me.ExplanationTrainingTextBox.Name = "ExplanationTrainingTextBox"
        Me.ExplanationTrainingTextBox.ReadOnly = True
        Me.ExplanationTrainingTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ExplanationTrainingTextBox.Size = New System.Drawing.Size(673, 201)
        Me.ExplanationTrainingTextBox.TabIndex = 2
        '
        'ExplanationTitleLabel
        '
        Me.ExplanationTitleLabel.AutoSize = True
        Me.ExplanationTitleLabel.Location = New System.Drawing.Point(6, 32)
        Me.ExplanationTitleLabel.Name = "ExplanationTitleLabel"
        Me.ExplanationTitleLabel.Size = New System.Drawing.Size(39, 13)
        Me.ExplanationTitleLabel.TabIndex = 1
        Me.ExplanationTitleLabel.Text = "Label1"
        '
        'ExplanationLabel
        '
        Me.ExplanationLabel.AutoSize = True
        Me.ExplanationLabel.Location = New System.Drawing.Point(6, 3)
        Me.ExplanationLabel.Name = "ExplanationLabel"
        Me.ExplanationLabel.Size = New System.Drawing.Size(140, 13)
        Me.ExplanationLabel.TabIndex = 0
        Me.ExplanationLabel.Text = "Read the following carefully."
        '
        'DemonstrationTabPage
        '
        Me.DemonstrationTabPage.BackColor = System.Drawing.Color.Black
        Me.DemonstrationTabPage.Controls.Add(Me.Label2)
        Me.DemonstrationTabPage.Controls.Add(Me.Label1)
        Me.DemonstrationTabPage.Controls.Add(Me.DemoPreviousButton)
        Me.DemonstrationTabPage.Controls.Add(Me.DemoNextButton)
        Me.DemonstrationTabPage.Controls.Add(Me.DemoDetailLabel)
        Me.DemonstrationTabPage.Controls.Add(Me.DemoStepDetailsTextBox)
        Me.DemonstrationTabPage.Controls.Add(Me.DemoAmountSteps)
        Me.DemonstrationTabPage.Controls.Add(Me.DemoStepsLabel)
        Me.DemonstrationTabPage.ForeColor = System.Drawing.Color.White
        Me.DemonstrationTabPage.Location = New System.Drawing.Point(4, 22)
        Me.DemonstrationTabPage.Name = "DemonstrationTabPage"
        Me.DemonstrationTabPage.Size = New System.Drawing.Size(688, 255)
        Me.DemonstrationTabPage.TabIndex = 2
        Me.DemonstrationTabPage.Text = "Demonstration"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 201)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(217, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "When finished, click the ""Immitation"" button."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(362, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Read each of the demonstration steps carefully.  When ready, click ""Next""."
        '
        'DemoPreviousButton
        '
        Me.DemoPreviousButton.Enabled = False
        Me.DemoPreviousButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DemoPreviousButton.ForeColor = System.Drawing.Color.Black
        Me.DemoPreviousButton.Location = New System.Drawing.Point(529, 121)
        Me.DemoPreviousButton.Name = "DemoPreviousButton"
        Me.DemoPreviousButton.Size = New System.Drawing.Size(75, 23)
        Me.DemoPreviousButton.TabIndex = 5
        Me.DemoPreviousButton.Text = "Previous"
        Me.DemoPreviousButton.UseVisualStyleBackColor = True
        '
        'DemoNextButton
        '
        Me.DemoNextButton.Enabled = False
        Me.DemoNextButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DemoNextButton.ForeColor = System.Drawing.Color.Black
        Me.DemoNextButton.Location = New System.Drawing.Point(610, 121)
        Me.DemoNextButton.Name = "DemoNextButton"
        Me.DemoNextButton.Size = New System.Drawing.Size(75, 23)
        Me.DemoNextButton.TabIndex = 4
        Me.DemoNextButton.Text = "Next"
        Me.DemoNextButton.UseVisualStyleBackColor = True
        '
        'DemoDetailLabel
        '
        Me.DemoDetailLabel.AutoSize = True
        Me.DemoDetailLabel.Location = New System.Drawing.Point(0, 73)
        Me.DemoDetailLabel.Name = "DemoDetailLabel"
        Me.DemoDetailLabel.Size = New System.Drawing.Size(113, 13)
        Me.DemoDetailLabel.TabIndex = 3
        Me.DemoDetailLabel.Text = "Demonstration Details:"
        '
        'DemoStepDetailsTextBox
        '
        Me.DemoStepDetailsTextBox.BackColor = System.Drawing.Color.Black
        Me.DemoStepDetailsTextBox.ForeColor = System.Drawing.Color.White
        Me.DemoStepDetailsTextBox.Location = New System.Drawing.Point(3, 89)
        Me.DemoStepDetailsTextBox.Name = "DemoStepDetailsTextBox"
        Me.DemoStepDetailsTextBox.Size = New System.Drawing.Size(682, 20)
        Me.DemoStepDetailsTextBox.TabIndex = 2
        '
        'DemoAmountSteps
        '
        Me.DemoAmountSteps.AutoSize = True
        Me.DemoAmountSteps.Location = New System.Drawing.Point(620, 242)
        Me.DemoAmountSteps.Name = "DemoAmountSteps"
        Me.DemoAmountSteps.Size = New System.Drawing.Size(13, 13)
        Me.DemoAmountSteps.TabIndex = 1
        Me.DemoAmountSteps.Text = "0"
        '
        'DemoStepsLabel
        '
        Me.DemoStepsLabel.AutoSize = True
        Me.DemoStepsLabel.Location = New System.Drawing.Point(488, 242)
        Me.DemoStepsLabel.Name = "DemoStepsLabel"
        Me.DemoStepsLabel.Size = New System.Drawing.Size(117, 13)
        Me.DemoStepsLabel.TabIndex = 0
        Me.DemoStepsLabel.Text = "Total Amount Of Steps:"
        '
        'ImmitationTabPage
        '
        Me.ImmitationTabPage.BackColor = System.Drawing.Color.Black
        Me.ImmitationTabPage.Controls.Add(Me.ImmitationTextBox)
        Me.ImmitationTabPage.Controls.Add(Me.ImmitationDemoTextBox)
        Me.ImmitationTabPage.Controls.Add(Me.ImmitationDetailsGroupBoxLabel)
        Me.ImmitationTabPage.Controls.Add(Me.ImmitationCheckButton)
        Me.ImmitationTabPage.Controls.Add(Me.DemoDetailGroupBoxLabel)
        Me.ImmitationTabPage.Controls.Add(Me.TrainingImmitationGuideLabel)
        Me.ImmitationTabPage.ForeColor = System.Drawing.Color.White
        Me.ImmitationTabPage.Location = New System.Drawing.Point(4, 22)
        Me.ImmitationTabPage.Name = "ImmitationTabPage"
        Me.ImmitationTabPage.Size = New System.Drawing.Size(688, 255)
        Me.ImmitationTabPage.TabIndex = 3
        Me.ImmitationTabPage.Text = "Immitation"
        '
        'ImmitationCheckButton
        '
        Me.ImmitationCheckButton.Enabled = False
        Me.ImmitationCheckButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ImmitationCheckButton.ForeColor = System.Drawing.Color.Black
        Me.ImmitationCheckButton.Location = New System.Drawing.Point(600, 214)
        Me.ImmitationCheckButton.Name = "ImmitationCheckButton"
        Me.ImmitationCheckButton.Size = New System.Drawing.Size(75, 23)
        Me.ImmitationCheckButton.TabIndex = 5
        Me.ImmitationCheckButton.Text = "Check"
        Me.ImmitationCheckButton.UseVisualStyleBackColor = True
        '
        'ImmitationTextBox
        '
        Me.ImmitationTextBox.BackColor = System.Drawing.Color.Black
        Me.ImmitationTextBox.ForeColor = System.Drawing.Color.White
        Me.ImmitationTextBox.Location = New System.Drawing.Point(353, 90)
        Me.ImmitationTextBox.Name = "ImmitationTextBox"
        Me.ImmitationTextBox.Size = New System.Drawing.Size(322, 20)
        Me.ImmitationTextBox.TabIndex = 5
        '
        'ImmitationDetailsGroupBoxLabel
        '
        Me.ImmitationDetailsGroupBoxLabel.AutoSize = True
        Me.ImmitationDetailsGroupBoxLabel.Location = New System.Drawing.Point(583, 37)
        Me.ImmitationDetailsGroupBoxLabel.Name = "ImmitationDetailsGroupBoxLabel"
        Me.ImmitationDetailsGroupBoxLabel.Size = New System.Drawing.Size(92, 13)
        Me.ImmitationDetailsGroupBoxLabel.TabIndex = 3
        Me.ImmitationDetailsGroupBoxLabel.Text = "Immitation Details:"
        '
        'TrainingImmitationGuideLabel
        '
        Me.TrainingImmitationGuideLabel.AutoSize = True
        Me.TrainingImmitationGuideLabel.Location = New System.Drawing.Point(4, 4)
        Me.TrainingImmitationGuideLabel.Name = "TrainingImmitationGuideLabel"
        Me.TrainingImmitationGuideLabel.Size = New System.Drawing.Size(129, 13)
        Me.TrainingImmitationGuideLabel.TabIndex = 0
        Me.TrainingImmitationGuideLabel.Text = "Immitate the steps shown."
        '
        'PracticeTabPage
        '
        Me.PracticeTabPage.BackColor = System.Drawing.Color.Black
        Me.PracticeTabPage.Controls.Add(Me.PracticeAnswerLabel)
        Me.PracticeTabPage.Controls.Add(Me.PracticeCheckButton)
        Me.PracticeTabPage.Controls.Add(Me.PracticeInputBox)
        Me.PracticeTabPage.Controls.Add(Me.PracticeQuestionLabel)
        Me.PracticeTabPage.Controls.Add(Me.PracticeTitleLabel)
        Me.PracticeTabPage.ForeColor = System.Drawing.Color.White
        Me.PracticeTabPage.Location = New System.Drawing.Point(4, 22)
        Me.PracticeTabPage.Name = "PracticeTabPage"
        Me.PracticeTabPage.Size = New System.Drawing.Size(688, 255)
        Me.PracticeTabPage.TabIndex = 4
        Me.PracticeTabPage.Text = "Practice"
        '
        'DemoButton
        '
        Me.DemoButton.Enabled = False
        Me.DemoButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DemoButton.Location = New System.Drawing.Point(626, 299)
        Me.DemoButton.Name = "DemoButton"
        Me.DemoButton.Size = New System.Drawing.Size(87, 23)
        Me.DemoButton.TabIndex = 19
        Me.DemoButton.Text = "Demonstration"
        Me.DemoButton.UseVisualStyleBackColor = True
        Me.DemoButton.Visible = False
        '
        'ImmitationButton
        '
        Me.ImmitationButton.Enabled = False
        Me.ImmitationButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ImmitationButton.Location = New System.Drawing.Point(626, 299)
        Me.ImmitationButton.Name = "ImmitationButton"
        Me.ImmitationButton.Size = New System.Drawing.Size(87, 23)
        Me.ImmitationButton.TabIndex = 20
        Me.ImmitationButton.Text = "Immitation"
        Me.ImmitationButton.UseVisualStyleBackColor = True
        Me.ImmitationButton.Visible = False
        '
        'PracticeButton
        '
        Me.PracticeButton.Enabled = False
        Me.PracticeButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PracticeButton.Location = New System.Drawing.Point(626, 299)
        Me.PracticeButton.Name = "PracticeButton"
        Me.PracticeButton.Size = New System.Drawing.Size(87, 23)
        Me.PracticeButton.TabIndex = 21
        Me.PracticeButton.Text = "Practice"
        Me.PracticeButton.UseVisualStyleBackColor = True
        Me.PracticeButton.Visible = False
        '
        'PracticeTitleLabel
        '
        Me.PracticeTitleLabel.AutoSize = True
        Me.PracticeTitleLabel.Location = New System.Drawing.Point(3, 11)
        Me.PracticeTitleLabel.Name = "PracticeTitleLabel"
        Me.PracticeTitleLabel.Size = New System.Drawing.Size(109, 13)
        Me.PracticeTitleLabel.TabIndex = 0
        Me.PracticeTitleLabel.Text = "Time for real practice."
        '
        'PracticeQuestionLabel
        '
        Me.PracticeQuestionLabel.AutoSize = True
        Me.PracticeQuestionLabel.Location = New System.Drawing.Point(3, 37)
        Me.PracticeQuestionLabel.Name = "PracticeQuestionLabel"
        Me.PracticeQuestionLabel.Size = New System.Drawing.Size(58, 13)
        Me.PracticeQuestionLabel.TabIndex = 1
        Me.PracticeQuestionLabel.Text = "Question..."
        '
        'DemoDetailGroupBoxLabel
        '
        Me.DemoDetailGroupBoxLabel.AutoSize = True
        Me.DemoDetailGroupBoxLabel.Location = New System.Drawing.Point(20, 37)
        Me.DemoDetailGroupBoxLabel.Name = "DemoDetailGroupBoxLabel"
        Me.DemoDetailGroupBoxLabel.Size = New System.Drawing.Size(113, 13)
        Me.DemoDetailGroupBoxLabel.TabIndex = 3
        Me.DemoDetailGroupBoxLabel.Text = "Demonstration Details:"
        '
        'ImmitationDemoTextBox
        '
        Me.ImmitationDemoTextBox.BackColor = System.Drawing.Color.Black
        Me.ImmitationDemoTextBox.Enabled = False
        Me.ImmitationDemoTextBox.ForeColor = System.Drawing.Color.White
        Me.ImmitationDemoTextBox.Location = New System.Drawing.Point(19, 90)
        Me.ImmitationDemoTextBox.Name = "ImmitationDemoTextBox"
        Me.ImmitationDemoTextBox.Size = New System.Drawing.Size(322, 20)
        Me.ImmitationDemoTextBox.TabIndex = 4
        '
        'PracticeInputBox
        '
        Me.PracticeInputBox.BackColor = System.Drawing.Color.Black
        Me.PracticeInputBox.ForeColor = System.Drawing.Color.White
        Me.PracticeInputBox.Location = New System.Drawing.Point(6, 63)
        Me.PracticeInputBox.Multiline = True
        Me.PracticeInputBox.Name = "PracticeInputBox"
        Me.PracticeInputBox.Size = New System.Drawing.Size(679, 79)
        Me.PracticeInputBox.TabIndex = 6
        '
        'PracticeCheckButton
        '
        Me.PracticeCheckButton.Enabled = False
        Me.PracticeCheckButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PracticeCheckButton.ForeColor = System.Drawing.Color.Black
        Me.PracticeCheckButton.Location = New System.Drawing.Point(610, 229)
        Me.PracticeCheckButton.Name = "PracticeCheckButton"
        Me.PracticeCheckButton.Size = New System.Drawing.Size(75, 23)
        Me.PracticeCheckButton.TabIndex = 7
        Me.PracticeCheckButton.Text = "Check"
        Me.PracticeCheckButton.UseVisualStyleBackColor = True
        '
        'PracticeAnswerLabel
        '
        Me.PracticeAnswerLabel.AutoSize = True
        Me.PracticeAnswerLabel.Location = New System.Drawing.Point(3, 145)
        Me.PracticeAnswerLabel.Name = "PracticeAnswerLabel"
        Me.PracticeAnswerLabel.Size = New System.Drawing.Size(51, 13)
        Me.PracticeAnswerLabel.TabIndex = 8
        Me.PracticeAnswerLabel.Text = "Answer..."
        '
        'SelectTrainingView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(725, 333)
        Me.Controls.Add(Me.PracticeButton)
        Me.Controls.Add(Me.ImmitationButton)
        Me.Controls.Add(Me.DemoButton)
        Me.Controls.Add(Me.TrainingTabControl)
        Me.Controls.Add(Me.ExplanationButton)
        Me.Controls.Add(Me.SelectTrainingCancelButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SelectTrainingView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SelectTraining"
        Me.TopMost = True
        Me.TrainingTabControl.ResumeLayout(False)
        Me.SelectionTabPage.ResumeLayout(False)
        Me.SelectionTabPage.PerformLayout()
        Me.ExplanationTabPage.ResumeLayout(False)
        Me.ExplanationTabPage.PerformLayout()
        Me.DemonstrationTabPage.ResumeLayout(False)
        Me.DemonstrationTabPage.PerformLayout()
        Me.ImmitationTabPage.ResumeLayout(False)
        Me.ImmitationTabPage.PerformLayout()
        Me.PracticeTabPage.ResumeLayout(False)
        Me.PracticeTabPage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SelectTrainingCancelButton As System.Windows.Forms.Button
    Friend WithEvents ExplanationButton As System.Windows.Forms.Button
    Friend WithEvents SubjectListBox As System.Windows.Forms.ListBox
    Friend WithEvents CurriculumListBox As System.Windows.Forms.ListBox
    Friend WithEvents KeyStageListBox As System.Windows.Forms.ListBox
    Friend WithEvents SelectSubjectLabel As System.Windows.Forms.Label
    Friend WithEvents SelectCurriculumLabel As System.Windows.Forms.Label
    Friend WithEvents SelectKeyStageLabel As System.Windows.Forms.Label
    Friend WithEvents ExplanationListBox As System.Windows.Forms.ListBox
    Friend WithEvents SelectExplanationLabel As System.Windows.Forms.Label
    Friend WithEvents TrainingTabControl As System.Windows.Forms.TabControl
    Friend WithEvents SelectionTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ExplanationTabPage As System.Windows.Forms.TabPage
    Friend WithEvents DemonstrationTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ImmitationTabPage As System.Windows.Forms.TabPage
    Friend WithEvents PracticeTabPage As System.Windows.Forms.TabPage
    Friend WithEvents DemoButton As System.Windows.Forms.Button
    Friend WithEvents ImmitationButton As System.Windows.Forms.Button
    Friend WithEvents PracticeButton As System.Windows.Forms.Button
    Friend WithEvents ExplanationTrainingTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ExplanationTitleLabel As System.Windows.Forms.Label
    Friend WithEvents ExplanationLabel As System.Windows.Forms.Label
    Friend WithEvents DemoDetailLabel As System.Windows.Forms.Label
    Friend WithEvents DemoStepDetailsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DemoAmountSteps As System.Windows.Forms.Label
    Friend WithEvents DemoStepsLabel As System.Windows.Forms.Label
    Friend WithEvents DemoNextButton As System.Windows.Forms.Button
    Friend WithEvents DemoPreviousButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TrainingImmitationGuideLabel As System.Windows.Forms.Label
    Friend WithEvents ImmitationDetailsGroupBoxLabel As System.Windows.Forms.Label
    Friend WithEvents ImmitationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ImmitationCheckButton As System.Windows.Forms.Button
    Friend WithEvents ImmitationDemoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DemoDetailGroupBoxLabel As System.Windows.Forms.Label
    Friend WithEvents PracticeQuestionLabel As System.Windows.Forms.Label
    Friend WithEvents PracticeTitleLabel As System.Windows.Forms.Label
    Friend WithEvents PracticeCheckButton As System.Windows.Forms.Button
    Friend WithEvents PracticeInputBox As System.Windows.Forms.TextBox
    Friend WithEvents PracticeAnswerLabel As System.Windows.Forms.Label
End Class
