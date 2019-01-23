Imports ExampleProg.InputClasses.Training
Imports ExampleProg.Interfaces
Imports ExampleProg.ProcedureReturnTypes
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq

Namespace TrainingTests
    ''' <summary>
    ''' Tests for the Select Training Input class.
    ''' </summary>
    ''' <remarks></remarks>
    <TestClass()> Public Class SelectTrainingInputTests
        Private _selectTraining As SelectTrainingInput
        Private _mockDb As Mock(Of IDbConnector)

#Region "Set up fake lists."
        Private Function GetSubjectList() As List(Of SubjectListType)
            Dim subjectList = New List(Of SubjectListType)
            Dim subject1 = New SubjectListType()
            subject1.ID = 1
            subject1.SubjectDetail = "English"
            Dim subject2 = New SubjectListType()
            subject2.ID = 2
            subject2.SubjectDetail = "Maths"

            subjectList.Add(subject1)
            subjectList.Add(subject2)
            Return subjectList
        End Function

        Private Function GetCurriculumList() As List(Of CurriculumListType)
            Dim curriculumList = New List(Of CurriculumListType)
            Dim curr1 = New CurriculumListType()
            curr1.ID = 1
            curr1.CurriculumDetails = "Bananas"
            Dim curr2 = New CurriculumListType()
            curr2.ID = 2
            curr2.CurriculumDetails = "Apples"

            curriculumList.Add(curr1)
            curriculumList.Add(curr2)
            Return curriculumList
        End Function

        Private Function GetKeyStageList() As List(Of KeyStageListType)
            Dim keystage1 = New KeyStageListType()
            keystage1.ID = 1
            keystage1.KeyStageDetail = "KS1"
            Dim keystage2 = New KeyStageListType()
            keystage2.ID = 2
            keystage2.KeyStageDetail = "KS2"

            Dim keyStageList = New List(Of KeyStageListType)
            keyStageList.Add(keystage1)
            keyStageList.Add(keystage2)
            Return keyStageList
        End Function

        Private Function GetExplanationList() As List(Of ExplanationListType)
            Dim explanation1 = New ExplanationListType()
            explanation1.ID = 1
            explanation1.ExplanationDetail = "Basic"
            Dim explanation2 = New ExplanationListType()
            explanation2.ID = 2
            explanation2.ExplanationDetail = "Advanced"

            Dim explanationList = New List(Of ExplanationListType)
            explanationList.Add(explanation1)
            explanationList.Add(explanation2)
            Return explanationList
        End Function
