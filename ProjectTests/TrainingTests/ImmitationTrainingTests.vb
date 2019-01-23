Imports ExampleProg.InputClasses.Training
Imports ExampleProg.Interfaces
Imports ExampleProg.ProcedureReturnTypes
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq

Namespace TrainingTests

    <TestClass()> Public Class ImmitationTrainingTests
        Private _immitation As ImmitationTraining
        Private _mockDb As Mock(Of IDbConnector)

#Region "Set up lists"
        Private Function GetListOfImmitationStages() As IEnumerable(Of ImmitationStageListType)
            Dim list As New List(Of ImmitationStageListType)
            Dim item1 As New ImmitationStageListType
            item1.DescriptionOfStage = "Hello"
            item1.RegEx = "^(Hello)$"
            item1.StageMark = 1
            list.Add(item1)

            Dim item2 As New ImmitationStageListType
            item2.DescriptionOfStage = "how"
            item2.RegEx = "^(how)$"
            item2.StageMark = 1
            list.Add(item2)

            Dim item3 As New ImmitationStageListType
            item3.DescriptionOfStage = "are"
            item3.RegEx = "^(are)$"
            item3.StageMark = 1
            list.Add(item3)

            Dim item4 As New ImmitationStageListType
            item4.DescriptionOfStage = "you?"
            item4.RegEx = "^(you)\?$"
            item4.StageMark = 1
            list.Add(item4)
            Return list
        End Function
