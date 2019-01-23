Imports ExampleProg.Constants
Imports ExampleProg.InputClasses.Training
Imports ExampleProg.Interfaces
Imports ExampleProg.ProcedureReturnTypes
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq

Namespace TrainingTests

    <TestClass()> Public Class PracticeTrainingTests
        Private _practiceTraining As PracticeTraining
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

        Private Function GetDemoDetailsList() As List(Of String)
            Dim list As New List(Of String)
            list.Add("Hello")
            list.Add("how")
            list.Add("are")
            list.Add("you?")

            Return list
        End Function

        Private Function GetDemoRegExList() As List(Of String)
            Dim list As New List(Of String)
            list.Add("^(Hello)$")
            list.Add("^(how)$")
            list.Add("^(are)$")
            list.Add("^(you)\?$")

            Return list
        End Function
#End Region

        <TestMethod()> Public Sub test_setup_practice_session_sets_error_message_if_no_question_id_supplied()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()

            ' Act.
            _practiceTraining = New PracticeTraining(_mockDb.Object)
            _practiceTraining.SetupPracticeSession(Nothing)

            ' Assert.
            Assert.AreEqual(CommonConstants.TrainingPracticeQuestionIdNoSuppliedError, _practiceTraining.ErrorMessage)
        End Sub

        <TestMethod()> Public Sub test_setup_practice_session_sets_error_message_if_question_id_is_zero()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()

            ' Act.
            _practiceTraining = New PracticeTraining(_mockDb.Object)
            _practiceTraining.SetupPracticeSession(0)

            ' Assert.
            Assert.AreEqual(CommonConstants.TrainingPracticeQuestionIdNoSuppliedError, _practiceTraining.ErrorMessage)
        End Sub

        <TestMethod()> Public Sub test_setup_practice_session_sets_error_message_if_question_id_is_less_than_zero()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()

            ' Act.
            _practiceTraining = New PracticeTraining(_mockDb.Object)
            _practiceTraining.SetupPracticeSession(-1)

            ' Assert.
            Assert.AreEqual(CommonConstants.TrainingPracticeQuestionIdNoSuppliedError, _practiceTraining.ErrorMessage)
        End Sub

        <TestMethod()> Public Sub test_setup_practice_session_sets_error_message_to_null_if_question_id_valid()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()

            ' Act.
            _practiceTraining = New PracticeTraining(_mockDb.Object)
            _practiceTraining.SetupPracticeSession(1)

            ' Assert.
            Assert.IsTrue(String.IsNullOrEmpty(_practiceTraining.ErrorMessage))
        End Sub

        <TestMethod()> Public Sub test_update_variables_sets_demo_list()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _practiceTraining = New PracticeTraining(_mockDb.Object)
            _practiceTraining.SetupPracticeSession(1)

            ' Assert.
            Assert.IsTrue(_practiceTraining.DemonstrationList.Any())
        End Sub

        <TestMethod()> Public Sub test_update_variables_sets_has_demo_been_setup_to_true()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _practiceTraining = New PracticeTraining(_mockDb.Object)
            _practiceTraining.SetupPracticeSession(1)

            ' Assert.
            Assert.IsTrue(_practiceTraining.HasDemoStepsBeenSetUp)
        End Sub

        <TestMethod()> Public Sub test_update_variables_sets_has_demo_been_setup_to_false_if_no_demos_returned()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()

            ' Act.
            _practiceTraining = New PracticeTraining(_mockDb.Object)
            _practiceTraining.SetupPracticeSession(1)

            ' Assert.
            Assert.IsFalse(_practiceTraining.HasDemoStepsBeenSetUp)
        End Sub

        <TestMethod()> Public Sub test_set_practice_stage_sets_count_of_demo_steps()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _practiceTraining = New PracticeTraining(_mockDb.Object)
            _practiceTraining.SetupPracticeSession(1)

            ' Assert.
            Assert.AreEqual(4, _practiceTraining.CountOfDemonstrationSteps)
        End Sub

        <TestMethod()> Public Sub test_set_practice_values_sets_demo_details_list_hello()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _practiceTraining = New PracticeTraining(_mockDb.Object)
            _practiceTraining.SetupPracticeSession(1)

            ' Assert.
            Assert.AreEqual(GetDemoDetailsList().First(), _practiceTraining.DemonstrationStepDetails.First())
        End Sub

        <TestMethod()> Public Sub test_set_practice_values_sets_demo_details_list_you()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _practiceTraining = New PracticeTraining(_mockDb.Object)
            _practiceTraining.SetupPracticeSession(1)

            ' Assert.
            Assert.AreEqual(GetDemoDetailsList().Last(), _practiceTraining.DemonstrationStepDetails.Last())
        End Sub

        <TestMethod()> Public Sub test_set_practice_values_sets_demo_reg_ex_list_how()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _practiceTraining = New PracticeTraining(_mockDb.Object)
            _practiceTraining.SetupPracticeSession(1)

            ' Assert.
            Assert.AreEqual(GetDemoRegExList().ElementAt(1), _practiceTraining.DemonstrationStepRegEx.ElementAt(1))
        End Sub

        <TestMethod()> Public Sub test_set_practice_values_sets_demo_reg_ex_list_are()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(x) x.GetImmitationStageSteps(It.IsAny(Of Integer))).Returns(GetListOfImmitationStages())

            ' Act.
            _practiceTraining = New PracticeTraining(_mockDb.Object)
            _practiceTraining.SetupPracticeSession(1)

            ' Assert.
            Assert.AreEqual(GetDemoRegExList().ElementAt(2), _practiceTraining.DemonstrationStepRegEx.ElementAt(2))
        End Sub

    End Class
End Namespace