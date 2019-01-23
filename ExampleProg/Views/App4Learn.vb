Imports System.Configuration
Imports DapperWrapper
Imports ExampleProg.Classes
Imports ExampleProg.Constants
Imports ExampleProg.DatabaseClasses
Imports ExampleProg.InputClasses
Imports ExampleProg.Interfaces

''' <summary>
''' The main Application View.
''' </summary>
''' <remarks>The main page.</remarks>
Public Class App4Learn

#Region "Properties"
    Dim WithEvents _userClass As IUserClass
    Dim WithEvents _tempUserClass As IUserClass
    Dim WithEvents _dbConnector As IDbConnector
    Private _dbConnectionString As String
#End Region

#Region "Initialize and Load"
    ''' <summary>
    ''' The on load method for the page.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _dbConnectionString = ConfigurationManager.ConnectionStrings(DatabaseConstants.ApplicationConfigString).ConnectionString
        StatusStrip.Items.Item(1).Text = DatabaseConstants.DBConnecting
        Initialize()
    End Sub

    ''' <summary>
    ''' Setting up all the systems for the page.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Initialize()
        InitializeDatabase()
        SetupUsers()
        RemoveMainTabs()
        ClearAllItems()
    End Sub

    ''' <summary>
    ''' Setting up the database connection.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitializeDatabase()
        Dim sqlExecutorFactory = New SqlExecutorFactory(_dbConnectionString)
        Dim newDatabaseConnection = New DatabaseConnectorWrapper(sqlExecutorFactory)
        _dbConnector = newDatabaseConnection
        StatusStrip.Items.Item(1).Text = _dbConnector.DBConnectionStatus.ToString()
        SetStatusColour()
    End Sub

    ''' <summary>
    ''' Setting up the users for the page.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetupUsers()
        Dim newUser = New UserClass
        _userClass = newUser
        Dim newTempUser = New UserClass
        _tempUserClass = newTempUser
    End Sub

    ''' <summary>
    ''' Setting the status colour based upon the connection status.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetStatusColour()
        StatusStrip.Items(1).ForeColor = If(StatusStrip.Items(1).Text = DatabaseConstants.DBConnectedSuccesful, Color.Green, Color.Red)
    End Sub

#End Region

#Region "Login / Logout"
    ''' <summary>
    ''' The log in button click method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        ' Create a log in class.
        Dim loginInput = New LogInInput(UserNameBox.Text, PasswordTextBox.Text)
        loginInput.SetBasicValidStates()
        loginInput.SetUserNameInDatabase(_dbConnector)
        loginInput.SetDoUserNameAndPasswordMatch(_dbConnector)
        loginInput.SetInvalidMessages()
        loginInput.SetArrayOfValidStates()

        ' Clear any previous User details.
        SetupUsers()
        ClearLogInInvalidLabels()

        UserNameErrorLabel.Text = loginInput.UserNameInvalidMessage
        PasswordErrorLabel.Text = loginInput.PasswordInvalidMessage
        InvalidLogOnLabel.Text = loginInput.OverallInvalidMessage

        ' Check if any one is invalid, then fail.
        If (loginInput.IsThereAFalseInTheInput()) Then
            Dim result As Boolean

            ' If all is okay, then set User.
            ' Send details to the database.
            _userClass.UserName = loginInput.LoginUserName
            _userClass.Password = loginInput.LoginPassword
            result = _userClass.Login(_dbConnector)

            If (result) Then
                SetLoggedInSettings()
            End If
        End If
    End Sub

    ''' <summary>
    ''' The log out button click.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LogOutButton_Click(sender As Object, e As EventArgs) Handles LogOutButton.Click
        ClearAllItems()
        _userClass.Logout()

        ' Clearing all of the logged in settings.
        SetupUsers()
        SetLoggedOutSettings()
    End Sub

    ''' <summary>
    ''' Setting up the logged in settings.
    ''' Flags.
    ''' The visible tabs.
    ''' Clearing the text boxes.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetLoggedInSettings()
        UserNameOfCurrentUser.Text = _userClass.UserName
        MainTabControl.TabPages(0).Text = "Log out"
        LoginButton.Visible = False
        LogOutButton.Visible = True
        AddMainTabs()
        MainTabControl.SelectTab(2)
        ClearLogInTextBoxes()
    End Sub

    ''' <summary>
    ''' Setting the logged out systems.
    ''' Flags.
    ''' The non-visible tabs.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetLoggedOutSettings()
        UserNameOfCurrentUser.Text = _userClass.UserName
        MainTabControl.TabPages(0).Text = "Log in"
        LoginButton.Visible = True
        LogOutButton.Visible = False

        MainTabControl.SelectTab(0)
        RemoveMainTabs()
    End Sub
#End Region

#Region "New User"
    ''' <summary>
    ''' The new user button click.
    ''' The process to create a new user.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NewUserButton_Click(sender As Object, e As EventArgs) Handles NewUserButton.Click
        ' Create a new user input class.
        Dim userInput = New NewUserInput(NewUserNameBox.Text, NewUserPasswordBox.Text, FirstNameBox.Text, MiddleNameBox.Text, LastNameBox.Text)
        userInput.SetValidStates()
        userInput.SetUserNameIsUsed(_dbConnector)
        userInput.SetInvalidMessages()
        userInput.SetArrayOfValidStates()

        ' Create a new _tempUserClass.
        _tempUserClass = New UserClass
        ClearInvalidLabels()

        If (userInput.IsUserAvailable And userInput.IsUserNameValid) Then
            NewUserNameValidation.ForeColor = Color.Green
        Else
            NewUserNameValidation.ForeColor = Color.Red
        End If

        NewUserNameValidation.Text = userInput.UserNameInvalidMessage
        NewUserPasswordValidation.Text = userInput.PasswordInvalidMessage
        NewUserFirstValidation.Text = userInput.FirstNameInvalidMessage
        NewUserLastValidation.Text = userInput.LastNameInvalidMessage

        ' Check if any one is invalid, then fail.
        If (userInput.IsThereAFalseInTheInput()) Then
            Dim result As Boolean

            ' If all is okay, then set _tempUserClass.
            ' Send details to the database.
            _tempUserClass.UserName = userInput.NewUserName
            _tempUserClass.Password = userInput.NewPassword
            _tempUserClass.FirstName = userInput.NewFirstName
            _tempUserClass.MiddleName = userInput.NewMiddleName
            _tempUserClass.LastName = userInput.NewLastName

            result = _tempUserClass.CreateNewUser(_dbConnector)

            If (result) Then
                MainTabControl.SelectTab(0)
                ClearNewUserTextBoxes()
            End If
        End If
    End Sub

