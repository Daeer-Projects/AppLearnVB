<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Revision
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
        Me.RadioButtonA = New System.Windows.Forms.RadioButton()
        Me.RadioButtonB = New System.Windows.Forms.RadioButton()
        Me.RadioButtonC = New System.Windows.Forms.RadioButton()
        Me.RadioButtonD = New System.Windows.Forms.RadioButton()
        Me.QuestionLabel = New System.Windows.Forms.Label()
        Me.RevisionTabControl = New System.Windows.Forms.TabControl()
        Me.SubjectSelectionPage = New System.Windows.Forms.TabPage()
        Me.AmountOfQuestionsDetailLabel = New System.Windows.Forms.Label()
        Me.QuestionsInDbLabel = New System.Windows.Forms.Label()
        Me.AmountOfQuestionsBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.KeyStageList = New System.Windows.Forms.ListBox()
        Me.KeyStageSelection = New System.Windows.Forms.Label()
        Me.CurriculumList = New System.Windows.Forms.ListBox()
        Me.SubjectList = New System.Windows.Forms.ListBox()
        Me.CurriculumSelectLabel = New System.Windows.Forms.Label()
        Me.SubjectSelectLabel = New System.Windows.Forms.Label()
        Me.QuestionTabPage = New System.Windows.Forms.TabPage()
        Me.NextButton = New System.Windows.Forms.Button()
        Me.PreviousButton = New System.Windows.Forms.Button()
        Me.ResultsTabPage = New System.Windows.Forms.TabPage()
        Me.ActualPercentLabel = New System.Windows.Forms.Label()
        Me.PercentLabel = New System.Windows.Forms.Label()
        Me.ActualWrongAnswersLabel = New System.Windows.Forms.Label()
        Me.WrongAnswersLabel = New System.Windows.Forms.Label()
        Me.ActualCorrectAnswersLabel = New System.Windows.Forms.Label()
        Me.CorrectAnswersLabel = New System.Windows.Forms.Label()
        Me.ActualTotalQuestions = New System.Windows.Forms.Label()
        Me.QuestionsLabel = New System.Windows.Forms.Label()
        Me.ActualUserNameLabel = New System.Windows.Forms.Label()
        Me.UserLabel = New System.Windows.Forms.Label()
        Me.RevisionCancelButton = New System.Windows.Forms.Button()
        Me.RevisionTabControl.SuspendLayout()
        Me.SubjectSelectionPage.SuspendLayout()
        Me.QuestionTabPage.SuspendLayout()
        Me.ResultsTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'RadioButtonA
        '
        Me.RadioButtonA.AutoSize = True
        Me.RadioButtonA.ForeColor = System.Drawing.Color.White
        Me.RadioButtonA.Location = New System.Drawing.Point(68, 47)
        Me.RadioButtonA.Name = "RadioButtonA"
        Me.RadioButtonA.Size = New System.Drawing.Size(91, 17)
        Me.RadioButtonA.TabIndex = 0
        Me.RadioButtonA.TabStop = True
        Me.RadioButtonA.Text = "RadioButtonA"
        Me.RadioButtonA.UseVisualStyleBackColor = True
        '
        'RadioButtonB
        '
        Me.RadioButtonB.AutoSize = True
        Me.RadioButtonB.ForeColor = System.Drawing.Color.White
        Me.RadioButtonB.Location = New System.Drawing.Point(68, 96)
        Me.RadioButtonB.Name = "RadioButtonB"
        Me.RadioButtonB.Size = New System.Drawing.Size(91, 17)
        Me.RadioButtonB.TabIndex = 1
        Me.RadioButtonB.TabStop = True
        Me.RadioButtonB.Text = "RadioButtonB"
        Me.RadioButtonB.UseVisualStyleBackColor = True
        '
        'RadioButtonC
        '
        Me.RadioButtonC.AutoSize = True
        Me.RadioButtonC.ForeColor = System.Drawing.Color.White
        Me.RadioButtonC.Location = New System.Drawing.Point(69, 142)
        Me.RadioButtonC.Name = "RadioButtonC"
        Me.RadioButtonC.Size = New System.Drawing.Size(91, 17)
        Me.RadioButtonC.TabIndex = 2
        Me.RadioButtonC.TabStop = True
        Me.RadioButtonC.Text = "RadioButtonC"
        Me.RadioButtonC.UseVisualStyleBackColor = True
        '
        'RadioButtonD
        '
        Me.RadioButtonD.AutoSize = True
        Me.RadioButtonD.ForeColor = System.Drawing.Color.White
        Me.RadioButtonD.Location = New System.Drawing.Point(68, 182)
        Me.RadioButtonD.Name = "RadioButtonD"
        Me.RadioButtonD.Size = New System.Drawing.Size(92, 17)
        Me.RadioButtonD.TabIndex = 3
        Me.RadioButtonD.TabStop = True
        Me.RadioButtonD.Text = "RadioButtonD"
        Me.RadioButtonD.UseVisualStyleBackColor = True
        '
        'QuestionLabel
        '
        Me.QuestionLabel.AutoSize = True
        Me.QuestionLabel.ForeColor = System.Drawing.Color.White
        Me.QuestionLabel.Location = New System.Drawing.Point(6, 3)
        Me.QuestionLabel.Name = "QuestionLabel"
        Me.QuestionLabel.Size = New System.Drawing.Size(99, 13)
        Me.QuestionLabel.TabIndex = 4
        Me.QuestionLabel.Text = "Question goes here"
        '
        'RevisionTabControl
        '
        Me.RevisionTabControl.Controls.Add(Me.SubjectSelectionPage)
        Me.RevisionTabControl.Controls.Add(Me.QuestionTabPage)
        Me.RevisionTabControl.Controls.Add(Me.ResultsTabPage)
        Me.RevisionTabControl.Location = New System.Drawing.Point(13, 13)
        Me.RevisionTabControl.Name = "RevisionTabControl"
        Me.RevisionTabControl.SelectedIndex = 0
        Me.RevisionTabControl.Size = New System.Drawing.Size(700, 280)
        Me.RevisionTabControl.TabIndex = 5
        '
        'SubjectSelectionPage
        '
        Me.SubjectSelectionPage.BackColor = System.Drawing.Color.Black
        Me.SubjectSelectionPage.Controls.Add(Me.AmountOfQuestionsDetailLabel)
        Me.SubjectSelectionPage.Controls.Add(Me.QuestionsInDbLabel)
        Me.SubjectSelectionPage.Controls.Add(Me.AmountOfQuestionsBox)
        Me.SubjectSelectionPage.Controls.Add(Me.Label1)
        Me.SubjectSelectionPage.Controls.Add(Me.KeyStageList)
        Me.SubjectSelectionPage.Controls.Add(Me.KeyStageSelection)
        Me.SubjectSelectionPage.Controls.Add(Me.CurriculumList)
        Me.SubjectSelectionPage.Controls.Add(Me.SubjectList)
        Me.SubjectSelectionPage.Controls.Add(Me.CurriculumSelectLabel)
        Me.SubjectSelectionPage.Controls.Add(Me.SubjectSelectLabel)
        Me.SubjectSelectionPage.ForeColor = System.Drawing.Color.White
        Me.SubjectSelectionPage.Location = New System.Drawing.Point(4, 22)
        Me.SubjectSelectionPage.Name = "SubjectSelectionPage"
        Me.SubjectSelectionPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SubjectSelectionPage.Size = New System.Drawing.Size(692, 254)
        Me.SubjectSelectionPage.TabIndex = 0
        Me.SubjectSelectionPage.Text = "Subject Selection"
        '
        'AmountOfQuestionsDetailLabel
        '
        Me.AmountOfQuestionsDetailLabel.AutoSize = True
        Me.AmountOfQuestionsDetailLabel.ForeColor = System.Drawing.Color.Gray
        Me.AmountOfQuestionsDetailLabel.Location = New System.Drawing.Point(429, 148)
        Me.AmountOfQuestionsDetailLabel.Name = "AmountOfQuestionsDetailLabel"
        Me.AmountOfQuestionsDetailLabel.Size = New System.Drawing.Size(13, 13)
        Me.AmountOfQuestionsDetailLabel.TabIndex = 10
        Me.AmountOfQuestionsDetailLabel.Text = "0"
        '
        'QuestionsInDbLabel
        '
        Me.QuestionsInDbLabel.AutoSize = True
        Me.QuestionsInDbLabel.Location = New System.Drawing.Point(281, 148)
        Me.QuestionsInDbLabel.Name = "QuestionsInDbLabel"
        Me.QuestionsInDbLabel.Size = New System.Drawing.Size(115, 13)
        Me.QuestionsInDbLabel.TabIndex = 9
        Me.QuestionsInDbLabel.Text = "Questions in database:"
        '
        'AmountOfQuestionsBox
        '
        Me.AmountOfQuestionsBox.BackColor = System.Drawing.Color.Black
        Me.AmountOfQuestionsBox.ForeColor = System.Drawing.Color.White
        Me.AmountOfQuestionsBox.Location = New System.Drawing.Point(114, 141)
        Me.AmountOfQuestionsBox.Name = "AmountOfQuestionsBox"
        Me.AmountOfQuestionsBox.Size = New System.Drawing.Size(119, 20)
        Me.AmountOfQuestionsBox.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Select Key Stage:"
        '
        'KeyStageList
        '
        Me.KeyStageList.BackColor = System.Drawing.Color.Black
        Me.KeyStageList.ForeColor = System.Drawing.Color.White
        Me.KeyStageList.FormattingEnabled = True
        Me.KeyStageList.Location = New System.Drawing.Point(114, 93)
        Me.KeyStageList.Name = "KeyStageList"
        Me.KeyStageList.Size = New System.Drawing.Size(572, 17)
        Me.KeyStageList.TabIndex = 6
        '
        'KeyStageSelection
        '
        Me.KeyStageSelection.AutoSize = True
        Me.KeyStageSelection.Location = New System.Drawing.Point(8, 97)
        Me.KeyStageSelection.Name = "KeyStageSelection"
        Me.KeyStageSelection.Size = New System.Drawing.Size(92, 13)
        Me.KeyStageSelection.TabIndex = 5
        Me.KeyStageSelection.Text = "Select Key Stage:"
        '
        'CurriculumList
        '
        Me.CurriculumList.BackColor = System.Drawing.Color.Black
        Me.CurriculumList.ForeColor = System.Drawing.Color.White
        Me.CurriculumList.FormattingEnabled = True
        Me.CurriculumList.Location = New System.Drawing.Point(114, 47)
        Me.CurriculumList.Name = "CurriculumList"
        Me.CurriculumList.Size = New System.Drawing.Size(572, 17)
        Me.CurriculumList.TabIndex = 4
        '
        'SubjectList
        '
        Me.SubjectList.BackColor = System.Drawing.Color.Black
        Me.SubjectList.ForeColor = System.Drawing.Color.White
        Me.SubjectList.FormattingEnabled = True
        Me.SubjectList.Location = New System.Drawing.Point(114, 6)
        Me.SubjectList.Name = "SubjectList"
        Me.SubjectList.Size = New System.Drawing.Size(572, 17)
        Me.SubjectList.TabIndex = 3
        '
        'CurriculumSelectLabel
        '
        Me.CurriculumSelectLabel.AutoSize = True
        Me.CurriculumSelectLabel.Location = New System.Drawing.Point(8, 51)
        Me.CurriculumSelectLabel.Name = "CurriculumSelectLabel"
        Me.CurriculumSelectLabel.Size = New System.Drawing.Size(92, 13)
        Me.CurriculumSelectLabel.TabIndex = 2
        Me.CurriculumSelectLabel.Text = "Select Curriculum:"
        '
        'SubjectSelectLabel
        '
        Me.SubjectSelectLabel.AutoSize = True
        Me.SubjectSelectLabel.Location = New System.Drawing.Point(8, 10)
        Me.SubjectSelectLabel.Name = "SubjectSelectLabel"
        Me.SubjectSelectLabel.Size = New System.Drawing.Size(79, 13)
        Me.SubjectSelectLabel.TabIndex = 0
        Me.SubjectSelectLabel.Text = "Select Subject:"
        '
        'QuestionTabPage
        '
        Me.QuestionTabPage.BackColor = System.Drawing.Color.Black
        Me.QuestionTabPage.Controls.Add(Me.NextButton)
        Me.QuestionTabPage.Controls.Add(Me.PreviousButton)
        Me.QuestionTabPage.Controls.Add(Me.QuestionLabel)
        Me.QuestionTabPage.Controls.Add(Me.RadioButtonD)
        Me.QuestionTabPage.Controls.Add(Me.RadioButtonA)
        Me.QuestionTabPage.Controls.Add(Me.RadioButtonC)
        Me.QuestionTabPage.Controls.Add(Me.RadioButtonB)
        Me.QuestionTabPage.ForeColor = System.Drawing.Color.White
        Me.QuestionTabPage.Location = New System.Drawing.Point(4, 22)
        Me.QuestionTabPage.Name = "QuestionTabPage"
        Me.QuestionTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.QuestionTabPage.Size = New System.Drawing.Size(692, 254)
        Me.QuestionTabPage.TabIndex = 1
        Me.QuestionTabPage.Text = "Questions"
        '
        'NextButton
        '
        Me.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NextButton.Location = New System.Drawing.Point(611, 225)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(75, 23)
        Me.NextButton.TabIndex = 6
        Me.NextButton.Text = "Next"
        Me.NextButton.UseVisualStyleBackColor = True
        '
        'PreviousButton
        '
        Me.PreviousButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.PreviousButton.Location = New System.Drawing.Point(530, 225)
        Me.PreviousButton.Name = "PreviousButton"
        Me.PreviousButton.Size = New System.Drawing.Size(75, 23)
        Me.PreviousButton.TabIndex = 5
        Me.PreviousButton.Text = "Previous"
        Me.PreviousButton.UseVisualStyleBackColor = True
        '
        'ResultsTabPage
        '
        Me.ResultsTabPage.BackColor = System.Drawing.Color.Black
        Me.ResultsTabPage.Controls.Add(Me.ActualPercentLabel)
        Me.ResultsTabPage.Controls.Add(Me.PercentLabel)
        Me.ResultsTabPage.Controls.Add(Me.ActualWrongAnswersLabel)
        Me.ResultsTabPage.Controls.Add(Me.WrongAnswersLabel)
        Me.ResultsTabPage.Controls.Add(Me.ActualCorrectAnswersLabel)
        Me.ResultsTabPage.Controls.Add(Me.CorrectAnswersLabel)
        Me.ResultsTabPage.Controls.Add(Me.ActualTotalQuestions)
        Me.ResultsTabPage.Controls.Add(Me.QuestionsLabel)
        Me.ResultsTabPage.Controls.Add(Me.ActualUserNameLabel)
        Me.ResultsTabPage.Controls.Add(Me.UserLabel)
        Me.ResultsTabPage.ForeColor = System.Drawing.Color.White
        Me.ResultsTabPage.Location = New System.Drawing.Point(4, 22)
        Me.ResultsTabPage.Name = "ResultsTabPage"
        Me.ResultsTabPage.Size = New System.Drawing.Size(692, 254)
        Me.ResultsTabPage.TabIndex = 2
        Me.ResultsTabPage.Text = "Results"
        '
        'ActualPercentLabel
        '
        Me.ActualPercentLabel.AutoSize = True
        Me.ActualPercentLabel.ForeColor = System.Drawing.Color.Gray
        Me.ActualPercentLabel.Location = New System.Drawing.Point(138, 173)
        Me.ActualPercentLabel.Name = "ActualPercentLabel"
        Me.ActualPercentLabel.Size = New System.Drawing.Size(21, 13)
        Me.ActualPercentLabel.TabIndex = 9
        Me.ActualPercentLabel.Text = "0%"
        '
        'PercentLabel
        '
        Me.PercentLabel.AutoSize = True
        Me.PercentLabel.Location = New System.Drawing.Point(8, 173)
        Me.PercentLabel.Name = "PercentLabel"
        Me.PercentLabel.Size = New System.Drawing.Size(102, 13)
        Me.PercentLabel.TabIndex = 8
        Me.PercentLabel.Text = "Percentage Correct:"
        '
        'ActualWrongAnswersLabel
        '
        Me.ActualWrongAnswersLabel.AutoSize = True
        Me.ActualWrongAnswersLabel.ForeColor = System.Drawing.Color.Gray
        Me.ActualWrongAnswersLabel.Location = New System.Drawing.Point(138, 113)
        Me.ActualWrongAnswersLabel.Name = "ActualWrongAnswersLabel"
        Me.ActualWrongAnswersLabel.Size = New System.Drawing.Size(13, 13)
        Me.ActualWrongAnswersLabel.TabIndex = 7
        Me.ActualWrongAnswersLabel.Text = "0"
        '
        'WrongAnswersLabel
        '
        Me.WrongAnswersLabel.AutoSize = True
        Me.WrongAnswersLabel.Location = New System.Drawing.Point(6, 113)
        Me.WrongAnswersLabel.Name = "WrongAnswersLabel"
        Me.WrongAnswersLabel.Size = New System.Drawing.Size(85, 13)
        Me.WrongAnswersLabel.TabIndex = 6
        Me.WrongAnswersLabel.Text = "Wrong Answers:"
        '
        'ActualCorrectAnswersLabel
        '
        Me.ActualCorrectAnswersLabel.AutoSize = True
        Me.ActualCorrectAnswersLabel.ForeColor = System.Drawing.Color.Gray
        Me.ActualCorrectAnswersLabel.Location = New System.Drawing.Point(138, 75)
        Me.ActualCorrectAnswersLabel.Name = "ActualCorrectAnswersLabel"
        Me.ActualCorrectAnswersLabel.Size = New System.Drawing.Size(13, 13)
        Me.ActualCorrectAnswersLabel.TabIndex = 5
        Me.ActualCorrectAnswersLabel.Text = "0"
        '
        'CorrectAnswersLabel
        '
        Me.CorrectAnswersLabel.AutoSize = True
        Me.CorrectAnswersLabel.Location = New System.Drawing.Point(6, 75)
        Me.CorrectAnswersLabel.Name = "CorrectAnswersLabel"
        Me.CorrectAnswersLabel.Size = New System.Drawing.Size(87, 13)
        Me.CorrectAnswersLabel.TabIndex = 4
        Me.CorrectAnswersLabel.Text = "Correct Answers:"
        '
        'ActualTotalQuestions
        '
        Me.ActualTotalQuestions.AutoSize = True
        Me.ActualTotalQuestions.ForeColor = System.Drawing.Color.Gray
        Me.ActualTotalQuestions.Location = New System.Drawing.Point(138, 41)
        Me.ActualTotalQuestions.Name = "ActualTotalQuestions"
        Me.ActualTotalQuestions.Size = New System.Drawing.Size(13, 13)
        Me.ActualTotalQuestions.TabIndex = 3
        Me.ActualTotalQuestions.Text = "0"
        '
        'QuestionsLabel
        '
        Me.QuestionsLabel.AutoSize = True
        Me.QuestionsLabel.Location = New System.Drawing.Point(6, 41)
        Me.QuestionsLabel.Name = "QuestionsLabel"
        Me.QuestionsLabel.Size = New System.Drawing.Size(84, 13)
        Me.QuestionsLabel.TabIndex = 2
        Me.QuestionsLabel.Text = "Total Questions:"
        '
        'ActualUserNameLabel
        '
        Me.ActualUserNameLabel.AutoSize = True
        Me.ActualUserNameLabel.ForeColor = System.Drawing.Color.Gray
        Me.ActualUserNameLabel.Location = New System.Drawing.Point(138, 10)
        Me.ActualUserNameLabel.Name = "ActualUserNameLabel"
        Me.ActualUserNameLabel.Size = New System.Drawing.Size(53, 13)
        Me.ActualUserNameLabel.TabIndex = 1
        Me.ActualUserNameLabel.Text = "username"
        '
        'UserLabel
        '
        Me.UserLabel.AutoSize = True
        Me.UserLabel.Location = New System.Drawing.Point(3, 10)
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(60, 13)
        Me.UserLabel.TabIndex = 0
        Me.UserLabel.Text = "UserName:"
        '
        'RevisionCancelButton
        '
        Me.RevisionCancelButton.Location = New System.Drawing.Point(17, 299)
        Me.RevisionCancelButton.Name = "RevisionCancelButton"
        Me.RevisionCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.RevisionCancelButton.TabIndex = 6
        Me.RevisionCancelButton.Text = "Cancel"
        Me.RevisionCancelButton.UseVisualStyleBackColor = True
        '
        'Revision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(725, 332)
        Me.Controls.Add(Me.RevisionCancelButton)
        Me.Controls.Add(Me.RevisionTabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Revision"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Revision"
        Me.TopMost = True
        Me.RevisionTabControl.ResumeLayout(False)
        Me.SubjectSelectionPage.ResumeLayout(False)
        Me.SubjectSelectionPage.PerformLayout()
        Me.QuestionTabPage.ResumeLayout(False)
        Me.QuestionTabPage.PerformLayout()
        Me.ResultsTabPage.ResumeLayout(False)
        Me.ResultsTabPage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RadioButtonA As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonB As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonC As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonD As System.Windows.Forms.RadioButton
    Friend WithEvents QuestionLabel As System.Windows.Forms.Label
    Friend WithEvents RevisionTabControl As System.Windows.Forms.TabControl
    Friend WithEvents SubjectSelectionPage As System.Windows.Forms.TabPage
    Friend WithEvents QuestionTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ResultsTabPage As System.Windows.Forms.TabPage
    Friend WithEvents CurriculumList As System.Windows.Forms.ListBox
    Friend WithEvents SubjectList As System.Windows.Forms.ListBox
    Friend WithEvents CurriculumSelectLabel As System.Windows.Forms.Label
    Friend WithEvents SubjectSelectLabel As System.Windows.Forms.Label
    Friend WithEvents AmountOfQuestionsDetailLabel As System.Windows.Forms.Label
    Friend WithEvents QuestionsInDbLabel As System.Windows.Forms.Label
    Friend WithEvents AmountOfQuestionsBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents KeyStageList As System.Windows.Forms.ListBox
    Friend WithEvents KeyStageSelection As System.Windows.Forms.Label
    Friend WithEvents ActualPercentLabel As System.Windows.Forms.Label
    Friend WithEvents PercentLabel As System.Windows.Forms.Label
    Friend WithEvents ActualWrongAnswersLabel As System.Windows.Forms.Label
    Friend WithEvents WrongAnswersLabel As System.Windows.Forms.Label
    Friend WithEvents ActualCorrectAnswersLabel As System.Windows.Forms.Label
    Friend WithEvents CorrectAnswersLabel As System.Windows.Forms.Label
    Friend WithEvents ActualTotalQuestions As System.Windows.Forms.Label
    Friend WithEvents QuestionsLabel As System.Windows.Forms.Label
    Friend WithEvents ActualUserNameLabel As System.Windows.Forms.Label
    Friend WithEvents UserLabel As System.Windows.Forms.Label
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents PreviousButton As System.Windows.Forms.Button
    Friend WithEvents RevisionCancelButton As System.Windows.Forms.Button
End Class
