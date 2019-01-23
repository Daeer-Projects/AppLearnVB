Imports ExampleProg.Constants
Imports ExampleProg.InputClasses
Imports ExampleProg.Interfaces
Imports ExampleProg.ProcedureReturnTypes
Imports ExampleProg.QuestionTypes
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq

''' <summary>
''' A set of tests for the New Question Input class.
''' </summary>
''' <remarks>Tests.</remarks>
<TestClass()> Public Class NewQuestionInputTests

#Region "Set up functions"
    Private _newQuestion As NewQuestionInput
    Private _mockDb As Mock(Of IDbConnector)

    Private Sub SetNewQuestionDefaults()
        _mockDb = New Mock(Of IDbConnector)
        _newQuestion = New NewQuestionInput(_mockDb.Object)
    End Sub

    Private Sub SetSubjectStuff()
        _newQuestion.SubjectType.SubjectList = New List(Of SubjectListType)
        _newQuestion.SubjectType.Process("OMG")
    End Sub

    Private Sub SetCurriculumStuff()
        _newQuestion.CurriculumType.CurriculumList = New List(Of CurriculumListType)
        _newQuestion.CurriculumType.Process("Blah")
    End Sub

    Private Sub SetKeyStageStuff()
        _newQuestion.KeyStageType.KeyStageList = New List(Of KeyStageListType)
        _newQuestion.KeyStageType.Process("N/A")
    End Sub

    Private Sub SetExplanationStuff()
        _newQuestion.ExplanationType.Process("Some where", "A log list of somthing or other")
    End Sub

    Private Sub SetQuestionStuff()
        _newQuestion.QuestionType.Process("What is this?", "www.whatgoesthere.com", "OMG", "Blah", "N/A", "Some where")
    End Sub

    Private Sub SetAnswerStuff()
        _newQuestion.AnswerType.Process("a", "b", "c", "d")
    End Sub

    Private Sub SetDemoStuff()
        _newQuestion.DemonstrationType.InsertNextStepDetails("You take one from here and add it to that")
        _newQuestion.DemonstrationType.UpdateRegEx("$\some\ rubbish\ here\ !$")
        _newQuestion.DemonstrationType.InsertMark("5")
        _newQuestion.DemonstrationType.AddDetailsToList()
    End Sub
