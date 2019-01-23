Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ExampleProg.InputClasses.NewQuestionTypes
Imports ExampleProg.Constants

<TestClass()> Public Class AnswerTypeInputTests

    <TestMethod()> Public Sub test_process_correct_answer_sets_valid_flag_to_true()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", "nope", "um", "no way")

        ' Assert.
        Assert.IsTrue(answerType.IsValidCorrectAnswer)
    End Sub

    <TestMethod()> Public Sub test_process_incorrect_answer_a_sets_valid_flag_to_true()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", "nope", "um", "no way")

        ' Assert.
        Assert.IsTrue(answerType.IsValidInCorrectAnswerA)
    End Sub

    <TestMethod()> Public Sub test_process_incorrect_answer_b_sets_valid_flag_to_true()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", "nope", "um", "no way")

        ' Assert.
        Assert.IsTrue(answerType.IsValidInCorrectAnswerB)
    End Sub

    <TestMethod()> Public Sub test_process_incorrect_answer_c_sets_valid_flag_to_true()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", "nope", "um", "no way")

        ' Assert.
        Assert.IsTrue(answerType.IsValidInCorrectAnswerC)
    End Sub

    <TestMethod()> Public Sub test_process_correct_answer_sets_valid_flag_to_false()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process(String.Empty, "nope", "um", "no way")

        ' Assert.
        Assert.IsFalse(answerType.IsValidCorrectAnswer)
    End Sub

    <TestMethod()> Public Sub test_process_incorrect_answer_a_sets_valid_flag_to_false()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", String.Empty, "um", "no way")

        ' Assert.
        Assert.IsFalse(answerType.IsValidInCorrectAnswerA)
    End Sub

    <TestMethod()> Public Sub test_process_incorrect_answer_b_sets_valid_flag_to_false()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", "nope", String.Empty, "no way")

        ' Assert.
        Assert.IsFalse(answerType.IsValidInCorrectAnswerB)
    End Sub

    <TestMethod()> Public Sub test_process_incorrect_answer_c_sets_valid_flag_to_false()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", "nope", "um", String.Empty)

        ' Assert.
        Assert.IsFalse(answerType.IsValidInCorrectAnswerC)
    End Sub

    <TestMethod()> Public Sub test_process_correct_answer_sets_invalid_message_to_empty_string()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", "nope", "um", "no way")

        ' Assert.
        Assert.AreEqual(String.Empty, answerType.InvalidCorrectAnswerMessage)
    End Sub

    <TestMethod()> Public Sub test_process_incorrect_answer_a_sets_invalid_message_to_empty_string()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", "nope", "um", "no way")

        ' Assert.
        Assert.AreEqual(String.Empty, answerType.InvalidInCorrectAnswerAMessage)
    End Sub

    <TestMethod()> Public Sub test_process_incorrect_answer_b_sets_invalid_message_to_empty_string()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", "nope", "um", "no way")

        ' Assert.
        Assert.AreEqual(String.Empty, answerType.InvalidInCorrectAnswerBMessage)
    End Sub

    <TestMethod()> Public Sub test_process_incorrect_answer_c_sets_invalid_message_to_empty_string()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", "nope", "um", "no way")

        ' Assert.
        Assert.AreEqual(String.Empty, answerType.InvalidInCorrectAnswerCMessage)
    End Sub

    <TestMethod()> Public Sub test_process_correct_answer_sets_invalid_message_to_not_a_valid_input()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process(String.Empty, "nope", "um", "no way")

        ' Assert.
        Assert.AreEqual(CommonConstants.NotAValidInput, answerType.InvalidCorrectAnswerMessage)
    End Sub

    <TestMethod()> Public Sub test_process_incorrect_answer_a_sets_invalid_message_to_not_a_valid_input()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", String.Empty, "um", "no way")

        ' Assert.
        Assert.AreEqual(CommonConstants.NotAValidInput, answerType.InvalidInCorrectAnswerAMessage)
    End Sub

    <TestMethod()> Public Sub test_process_incorrect_answer_b_sets_invalid_message_to_not_a_valid_input()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", "nope", String.Empty, "no way")

        ' Assert.
        Assert.AreEqual(CommonConstants.NotAValidInput, answerType.InvalidInCorrectAnswerBMessage)
    End Sub

    <TestMethod()> Public Sub test_process_incorrect_answer_c_sets_invalid_message_to_not_a_valid_input()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", "nope", "um", String.Empty)

        ' Assert.
        Assert.AreEqual(CommonConstants.NotAValidInput, answerType.InvalidInCorrectAnswerCMessage)
    End Sub

    <TestMethod()> Public Sub test_process_sets_can_proceed_to_true()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", "nope", "um", "no way")

        ' Assert.
        Assert.IsTrue(answerType.CanProceed)
    End Sub

    <TestMethod()> Public Sub test_process_sets_can_proceed_to_false_with_no_correct_answer()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process(String.Empty, "nope", "um", "no way")

        ' Assert.
        Assert.IsFalse(answerType.CanProceed)
    End Sub

    <TestMethod()> Public Sub test_process_sets_can_proceed_to_false_with_no_incorrect_answer_a()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", String.Empty, "um", "no way")

        ' Assert.
        Assert.IsFalse(answerType.CanProceed)
    End Sub

    <TestMethod()> Public Sub test_process_sets_can_proceed_to_false_with_no_incorrect_answer_b()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", "nope", String.Empty, "no way")

        ' Assert.
        Assert.IsFalse(answerType.CanProceed)
    End Sub

    <TestMethod()> Public Sub test_process_sets_can_proceed_to_false_with_no_incorrect_answer_c()
        ' Arrange.
        Dim answerType = New AnswerTypeInput()

        ' Act.
        answerType.Process("yep", "nope", "um", String.Empty)

        ' Assert.
        Assert.IsFalse(answerType.CanProceed)
    End Sub

End Class