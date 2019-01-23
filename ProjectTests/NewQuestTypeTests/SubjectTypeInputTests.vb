Imports ExampleProg.Constants
Imports ExampleProg.InputClasses.NewQuestionTypes
Imports ExampleProg.ProcedureReturnTypes
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace NewQuestTypeTests

    <TestClass()> Public Class SubjectTypeInputTests

        <TestMethod()> Public Sub process_sets_can_proceed_to_true()
            ' Arrange.
            Dim subjectTypeInput = New SubjectTypeInput()

            Dim subject1 = New SubjectListType()
            subject1.ID = 1
            subject1.SubjectDetail = "English"
            Dim subject2 = New SubjectListType()
            subject2.ID = 2
            subject2.SubjectDetail = "Maths"

            ' Faking out the list.
            Dim list = New List(Of SubjectListType)
            list.Add(subject1)
            list.Add(subject2)
            subjectTypeInput.SubjectList = list

            ' Act.
            subjectTypeInput.Process("English")

            ' Assert.
            Assert.IsTrue(subjectTypeInput.CanProceed)
        End Sub

        <TestMethod()> Public Sub process_sets_can_proceed_to_false()
            ' Arrange.
            Dim subjectTypeInput = New SubjectTypeInput()

            ' Faking out the list.
            Dim list = New List(Of SubjectListType)
            subjectTypeInput.SubjectList = list

            ' Act.
            subjectTypeInput.Process(String.Empty)

            ' Assert.
            Assert.IsFalse(subjectTypeInput.CanProceed)
        End Sub

        <TestMethod()> Public Sub process_sets_invalid_message_flag_to_empty_string()
            ' Arrange.
            Dim subjectTypeInput = New SubjectTypeInput()

            ' Faking out the list.
            Dim list = New List(Of SubjectListType)
            subjectTypeInput.SubjectList = list

            ' Act.
            subjectTypeInput.Process("hello")

            ' Assert.
            Assert.AreEqual(String.Empty, subjectTypeInput.InvalidMessage)
        End Sub

        <TestMethod()> Public Sub process_sets_invalid_message_flag_to_not_a_valid_input()
            ' Arrange.
            Dim subjectTypeInput = New SubjectTypeInput()

            ' Faking out the list.
            Dim list = New List(Of SubjectListType)
            subjectTypeInput.SubjectList = list

            ' Act.
            subjectTypeInput.Process(String.Empty)

            ' Assert.
            Assert.AreEqual(CommonConstants.NotAValidInput, subjectTypeInput.InvalidMessage)
        End Sub

        <TestMethod()> Public Sub process_sets_subject_id_correctly()
            ' Arrange.
            Dim subjectTypeInput = New SubjectTypeInput()

            Dim subject1 = New SubjectListType()
            subject1.ID = 1
            subject1.SubjectDetail = "English"
            Dim subject2 = New SubjectListType()
            subject2.ID = 2
            subject2.SubjectDetail = "Maths"

            ' Faking out the list.
            Dim list = New List(Of SubjectListType)
            list.Add(subject1)
            list.Add(subject2)
            subjectTypeInput.SubjectList = list

            ' Act.
            subjectTypeInput.Process("English")

            ' Assert.
            Assert.AreEqual(1, subjectTypeInput.SubjectID)
        End Sub

        <TestMethod()> Public Sub process_sets_subject_id_to_zero_if_subject_not_in_list()
            ' Arrange.
            Dim subjectTypeInput = New SubjectTypeInput()

            Dim subject1 = New SubjectListType()
            subject1.ID = 1
            subject1.SubjectDetail = "English"
            Dim subject2 = New SubjectListType()
            subject2.ID = 2
            subject2.SubjectDetail = "Maths"

            ' Faking out the list.
            Dim list = New List(Of SubjectListType)
            list.Add(subject1)
            list.Add(subject2)
            subjectTypeInput.SubjectList = list

            ' Act.
            subjectTypeInput.Process("bananas")

            ' Assert.
            Assert.AreEqual(0, subjectTypeInput.SubjectID)
        End Sub

        <TestMethod()> Public Sub process_sets_is_new_subject_if_subject_not_in_list()
            ' Arrange.
            Dim subjectTypeInput = New SubjectTypeInput()

            Dim subject1 = New SubjectListType()
            subject1.ID = 1
            subject1.SubjectDetail = "English"
            Dim subject2 = New SubjectListType()
            subject2.ID = 2
            subject2.SubjectDetail = "Maths"

            ' Faking out the list.
            Dim list = New List(Of SubjectListType)
            list.Add(subject1)
            list.Add(subject2)
            subjectTypeInput.SubjectList = list

            ' Act.
            subjectTypeInput.Process("bananas")

            ' Assert.
            Assert.IsTrue(subjectTypeInput.IsNewSubject)
        End Sub

        <TestMethod()> Public Sub process_sets_subject_id_correctly_if_input_is_lower_case()
            ' Arrange.
            Dim subjectTypeInput = New SubjectTypeInput()

            Dim subject1 = New SubjectListType()
            subject1.ID = 1
            subject1.SubjectDetail = "English"
            Dim subject2 = New SubjectListType()
            subject2.ID = 2
            subject2.SubjectDetail = "Maths"

            ' Faking out the list.
            Dim list = New List(Of SubjectListType)
            list.Add(subject1)
            list.Add(subject2)
            subjectTypeInput.SubjectList = list

            ' Act.
            subjectTypeInput.Process("maths")

            ' Assert.
            Assert.AreEqual(2, subjectTypeInput.SubjectID)
        End Sub

        <TestMethod()> Public Sub process_sets_subject_id_correctly_if_input_is_upper_case()
            ' Arrange.
            Dim subjectTypeInput = New SubjectTypeInput()

            Dim subject1 = New SubjectListType()
            subject1.ID = 1
            subject1.SubjectDetail = "English"
            Dim subject2 = New SubjectListType()
            subject2.ID = 2
            subject2.SubjectDetail = "Maths"

            ' Faking out the list.
            Dim list = New List(Of SubjectListType)
            list.Add(subject1)
            list.Add(subject2)
            subjectTypeInput.SubjectList = list

            ' Act.
            subjectTypeInput.Process("MATHS")

            ' Assert.
            Assert.AreEqual(2, subjectTypeInput.SubjectID)
        End Sub

        <TestMethod()> Public Sub process_sets_subject_id_correctly_if_input_is_mixed_case()
            ' Arrange.
            Dim subjectTypeInput = New SubjectTypeInput()

            Dim subject1 = New SubjectListType()
            subject1.ID = 1
            subject1.SubjectDetail = "English"
            Dim subject2 = New SubjectListType()
            subject2.ID = 2
            subject2.SubjectDetail = "Maths"

            ' Faking out the list.
            Dim list = New List(Of SubjectListType)
            list.Add(subject1)
            list.Add(subject2)
            subjectTypeInput.SubjectList = list

            ' Act.
            subjectTypeInput.Process("MaThS")

            ' Assert.
            Assert.AreEqual(2, subjectTypeInput.SubjectID)
        End Sub
    End Class
End Namespace