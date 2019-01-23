Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports ExampleProg.Classes
Imports ExampleProg.Interfaces

''' <summary>
''' A set of tests for the User class.
''' </summary>
''' <remarks>Tests.</remarks>
<TestClass()> Public Class UserClassTests
    <TestMethod()> Public Sub create_new_user_returns_true()
        ' Arrange.
        Dim dbConnector = New Mock(Of IDbConnector)
        Const expected As Boolean = True

        dbConnector.Setup(Function(c) c.CreateNewUser(It.IsAny(Of UserClass))).Returns(expected)
        Dim user As IUserClass
        user = New UserClass
        user.UserName = "pooh"
        user.Password = "1234"
        user.FirstName = "Pooh"
        user.LastName = "Bear"

        ' Act.
        Dim result As Boolean
        result = user.CreateNewUser(dbConnector.Object)

        ' Assert.
        Assert.IsTrue(result)
    End Sub

    <TestMethod()> Public Sub create_new_user_returns_false()
        ' Arrange.
        Dim dbConnector = New Mock(Of IDbConnector)
        Const expected As Boolean = False

        dbConnector.Setup(Function(c) c.CreateNewUser(It.IsAny(Of UserClass))).Returns(expected)
        Dim user As IUserClass
        user = New UserClass
        user.UserName = "pooh"
        user.Password = "1234"
        user.FirstName = "Pooh"
        user.LastName = "Bear"

        ' Act.
        Dim result As Boolean
        result = user.CreateNewUser(dbConnector.Object)

        ' Assert.
        Assert.IsFalse(result)
    End Sub

    <TestMethod()> Public Sub log_in_returns_true()
        ' Arrange.
        Dim dbConnector = New Mock(Of IDbConnector)
        Const id As Integer = 1
        Dim user = New UserClass
        user.FirstName = "Pooh"
        user.LastName = "Bear"
        user.UserId = 1
        user.UserName = "poohB"
        user.Password = "ohbother"

        dbConnector.Setup(Function(c) c.GetUserIdOfValidUser(It.IsAny(Of String), It.IsAny(Of String))).Returns(id)
        dbConnector.Setup(Function(d) d.GetUserDetails(It.IsAny(Of UserClass))).Returns(user)

        Dim userInput = New UserClass
        userInput.UserName = "poohB"
        userInput.Password = "ohbother"

        ' Act.
        Dim result As Boolean
        result = userInput.Login(dbConnector.Object)

        ' Assert.
        Assert.IsTrue(result)
    End Sub

    <TestMethod()> Public Sub log_in_returns_false()
        ' Arrange.
        Dim dbConnector = New Mock(Of IDbConnector)
        Dim user = New UserClass
        dbConnector.Setup(Function(d) d.GetUserDetails(It.IsAny(Of UserClass))).Returns(user)

        Dim userInput = New UserClass
        userInput.UserName = "poohB"
        userInput.Password = "ohbother"

        ' Act.
        Dim result As Boolean
        result = userInput.Login(dbConnector.Object)

        ' Assert.
        Assert.IsFalse(result)
    End Sub

    <TestMethod()> Public Sub log_in_sets_id_correctly()
        ' Arrange.
        Dim dbConnector = New Mock(Of IDbConnector)
        Const id As Integer = 1
        Dim user = New UserClass
        user.FirstName = "Pooh"
        user.LastName = "Bear"
        user.UserId = 1
        user.UserName = "poohB"
        user.Password = "ohbother"

        dbConnector.Setup(Function(c) c.GetUserIdOfValidUser(It.IsAny(Of String), It.IsAny(Of String))).Returns(id)
        dbConnector.Setup(Function(d) d.GetUserDetails(It.IsAny(Of UserClass))).Returns(user)

        Dim userInput = New UserClass
        userInput.UserName = "poohB"
        userInput.Password = "ohbother"

        ' Act.
        userInput.Login(dbConnector.Object)

        ' Assert.
        Assert.AreEqual(1, userInput.UserId)
    End Sub

    <TestMethod()> Public Sub does_user_name_exist_returns_true()
        ' Arrange.
        Const result As Boolean = True
        Dim dbConnector = New Mock(Of IDbConnector)
        dbConnector.Setup(Function(c) c.DoesUserNameAlreadyExists(It.IsAny(Of String))).Returns(result)
        Dim user = New UserClass
        user.UserName = "tiggr"

        ' Act.
        Dim actual = user.DoesUserNameAlreadyExists(dbConnector.Object)

        ' Assert.
        Assert.IsTrue(actual)
    End Sub

    <TestMethod()> Public Sub does_user_name_exist_returns_false()
        ' Arrange.
        Const result As Boolean = False
        Dim dbConnector = New Mock(Of IDbConnector)
        dbConnector.Setup(Function(c) c.DoesUserNameAlreadyExists(It.IsAny(Of String))).Returns(result)
        Dim user = New UserClass
        user.UserName = "tiggr"

        ' Act.
        Dim actual = user.DoesUserNameAlreadyExists(dbConnector.Object)

        ' Assert.
        Assert.IsFalse(actual)
    End Sub

    <TestMethod()> Public Sub test_is_user_name_available_returns_true()
        ' Arrange.
        Const result As Boolean = True
        Dim dbConnector = New Mock(Of IDbConnector)
        dbConnector.Setup(Function(c) c.IsUserNameAvailable(It.IsAny(Of String))).Returns(result)
        Dim testUser = New UserClass
        testUser.UserName = "tiggr"

        ' Act.
        Dim actual = testUser.IsUserNameInDatabase(dbConnector.Object)

        ' Assert.
        Assert.IsTrue(actual)
    End Sub

    <TestMethod()> Public Sub test_is_user_name_available_returns_false()
        ' Arrange.
        Const result As Boolean = False
        Dim dbConnector = New Mock(Of IDbConnector)
        dbConnector.Setup(Function(c) c.IsUserNameAvailable(It.IsAny(Of String))).Returns(result)
        Dim testUser = New UserClass
        testUser.UserName = "tiggr"

        ' Act.
        Dim actual = testUser.IsUserNameInDatabase(dbConnector.Object)

        ' Assert.
        Assert.IsFalse(actual)
    End Sub

    <TestMethod()> Public Sub test_log_out_sets_user_id_to_zero()
        ' Arrange.
        Dim testUser = New UserClass
        testUser.UserId = 4
        testUser.FirstName = "Pooh"
        testUser.LastName = "Bear"
        testUser.UserName = "poohB"
        testUser.Password = "secret"

        ' Act.
        testUser.Logout()

        ' Assert.
        Assert.AreEqual(0, testUser.UserId)
    End Sub

    <TestMethod()> Public Sub test_log_out_sets_user_name_to_empty_string()
        ' Arrange.
        Dim testUser = New UserClass
        testUser.UserId = 4
        testUser.FirstName = "Pooh"
        testUser.LastName = "Bear"
        testUser.UserName = "poohB"
        testUser.Password = "secret"

        ' Act.
        testUser.Logout()

        ' Assert.
        Assert.AreEqual(String.Empty, testUser.UserName)
    End Sub

    <TestMethod()> Public Sub test_log_out_sets_first_name_to_empty_string()
        ' Arrange.
        Dim testUser = New UserClass
        testUser.UserId = 4
        testUser.FirstName = "Pooh"
        testUser.LastName = "Bear"
        testUser.UserName = "poohB"
        testUser.Password = "secret"

        ' Act.
        testUser.Logout()

        ' Assert.
        Assert.AreEqual(String.Empty, testUser.FirstName)
    End Sub

    <TestMethod()> Public Sub test_log_out_sets_last_name_to_empty_string()
        ' Arrange.
        Dim testUser = New UserClass
        testUser.UserId = 4
        testUser.FirstName = "Pooh"
        testUser.LastName = "Bear"
        testUser.UserName = "poohB"
        testUser.Password = "secret"

        ' Act.
        testUser.Logout()

        ' Assert.
        Assert.AreEqual(String.Empty, testUser.LastName)
    End Sub

    <TestMethod()> Public Sub test_log_out_sets_password_to_empty_string()
        ' Arrange.
        Dim testUser = New UserClass
        testUser.UserId = 4
        testUser.FirstName = "Pooh"
        testUser.LastName = "Bear"
        testUser.UserName = "poohB"
        testUser.Password = "secret"

        ' Act.
        testUser.Logout()

        ' Assert.
        Assert.AreEqual(String.Empty, testUser.Password)
    End Sub

End Class