Imports ExampleProg.InputClasses.Training
Imports ExampleProg.Interfaces
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq

Namespace TrainingTests

    <TestClass()> Public Class DemonstrationTrainingTests
        Private _demoTraining As DemonstrationTraining
        Private _mockDb As Mock(Of IDbConnector)

#Region "Set up lists"
        Private Function GetListOfIds() As IEnumerable(Of Integer)
            Dim list As New List(Of Integer)

            list.Add(2)
            list.Add(3)
            list.Add(6)
            list.Add(7)
            list.Add(12)

            Return list
        End Function

        Private Function GetListOfDemos() As IEnumerable(Of String)
            Dim demoList As New List(Of String)

            demoList.Add("Hello")
            demoList.Add("Oh dear")
            demoList.Add("Goodbye")

            Return demoList
        End Function
#End Region

        <TestMethod()> Public Sub test_set_random_question_id_sets_valid_id_with_list_of_questions()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(q) q.GetListOfQuestionIdsForTraining(It.IsAny(Of Integer), It.IsAny(Of Integer), It.IsAny(Of Integer), It.IsAny(Of Integer))).Returns(GetListOfIds())

            ' Act.
            _demoTraining = New DemonstrationTraining(_mockDb.Object)
            _demoTraining.Initialise(1, 3, 5, 6)
            _demoTraining.SetRandomQuestionID()
            Dim result = _demoTraining.QuestionID

            ' Assert.
            Assert.IsTrue(result = 2 OrElse result = 3 OrElse result = 6 OrElse result = 7 OrElse result = 12)
        End Sub

        <TestMethod()> Public Sub test_set_random_question_id_sets_specific_id_but_not_anything_not_in_list()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(q) q.GetListOfQuestionIdsForTraining(It.IsAny(Of Integer), It.IsAny(Of Integer), It.IsAny(Of Integer), It.IsAny(Of Integer))).Returns(GetListOfIds())

            ' Act.
            _demoTraining = New DemonstrationTraining(_mockDb.Object)
            _demoTraining.Initialise(1, 3, 5, 6)
            _demoTraining.SetRandomQuestionID()
            Dim result = _demoTraining.QuestionID

            ' Assert
            Assert.IsFalse(Not result = 2 AndAlso Not result = 3 AndAlso Not result = 6 AndAlso Not result = 7 AndAlso Not result = 12)
        End Sub

        <TestMethod()> Public Sub test_set_up_demo_steps_sets_has_been_set_up_to_false()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _demoTraining = New DemonstrationTraining(_mockDb.Object)
            _demoTraining.Initialise(1, 3, 5, 6)
            _demoTraining.QuestionID = 12

            ' Act.
            _demoTraining.SetUpDemoSteps()

            ' Assert.
            Assert.IsFalse(_demoTraining.HasDemoStepsBeenSetUp)
        End Sub

        <TestMethod()> Public Sub test_set_up_demo_steps_sets_has_been_set_up_to_false_with_question_id_less_than_zero()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _demoTraining = New DemonstrationTraining(_mockDb.Object)
            _demoTraining.Initialise(1, 3, 5, 6)
            _demoTraining.QuestionID = -1

            ' Act.
            _demoTraining.SetUpDemoSteps()

            ' Assert.
            Assert.IsFalse(_demoTraining.HasDemoStepsBeenSetUp)
        End Sub

        <TestMethod()> Public Sub test_set_up_demo_steps_sets_has_been_set_up_to_false_with_no_question_list()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(q) q.GetListOfDemoStepDetails(It.IsAny(Of Integer))).Returns(New List(Of String))
            _demoTraining = New DemonstrationTraining(_mockDb.Object)
            _demoTraining.Initialise(1, 3, 5, 6)
            _demoTraining.QuestionID = 12

            ' Act.
            _demoTraining.SetUpDemoSteps()

            ' Assert.
            Assert.IsFalse(_demoTraining.HasDemoStepsBeenSetUp)
        End Sub

        <TestMethod()> Public Sub test_set_up_demo_steps_sets_has_been_set_up_to_true_with_question_list()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(q) q.GetListOfDemoStepDetails(It.IsAny(Of Integer))).Returns(GetListOfDemos())
            _demoTraining = New DemonstrationTraining(_mockDb.Object)
            _demoTraining.Initialise(1, 3, 5, 6)
            _demoTraining.QuestionID = 13

            ' Act.
            _demoTraining.SetUpDemoSteps()

            ' Assert.
            Assert.IsTrue(_demoTraining.HasDemoStepsBeenSetUp)
        End Sub

        <TestMethod()> Public Sub test_set_up_demo_steps_sets_count_of_steps_with_question_list()
            ' Arrange.
            Const expectedCount As Integer = 3
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(q) q.GetListOfDemoStepDetails(It.IsAny(Of Integer))).Returns(GetListOfDemos())
            _demoTraining = New DemonstrationTraining(_mockDb.Object)
            _demoTraining.Initialise(1, 3, 5, 6)
            _demoTraining.QuestionID = 13

            ' Act.
            _demoTraining.SetUpDemoSteps()

            ' Assert.
            Assert.AreEqual(expectedCount, _demoTraining.CountOfDemonstrationSteps)
        End Sub

        <TestMethod()> Public Sub test_next_step_updates_step_details()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(q) q.GetListOfDemoStepDetails(It.IsAny(Of Integer))).Returns(GetListOfDemos())
            _demoTraining = New DemonstrationTraining(_mockDb.Object)
            _demoTraining.Initialise(1, 3, 5, 6)
            _demoTraining.QuestionID = 13
            _demoTraining.SetUpDemoSteps()

            ' Act.
            _demoTraining.NextStep()

            ' Assert.
            Assert.AreEqual("Oh dear", _demoTraining.DemonstrationStepDetails)
        End Sub

        <TestMethod()> Public Sub test_next_step_updates_current_step()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(q) q.GetListOfDemoStepDetails(It.IsAny(Of Integer))).Returns(GetListOfDemos())
            _demoTraining = New DemonstrationTraining(_mockDb.Object)
            _demoTraining.Initialise(1, 3, 5, 6)
            _demoTraining.QuestionID = 13
            _demoTraining.SetUpDemoSteps()

            ' Act.
            _demoTraining.NextStep()

            ' Assert.
            Assert.AreEqual(1, _demoTraining.DemonstrationStep)
        End Sub

        <TestMethod()> Public Sub test_next_step_cannot_update_if_at_count_of_steps()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(q) q.GetListOfDemoStepDetails(It.IsAny(Of Integer))).Returns(GetListOfDemos())
            _demoTraining = New DemonstrationTraining(_mockDb.Object)
            _demoTraining.Initialise(1, 3, 5, 6)
            _demoTraining.QuestionID = 13
            _demoTraining.SetUpDemoSteps()

            ' Act.
            _demoTraining.DemonstrationStep = 2
            _demoTraining.NextStep()

            ' Assert.
            Assert.AreEqual(2, _demoTraining.DemonstrationStep)
        End Sub

        <TestMethod()> Public Sub test_previous_step_updates_step_details()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(q) q.GetListOfDemoStepDetails(It.IsAny(Of Integer))).Returns(GetListOfDemos())
            _demoTraining = New DemonstrationTraining(_mockDb.Object)
            _demoTraining.Initialise(1, 3, 5, 6)
            _demoTraining.QuestionID = 13
            _demoTraining.SetUpDemoSteps()

            ' Act.
            _demoTraining.DemonstrationStep = 2
            _demoTraining.PreviousStep()

            ' Assert.
            Assert.AreEqual("Oh dear", _demoTraining.DemonstrationStepDetails)
        End Sub

        <TestMethod()> Public Sub test_previous_step_updates_current_step()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(q) q.GetListOfDemoStepDetails(It.IsAny(Of Integer))).Returns(GetListOfDemos())
            _demoTraining = New DemonstrationTraining(_mockDb.Object)
            _demoTraining.Initialise(1, 3, 5, 6)
            _demoTraining.QuestionID = 13
            _demoTraining.SetUpDemoSteps()

            ' Act.
            _demoTraining.DemonstrationStep = 2
            _demoTraining.PreviousStep()

            ' Assert.
            Assert.AreEqual(1, _demoTraining.DemonstrationStep)
        End Sub

        <TestMethod()> Public Sub test_previous_step_cannot_update_if_at_beginning()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(q) q.GetListOfDemoStepDetails(It.IsAny(Of Integer))).Returns(GetListOfDemos())
            _demoTraining = New DemonstrationTraining(_mockDb.Object)
            _demoTraining.Initialise(1, 3, 5, 6)
            _demoTraining.QuestionID = 13
            _demoTraining.SetUpDemoSteps()

            ' Act.
            _demoTraining.DemonstrationStep = 0
            _demoTraining.PreviousStep()

            ' Assert.
            Assert.AreEqual(0, _demoTraining.DemonstrationStep)
        End Sub

        <TestMethod()> Public Sub test_can_proceed_returns_true_when_at_count_of_steps()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(q) q.GetListOfDemoStepDetails(It.IsAny(Of Integer))).Returns(GetListOfDemos())
            _demoTraining = New DemonstrationTraining(_mockDb.Object)
            _demoTraining.Initialise(1, 3, 5, 6)
            _demoTraining.QuestionID = 13
            _demoTraining.SetUpDemoSteps()

            ' Act.
            _demoTraining.DemonstrationStep = 2
            Dim result = _demoTraining.CanProceed()

            ' Assert.
            Assert.IsTrue(result)
        End Sub

        <TestMethod()> Public Sub test_can_proceed_returns_false_when_not_at_count_of_steps()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(q) q.GetListOfDemoStepDetails(It.IsAny(Of Integer))).Returns(GetListOfDemos())
            _demoTraining = New DemonstrationTraining(_mockDb.Object)
            _demoTraining.Initialise(1, 3, 5, 6)
            _demoTraining.QuestionID = 13
            _demoTraining.SetUpDemoSteps()

            ' Act.
            _demoTraining.DemonstrationStep = 1
            Dim result = _demoTraining.CanProceed()

            ' Assert.
            Assert.IsFalse(result)
        End Sub

    End Class
End Namespace