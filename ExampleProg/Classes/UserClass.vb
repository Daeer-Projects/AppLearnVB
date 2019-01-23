Imports ExampleProg.Interfaces

Namespace Classes
    ''' <summary>
    ''' The User class.
    ''' Does everything to do with the user.
    ''' Creates new users.
    ''' Stores log in and log out information.
    ''' </summary>
    ''' <remarks>The User class.</remarks>
    Public Class UserClass
        Implements IUserClass

        Property UserId As Integer Implements IUserClass.UserId
        Property UserName As String Implements IUserClass.UserName
        Property Password As String Implements IUserClass.Password
        Property FirstName As String Implements IUserClass.FirstName
        Property MiddleName As String Implements IUserClass.MiddleName
        Property LastName As String Implements IUserClass.LastName
        Property IsValidUser As Boolean Implements IUserClass.IsValidUser

        ''' <summary>
        ''' Checks to see if the user name already exists in the database.
        ''' </summary>
        ''' <param name="dbConnection"></param>
        ''' <returns>True or false.</returns>
        ''' <remarks></remarks>
        Public Function DoesUserNameAlreadyExists(dbConnection As IDbConnector) As Boolean Implements IUserClass.DoesUserNameAlreadyExists
            Dim result As Boolean

            result = dbConnection.DoesUserNameAlreadyExists(UserName)

            Return result
        End Function

        ''' <summary>
        ''' Is the user name already in use.  Is it available.
        ''' </summary>
        ''' <param name="dbConnection"></param>
        ''' <returns>True or false.</returns>
        ''' <remarks></remarks>
        Public Function IsUserNameInDatabase(dbConnection As IDbConnector) As Boolean Implements IUserClass.IsUserNameInDatabase
            Dim result As Boolean

            result = dbConnection.IsUserNameAvailable(UserName)

            Return result
        End Function

        ''' <summary>
        ''' Creates a new user in the database.
        ''' </summary>
        ''' <param name="dbConnection"></param>
        ''' <returns>True or false.</returns>
        ''' <remarks></remarks>
        Public Function CreateNewUser(dbConnection As IDbConnector) As Boolean Implements IUserClass.CreateNewUser
            Dim createdNewUser As Boolean

            createdNewUser = dbConnection.CreateNewUser(Me)

            Return createdNewUser
        End Function

        ''' <summary>
        ''' Gets the user id from the log in details.
        ''' </summary>
        ''' <param name="dbConnection"></param>
        ''' <returns>The user id.</returns>
        ''' <remarks></remarks>
        Public Function Login(dbConnection As IDbConnector) As Boolean Implements IUserClass.Login
            Dim isLoggedIn As Boolean

            ' Validation is done in the log in input class.

            UserId = dbConnection.GetUserIdOfValidUser(UserName, Password)

            Dim tempUser = dbConnection.GetUserDetails(Me)

            If (tempUser.UserName <> Nothing) Then
                FirstName = tempUser.FirstName
                MiddleName = tempUser.MiddleName
                LastName = tempUser.LastName

                UserName = tempUser.UserName
                Password = tempUser.Password

                IsValidUser = True
                isLoggedIn = True
            End If

            Return isLoggedIn
        End Function

        ''' <summary>
        ''' Logs out the current user.  Just resets all the variables.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Logout() Implements IUserClass.Logout

            UserId = 0
            UserName = String.Empty
            Password = String.Empty
            FirstName = String.Empty
            MiddleName = String.Empty
            LastName = String.Empty
            IsValidUser = False

        End Sub

    End Class
End Namespace