Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ExampleProg.Constants
Imports ExampleProg.InputClasses
Imports ExampleProg.Interfaces
Imports Moq

''' <summary>
''' A set of tests for the Log In Input class.
''' </summary>
''' <remarks>Tests.</remarks>
<TestClass()> Public Class LogInInputTests

    <TestMethod()> Public Sub test_log_in_sets_user_name_valid_states_to_true()
        ' Arrange.
        Dim loginInput = New LogInInput("me", "secret")

        ' Act.
        loginInput.SetBasicValidStates()

        ' Assert.
        Assert.IsTrue(loginInput.IsUserNameValid)
    End Sub

    <TestMethod()> Public Sub test_log_in_sets_user_name_valid_states_to_false()
        ' Arrange.
        Dim loginInput = New LogInInput(String.Empty, "secret")

        ' Act.
        loginInput.SetBasicValidStates()

        ' Assert.
        Assert.IsFalse(loginInput.IsUserNameValid)
    End Sub

    <TestMethod()> Public Sub test_log_in_sets_password_valid_states_to_true()
        ' Arrange.
        Dim loginInput = New LogInInput("me", "secret")

        ' Act.
        loginInput.SetBasicValidStates()

        ' Assert.
        Assert.IsTrue(loginInput.IsPasswordValid)
    End Sub

    <TestMethod()> Public Sub test_log_in_sets_password_valid_states_to_false()
        ' Arrange.
        Dim loginInput = New LogInInput("me", String.Empty)

        ' Act.
        loginInput.SetBasicValidStates()

        ' Assert.
        Assert.IsFalse(loginInput.IsPasswordValid)
    End Sub

    <TestMethod()> Public Sub test_log_in_sets_array_of_valid_states_for_user_name_to_true()
        ' Arrange.
        Dim loginInput = New LogInInput("me", "secret")
        loginInput.SetBasicValidStates()
        loginInput.IsUserNameInDatabase = False
        loginInput.DoUserNameAndPasswordMatch = True

        ' Act.
        loginInput.SetArrayOfValidStates()

        ' Assert.
        Assert.IsTrue(loginInput.ArrayOfValidity(0))
    End Sub

    <TestMethod()> Public Sub test_log_in_sets_array_of_valid_states_for_password_to_true()
        ' Arrange.
        Dim loginInput = New LogInInput("me", "secret")
        loginInput.SetBasicValidStates()
        loginInput.IsUserNameInDatabase = False
        loginInput.DoUserNameAndPasswordMatch = True

        ' Act.
        loginInput.SetArrayOfValidStates()

        ' Assert.
        Assert.IsTrue(loginInput.ArrayOfValidity(2))
    End Sub

    <TestMethod()> Public Sub test_log_in_sets_invalid_message_for_user_name()
        ' Arrange.
        Dim loginInput = New LogInInput("me", "secret")
        loginInput.SetBasicValidStates()
        loginInput.IsUserNameInDatabase = False
        loginInput.DoUserNameAndPasswordMatch = True

        ' Act.
        loginInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(String.Empty, loginInput.UserNameInvalidMessage)
    End Sub

    <TestMethod()> Public Sub test_log_in_sets_invalid_message_for_user_name_when_null()
        ' Arrange.
        Dim loginInput = New LogInInput(String.Empty, "secret")
        loginInput.SetBasicValidStates()
        loginInput.IsUserNameInDatabase = False
        loginInput.DoUserNameAndPasswordMatch = True

        ' Act.
        loginInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(CommonConstants.NotAValidInput, loginInput.UserNameInvalidMessage)
    End Sub

    <TestMethod()> Public Sub test_log_in_sets_invalid_message_for_password()
        ' Arrange.
        Dim loginInput = New LogInInput("me", "secret")
        loginInput.SetBasicValidStates()
        loginInput.IsUserNameInDatabase = False
        loginInput.DoUserNameAndPasswordMatch = True

        ' Act.
        loginInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(String.Empty, loginInput.PasswordInvalidMessage)
    End Sub

    <TestMethod()> Public Sub test_log_in_sets_invalid_message_for_password_when_null()
        ' Arrange.
        Dim loginInput = New LogInInput("me", String.Empty)
        loginInput.SetBasicValidStates()
        loginInput.IsUserNameInDatabase = False
        loginInput.DoUserNameAndPasswordMatch = True

        ' Act.
        loginInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(CommonConstants.NotAValidInput, loginInput.PasswordInvalidMessage)
    End Sub

    <TestMethod()> Public Sub test_log_in_sets_invalid_message_for_user_name_that_already_exists()
        ' Arrange.
        Dim loginInput = New LogInInput("me", "secret")
        loginInput.SetBasicValidStates()
        loginInput.IsUserNameInDatabase = True
        loginInput.DoUserNameAndPasswordMatch = True

        ' Act.
        loginInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(String.Empty, loginInput.UserNameInvalidMessage)
    End Sub

    <TestMethod()> Public Sub test_log_in_sets_invalid_message_for_invalid_user_and_password()
        ' Arrange.
        Dim loginInput = New LogInInput("me", "secret")
        loginInput.SetBasicValidStates()
        loginInput.IsUserNameInDatabase = True
        loginInput.DoUserNameAndPasswordMatch = False

        ' Act.
        loginInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(CommonConstants.UserNameAndPasswordDoNotMatch, loginInput.OverallInvalidMessage)
    End Sub

    <TestMethod()> Public Sub test_set_user_name_in_db_to_true()
        ' Arrange.
        Const expected As Boolean = True
        Dim dbConnector = New Mock(Of IDbConnector)
        dbConnector.Setup(Function(c) c.DoesUserNameAlreadyExists(It.IsAny(Of String))).Returns(expected)
        Dim loginInput = New LogInInput("me", "secret")

        ' Act.
        loginInput.SetUserNameInDatabase(dbConnector.Object)

        ' Assert.
        Assert.IsTrue(loginInput.IsUserNameInDatabase)
    End Sub

    <TestMethod()> Public Sub test_set_user_name_in_db_to_false()
        ' Arrange.
        Const expected As Boolean = False
        Dim dbConnector = New Mock(Of IDbConnector)
        dbConnector.Setup(Function(c) c.DoesUserNameAlreadyExists(It.IsAny(Of String))).Returns(expected)
        Dim loginInput = New LogInInput("me", "secret")

        ' Act.
        loginInput.SetUserNameInDatabase(dbConnector.Object)

        ' Assert.
        Assert.IsFalse(loginInput.IsUserNameInDatabase)
    End Sub

    <TestMethod()> Public Sub test_set_do_user_name_and_password_match_returns_true()
        ' Arrange.
        Const expected As Integer = 4
        Dim dbConnector = New Mock(Of IDbConnector)
        dbConnector.Setup(Function(c) c.GetUserIdOfValidUser(It.IsAny(Of String), It.IsAny(Of String))).Returns(expected)
        Dim loginInput = New LogInInput("me", "secret")

        ' Act.
        loginInput.SetDoUserNameAndPasswordMatch(dbConnector.Object)

        ' Assert.
        Assert.IsTrue(loginInput.DoUserNameAndPasswordMatch)
    End Sub

    <TestMethod()> Public Sub test_set_do_user_name_and_password_match_returns_false()
        ' Arrange.
        Const expected As Integer = 0
        Dim dbConnector = New Mock(Of IDbConnector)
        dbConnector.Setup(Function(c) c.GetUserIdOfValidUser(It.IsAny(Of String), It.IsAny(Of String))).Returns(expected)
        Dim loginInput = New LogInInput("me", "secret")

        ' Act.
        loginInput.SetDoUserNameAndPasswordMatch(dbConnector.Object)

        ' Assert.
        Assert.IsFalse(loginInput.DoUserNameAndPasswordMatch)
    End Sub

    <TestMethod()> Public Sub test_is_there_a_false_in_array_returs_true_for_all_good()
        ' Arrange.
        Const userID As Integer = 6
        Const userExists As Boolean = True
        Dim dbConnector = New Mock(Of IDbConnector)
        dbConnector.Setup(Function(c) c.DoesUserNameAlreadyExists(It.IsAny(Of String))).Returns(userExists)
        dbConnector.Setup(Function(c) c.GetUserIdOfValidUser(It.IsAny(Of String), It.IsAny(Of String))).Returns(userID)
        Dim loginInput = New LogInInput("me", "secret")

        ' Act.
        loginInput.SetBasicValidStates()
        loginInput.SetUserNameInDatabase(dbConnector.Object)
        loginInput.SetDoUserNameAndPasswordMatch(dbConnector.Object)
        loginInput.SetArrayOfValidStates()

        ' Assert.
        Assert.IsTrue(loginInput.IsThereAFalseInTheInput())
    End Sub

    <TestMethod()> Public Sub test_is_there_a_false_in_array_returs_false_for_no_user_name()
        ' Arrange.
        Const userID As Integer = 6
        Const userExists As Boolean = True
        Dim dbConnector = New Mock(Of IDbConnector)
        dbConnector.Setup(Function(c) c.DoesUserNameAlreadyExists(It.IsAny(Of String))).Returns(userExists)
        dbConnector.Setup(Function(c) c.GetUserIdOfValidUser(It.IsAny(Of String), It.IsAny(Of String))).Returns(userID)
        Dim loginInput = New LogInInput(String.Empty, "secret")

        ' Act.
        loginInput.SetBasicValidStates()
        loginInput.SetUserNameInDatabase(dbConnector.Object)
        loginInput.SetDoUserNameAndPasswordMatch(dbConnector.Object)
        loginInput.SetArrayOfValidStates()

        ' Assert.
        Assert.IsFalse(loginInput.IsThereAFalseInTheInput())
    End Sub

    <TestMethod()> Public Sub test_is_there_a_false_in_array_returs_false_for_no_password()
        ' Arrange.
        Const userID As Integer = 6
        Const userExists As Boolean = True
        Dim dbConnector = New Mock(Of IDbConnector)
        dbConnector.Setup(Function(c) c.DoesUserNameAlreadyExists(It.IsAny(Of String))).Returns(userExists)
        dbConnector.Setup(Function(c) c.GetUserIdOfValidUser(It.IsAny(Of String), It.IsAny(Of String))).Returns(userID)
        Dim loginInput = New LogInInput("me", String.Empty)

        ' Act.
        loginInput.SetBasicValidStates()
        loginInput.SetUserNameInDatabase(dbConnector.Object)
        loginInput.SetDoUserNameAndPasswordMatch(dbConnector.Object)
        loginInput.SetArrayOfValidStates()

        ' Assert.
        Assert.IsFalse(loginInput.IsThereAFalseInTheInput())
    End Sub

End Class