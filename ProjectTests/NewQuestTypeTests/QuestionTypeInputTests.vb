Imports ExampleProg.Constants
Imports ExampleProg.InputClasses.NewQuestionTypes
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace NewQuestTypeTests

    <TestClass()> Public Class QuestionTypeInputTests

        <TestMethod()> Public Sub test_process_sets_text_flag_to_true()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "www.something.com", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.IsTrue(questionType.IsValidQuestion)
        End Sub

        <TestMethod()> Public Sub test_process_sets_text_flag_to_false()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process(String.Empty, "Life", "www.something.com", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.IsFalse(questionType.IsValidQuestion)
        End Sub

        ' Tested more thoroughly in Helpers tests.
        <TestMethod()> Public Sub test_process_sets_search_string_correctly()
            ' Arrange.
            Const expected As String = """Life"" + ""Questions"" + ""Um.."""
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "www.something.com", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(expected, questionType.SearchString)
        End Sub

        <TestMethod()> Public Sub test_process_sets_search_flag_to_true()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "www.something.com", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.IsTrue(questionType.IsValidSerchString)
        End Sub

        <TestMethod()> Public Sub test_process_sets_search_flag_to_false_with_no_subject()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "www.something.com", String.Empty, "Questions", "N/A", "Um..")

            ' Assert.
            Assert.IsFalse(questionType.IsValidSerchString)
        End Sub

        <TestMethod()> Public Sub test_process_sets_search_flag_to_false_with_no_curriculum()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "www.something.com", "Life", String.Empty, "N/A", "Um..")

            ' Assert.
            Assert.IsFalse(questionType.IsValidSerchString)
        End Sub

        <TestMethod()> Public Sub test_process_sets_search_flag_to_false_with_no_key_stage()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "www.something.com", "Life", "Questions", String.Empty, "Um..")

            ' Assert.
            Assert.IsFalse(questionType.IsValidSerchString)
        End Sub

        <TestMethod()> Public Sub test_process_sets_search_flag_to_false_with_no_explanation()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "www.something.com", "Life", "Questions", "N/A", String.Empty)

            ' Assert.
            Assert.IsFalse(questionType.IsValidSerchString)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_question_message_to_empty_string()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "www.something.com", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(String.Empty, questionType.InvalidQuestionMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_question_message_to_not_a_valid_input()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process(String.Empty, "www.something.com", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(CommonConstants.NotAValidInput, questionType.InvalidQuestionMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_search_string_to_empty_string()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "www.something.com", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(String.Empty, questionType.InvalidSearchStringMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_search_string_to_not_a_valid_input_if_no_subject()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "www.something.com", String.Empty, "Questions", "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(CommonConstants.NotAValidInput, questionType.InvalidSearchStringMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_search_string_to_not_a_valid_input_if_no_curriculum()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "www.something.com", "Life", String.Empty, "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(CommonConstants.NotAValidInput, questionType.InvalidSearchStringMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_search_string_to_not_a_valid_input_if_no_key_stage()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "www.something.com", "Life", "Questions", String.Empty, "Um..")

            ' Assert.
            Assert.AreEqual(CommonConstants.NotAValidInput, questionType.InvalidSearchStringMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_search_string_to_not_a_valid_input_if_no_explanation()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "www.something.com", "Life", "Questions", "N/A", String.Empty)

            ' Assert.
            Assert.AreEqual(CommonConstants.NotAValidInput, questionType.InvalidSearchStringMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_web_address_with_www_to_empty_string()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "www.something.com", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(String.Empty, questionType.InvalidWebAddressMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_web_address_with_http_to_empty_string()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "http://www.something.com", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(String.Empty, questionType.InvalidWebAddressMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_web_address_with_https_to_empty_string()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "https://www.something.com", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(String.Empty, questionType.InvalidWebAddressMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_web_address_to_not_a_valid_input()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "ww.umbongo.org", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(CommonConstants.WebAddressNotValid, questionType.InvalidWebAddressMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_web_address_with_rubbish_to_not_a_valid_input()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "oh dear what can the matter be", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(CommonConstants.WebAddressNotValid, questionType.InvalidWebAddressMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_web_address_with_almost_valid_address_to_not_a_valid_input()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "htp://ww.urgh.com/help", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(CommonConstants.WebAddressNotValid, questionType.InvalidWebAddressMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_web_address_with_almost_valid_address_2_to_not_a_valid_input()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "ht:/ww.urgh.com/help", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(CommonConstants.WebAddressNotValid, questionType.InvalidWebAddressMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_web_address_with_almost_valid_address_3_to_not_a_valid_input()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "htps:/ww.urgh.com", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(CommonConstants.WebAddressNotValid, questionType.InvalidWebAddressMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_invalid_web_address_with_almost_valid_address_4_to_not_a_valid_input()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "http:/ww.urgh.com", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(CommonConstants.WebAddressNotValid, questionType.InvalidWebAddressMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_valid_web_address_with_null_to_empty_string()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", String.Empty, "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.AreEqual(String.Empty, questionType.InvalidWebAddressMessage)
        End Sub

        <TestMethod()> Public Sub test_process_sets_can_proceed_to_true()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process("What is something?", "https://www.something.com", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.IsTrue(questionType.CanProceed)
        End Sub

        <TestMethod()> Public Sub test_process_sets_can_proceed_to_false()
            ' Arrange.
            Dim questionType = New QuestionTypeInput()

            ' Act.
            questionType.Process(String.Empty, "https://www.something.com", "Life", "Questions", "N/A", "Um..")

            ' Assert.
            Assert.IsFalse(questionType.CanProceed)
        End Sub

    End Class
End Namespace