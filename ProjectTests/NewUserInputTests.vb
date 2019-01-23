Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ExampleProg.Constants
Imports ExampleProg.InputClasses
Imports ExampleProg.Interfaces
Imports Moq

''' <summary>
''' A set of tests for the New User Input class.
''' </summary>
''' <remarks>Tests.</remarks>
<TestClass()> Public Class NewUserInputTests

    <TestMethod()> Public Sub test_new_user_sets_user_name_valid_state_to_true()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")

        ' Act.
        userInput.SetValidStates()

        ' Assert.
        Assert.IsTrue(userInput.IsUserNameValid)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_user_name_valid_state_to_false()
        ' Arrange.
        Dim userInput = New NewUserInput(String.Empty, "secret", "Pooh", "S", "Bear")

        ' Act.
        userInput.SetValidStates()

        ' Assert.
        Assert.IsFalse(userInput.IsUserNameValid)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_password_valid_state_to_true()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")

        ' Act.
        userInput.SetValidStates()

        ' Assert.
        Assert.IsTrue(userInput.IsPasswordValid)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_password_valid_state_to_false()
        ' Arrange.
        Dim userInput = New NewUserInput("me", String.Empty, "Pooh", "S", "Bear")

        ' Act.
        userInput.SetValidStates()

        ' Assert.
        Assert.IsFalse(userInput.IsPasswordValid)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_first_name_valid_state_to_true()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")

        ' Act.
        userInput.SetValidStates()

        ' Assert.
        Assert.IsTrue(userInput.IsFirstNameValid)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_first_name_valid_state_to_false()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", String.Empty, "S", "Bear")

        ' Act.
        userInput.SetValidStates()

        ' Assert.
        Assert.IsFalse(userInput.IsFirstNameValid)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_middle_name_valid_state_to_true()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")

        ' Act.
        userInput.SetValidStates()

        ' Assert.
        Assert.IsTrue(userInput.IsMiddleNameValid)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_middle_name_valid_state_to_true_with_null_value()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", String.Empty, "Bear")

        ' Act.
        userInput.SetValidStates()

        ' Assert.
        Assert.IsTrue(userInput.IsMiddleNameValid)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_last_name_valid_state_to_true()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")

        ' Act.
        userInput.SetValidStates()

        ' Assert.
        Assert.IsTrue(userInput.IsLastNameValid)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_last_name_valid_state_to_false()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", String.Empty)

        ' Act.
        userInput.SetValidStates()

        ' Assert.
        Assert.IsFalse(userInput.IsLastNameValid)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_array_of_valid_states_for_user_name_to_true()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")
        userInput.SetValidStates()

        ' Act.
        userInput.SetArrayOfValidStates()

        ' Assert.
        Assert.IsTrue(userInput.ArrayOfValidity(0))
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_array_of_valid_states_for_user_name_already_used_to_false()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")
        userInput.SetValidStates()

        ' Act.
        userInput.SetArrayOfValidStates()

        ' Assert.
        Assert.IsFalse(userInput.ArrayOfValidity(1))
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_array_of_valid_states_for_password_to_true()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")
        userInput.SetValidStates()

        ' Act.
        userInput.SetArrayOfValidStates()

        ' Assert.
        Assert.IsTrue(userInput.ArrayOfValidity(2))
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_array_of_valid_states_for_first_name_to_true()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")
        userInput.SetValidStates()

        ' Act.
        userInput.SetArrayOfValidStates()

        ' Assert.
        Assert.IsTrue(userInput.ArrayOfValidity(3))
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_array_of_valid_states_for_middle_name_to_true()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")
        userInput.SetValidStates()

        ' Act.
        userInput.SetArrayOfValidStates()

        ' Assert.
        Assert.IsTrue(userInput.ArrayOfValidity(4))
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_array_of_valid_states_for_last_name_to_true()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")
        userInput.SetValidStates()

        ' Act.
        userInput.SetArrayOfValidStates()

        ' Assert.
        Assert.IsTrue(userInput.ArrayOfValidity(5))
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_invalid_message_for_user_name()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")
        userInput.SetValidStates()
        userInput.IsUserAvailable = True

        ' Act.
        userInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(CommonConstants.UserIsAvailable, userInput.UserNameInvalidMessage)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_invalid_message_for_user_name_when_null()
        ' Arrange.
        Dim userInput = New NewUserInput(String.Empty, "secret", "Pooh", "S", "Bear")
        userInput.SetValidStates()

        ' Act.
        userInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(CommonConstants.NotAValidInput, userInput.UserNameInvalidMessage)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_invalid_message_for_user_name_when_already_used()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")
        userInput.SetValidStates()
        userInput.IsUserAvailable = False

        ' Act.
        userInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(CommonConstants.UserAlreadyExists, userInput.UserNameInvalidMessage)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_invalid_message_for_password()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")
        userInput.SetValidStates()

        ' Act.
        userInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(String.Empty, userInput.PasswordInvalidMessage)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_invalid_message_for_password_when_null()
        ' Arrange.
        Dim userInput = New NewUserInput("me", String.Empty, "Pooh", "S", "Bear")
        userInput.SetValidStates()

        ' Act.
        userInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(CommonConstants.NotAValidInput, userInput.PasswordInvalidMessage)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_invalid_message_for_first_name()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")
        userInput.SetValidStates()

        ' Act.
        userInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(String.Empty, userInput.FirstNameInvalidMessage)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_invalid_message_for_first_name_when_null()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", String.Empty, "S", "Bear")
        userInput.SetValidStates()

        ' Act.
        userInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(CommonConstants.NotAValidInput, userInput.FirstNameInvalidMessage)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_invalid_message_for_middle_name()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")
        userInput.SetValidStates()

        ' Act.
        userInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(String.Empty, userInput.MiddleNameInvalidmessage)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_invalid_message_for_first_middle_when_null()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", String.Empty, "Bear")
        userInput.SetValidStates()

        ' Act.
        userInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(String.Empty, userInput.MiddleNameInvalidmessage)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_invalid_message_for_last_name()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", "Bear")
        userInput.SetValidStates()

        ' Act.
        userInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(String.Empty, userInput.LastNameInvalidMessage)
    End Sub

    <TestMethod()> Public Sub test_new_user_sets_invalid_message_for_last_name_when_null()
        ' Arrange.
        Dim userInput = New NewUserInput("me", "secret", "Pooh", "S", String.Empty)
        userInput.SetValidStates()

        ' Act.
        userInput.SetInvalidMessages()

        ' Assert.
        Assert.AreEqual(CommonConstants.NotAValidInput, userInput.LastNameInvalidMessage)
    End Sub

    <TestMethod()> Public Sub test_is_there_false_returns_true()
        ' Arrange.
        Const result As Boolean = True
        Dim dbConnector = New Mock(Of IDbConnector)
        dbConnector.Setup(Function(c) c.IsUserNameAvailable(It.IsAny(Of String))).Returns(result)
        Dim testUser = New NewUserInput("pooh", "secret", "Pooh", "M", "Bear")
        testUser.SetValidStates()
        testUser.SetUserNameIsUsed(dbConnector.Object)

        ' Act.
        testUser.SetArrayOfValidStates()

        ' Assert.
        Assert.IsTrue(testUser.IsThereAFalseInTheInput())
    End Sub

    <TestMethod()> Public Sub test_is_user_available()
        ' Arrange.
        Const result As Boolean = True
        Dim dbConnector = New Mock(Of IDbConnector)
        dbConnector.Setup(Function(c) c.IsUserNameAvailable(It.IsAny(Of String))).Returns(result)
        Dim testUser = New NewUserInput("pooh", "secret", "Pooh", "M", "Bear")

        ' Act.
        testUser.SetUserNameIsUsed(dbConnector.Object)

        ' Assert.
        Assert.IsTrue(testUser.IsUserAvailable)
    End Sub

    <TestMethod()> Public Sub test_is_user_available_returns_false()
        ' Arrange.
        Const result As Boolean = False
        Dim dbConnector = New Mock(Of IDbConnector)
        dbConnector.Setup(Function(c) c.IsUserNameAvailable(It.IsAny(Of String))).Returns(result)
        Dim testUser = New NewUserInput("pooh", "secret", "Pooh", "M", "Bear")

        ' Act.
        testUser.SetUserNameIsUsed(dbConnector.Object)

        ' Assert.
        Assert.IsFalse(testUser.IsUserAvailable)
    End Sub

End Class