#End Region

    <TestMethod()> Public Sub test_process_sets_can_submit_flag_to_true()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        ' Act.
        _newQuestion.Process()

        ' Assert.
        Assert.IsTrue(_newQuestion.CanSubmit)
    End Sub

    <TestMethod()> Public Sub test_process_sets_can_submit_flag_to_false_with_no_subject()
        ' Arrange.
        SetNewQuestionDefaults()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        ' Act.
        _newQuestion.Process()

        ' Assert.
        Assert.IsFalse(_newQuestion.CanSubmit)
    End Sub

    <TestMethod()> Public Sub test_process_sets_can_submit_flag_to_false_with_no_curriculum()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        ' Act.
        _newQuestion.Process()

        ' Assert.
        Assert.IsFalse(_newQuestion.CanSubmit)
    End Sub

    <TestMethod()> Public Sub test_process_sets_can_submit_flag_to_false_with_no_key_stage()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        ' Act.
        _newQuestion.Process()

        ' Assert.
        Assert.IsFalse(_newQuestion.CanSubmit)
    End Sub

    <TestMethod()> Public Sub test_process_sets_can_submit_flag_to_false_with_no_explanation()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        ' Act.
        _newQuestion.Process()

        ' Assert.
        Assert.IsFalse(_newQuestion.CanSubmit)
    End Sub

    <TestMethod()> Public Sub test_process_sets_can_submit_flag_to_false_with_no_question()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetAnswerStuff()
        SetDemoStuff()

        ' Act.
        _newQuestion.Process()

        ' Assert.
        Assert.IsFalse(_newQuestion.CanSubmit)
    End Sub

    <TestMethod()> Public Sub test_process_sets_can_submit_flag_to_false_with_no_answer()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetDemoStuff()

        ' Act.
        _newQuestion.Process()

        ' Assert.
        Assert.IsFalse(_newQuestion.CanSubmit)
    End Sub

    <TestMethod()> Public Sub test_process_sets_can_submit_flag_to_false_with_no_demonstration()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()

        ' Act.
        _newQuestion.Process()

        ' Assert.
        Assert.IsFalse(_newQuestion.CanSubmit)
    End Sub

    <TestMethod()> Public Sub test_set_lists_from_db_sets_subject_list()
        ' Arrange.
        SetNewQuestionDefaults()
        Dim subject1 = New SubjectListType
        subject1.ID = 1
        subject1.SubjectDetail = "Bananas"
        Dim subject2 = New SubjectListType
        subject2.ID = 2
        subject2.SubjectDetail = "Apples"
        Dim list = New List(Of SubjectListType)
        list.Add(subject1)
        list.Add(subject2)

        _mockDb.Setup(Function(c) c.GetListOfSubjects()).Returns(list)

        ' Act.
        _newQuestion.SetListsFromDatabase()

        ' Assert.
        Assert.AreEqual(list, _newQuestion.SubjectType.SubjectList)
    End Sub

    <TestMethod()> Public Sub test_set_lists_from_db_sets_curriculum_list()
        ' Arrange.
        SetNewQuestionDefaults()
        Dim curr1 = New CurriculumListType
        curr1.ID = 1
        curr1.CurriculumDetails = "Bananas"
        Dim curr2 = New CurriculumListType
        curr2.ID = 2
        curr2.CurriculumDetails = "Apples"
        Dim list = New List(Of CurriculumListType)
        list.Add(curr1)
        list.Add(curr2)

        _mockDb.Setup(Function(c) c.GetListOfCurriculum()).Returns(list)

        ' Act.
        _newQuestion.SetListsFromDatabase()

        ' Assert.
        Assert.AreEqual(list, _newQuestion.CurriculumType.CurriculumList)
    End Sub

    <TestMethod()> Public Sub test_set_lists_from_db_sets_key_stage_list()
        ' Arrange.
        SetNewQuestionDefaults()
        Dim key1 = New KeyStageListType
        key1.ID = 1
        key1.KeyStageDetail = "N/A"
        Dim key2 = New KeyStageListType
        key2.ID = 2
        key2.KeyStageDetail = "KS1"
        Dim list = New List(Of KeyStageListType)
        list.Add(key1)
        list.Add(key2)

        _mockDb.Setup(Function(c) c.GetListOfKeyStages()).Returns(list)

        ' Act.
        _newQuestion.SetListsFromDatabase()

        ' Assert.
        Assert.AreEqual(list, _newQuestion.KeyStageType.KeyStageList)
    End Sub

    <TestMethod()> Public Sub test_set_lists_from_db_sets_explanation_list()
        ' Arrange.
        SetNewQuestionDefaults()
        Dim explanation1 = New ExplanationListType
        explanation1.ID = 1
        explanation1.ExplanationDetail = "Carrots"
        Dim explanation2 = New ExplanationListType
        explanation2.ID = 2
        explanation2.ExplanationDetail = "Oh something"
        Dim list = New List(Of ExplanationListType)
        list.Add(explanation1)
        list.Add(explanation2)

        _mockDb.Setup(Function(c) c.GetListOfExplanations()).Returns(list)

        ' Act.
        _newQuestion.SetListsFromDatabase()

        ' Assert.
        Assert.AreEqual(list, _newQuestion.ExplanationType.ExplanationList)
    End Sub

    <TestMethod()> Public Sub test_update_lists_from_db_updates_curriculum_list()
        ' Arrange.
        SetNewQuestionDefaults()
        Dim curr1 = New CurriculumListType
        curr1.ID = 1
        curr1.CurriculumDetails = "Bananas"
        Dim curr2 = New CurriculumListType
        curr2.ID = 2
        curr2.CurriculumDetails = "Apples"
        Dim list = New List(Of CurriculumListType)
        list.Add(curr1)
        list.Add(curr2)

        _mockDb.Setup(Function(c) c.GetUpdatedListOfCurriculum(It.IsAny(Of Integer))).Returns(list)

        ' Act.
        _newQuestion.UpdateOtherLists()

        ' Assert.
        Assert.AreEqual(list, _newQuestion.CurriculumType.CurriculumList)
    End Sub

    <TestMethod()> Public Sub test_update_lists_from_db_updates_explanation_list()
        ' Arrange.
        SetNewQuestionDefaults()
        Dim explanation1 = New ExplanationListType
        explanation1.ID = 1
        explanation1.ExplanationDetail = "Carrots"
        Dim explanation2 = New ExplanationListType
        explanation2.ID = 2
        explanation2.ExplanationDetail = "Oh something"
        Dim list = New List(Of ExplanationListType)
        list.Add(explanation1)
        list.Add(explanation2)

        _mockDb.Setup(Function(c) c.GetUpdatedListOfExplanations(It.IsAny(Of Integer))).Returns(list)

        ' Act.
        _newQuestion.UpdateOtherLists()

        ' Assert.
        Assert.AreEqual(list, _newQuestion.ExplanationType.ExplanationList)
    End Sub

    <TestMethod()> Public Sub test_update_explanation_list_from_db_updates_explanation_list()
        ' Arrange.
        SetNewQuestionDefaults()
        Dim explanation1 = New ExplanationListType
        explanation1.ID = 1
        explanation1.ExplanationDetail = "Carrots"
        Dim explanation2 = New ExplanationListType
        explanation2.ID = 2
        explanation2.ExplanationDetail = "Oh something"
        Dim list = New List(Of ExplanationListType)
        list.Add(explanation1)
        list.Add(explanation2)

        _mockDb.Setup(Function(c) c.GetUpdatedExplanationsByCurriculum(It.IsAny(Of Integer))).Returns(list)

        ' Act.
        _newQuestion.UpdateExplanation()

        ' Assert.
        Assert.AreEqual(list, _newQuestion.ExplanationType.ExplanationList)
    End Sub

    ' Gets any changes and re-validates all fields.
    ' Sets parameters for stored procedures.
    ' Executes stored procedure to insert new question into the database.
    ' Checks it is inserted successfully.

    <TestMethod()> Public Sub test_insert_question_sets_inserted_successfully_to_true()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(1)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(2)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(3)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(4)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(5)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(True)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.IsTrue(_newQuestion.InsertedSuccessfully)
    End Sub

    <TestMethod()> Public Sub test_insert_question_sets_new_question_insert_message_to_success()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(1)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(2)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(3)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(4)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(5)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(True)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.AreEqual(CommonConstants.NewQuestionInsertedCorrectly, _newQuestion.NewQuestionInsertMessage)
    End Sub

    <TestMethod()> Public Sub test_insert_question_sets_inserted_successfully_to_false_with_no_subject()
        ' Arrange.
        SetNewQuestionDefaults()
        'SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(0)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(2)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(3)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(4)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(5)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(True)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.IsFalse(_newQuestion.InsertedSuccessfully)
    End Sub

    <TestMethod()> Public Sub test_insert_question_sets_new_question_insert_message_to_failure_with_no_subject()
        ' Arrange.
        SetNewQuestionDefaults()
        'SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(0)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(2)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(3)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(4)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(5)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(True)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.AreEqual(CommonConstants.InsertNewQuestionError, _newQuestion.NewQuestionInsertMessage)
    End Sub

    <TestMethod()> Public Sub test_insert_question_sets_inserted_successfully_to_false_with_no_curriculum()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        'SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(1)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(0)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(3)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(4)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(5)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(True)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.IsFalse(_newQuestion.InsertedSuccessfully)
    End Sub

    <TestMethod()> Public Sub test_insert_question_sets_new_question_insert_message_to_failure_with_no_curriculum()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        'SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(1)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(0)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(3)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(4)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(5)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(True)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.AreEqual(CommonConstants.InsertNewQuestionError, _newQuestion.NewQuestionInsertMessage)
    End Sub

    <TestMethod()> Public Sub test_insert_question_sets_inserted_successfully_to_false_with_no_key_stage()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        'SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(1)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(2)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(0)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(4)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(5)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(True)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.IsFalse(_newQuestion.InsertedSuccessfully)
    End Sub

    <TestMethod()> Public Sub test_insert_question_sets_new_question_insert_message_to_failure_with_no_key_stage()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        'SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(1)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(2)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(0)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(4)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(5)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(True)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.AreEqual(CommonConstants.InsertNewQuestionError, _newQuestion.NewQuestionInsertMessage)
    End Sub

    <TestMethod()> Public Sub test_insert_question_sets_inserted_successfully_to_false_with_no_explanation()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        'SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(1)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(2)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(3)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(0)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(5)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(True)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.IsFalse(_newQuestion.InsertedSuccessfully)
    End Sub

    <TestMethod()> Public Sub test_insert_question_sets_new_question_insert_message_to_failure_with_no_explanation()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        'SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(1)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(2)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(3)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(0)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(5)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(True)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.AreEqual(CommonConstants.InsertNewQuestionError, _newQuestion.NewQuestionInsertMessage)
    End Sub

    <TestMethod()> Public Sub test_insert_question_sets_inserted_successfully_to_false_with_no_question()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        'SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(1)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(2)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(3)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(4)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(0)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(True)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.IsFalse(_newQuestion.InsertedSuccessfully)
    End Sub

    <TestMethod()> Public Sub test_insert_question_sets_new_question_insert_message_to_failure_with_no_question()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        'SetQuestionStuff()
        SetAnswerStuff()
        SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(1)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(2)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(3)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(4)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(0)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(True)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.AreEqual(CommonConstants.InsertNewQuestionError, _newQuestion.NewQuestionInsertMessage)
    End Sub

    <TestMethod()> Public Sub test_insert_question_sets_inserted_successfully_to_false_with_no_answer()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        'SetAnswerStuff()
        SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(1)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(2)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(3)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(4)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(0)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(True)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.IsFalse(_newQuestion.InsertedSuccessfully)
    End Sub

    <TestMethod()> Public Sub test_insert_question_sets_new_question_insert_message_to_failure_with_no_answer()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        'SetAnswerStuff()
        SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(1)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(2)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(3)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(4)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(0)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(True)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.AreEqual(CommonConstants.InsertNewQuestionError, _newQuestion.NewQuestionInsertMessage)
    End Sub

    <TestMethod()> Public Sub test_insert_question_sets_inserted_successfully_to_false_with_no_demo_steps()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        'SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(1)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(2)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(3)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(4)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(5)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(False)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.IsFalse(_newQuestion.InsertedSuccessfully)
    End Sub

    <TestMethod()> Public Sub test_insert_question_sets_new_question_insert_message_to_failure_with_no_demo_step()
        ' Arrange.
        SetNewQuestionDefaults()
        SetSubjectStuff()
        SetCurriculumStuff()
        SetKeyStageStuff()
        SetExplanationStuff()
        SetQuestionStuff()
        SetAnswerStuff()
        'SetDemoStuff()

        _newQuestion.Process()

        _mockDb.Setup(Function(s) s.InsertNewSubject(It.IsAny(Of String))).Returns(1)
        _mockDb.Setup(Function(c) c.InsertNewCurriculum(It.IsAny(Of Integer), It.IsAny(Of String))).Returns(2)
        _mockDb.Setup(Function(k) k.InsertNewKeyStage(It.IsAny(Of String))).Returns(3)
        _mockDb.Setup(Function(e) e.InsertNewExplanation(It.IsAny(Of Integer), It.IsAny(Of String), It.IsAny(Of String))).Returns(4)
        _mockDb.Setup(Function(q) q.InsertNewQuestion(It.IsAny(Of QuestionInsertType))).Returns(5)
        _mockDb.Setup(Function(d) d.InsertNewDemoStep(It.IsAny(Of DemonstrationStepType), It.IsAny(Of Integer))).Returns(False)

        ' Act.
        _newQuestion.InsertNewQuestion()

        ' Assert.
        Assert.AreEqual(CommonConstants.InsertNewDemoStepError, _newQuestion.NewQuestionInsertMessage)
    End Sub

End Class