Imports ExampleProg.Constants
Imports ExampleProg.InputClasses.NewQuestionTypes
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Text.RegularExpressions

Namespace NewQuestTypeTests

    <TestClass()> Public Class DemonstrationTypeInputTests

        <TestMethod()> Public Sub test_demo_details_sets_valid_flag_to_true()
            ' Arrange.
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails("Do this to that.")

            ' Act.

            ' Assert.
            Assert.IsTrue(demoStep.IsValidDemoDetails)
        End Sub

        <TestMethod()> Public Sub test_demo_details_sets_valid_flag_to_false()
            ' Arrange.
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(String.Empty)

            ' Act.

            ' Assert.
            Assert.IsFalse(demoStep.IsValidDemoDetails)
        End Sub

        <TestMethod()> Public Sub test_demo_details_sets_invalid_message_to_empty_string()
            ' Arrange.
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails("Do this to that.")

            ' Act.

            ' Assert.
            Assert.AreEqual(String.Empty, demoStep.InvalidDemoDetailsMessage)
        End Sub

        <TestMethod()> Public Sub test_demo_details_sets_invalid_message_to_not_a_valid_entry()
            ' Arrange.
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(String.Empty)

            ' Act.

            ' Assert.
            Assert.AreEqual(CommonConstants.NotAValidInput, demoStep.InvalidDemoDetailsMessage)
        End Sub

        <TestMethod()> Public Sub test_insert_demo_details_sets_regex_with_simple_text()
            ' Arrange.
            Const expectedRegEx As String = "^(?=.*Do\ this\ to\ that\.)(?!^\s|.*\s$).+$"
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails("Do this to that.")

            ' Act.
            demoStep.SetRegEx()

            ' Assert.
            Assert.AreEqual(expectedRegEx, demoStep.RegExDetails)
        End Sub

        <TestMethod()> Public Sub test_insert_demo_details_sets_regex_with_maths_calculation()
            ' Arrange.
            Const input As String = "2(2x - 1) + x = 8"
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(input)

            ' Act.
            demoStep.SetRegEx()
            Dim result = Regex.IsMatch(input, demoStep.RegExDetails)

            ' Assert.
            Assert.IsTrue(result)
        End Sub

        <TestMethod()> Public Sub test_update_regex_sets_flag_to_true()
            ' Arrange.
            Const input As String = "Do this to that."
            Const regEx As String = "^(?=.*Do\ this\ to\ that\.)(?!^\s|.*\s$).+$"
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(input)

            ' Act.
            demoStep.SetRegEx()
            demoStep.UpdateRegEx(regEx)

            ' Assert.
            Assert.IsTrue(demoStep.IsValidRegExDetails)
        End Sub

        <TestMethod()> Public Sub test_update_regex_sets_flag_to_false()
            ' Arrange.
            Const input As String = "Do this to that."
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(input)

            ' Act.
            demoStep.SetRegEx()
            demoStep.UpdateRegEx(String.Empty)

            ' Assert.
            Assert.IsFalse(demoStep.IsValidRegExDetails)
        End Sub

        <TestMethod()> Public Sub test_update_regex_sets_invalid_message_to_empty_string()
            ' Arrange.
            Const input As String = "Do this to that."
            Const regEx As String = "^(?=.*Do\ this\ to\ that\.)(?!^\s|.*\s$).+$"
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(input)

            ' Act.
            demoStep.SetRegEx()
            demoStep.UpdateRegEx(regEx)

            ' Assert.
            Assert.AreEqual(String.Empty, demoStep.InvalidRegExDetailsMessage)
        End Sub

        <TestMethod()> Public Sub test_update_regex_sets_invalid_message_to_not_a_valid_input()
            ' Arrange.
            Const input As String = "Do this to that."
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(input)

            ' Act.
            demoStep.SetRegEx()
            demoStep.UpdateRegEx(String.Empty)

            ' Assert.
            Assert.AreEqual(CommonConstants.NotAValidInput, demoStep.InvalidRegExDetailsMessage)
        End Sub
        
        <TestMethod()> Public Sub test_insert_mark_sets_flag_to_true()
            ' Arrange.
            Const input As String = "Do this to that."
            Const regEx As String = "^(?=.*Do\ this\ to\ that\.)(?!^\s|.*\s$).+$"
            Const mark As String = "5"
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(input)

            ' Act.
            demoStep.SetRegEx()
            demoStep.UpdateRegEx(regEx)
            demoStep.InsertMark(mark)

            ' Assert.
            Assert.IsTrue(demoStep.IsValidMark)
        End Sub

        <TestMethod()> Public Sub test_insert_mark_sets_flag_to_false()
            ' Arrange.
            Const input As String = "Do this to that."
            Const regEx As String = "^(?=.*Do\ this\ to\ that\.)(?!^\s|.*\s$).+$"
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(input)

            ' Act.
            demoStep.SetRegEx()
            demoStep.UpdateRegEx(regEx)
            demoStep.InsertMark(String.Empty)

            ' Assert.
            Assert.IsFalse(demoStep.IsValidMark)
        End Sub

        <TestMethod()> Public Sub test_insert_mark_sets_flag_to_false_with_word_input()
            ' Arrange.
            Const input As String = "Do this to that."
            Const regEx As String = "^(?=.*Do\ this\ to\ that\.)(?!^\s|.*\s$).+$"
            Const mark As String = "hello"
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(input)

            ' Act.
            demoStep.SetRegEx()
            demoStep.UpdateRegEx(regEx)
            demoStep.InsertMark(mark)

            ' Assert.
            Assert.IsFalse(demoStep.IsValidMark)
        End Sub

        <TestMethod()> Public Sub test_insert_mark_sets_flag_to_false_with_punctuation_input()
            ' Arrange.
            Const input As String = "Do this to that."
            Const regEx As String = "^(?=.*Do\ this\ to\ that\.)(?!^\s|.*\s$).+$"
            Const mark As String = "!£$%^&*()"
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(input)

            ' Act.
            demoStep.SetRegEx()
            demoStep.UpdateRegEx(regEx)
            demoStep.InsertMark(mark)

            ' Assert.
            Assert.IsFalse(demoStep.IsValidMark)
        End Sub

        <TestMethod()> Public Sub test_insert_mark_sets_invalid_message_to_empty_string()
            ' Arrange.
            Const input As String = "Do this to that."
            Const regEx As String = "^(?=.*Do\ this\ to\ that\.)(?!^\s|.*\s$).+$"
            Const mark As String = "5"
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(input)

            ' Act.
            demoStep.SetRegEx()
            demoStep.UpdateRegEx(regEx)
            demoStep.InsertMark(mark)

            ' Assert.
            Assert.AreEqual(String.Empty, demoStep.InvalidMarkMessage)
        End Sub

        <TestMethod()> Public Sub test_insert_mark_sets_invalid_message_to_invalid_input()
            ' Arrange.
            Const input As String = "Do this to that."
            Const regEx As String = "^(?=.*Do\ this\ to\ that\.)(?!^\s|.*\s$).+$"
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(input)

            ' Act.
            demoStep.SetRegEx()
            demoStep.UpdateRegEx(regEx)
            demoStep.InsertMark(String.Empty)

            ' Assert.
            Assert.AreEqual(CommonConstants.NotAValidInteger, demoStep.InvalidMarkMessage)
        End Sub

        <TestMethod()> Public Sub test_insert_demo_details_updates_total_amount_of_steps()
            ' Arrange.
            Const input As String = "Do this to that."
            Const mark As String = "5"
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(input)
            demoStep.SetRegEx()
            demoStep.InsertMark(mark)

            ' Act.
            demoStep.AddDetailsToList()

            ' Assert.
            Assert.AreEqual(1, demoStep.AmountOfSteps)
        End Sub

        <TestMethod()> Public Sub test_insert_demo_details_updates_can_insert_details_to_true()
            ' Arrange.
            Const input As String = "Do this to that."
            Const mark As String = "5"
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(input)
            demoStep.SetRegEx()
            demoStep.InsertMark(mark)

            ' Act.
            demoStep.AddDetailsToList()

            ' Assert.
            Assert.IsTrue(demoStep.CanInsertDetailsToList)
        End Sub

        <TestMethod()> Public Sub test_insert_demo_details_updates_can_insert_details_to_false()
            ' Arrange.
            Const input As String = "Do this to that."
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(input)
            demoStep.SetRegEx()
            demoStep.UpdateRegEx(String.Empty)

            ' Act.
            demoStep.AddDetailsToList()

            ' Assert.
            Assert.IsFalse(demoStep.CanInsertDetailsToList)
        End Sub

        <TestMethod()> Public Sub test_insert_demo_details_does_not_update_total_amount_of_steps_without_regex()
            ' Arrange.
            Const input As String = "Do this to that."
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(input)
            demoStep.SetRegEx()
            demoStep.UpdateRegEx(String.Empty)

            ' Act.
            demoStep.AddDetailsToList()

            ' Assert.
            Assert.AreEqual(0, demoStep.AmountOfSteps)
        End Sub

        <TestMethod()> Public Sub test_insert_demo_details_does_not_update_total_amount_of_steps_without_demo_details()
            ' Arrange.
            Dim demoStep = New DemonstrationTypeInput
            demoStep.ResetValuesToDefaults()
            demoStep.InsertNextStepDetails(String.Empty)
            ' Act.
            demoStep.AddDetailsToList()

            ' Assert.
            Assert.AreEqual(0, demoStep.AmountOfSteps)
        End Sub

        <TestMethod()> Public Sub test_reset_values_to_default_sets_demo_details_to_empty_string()
            ' Arrange.
            Const input As String = "Do this to that."
            Dim demo = New DemonstrationTypeInput
            demo.ResetValuesToDefaults()
            demo.InsertNextStepDetails(input)
            demo.SetRegEx()
            demo.AddDetailsToList()

            ' Act.
            demo.ResetValuesToDefaults()

            ' Assert.
            Assert.AreEqual(String.Empty, demo.GetDemoDetails())
        End Sub

        <TestMethod()> Public Sub test_reset_values_to_default_sets_regex_details_to_empty_string()
            ' Arrange.
            Const input As String = "Do this to that."
            Dim demo = New DemonstrationTypeInput
            demo.ResetValuesToDefaults()
            demo.InsertNextStepDetails(input)
            demo.SetRegEx()
            demo.AddDetailsToList()

            ' Act.
            demo.ResetValuesToDefaults()

            ' Assert.
            Assert.AreEqual(String.Empty, demo.RegExDetails)
        End Sub

        <TestMethod()> Public Sub test_reset_values_to_default_sets_demo_list_to_empty_list()
            ' Arrange.
            Const input As String = "Do this to that."
            Dim demo = New DemonstrationTypeInput
            demo.ResetValuesToDefaults()
            demo.InsertNextStepDetails(input)
            demo.SetRegEx()
            demo.AddDetailsToList()

            ' Act.
            demo.ResetValuesToDefaults()

            ' Assert.
            Assert.AreEqual(0, demo.DemonstrationList.Count)
        End Sub

        <TestMethod()> Public Sub test_remove_step_from_list_returns_true()
            ' Arrange.
            Const input As String = "Do this to that."
            Const mark As String = "5"
            Dim demo = New DemonstrationTypeInput
            demo.ResetValuesToDefaults()
            demo.InsertNextStepDetails(input)
            demo.SetRegEx()
            demo.InsertMark(mark)
            demo.AddDetailsToList()

            ' Act.
            Dim result = demo.RemoveStepFromList(input)

            ' Assert.
            Assert.IsTrue(result)
        End Sub

        <TestMethod()> Public Sub test_remove_step_from_list_returns_false()
            ' Arrange.
            Const input As String = "Do this to that."
            Dim demo = New DemonstrationTypeInput
            demo.ResetValuesToDefaults()
            demo.InsertNextStepDetails(input)
            demo.SetRegEx()
            demo.AddDetailsToList()

            ' Act.
            Dim result = demo.RemoveStepFromList("Not in this list.")

            ' Assert.
            Assert.IsFalse(result)
        End Sub

        <TestMethod()> Public Sub test_remove_step_from_list_returns_true_with_many_items_in_list()
            ' Arrange.
            Const input As String = "Do this to that."
            Const mark1 As String = "5"
            Const input2 As String = "Don't do that."
            Const mark2 As String = "3"
            Const input3 As String = "Oh, do this then!"
            Const mark3 As String = "7"
            Dim demo = New DemonstrationTypeInput
            demo.ResetValuesToDefaults()
            demo.InsertNextStepDetails(input)
            demo.SetRegEx()
            demo.InsertMark(mark1)
            demo.AddDetailsToList()
            demo.InsertNextStepDetails(input2)
            demo.SetRegEx()
            demo.InsertMark(mark2)
            demo.AddDetailsToList()
            demo.InsertNextStepDetails(input3)
            demo.SetRegEx()
            demo.InsertMark(mark3)
            demo.AddDetailsToList()

            ' Act.
            Dim result = demo.RemoveStepFromList(input2)

            ' Assert.
            Assert.IsTrue(result)
        End Sub

    End Class
End Namespace