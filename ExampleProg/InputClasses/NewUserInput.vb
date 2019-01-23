Imports ExampleProg.Constants
Imports ExampleProg.Interfaces

Namespace InputClasses
    ''' <summary>
    ''' The New User Input class.
    ''' Validates all of the inputs for a new user.
    ''' </summary>
    ''' <remarks>The New User class.</remarks>
    Public Class NewUserInput
        Property NewUserName As String
        Property NewPassword As String
        Property NewFirstName As String
        Property NewMiddleName As String
        Property NewLastName As String

        Property IsUserNameValid As Boolean
        Property IsUserAvailable As Boolean
        Property IsPasswordValid As Boolean
        Property IsFirstNameValid As Boolean
        Property IsMiddleNameValid As Boolean
        Property IsLastNameValid As Boolean

        Property UserNameInvalidMessage As String
        Property PasswordInvalidMessage As String
        Property FirstNameInvalidMessage As String
        Property MiddleNameInvalidmessage As String
        Property LastNameInvalidMessage As String

        Private ReadOnly _arrayOfValidity(5) As Boolean
        ''' <summary>
        ''' The validity array property.
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
        ''' Declares all the variables.
        ''' Sets the default flags.
        ''' calls the other methods to create the new user.
        ''' </summary>
        ''' <param name="userName"></param>
        ''' <param name="password"></param>
        ''' <param name="firstName"></param>
        ''' <param name="middleName"></param>
        ''' <param name="lastName"></param>
        ''' <remarks></remarks>
        Public Sub New(userName As String, password As String, firstName As String, middleName As String, lastName As String)
            Dim array(5) As Boolean
            _arrayOfValidity(5) = array(5)

            NewUserName = userName
            NewPassword = password
            NewFirstName = firstName
            NewMiddleName = middleName
            NewLastName = lastName

            IsUserNameValid = False
            IsUserAvailable = False
            IsPasswordValid = False
            IsFirstNameValid = False
            IsMiddleNameValid = True
            IsLastNameValid = False

            UserNameInvalidMessage = String.Empty
            PasswordInvalidMessage = String.Empty
            FirstNameInvalidMessage = String.Empty
            MiddleNameInvalidmessage = String.Empty
            LastNameInvalidMessage = String.Empty
        End Sub

        ''' <summary>
        ''' Sets the flags from the user inputs.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetValidStates()
            IsUserNameValid = Helpers.Helpers.IsTextNotNull(NewUserName)
            IsPasswordValid = Helpers.Helpers.IsTextNotNull(NewPassword)
            IsFirstNameValid = Helpers.Helpers.IsTextNotNull(NewFirstName)
            IsLastNameValid = Helpers.Helpers.IsTextNotNull(NewLastName)
        End Sub

        ''' <summary>
        ''' Checks if the user name is already used.
        ''' </summary>
        ''' <param name="dbConnector"></param>
        ''' <remarks></remarks>
        Public Sub SetUserNameIsUsed(dbConnector As IDbConnector)
            IsUserAvailable = dbConnector.IsUserNameAvailable(NewUserName)
        End Sub

        ''' <summary>
        ''' Set the array from the flags.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetArrayOfValidStates()
            ArrayOfValidity(0) = IsUserNameValid
            ArrayOfValidity(1) = IsUserAvailable
            ArrayOfValidity(2) = IsPasswordValid
            ArrayOfValidity(3) = IsFirstNameValid
            ArrayOfValidity(4) = IsMiddleNameValid
            ArrayOfValidity(5) = IsLastNameValid
        End Sub

        ''' <summary>
        ''' Sets the invalid messages.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetInvalidMessages()
            UserNameInvalidMessage = If(IsUserNameValid, If(IsUserAvailable, CommonConstants.UserIsAvailable, CommonConstants.UserAlreadyExists), CommonConstants.NotAValidInput)
            PasswordInvalidMessage = If(IsPasswordValid, String.Empty, CommonConstants.NotAValidInput)
            FirstNameInvalidMessage = If(IsFirstNameValid, String.Empty, CommonConstants.NotAValidInput)
            LastNameInvalidMessage = If(IsLastNameValid, String.Empty, CommonConstants.NotAValidInput)
        End Sub

        ''' <summary>
        ''' Checks if the array is valid.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsThereAFalseInTheInput() As Boolean
            Dim testArray(5) As Boolean
            testArray(0) = ArrayOfValidity(0)
            testArray(1) = ArrayOfValidity(1)
            testArray(2) = ArrayOfValidity(2)
            testArray(3) = ArrayOfValidity(3)
            testArray(4) = ArrayOfValidity(4)
            testArray(5) = ArrayOfValidity(5)

            Return Helpers.Helpers.IsThereAFalseInArray(testArray)
        End Function

    End Class
End Namespace