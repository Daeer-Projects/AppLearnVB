<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class App4Learn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(App4Learn))
        Me.LoginButton = New System.Windows.Forms.Button()
        Me.UserNameLabel = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UserNameBox = New System.Windows.Forms.TextBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.FirstNameLabel = New System.Windows.Forms.Label()
        Me.MiddleNameLabel = New System.Windows.Forms.Label()
        Me.LastNameLabel = New System.Windows.Forms.Label()
        Me.FirstNameBox = New System.Windows.Forms.TextBox()
        Me.MiddleNameBox = New System.Windows.Forms.TextBox()
        Me.LastNameBox = New System.Windows.Forms.TextBox()
        Me.NewUserButton = New System.Windows.Forms.Button()
        Me.UserNameErrorLabel = New System.Windows.Forms.Label()
        Me.PasswordErrorLabel = New System.Windows.Forms.Label()
        Me.UserErrorLabel = New System.Windows.Forms.Label()
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.LogInPage = New System.Windows.Forms.TabPage()
        Me.InvalidLogOnLabel = New System.Windows.Forms.Label()
        Me.LogOutButton = New System.Windows.Forms.Button()
        Me.NewUserPage = New System.Windows.Forms.TabPage()
        Me.NewUserLastValidation = New System.Windows.Forms.Label()
        Me.NewUserFirstValidation = New System.Windows.Forms.Label()
        Me.NewUserNameBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NewUserPasswordValidation = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NewUserNameValidation = New System.Windows.Forms.Label()
        Me.NewUserPasswordBox = New System.Windows.Forms.TextBox()
        Me.SelectTrainingPage = New System.Windows.Forms.TabPage()
        Me.InsertNewQuestion = New System.Windows.Forms.TabPage()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.RevisionPage = New System.Windows.Forms.TabPage()
        Me.RevisionStartButton = New System.Windows.Forms.Button()
        Me.RevisionDescriptionBox = New System.Windows.Forms.TextBox()
        Me.LoggedInUser = New System.Windows.Forms.Label()
        Me.UserNameOfCurrentUser = New System.Windows.Forms.Label()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.DBConnLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DBStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StartTrainingBox = New System.Windows.Forms.TextBox()
        Me.StartTrainingButton = New System.Windows.Forms.Button()
        Me.MainTabControl.SuspendLayout()
        Me.LogInPage.SuspendLayout()
        Me.NewUserPage.SuspendLayout()
        Me.SelectTrainingPage.SuspendLayout()
        Me.InsertNewQuestion.SuspendLayout()
        Me.RevisionPage.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'LoginButton
        '
        Me.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LoginButton.ForeColor = System.Drawing.Color.Black
        Me.LoginButton.Location = New System.Drawing.Point(115, 179)
        Me.LoginButton.Name = "LoginButton"
        Me.LoginButton.Size = New System.Drawing.Size(88, 29)
        Me.LoginButton.TabIndex = 6
        Me.LoginButton.Text = "Login"
        Me.LoginButton.UseVisualStyleBackColor = True
        '
        'UserNameLabel
        '
        Me.UserNameLabel.AutoSize = True
        Me.UserNameLabel.Location = New System.Drawing.Point(13, 21)
        Me.UserNameLabel.Name = "UserNameLabel"
        Me.UserNameLabel.Size = New System.Drawing.Size(63, 13)
        Me.UserNameLabel.TabIndex = 0
        Me.UserNameLabel.Text = "User Name:"
        '
        'PasswordLabel
        '
        Me.PasswordLabel.AutoSize = True
        Me.PasswordLabel.Location = New System.Drawing.Point(13, 39)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(56, 13)
        Me.PasswordLabel.TabIndex = 0
        Me.PasswordLabel.Text = "Password:"
        '
        'UserNameBox
        '
        Me.UserNameBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.UserNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UserNameBox.ForeColor = System.Drawing.Color.White
        Me.UserNameBox.Location = New System.Drawing.Point(92, 19)
        Me.UserNameBox.Name = "UserNameBox"
        Me.UserNameBox.Size = New System.Drawing.Size(134, 20)
        Me.UserNameBox.TabIndex = 1
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PasswordTextBox.ForeColor = System.Drawing.Color.White
        Me.PasswordTextBox.Location = New System.Drawing.Point(92, 39)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(134, 20)
        Me.PasswordTextBox.TabIndex = 2
        '
        'FirstNameLabel
        '
        Me.FirstNameLabel.AutoSize = True
        Me.FirstNameLabel.Location = New System.Drawing.Point(13, 86)
        Me.FirstNameLabel.Name = "FirstNameLabel"
        Me.FirstNameLabel.Size = New System.Drawing.Size(60, 13)
        Me.FirstNameLabel.TabIndex = 0
        Me.FirstNameLabel.Text = "First Name:"
        '
        'MiddleNameLabel
        '
        Me.MiddleNameLabel.AutoSize = True
        Me.MiddleNameLabel.Location = New System.Drawing.Point(13, 108)
        Me.MiddleNameLabel.Name = "MiddleNameLabel"
        Me.MiddleNameLabel.Size = New System.Drawing.Size(72, 13)
        Me.MiddleNameLabel.TabIndex = 0
        Me.MiddleNameLabel.Text = "Middle Name:"
        '
        'LastNameLabel
        '
        Me.LastNameLabel.AutoSize = True
        Me.LastNameLabel.Location = New System.Drawing.Point(13, 130)
        Me.LastNameLabel.Name = "LastNameLabel"
        Me.LastNameLabel.Size = New System.Drawing.Size(61, 13)
        Me.LastNameLabel.TabIndex = 0
        Me.LastNameLabel.Text = "Last Name:"
        '
        'FirstNameBox
        '
        Me.FirstNameBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FirstNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FirstNameBox.ForeColor = System.Drawing.Color.White
        Me.FirstNameBox.Location = New System.Drawing.Point(92, 86)
        Me.FirstNameBox.Name = "FirstNameBox"
        Me.FirstNameBox.Size = New System.Drawing.Size(134, 20)
        Me.FirstNameBox.TabIndex = 3
        '
        'MiddleNameBox
        '
        Me.MiddleNameBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MiddleNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MiddleNameBox.ForeColor = System.Drawing.Color.White
        Me.MiddleNameBox.Location = New System.Drawing.Point(92, 106)
        Me.MiddleNameBox.Name = "MiddleNameBox"
        Me.MiddleNameBox.Size = New System.Drawing.Size(134, 20)
        Me.MiddleNameBox.TabIndex = 4
        '
        'LastNameBox
        '
        Me.LastNameBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LastNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LastNameBox.ForeColor = System.Drawing.Color.White
        Me.LastNameBox.Location = New System.Drawing.Point(92, 123)
        Me.LastNameBox.Name = "LastNameBox"
        Me.LastNameBox.Size = New System.Drawing.Size(134, 20)
        Me.LastNameBox.TabIndex = 5
        '
        'NewUserButton
        '
        Me.NewUserButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.NewUserButton.ForeColor = System.Drawing.Color.Black
        Me.NewUserButton.Location = New System.Drawing.Point(115, 179)
        Me.NewUserButton.Name = "NewUserButton"
        Me.NewUserButton.Size = New System.Drawing.Size(88, 29)
        Me.NewUserButton.TabIndex = 7
        Me.NewUserButton.Text = "Create New User"
        Me.NewUserButton.UseVisualStyleBackColor = True
        '
        'UserNameErrorLabel
        '
        Me.UserNameErrorLabel.AutoSize = True
        Me.UserNameErrorLabel.ForeColor = System.Drawing.Color.Red
        Me.UserNameErrorLabel.Location = New System.Drawing.Point(234, 20)
        Me.UserNameErrorLabel.Name = "UserNameErrorLabel"
        Me.UserNameErrorLabel.Size = New System.Drawing.Size(0, 13)
        Me.UserNameErrorLabel.TabIndex = 8
        '
        'PasswordErrorLabel
        '
        Me.PasswordErrorLabel.AutoSize = True
        Me.PasswordErrorLabel.ForeColor = System.Drawing.Color.Red
        Me.PasswordErrorLabel.Location = New System.Drawing.Point(234, 46)
        Me.PasswordErrorLabel.Name = "PasswordErrorLabel"
        Me.PasswordErrorLabel.Size = New System.Drawing.Size(0, 13)
        Me.PasswordErrorLabel.TabIndex = 9
        '
        'UserErrorLabel
        '
        Me.UserErrorLabel.AutoSize = True
        Me.UserErrorLabel.Location = New System.Drawing.Point(234, 108)
        Me.UserErrorLabel.Name = "UserErrorLabel"
        Me.UserErrorLabel.Size = New System.Drawing.Size(0, 13)
        Me.UserErrorLabel.TabIndex = 10
        '
        'MainTabControl
        '
        Me.MainTabControl.Controls.Add(Me.LogInPage)
        Me.MainTabControl.Controls.Add(Me.NewUserPage)
        Me.MainTabControl.Controls.Add(Me.SelectTrainingPage)
        Me.MainTabControl.Controls.Add(Me.InsertNewQuestion)
        Me.MainTabControl.Controls.Add(Me.RevisionPage)
        Me.MainTabControl.Location = New System.Drawing.Point(24, 34)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(802, 349)
        Me.MainTabControl.TabIndex = 11
        Me.MainTabControl.TabStop = False
        '
        'LogInPage
        '
        Me.LogInPage.BackColor = System.Drawing.Color.Black
        Me.LogInPage.Controls.Add(Me.InvalidLogOnLabel)
        Me.LogInPage.Controls.Add(Me.UserNameBox)
        Me.LogInPage.Controls.Add(Me.UserNameLabel)
        Me.LogInPage.Controls.Add(Me.PasswordErrorLabel)
        Me.LogInPage.Controls.Add(Me.PasswordLabel)
        Me.LogInPage.Controls.Add(Me.UserNameErrorLabel)
        Me.LogInPage.Controls.Add(Me.PasswordTextBox)
        Me.LogInPage.Controls.Add(Me.LoginButton)
        Me.LogInPage.Controls.Add(Me.LogOutButton)
        Me.LogInPage.ForeColor = System.Drawing.Color.Transparent
        Me.LogInPage.Location = New System.Drawing.Point(4, 22)
        Me.LogInPage.Name = "LogInPage"
        Me.LogInPage.Padding = New System.Windows.Forms.Padding(3)
        Me.LogInPage.Size = New System.Drawing.Size(794, 323)
        Me.LogInPage.TabIndex = 0
        Me.LogInPage.Text = "Log In"
        '
        'InvalidLogOnLabel
        '
        Me.InvalidLogOnLabel.AutoSize = True
        Me.InvalidLogOnLabel.ForeColor = System.Drawing.Color.Red
        Me.InvalidLogOnLabel.Location = New System.Drawing.Point(89, 62)
        Me.InvalidLogOnLabel.Name = "InvalidLogOnLabel"
        Me.InvalidLogOnLabel.Size = New System.Drawing.Size(0, 13)
        Me.InvalidLogOnLabel.TabIndex = 11
        '
        'LogOutButton
        '
        Me.LogOutButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LogOutButton.ForeColor = System.Drawing.Color.Black
        Me.LogOutButton.Location = New System.Drawing.Point(115, 179)
        Me.LogOutButton.Name = "LogOutButton"
        Me.LogOutButton.Size = New System.Drawing.Size(88, 29)
        Me.LogOutButton.TabIndex = 10
        Me.LogOutButton.Text = "Logout"
        Me.LogOutButton.UseVisualStyleBackColor = True
        Me.LogOutButton.Visible = False
        '
        'NewUserPage
        '
        Me.NewUserPage.BackColor = System.Drawing.Color.Black
        Me.NewUserPage.Controls.Add(Me.NewUserLastValidation)
        Me.NewUserPage.Controls.Add(Me.NewUserFirstValidation)
        Me.NewUserPage.Controls.Add(Me.NewUserNameBox)
        Me.NewUserPage.Controls.Add(Me.Label1)
        Me.NewUserPage.Controls.Add(Me.NewUserPasswordValidation)
        Me.NewUserPage.Controls.Add(Me.Label3)
        Me.NewUserPage.Controls.Add(Me.NewUserNameValidation)
        Me.NewUserPage.Controls.Add(Me.NewUserPasswordBox)
        Me.NewUserPage.Controls.Add(Me.MiddleNameBox)
        Me.NewUserPage.Controls.Add(Me.NewUserButton)
        Me.NewUserPage.Controls.Add(Me.UserErrorLabel)
        Me.NewUserPage.Controls.Add(Me.FirstNameLabel)
        Me.NewUserPage.Controls.Add(Me.MiddleNameLabel)
        Me.NewUserPage.Controls.Add(Me.LastNameBox)
        Me.NewUserPage.Controls.Add(Me.LastNameLabel)
        Me.NewUserPage.Controls.Add(Me.FirstNameBox)
        Me.NewUserPage.Location = New System.Drawing.Point(4, 22)
        Me.NewUserPage.Name = "NewUserPage"
        Me.NewUserPage.Padding = New System.Windows.Forms.Padding(3)
        Me.NewUserPage.Size = New System.Drawing.Size(794, 323)
        Me.NewUserPage.TabIndex = 1
        Me.NewUserPage.Text = "Create New User"
        '
        'NewUserLastValidation
        '
        Me.NewUserLastValidation.AutoSize = True
        Me.NewUserLastValidation.ForeColor = System.Drawing.Color.Red
        Me.NewUserLastValidation.Location = New System.Drawing.Point(234, 129)
        Me.NewUserLastValidation.Name = "NewUserLastValidation"
        Me.NewUserLastValidation.Size = New System.Drawing.Size(0, 13)
        Me.NewUserLastValidation.TabIndex = 18
        '
        'NewUserFirstValidation
        '
        Me.NewUserFirstValidation.AutoSize = True
        Me.NewUserFirstValidation.ForeColor = System.Drawing.Color.Red
        Me.NewUserFirstValidation.Location = New System.Drawing.Point(234, 90)
        Me.NewUserFirstValidation.Name = "NewUserFirstValidation"
        Me.NewUserFirstValidation.Size = New System.Drawing.Size(0, 13)
        Me.NewUserFirstValidation.TabIndex = 17
        '
        'NewUserNameBox
        '
        Me.NewUserNameBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NewUserNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NewUserNameBox.ForeColor = System.Drawing.Color.White
        Me.NewUserNameBox.Location = New System.Drawing.Point(92, 19)
        Me.NewUserNameBox.Name = "NewUserNameBox"
        Me.NewUserNameBox.Size = New System.Drawing.Size(134, 20)
        Me.NewUserNameBox.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "User Name:"
        '
        'NewUserPasswordValidation
        '
        Me.NewUserPasswordValidation.AutoSize = True
        Me.NewUserPasswordValidation.ForeColor = System.Drawing.Color.Red
        Me.NewUserPasswordValidation.Location = New System.Drawing.Point(234, 43)
        Me.NewUserPasswordValidation.Name = "NewUserPasswordValidation"
        Me.NewUserPasswordValidation.Size = New System.Drawing.Size(0, 13)
        Me.NewUserPasswordValidation.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Password:"
        '
        'NewUserNameValidation
        '
        Me.NewUserNameValidation.AutoSize = True
        Me.NewUserNameValidation.ForeColor = System.Drawing.Color.Red
        Me.NewUserNameValidation.Location = New System.Drawing.Point(234, 23)
        Me.NewUserNameValidation.Name = "NewUserNameValidation"
        Me.NewUserNameValidation.Size = New System.Drawing.Size(0, 13)
        Me.NewUserNameValidation.TabIndex = 15
        '
        'NewUserPasswordBox
        '
        Me.NewUserPasswordBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NewUserPasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NewUserPasswordBox.ForeColor = System.Drawing.Color.White
        Me.NewUserPasswordBox.Location = New System.Drawing.Point(92, 39)
        Me.NewUserPasswordBox.Name = "NewUserPasswordBox"
        Me.NewUserPasswordBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.NewUserPasswordBox.Size = New System.Drawing.Size(134, 20)
        Me.NewUserPasswordBox.TabIndex = 14
        '
        'SelectTrainingPage
        '
        Me.SelectTrainingPage.BackColor = System.Drawing.Color.Black
        Me.SelectTrainingPage.Controls.Add(Me.StartTrainingButton)
        Me.SelectTrainingPage.Controls.Add(Me.StartTrainingBox)
        Me.SelectTrainingPage.Location = New System.Drawing.Point(4, 22)
        Me.SelectTrainingPage.Name = "SelectTrainingPage"
        Me.SelectTrainingPage.Size = New System.Drawing.Size(794, 323)
        Me.SelectTrainingPage.TabIndex = 2
        Me.SelectTrainingPage.Text = "Start Training"
        Me.SelectTrainingPage.UseWaitCursor = True
        '
        'InsertNewQuestion
        '
        Me.InsertNewQuestion.BackColor = System.Drawing.Color.Black
        Me.InsertNewQuestion.Controls.Add(Me.StartButton)
        Me.InsertNewQuestion.Controls.Add(Me.TextBox2)
        Me.InsertNewQuestion.Location = New System.Drawing.Point(4, 22)
        Me.InsertNewQuestion.Name = "InsertNewQuestion"
        Me.InsertNewQuestion.Size = New System.Drawing.Size(794, 323)
        Me.InsertNewQuestion.TabIndex = 3
        Me.InsertNewQuestion.Text = "Insert New Question"
        '
        'StartButton
        '
        Me.StartButton.ForeColor = System.Drawing.Color.Black
        Me.StartButton.Location = New System.Drawing.Point(716, 297)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 2
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.Black
        Me.TextBox2.ForeColor = System.Drawing.Color.White
        Me.TextBox2.Location = New System.Drawing.Point(3, 3)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox2.Size = New System.Drawing.Size(788, 268)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = "Introduction:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "To start entering a new question into the database, click the ""S" & _
    "tart"" button below." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You can cancel the enrtry, by clicking the ""Cancel"" butto" & _
    "n in the New Question Window."
        '
        'RevisionPage
        '
        Me.RevisionPage.BackColor = System.Drawing.Color.Black
        Me.RevisionPage.Controls.Add(Me.RevisionStartButton)
        Me.RevisionPage.Controls.Add(Me.RevisionDescriptionBox)
        Me.RevisionPage.Location = New System.Drawing.Point(4, 22)
        Me.RevisionPage.Name = "RevisionPage"
        Me.RevisionPage.Size = New System.Drawing.Size(794, 323)
        Me.RevisionPage.TabIndex = 4
        Me.RevisionPage.Text = "Revision"
        '
        'RevisionStartButton
        '
        Me.RevisionStartButton.ForeColor = System.Drawing.Color.Black
        Me.RevisionStartButton.Location = New System.Drawing.Point(716, 297)
        Me.RevisionStartButton.Name = "RevisionStartButton"
        Me.RevisionStartButton.Size = New System.Drawing.Size(75, 23)
        Me.RevisionStartButton.TabIndex = 3
        Me.RevisionStartButton.Text = "Start"
        Me.RevisionStartButton.UseVisualStyleBackColor = True
        '
        'RevisionDescriptionBox
        '
        Me.RevisionDescriptionBox.BackColor = System.Drawing.Color.Black
        Me.RevisionDescriptionBox.ForeColor = System.Drawing.Color.White
        Me.RevisionDescriptionBox.Location = New System.Drawing.Point(3, 3)
        Me.RevisionDescriptionBox.MaxLength = 8000
        Me.RevisionDescriptionBox.Multiline = True
        Me.RevisionDescriptionBox.Name = "RevisionDescriptionBox"
        Me.RevisionDescriptionBox.Size = New System.Drawing.Size(788, 289)
        Me.RevisionDescriptionBox.TabIndex = 0
        Me.RevisionDescriptionBox.Text = resources.GetString("RevisionDescriptionBox.Text")
        '
        'LoggedInUser
        '
        Me.LoggedInUser.AutoSize = True
        Me.LoggedInUser.Location = New System.Drawing.Point(537, 6)
        Me.LoggedInUser.Name = "LoggedInUser"
        Me.LoggedInUser.Size = New System.Drawing.Size(32, 13)
        Me.LoggedInUser.TabIndex = 12
        Me.LoggedInUser.Text = "User:"
        '
        'UserNameOfCurrentUser
        '
        Me.UserNameOfCurrentUser.AutoSize = True
        Me.UserNameOfCurrentUser.Location = New System.Drawing.Point(582, 5)
        Me.UserNameOfCurrentUser.Name = "UserNameOfCurrentUser"
        Me.UserNameOfCurrentUser.Size = New System.Drawing.Size(0, 13)
        Me.UserNameOfCurrentUser.TabIndex = 13
        Me.UserNameOfCurrentUser.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DBConnLabel, Me.DBStatus})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 399)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(850, 22)
        Me.StatusStrip.TabIndex = 14
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'DBConnLabel
        '
        Me.DBConnLabel.Name = "DBConnLabel"
        Me.DBConnLabel.Size = New System.Drawing.Size(123, 17)
        Me.DBConnLabel.Text = "Database Connection:"
        '
        'DBStatus
        '
        Me.DBStatus.Name = "DBStatus"
        Me.DBStatus.Size = New System.Drawing.Size(42, 17)
        Me.DBStatus.Text = "Failure"
        '
        'StartTrainingBox
        '
        Me.StartTrainingBox.BackColor = System.Drawing.Color.Black
        Me.StartTrainingBox.ForeColor = System.Drawing.Color.White
        Me.StartTrainingBox.Location = New System.Drawing.Point(3, 3)
        Me.StartTrainingBox.Multiline = True
        Me.StartTrainingBox.Name = "StartTrainingBox"
        Me.StartTrainingBox.ReadOnly = True
        Me.StartTrainingBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.StartTrainingBox.Size = New System.Drawing.Size(788, 268)
        Me.StartTrainingBox.TabIndex = 2
        Me.StartTrainingBox.Text = "Introduction:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "To start training, click the ""Start"" button below."
        '
        'StartTrainingButton
        '
        Me.StartTrainingButton.ForeColor = System.Drawing.Color.Black
        Me.StartTrainingButton.Location = New System.Drawing.Point(716, 297)
        Me.StartTrainingButton.Name = "StartTrainingButton"
        Me.StartTrainingButton.Size = New System.Drawing.Size(75, 23)
        Me.StartTrainingButton.TabIndex = 3
        Me.StartTrainingButton.Text = "Start"
        Me.StartTrainingButton.UseVisualStyleBackColor = True
        '
        'App4Learn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(850, 421)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.UserNameOfCurrentUser)
        Me.Controls.Add(Me.LoggedInUser)
        Me.Controls.Add(Me.MainTabControl)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "App4Learn"
        Me.Text = "Welcome"
        Me.MainTabControl.ResumeLayout(False)
        Me.LogInPage.ResumeLayout(False)
        Me.LogInPage.PerformLayout()
        Me.NewUserPage.ResumeLayout(False)
        Me.NewUserPage.PerformLayout()
        Me.SelectTrainingPage.ResumeLayout(False)
        Me.SelectTrainingPage.PerformLayout()
        Me.InsertNewQuestion.ResumeLayout(False)
        Me.InsertNewQuestion.PerformLayout()
        Me.RevisionPage.ResumeLayout(False)
        Me.RevisionPage.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LoginButton As System.Windows.Forms.Button
    Friend WithEvents UserNameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UserNameBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FirstNameLabel As System.Windows.Forms.Label
    Friend WithEvents MiddleNameLabel As System.Windows.Forms.Label
    Friend WithEvents LastNameLabel As System.Windows.Forms.Label
    Friend WithEvents FirstNameBox As System.Windows.Forms.TextBox
    Friend WithEvents MiddleNameBox As System.Windows.Forms.TextBox
    Friend WithEvents LastNameBox As System.Windows.Forms.TextBox
    Friend WithEvents NewUserButton As System.Windows.Forms.Button
    Friend WithEvents UserNameErrorLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordErrorLabel As System.Windows.Forms.Label
    Friend WithEvents UserErrorLabel As System.Windows.Forms.Label
    Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents LogInPage As System.Windows.Forms.TabPage
    Friend WithEvents NewUserPage As System.Windows.Forms.TabPage
    Friend WithEvents LoggedInUser As System.Windows.Forms.Label
    Friend WithEvents UserNameOfCurrentUser As System.Windows.Forms.Label
    Friend WithEvents NewUserNameBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NewUserPasswordValidation As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NewUserNameValidation As System.Windows.Forms.Label
    Friend WithEvents NewUserPasswordBox As System.Windows.Forms.TextBox
    Friend WithEvents SelectTrainingPage As System.Windows.Forms.TabPage
    Friend WithEvents InsertNewQuestion As System.Windows.Forms.TabPage
    Friend WithEvents LogOutButton As System.Windows.Forms.Button
    Friend WithEvents NewUserFirstValidation As System.Windows.Forms.Label
    Friend WithEvents NewUserLastValidation As System.Windows.Forms.Label
    Friend WithEvents InvalidLogOnLabel As System.Windows.Forms.Label
    Friend WithEvents RevisionPage As System.Windows.Forms.TabPage
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents DBConnLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DBStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents RevisionStartButton As System.Windows.Forms.Button
    Friend WithEvents RevisionDescriptionBox As System.Windows.Forms.TextBox
    Friend WithEvents StartTrainingButton As System.Windows.Forms.Button
    Friend WithEvents StartTrainingBox As System.Windows.Forms.TextBox

End Class