#End Region

        <TestMethod()> Public Sub test_populate_subject_list_returns_correct_count()
            ' Arrange.
            Dim subjectList As List(Of SubjectListType) = GetSubjectList()
            _mockDb = New Mock(Of IDbConnector)

            ' Act.
            _mockDb.Setup(Function(s) s.GetListOfSubjects()).Returns(subjectList)
            _selectTraining = New SelectTrainingInput(_mockDb.Object)

            ' Assert.
            Assert.AreEqual(subjectList.Count(), _selectTraining.SubjectList.Count())
        End Sub

        <TestMethod()> Public Sub test_populate_curriculum_list_returns_correct_count()
            ' Arrange.
            Dim curriculumList As List(Of CurriculumListType) = GetCurriculumList()
            _mockDb = New Mock(Of IDbConnector)

            ' Act.
            _mockDb.Setup(Function(c) c.GetListOfCurriculum()).Returns(curriculumList)
            _selectTraining = New SelectTrainingInput(_mockDb.Object)
            _selectTraining.PopulateCurriculumList()

            ' Assert.
            Assert.AreEqual(curriculumList.Count(), _selectTraining.CurriculumList.Count())
        End Sub

        <TestMethod()> Public Sub test_populate_update_curriculum_list_returns_correct_count()
            ' Arrange.
            Dim curriculumList As List(Of CurriculumListType) = GetCurriculumList()
            _mockDb = New Mock(Of IDbConnector)

            ' Act.
            _mockDb.Setup(Function(c) c.GetUpdatedListOfCurriculum(It.IsAny(Of Integer))).Returns(curriculumList)
            _selectTraining = New SelectTrainingInput(_mockDb.Object)
            _selectTraining.PopulateUpdatedCurriculumList()

            ' Assert.
            Assert.AreEqual(curriculumList.Count(), _selectTraining.CurriculumList.Count())
        End Sub

        <TestMethod()> Public Sub test_populate_key_stage_list_returns_correct_count()
            ' Arrange.
            Dim keyStageList As List(Of KeyStageListType) = GetKeyStageList()
            _mockDb = New Mock(Of IDbConnector)

            ' Act.
            _mockDb.Setup(Function(c) c.GetListOfKeyStages()).Returns(keyStageList)
            _selectTraining = New SelectTrainingInput(_mockDb.Object)

            ' Assert.
            Assert.AreEqual(keyStageList.Count(), _selectTraining.KeyStageList.Count())
        End Sub

        <TestMethod()> Public Sub test_populate_explanation_list_returns_correct_count()
            ' Arrange.
            Dim explanationList As List(Of ExplanationListType) = GetExplanationList()
            _mockDb = New Mock(Of IDbConnector)

            ' Act.
            _mockDb.Setup(Function(c) c.GetListOfExplanations()).Returns(explanationList)
            _selectTraining = New SelectTrainingInput(_mockDb.Object)
            _selectTraining.PopulateExplanationList()

            ' Assert.
            Assert.AreEqual(explanationList.Count(), _selectTraining.ExplanationList.Count())
        End Sub

        <TestMethod()> Public Sub test_populate_updated_explanation_list_by_curriculum_id_returns_correct_count()
            ' Arrange.
            Dim explanationList As List(Of ExplanationListType) = GetExplanationList()
            _mockDb = New Mock(Of IDbConnector)

            ' Act.
            _mockDb.Setup(Function(c) c.GetUpdatedExplanationsByCurriculum(It.IsAny(Of Integer))).Returns(explanationList)
            _selectTraining = New SelectTrainingInput(_mockDb.Object)
            _selectTraining.PopulateUpdatedExplanationList()

            ' Assert.
            Assert.AreEqual(explanationList.Count(), _selectTraining.ExplanationList.Count())
        End Sub

        <TestMethod()> Public Sub test_set_subject_id_returns_correct_id()
            ' Arrange.
            Dim subjectList As List(Of SubjectListType) = GetSubjectList()
            _mockDb = New Mock(Of IDbConnector)

            ' Act.
            _mockDb.Setup(Function(s) s.GetListOfSubjects()).Returns(subjectList)
            _selectTraining = New SelectTrainingInput(_mockDb.Object)
            _selectTraining.SelectedSubjectText = "Maths"
            _selectTraining.SetSubjectID()

            ' Assert.
            Assert.AreEqual(2, _selectTraining.SelectedSubjectID)
        End Sub

        <TestMethod()> Public Sub test_set_curriculum_id_returns_correct_id()
            ' Arrange.
            Dim curriculumList As List(Of CurriculumListType) = GetCurriculumList()
            _mockDb = New Mock(Of IDbConnector)

            ' Act.
            _mockDb.Setup(Function(s) s.GetListOfCurriculum()).Returns(curriculumList)
            _selectTraining = New SelectTrainingInput(_mockDb.Object)
            _selectTraining.PopulateCurriculumList()
            _selectTraining.SelectedCurriculumText = "Bananas"
            _selectTraining.SetCurriculumID()

            ' Assert.
            Assert.AreEqual(1, _selectTraining.SelectedCurriculumID)
        End Sub

        <TestMethod()> Public Sub test_set_key_stage_id_returns_correct_id()
            ' Arrange.
            Dim keyStageList As List(Of KeyStageListType) = GetKeyStageList()
            _mockDb = New Mock(Of IDbConnector)

            ' Act.
            _mockDb.Setup(Function(s) s.GetListOfKeyStages()).Returns(keyStageList)
            _selectTraining = New SelectTrainingInput(_mockDb.Object)
            _selectTraining.SelectedKeyStageText = "KS2"
            _selectTraining.SetKeyStageID()

            ' Assert.
            Assert.AreEqual(2, _selectTraining.SelectedKeyStageID)
        End Sub

        <TestMethod()> Public Sub test_set_explanation_id_returns_correct_id()
            ' Arrange.
            Dim explanationList As List(Of ExplanationListType) = GetExplanationList()
            _mockDb = New Mock(Of IDbConnector)

            ' Act.
            _mockDb.Setup(Function(s) s.GetListOfExplanations()).Returns(explanationList)
            _selectTraining = New SelectTrainingInput(_mockDb.Object)
            _selectTraining.PopulateExplanationList()
            _selectTraining.SelectedExplanationText = "Basic"
            _selectTraining.SetExplanationID()

            ' Assert.
            Assert.AreEqual(1, _selectTraining.SelectedExplanationID)
        End Sub
    End Class
End Namespace