Imports ExampleProg.Constants
Imports ExampleProg.Interfaces

Namespace InputClasses
    ''' <summary>
    ''' The Log In Input class.
    ''' Used to validate the user name and password.
    ''' ToDo: sort out the encryption of the password.
    ''' </summary>
    ''' <remarks>Validates the user name and password.</remarks>
    Public Class LogInInput
        Property LoginUserName As String
        Property LoginPassword As String

        Private Property LogInUserId As Integer

        Property IsUserNameValid As Boolean
        Property IsUserNameInDatabase As Boolean
        Property IsPasswordValid As Boolean

        Property DoUserNameAndPasswordMatch As Boolean

        Property UserNameInvalidMessage As String
        Property PasswordInvalidMessage As String
        Property OverallInvalidMessage As String
        
        Private _arrayOfValidity(3) As Boolean

        ''' <summary>
        ''' The validity of the log in details.
        ''' Sets an array and then checks them.
        ''' </summary>
        ''' <param name="p1"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ArrayOfValidity(p1 As Integer) As Boolean
            Get
                Return _arrayOfValidity(p1)
            End Get
            Private Set(value As Boolean)
                _arrayOfValidity(p1) = value
            End Set
        End Property

        ''' <summary>
        ''' The basic constructor.
        ''' Declares the variables.
        ''' Sets the flags.
        ''' Calls the methods to set everything up.
        ''' </summary>
        ''' <param name="username"></param>
        ''' <param name="password"></param>
        ''' <remarks></remarks>
        Public Sub New(username As String, password As String)
            Dim array(3) As Boolean
            _arrayOfValidity(3) = array(3)

            LoginUserName = username
            LoginPassword = password
            LogInUserId = 0

            IsUserNameValid = False
            IsUserNameInDatabase = False
            IsPasswordValid = False
            DoUserNameAndPasswordMatch = False

            UserNameInvalidMessage = String.Empty
            PasswordInvalidMessage = String.Empty
            OverallInvalidMessage = String.Empty
        End Sub

        ''' <summary>
        ''' Sets the basic flags from the input detais.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetBasicValidStates()
            IsUserNameValid = Helpers.Helpers.IsTextNotNull(LoginUserName)
            IsPasswordValid = Helpers.Helpers.IsTextNotNull(LoginPassword)
        End Sub

        ''' <summary>
        ''' Checks if the user name is already in the database.
        ''' </summary>
        ''' <param name="dbConnector"></param>
        ''' <remarks></remarks>
        Public Sub SetUserNameInDatabase(dbConnector As IDbConnector)
            IsUserNameInDatabase = dbConnector.DoesUserNameAlreadyExists(LoginUserName)
        End Sub

        ''' <summary>
        ''' Checks if the user name and password match what is in the database.
        ''' </summary>
        ''' <param name="dbConnector"></param>
        ''' <remarks></remarks>
        Public Sub SetDoUserNameAndPasswordMatch(dbConnector As IDbConnector)
            LogInUserId = dbConnector.GetUserIdOfValidUser(LoginUserName, LoginPassword)

            If (LogInUserId <> 0) Then
                DoUserNameAndPasswordMatch = True
            End If
        End Sub

        ''' <summary>
        ''' Sets the array from the boolean flags.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetArrayOfValidStates()
            ArrayOfValidity(0) = IsUserNameValid
            ArrayOfValidity(1) = IsUserNameInDatabase
            ArrayOfValidity(2) = IsPasswordValid
            ArrayOfValidity(3) = DoUserNameAndPasswordMatch
        End Sub

        ''' <summary>
        ''' Sets the invalid messages.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetInvalidMessages()
            UserNameInvalidMessage = If((IsUserNameValid Or IsUserNameInDatabase), String.Empty, CommonConstants.NotAValidInput)
            PasswordInvalidMessage = If(IsPasswordValid, String.Empty, CommonConstants.NotAValidInput)
            OverallInvalidMessage = If(DoUserNameAndPasswordMatch, String.Empty, CommonConstants.UserNameAndPasswordDoNotMatch)
        End Sub

        ''' <summary>
        ''' Checks to find any false flags in the array.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsThereAFalseInTheInput() As Boolean
            Dim testArray(3) As Boolean
            testArray(0) = ArrayOfValidity(0)
            testArray(1) = ArrayOfValidity(1)
            testArray(2) = ArrayOfValidity(2)
            testArray(3) = ArrayOfValidity(3)

            Return Helpers.Helpers.IsThereAFalseInArray(testArray)
        End Function

    End Class
End Namespace