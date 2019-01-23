Imports ExampleProg.Classes
Imports ExampleProg.ProcedureReturnTypes
Imports ExampleProg.QuestionTypes

Namespace Interfaces
    ''' <summary>
    ''' Database Connector Wrapper Interface.
    ''' </summary>
    ''' <remarks>Database Interface.</remarks>
    Public Interface IDbConnector
        Function DBConnectionStatus() As String

        Function IsUserNameAvailable(userName As String) As Boolean
        Function DoesUserNameAlreadyExists(userName As String) As Boolean
        Function GetUserIdOfValidUser(userName As String, password As String) As Integer
        Function GetUserDetails(user As IUserClass) As UserClass
        Function CreateNewUser(user As IUserClass) As Boolean

        Function GetListOfSubjects() As IEnumerable(Of SubjectListType)
        Function GetListOfCurriculum() As IEnumerable(Of CurriculumListType)
        Function GetListOfKeyStages() As IEnumerable(Of KeyStageListType)
        Function GetListOfExplanations() As IEnumerable(Of ExplanationListType)
        Function GetUpdatedListOfCurriculum(subjectID As Integer) As IEnumerable(Of CurriculumListType)
        Function GetUpdatedListOfExplanations(subjectID As Integer) As IEnumerable(Of ExplanationListType)
        Function GetUpdatedExplanationsByCurriculum(curriculumID As Integer) As IEnumerable(Of ExplanationListType)

        Function GetExplanationDetailsById(explanationID As Integer) As String

        Function InsertNewSubject(subjectText As String) As Integer
        Function InsertNewCurriculum(subjectID As Integer, curriculumText As String) As Integer
        Function InsertNewKeyStage(keyStageText As String) As Integer
        Function InsertNewExplanation(curriculumID As Integer, explanationTitle As String, explanationText As String) As Integer

        Function InsertNewQuestion(question As QuestionInsertType) As Integer
        Function InsertNewDemoStep(demo As DemonstrationStepType, questionID As Integer) As Boolean

        Function GetExplanationDetailsForTraining(explanationID As Integer) As GetExplanationDetailsType
        Function GetListOfQuestionIdsForTraining(subjectID As Integer, curriculumID As Integer, keyStageID As Integer, explanationID As Integer) As IEnumerable(Of Integer)

        Function GetListOfDemoStepDetails(questionID As Integer) As IEnumerable(Of String)
        Function GetImmitationStageSteps(questionID As Integer) As IEnumerable(Of ImmitationStageListType)

        Function GetQuestionDetail(questionID As Integer) As QuestionDetailsReturnType
    End Interface
End Namespace