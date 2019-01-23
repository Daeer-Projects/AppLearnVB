Imports ExampleProg.Constants
Imports ExampleProg.InputClasses.NewQuestionTypes
Imports ExampleProg.ProcedureReturnTypes
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace NewQuestTypeTests

    <TestClass()> Public Class CurriculumTypeInputTests

        <TestMethod()> Public Sub process_sets_can_proceed_to_true()
            ' Arrange.
            Dim curriculumTypeInput = New CurriculumTypeInput()

            Dim curriculum1 = New CurriculumListType()
            curriculum1.ID = 1
            curriculum1.CurriculumDetails = "Basic"
            Dim curriculum2 = New CurriculumListType()
            curriculum2.ID = 2
            curriculum2.CurriculumDetails = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of CurriculumListType)
            list.Add(curriculum1)
            list.Add(curriculum2)
            curriculumTypeInput.CurriculumList = list

            ' Act.
            curriculumTypeInput.Process("Basic")

            ' Assert.
            Assert.IsTrue(curriculumTypeInput.CanProceed)
        End Sub

        <TestMethod()> Public Sub process_sets_can_proceed_to_false()
            ' Arrange.
            Dim curriculumTypeInput = New CurriculumTypeInput()

            ' Faking out the list.
            curriculumTypeInput.CurriculumList = New List(Of CurriculumListType)

            ' Act.
            curriculumTypeInput.Process(String.Empty)

            ' Assert.
            Assert.IsFalse(curriculumTypeInput.CanProceed)
        End Sub

        <TestMethod()> Public Sub process_sets_invalid_message_flag_to_empty_string()
            ' Arrange.
            Dim curriculumTypeInput = New CurriculumTypeInput()

            ' Faking out the list.
            curriculumTypeInput.CurriculumList = New List(Of CurriculumListType)

            ' Act.
            curriculumTypeInput.Process("hello")

            ' Assert.
            Assert.AreEqual(String.Empty, curriculumTypeInput.InvalidMessage)
        End Sub

        <TestMethod()> Public Sub process_sets_invalid_message_flag_to_not_a_valid_input()
            ' Arrange.
            Dim curriculumTypeInput = New CurriculumTypeInput()

            ' Faking out the list.
            curriculumTypeInput.CurriculumList = New List(Of CurriculumListType)

            ' Act.
            curriculumTypeInput.Process(String.Empty)

            ' Assert.
            Assert.AreEqual(CommonConstants.NotAValidInput, curriculumTypeInput.InvalidMessage)
        End Sub

        <TestMethod()> Public Sub process_sets_curriculum_id_correctly()
            ' Arrange.
            Dim curriculumTypeInput = New CurriculumTypeInput()

            Dim curriculum1 = New CurriculumListType()
            curriculum1.ID = 1
            curriculum1.CurriculumDetails = "Basic"
            Dim curriculum2 = New CurriculumListType()
            curriculum2.ID = 2
            curriculum2.CurriculumDetails = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of CurriculumListType)
            list.Add(curriculum1)
            list.Add(curriculum2)
            curriculumTypeInput.CurriculumList = list

            ' Act.
            curriculumTypeInput.Process("Basic")

            ' Assert.
            Assert.AreEqual(1, curriculumTypeInput.CurriculumID)
        End Sub

        <TestMethod()> Public Sub process_sets_curriculum_id_to_zero_if_curriculum_not_in_list()
            ' Arrange.
            Dim curriculumTypeInput = New CurriculumTypeInput()

            Dim curriculum1 = New CurriculumListType()
            curriculum1.ID = 1
            curriculum1.CurriculumDetails = "Basic"
            Dim curriculum2 = New CurriculumListType()
            curriculum2.ID = 2
            curriculum2.CurriculumDetails = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of CurriculumListType)
            list.Add(curriculum1)
            list.Add(curriculum2)
            curriculumTypeInput.CurriculumList = list

            ' Act.
            curriculumTypeInput.Process("Manic")

            ' Assert.
            Assert.AreEqual(0, curriculumTypeInput.CurriculumID)
        End Sub

        <TestMethod()> Public Sub process_sets_is_new_curriculum_if_curriculum_not_in_list()
            'Arrange.
            Dim curriculumTypeInput = New CurriculumTypeInput()

            Dim curriculum1 = New CurriculumListType()
            curriculum1.ID = 1
            curriculum1.CurriculumDetails = "Basic"
            Dim curriculum2 = New CurriculumListType()
            curriculum2.ID = 2
            curriculum2.CurriculumDetails = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of CurriculumListType)
            list.Add(curriculum1)
            list.Add(curriculum2)
            curriculumTypeInput.CurriculumList = list

            ' Act.
            curriculumTypeInput.Process("Manic")

            ' Assert.
            Assert.IsTrue(curriculumTypeInput.IsNewCurriculum)
        End Sub

        <TestMethod()> Public Sub process_sets_curriculum_id_correctly_if_input_is_lower_case()
            ' Arrange.
            Dim curriculumTypeInput = New CurriculumTypeInput()

            Dim curriculum1 = New CurriculumListType()
            curriculum1.ID = 1
            curriculum1.CurriculumDetails = "Basic"
            Dim curriculum2 = New CurriculumListType()
            curriculum2.ID = 2
            curriculum2.CurriculumDetails = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of CurriculumListType)
            list.Add(curriculum1)
            list.Add(curriculum2)
            curriculumTypeInput.CurriculumList = list

            ' Act.
            curriculumTypeInput.Process("advanced")

            ' Assert.
            Assert.AreEqual(2, curriculumTypeInput.CurriculumID)
        End Sub

        <TestMethod()> Public Sub process_sets_curriculum_id_correctly_if_input_is_upper_case()
            ' Arrange.
            Dim curriculumTypeInput = New CurriculumTypeInput()

            Dim curriculum1 = New CurriculumListType()
            curriculum1.ID = 1
            curriculum1.CurriculumDetails = "Basic"
            Dim curriculum2 = New CurriculumListType()
            curriculum2.ID = 2
            curriculum2.CurriculumDetails = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of CurriculumListType)
            list.Add(curriculum1)
            list.Add(curriculum2)
            curriculumTypeInput.CurriculumList = list

            ' Act.
            curriculumTypeInput.Process("ADVANCED")

            ' Assert.
            Assert.AreEqual(2, curriculumTypeInput.CurriculumID)
        End Sub

        <TestMethod()> Public Sub process_sets_subject_id_correctly_if_input_is_mixed_case()
            ' Arrange.
            Dim curriculumTypeInput = New CurriculumTypeInput()

            Dim curriculum1 = New CurriculumListType()
            curriculum1.ID = 1
            curriculum1.CurriculumDetails = "Basic"
            Dim curriculum2 = New CurriculumListType()
            curriculum2.ID = 2
            curriculum2.CurriculumDetails = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of CurriculumListType)
            list.Add(curriculum1)
            list.Add(curriculum2)
            curriculumTypeInput.CurriculumList = list

            ' Act.
            curriculumTypeInput.Process("AdVaNcEd")

            ' Assert.
            Assert.AreEqual(2, curriculumTypeInput.CurriculumID)
        End Sub
    End Class
End Namespace