#Region "Extra Commands and functions"
    ''' <summary>
    ''' Clears the text boxes for the new user page.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearNewUserTextBoxes()
        NewUserNameBox.Text = String.Empty
        NewUserPasswordBox.Text = String.Empty
        FirstNameBox.Text = String.Empty
        MiddleNameBox.Text = String.Empty
        LastNameBox.Text = String.Empty
    End Sub

    ''' <summary>
    ''' Clears the invalid labels for the new user page.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearInvalidLabels()
        NewUserNameValidation.Text = String.Empty
        NewUserPasswordValidation.Text = String.Empty
        NewUserFirstValidation.Text = String.Empty
        NewUserLastValidation.Text = String.Empty
    End Sub
#End Region

#End Region

#Region "Start Training"
    ''' <summary>
    ''' The start training click button.
    ''' Starts the new view for training.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub StartTrainingButton_Click(sender As Object, e As EventArgs) Handles StartTrainingButton.Click
        WindowState = FormWindowState.Minimized
        SelectTrainingView.ShowDialog()
        WindowState = FormWindowState.Normal
    End Sub
#End Region

#Region "New Question"
    ''' <summary>
    ''' The start new question button click.
    ''' Starts the new question page.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        WindowState = FormWindowState.Minimized
        NewQuestionView.ShowDialog()
        WindowState = FormWindowState.Normal
    End Sub
#End Region

#Region "Revision"
    ''' <summary>
    ''' The revision button click.
    ''' Starts the revision page.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles RevisionStartButton.Click
        WindowState = FormWindowState.Minimized
        Revision.ShowDialog()
        WindowState = FormWindowState.Normal
    End Sub
#End Region

#Region "Misc commands"

#Region "Clear Items"
    ''' <summary>
    ''' Clears the text boxes and labels.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearAllItems()
        ClearLogInTextBoxes()
        ClearLogInInvalidLabels()
    End Sub

    ''' <summary>
    ''' Clears the combo boxes.
    ''' </summary>
    ''' <param name="box"></param>
    ''' <remarks></remarks>
    Private Sub ClearComboBoxes(box As ComboBox)
        box.Items.Clear()
        box.Text = String.Empty
    End Sub

    ''' <summary>
    ''' Clears the log in text boxes.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearLogInTextBoxes()
        UserNameBox.Text = String.Empty
        PasswordTextBox.Text = String.Empty
    End Sub

    ''' <summary>
    ''' Clears the log in invalid labels.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearLogInInvalidLabels()
        UserNameErrorLabel.Text = String.Empty
        PasswordErrorLabel.Text = String.Empty
        InvalidLogOnLabel.Text = String.Empty
    End Sub
#End Region

#Region "Tab Controls"
    ''' <summary>
    ''' Removes the main page tabs.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RemoveMainTabs()
        MainTabControl.TabPages.Remove(SelectTrainingPage)
        MainTabControl.TabPages.Remove(InsertNewQuestion)
        MainTabControl.TabPages.Remove(RevisionPage)
    End Sub

    ''' <summary>
    ''' Adds the main page tabs.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddMainTabs()
        MainTabControl.TabPages.Add(SelectTrainingPage)
        MainTabControl.TabPages.Add(InsertNewQuestion)
        MainTabControl.TabPages.Add(RevisionPage)
    End Sub
#End Region

#End Region

End Class