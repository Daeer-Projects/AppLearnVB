Namespace Interfaces
    ''' <summary>
    ''' The User class Interface.
    ''' </summary>
    ''' <remarks>Interface for the User class.</remarks>
    Public Interface IUserClass

        Property UserId() As Integer
        Property UserName() As String
        Property Password() As String
        Property FirstName() As String
        Property MiddleName() As String
        Property LastName() As String
        Property IsValidUser() As Boolean

        Function IsUserNameInDatabase(dbConnection As IDbConnector) As Boolean
        Function DoesUserNameAlreadyExists(dbConnection As IDbConnector) As Boolean
        Function CreateNewUser(dbConnection As IDbConnector) As Boolean
        Function Login(dbConnection As IDbConnector) As Boolean
        Sub Logout()

    End Interface
End Namespace