#End Region

        <TestMethod()> Public Sub test_get_demonstration_list_returns_valid_list()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)

            ' Assert.
            Assert.IsTrue(_immitation.DemonstrationList.Any())
        End Sub

        <TestMethod()> Public Sub test_get_demonstration_list_count_returns_valid_list_with_four_items()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)

            ' Assert.
            Assert.AreEqual(4, _immitation.DemonstrationList.Count())
        End Sub

        <TestMethod()> Public Sub test_get_demonstration_list_third_item_returns_are_as_description()
            ' Arrange.
            Const expected As String = "are"
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)

            ' Assert.
            Assert.AreEqual(expected, _immitation.DemonstrationList.ElementAt(2).DescriptionOfStage)
        End Sub

        <TestMethod()> Public Sub test_get_demonstration_list_sets_has_demo_been_set_up_returns_true()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)

            ' Assert.
            Assert.IsTrue(_immitation.HasDemoStepsBeenSetUp)
        End Sub

        <TestMethod()> Public Sub test_get_demonstration_list_sets_has_demo_been_set_up_returns_false()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)

            ' Assert.
            Assert.IsFalse(_immitation.HasDemoStepsBeenSetUp)
        End Sub

        <TestMethod()> Public Sub test_get_demonstration_list_sets_has_demo_been_set_up_returns_false_with_no_question_id()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(-1)

            ' Assert.
            Assert.IsFalse(_immitation.HasDemoStepsBeenSetUp)
        End Sub

        <TestMethod()> Public Sub test_set_immitation_sets_count_of_steps_correctly()
            ' Arrange.
            Const expectedCount As Integer = 4
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)

            ' Assert.
            Assert.AreEqual(expectedCount, _immitation.CountOfDemonstrationSteps)
        End Sub

        <TestMethod()> Public Sub test_set_immitation_sets_reg_ex_correctly()
            ' Arrange.
            Const expected As String = "^(Hello)$"
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)

            ' Assert.
            Assert.AreEqual(expected, _immitation.DemonstrationStepRegEx)
        End Sub

        <TestMethod()> Public Sub test_set_immitation_sets_stage_mark_correctly()
            ' Arrange.
            Const expected As Integer = 1
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)

            ' Assert.
            Assert.AreEqual(expected, _immitation.DemonstrationStepMark)
        End Sub

        <TestMethod()> Public Sub test_set_immitation_sets_stage_details_correctly()
            ' Arrange.
            Const expected As String = "Hello"
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)

            ' Assert.
            Assert.AreEqual(expected, _immitation.DemonstrationStepDetails)
        End Sub

        <TestMethod()> Public Sub test_set_immitation_sets_step_correctly()
            ' Arrange.
            Const expected As Integer = 0
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)

            ' Assert.
            Assert.AreEqual(expected, _immitation.DemonstrationStep)
        End Sub

        <TestMethod()> Public Sub test_process_input_sets_is_demo_correct_to_true()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)
            _immitation.ProcessInput("Hello")

            ' Assert.
            Assert.IsTrue(_immitation.IsDemoInputCorrect)
        End Sub

        <TestMethod()> Public Sub test_process_input_sets_is_demo_correct_to_false_with_no_question()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(-1)
            _immitation.ProcessInput("Hello")

            ' Assert.
            Assert.IsFalse(_immitation.IsDemoInputCorrect)
        End Sub

        <TestMethod()> Public Sub test_process_input_sets_is_demo_correct_to_false_with_no_list()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)
            _immitation.ProcessInput("Hello")

            ' Assert.
            Assert.IsFalse(_immitation.IsDemoInputCorrect)
        End Sub

        <TestMethod()> Public Sub test_process_input_sets_is_demo_correct_to_false_with_null_input()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)
            _immitation.ProcessInput(Nothing)

            ' Assert.
            Assert.IsFalse(_immitation.IsDemoInputCorrect)
        End Sub

        <TestMethod()> Public Sub test_process_input_sets_is_demo_correct_to_false_with_empty_string_input()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)
            _immitation.ProcessInput(String.Empty)

            ' Assert.
            Assert.IsFalse(_immitation.IsDemoInputCorrect)
        End Sub

        <TestMethod()> Public Sub test_next_step_updates_details_to_next_detail()
            ' Arrange.
            Const expected As String = "how"
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)
            _immitation.ProcessInput("Hello")

            ' Assert.
            Assert.AreEqual(expected, _immitation.DemonstrationStepDetails)
        End Sub

        <TestMethod()> Public Sub test_next_step_updates_reg_ex_to_next_reg_ex()
            ' Arrange.
            Const expected As String = "^(how)$"
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)
            _immitation.ProcessInput("Hello")

            ' Assert.
            Assert.AreEqual(expected, _immitation.DemonstrationStepRegEx)
        End Sub

        <TestMethod()> Public Sub test_next_step_updates_mark_to_next_mark()
            ' Arrange.
            Const expected As Integer = 1
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)
            _immitation.ProcessInput("Hello")

            ' Assert.
            Assert.AreEqual(expected, _immitation.DemonstrationStepMark)
        End Sub

        <TestMethod()> Public Sub test_next_step_updates_step_to_next_step()
            ' Arrange.
            Const expected As Integer = 1
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)
            _immitation.ProcessInput("Hello")

            ' Assert.
            Assert.AreEqual(expected, _immitation.DemonstrationStep)
        End Sub

        <TestMethod()> Public Sub test_next_step_updates_step_to_next_step_and_next()
            ' Arrange.
            Const expected As Integer = 2
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)
            _immitation.ProcessInput("Hello")
            _immitation.ProcessInput("how")

            ' Assert.
            Assert.AreEqual(expected, _immitation.DemonstrationStep)
        End Sub

        <TestMethod()> Public Sub test_next_step_updates_step_to_next_step_and_next_till_has_immitation_been_completed_is_true()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _immitation = New ImmitationTraining(_mockDb.Object)
            _immitation.GetDemonstrationList(1)
            _immitation.ProcessInput("Hello")
            _immitation.ProcessInput("how")
            _immitation.ProcessInput("are")
            _immitation.ProcessInput("you?")

            ' Assert.
            Assert.IsTrue(_immitation.HasImmitationBeenCompleted)
        End Sub

    End Class
End Namespace