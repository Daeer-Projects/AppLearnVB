
Imports ExampleProg.Constants
Imports ExampleProg.Interfaces
Imports ExampleProg.ProcedureReturnTypes

Namespace InputClasses.Training
    ''' <summary>
    ''' The practice section of training.
    ''' The user gets to answer the question without any help.
    ''' If they get it wrong, the answer does show, and they get a chance to answer again.
    ''' Marks will be deducted for each go round.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PracticeTraining
        Private ReadOnly _dbConnection As IDbConnector

        Private _questionID As Integer
        Private _questionDetails As QuestionDetailsReturnType

        Property DemonstrationList As IEnumerable(Of ImmitationStageListType)
        Property DemonstrationStepDetails As List(Of String)
        Property DemonstrationStepRegEx As List(Of String)
        Property CountOfDemonstrationSteps As Integer
        Property HasDemoStepsBeenSetUp As Boolean

        Property PracticeInput As String
        Property UserMark As Integer

        Property ErrorMessage As String

        ''' <summary>
        ''' The basic constructor.
        ''' Sets up the db connection.
        ''' </summary>
        ''' <param name="dbConnection"></param>
        ''' <remarks></remarks>
        Public Sub New(dbConnection As IDbConnector)
            _dbConnection = dbConnection
            DemonstrationStepDetails = New List(Of String)
            DemonstrationStepRegEx = New List(Of String)
        End Sub

        ''' <summary>
        ''' Checks the questionId and sets it.
        ''' Then uses that to set up the rest of the practice session.
        ''' </summary>
        ''' <param name="questionId"></param>
        ''' <remarks></remarks>
        Public Sub SetupPracticeSession(questionId As Integer)
            If Not (questionId = Nothing) AndAlso (questionId > 0) Then
                _questionID = questionId
                UpdateVariables()
            Else
                ErrorMessage = CommonConstants.TrainingPracticeQuestionIdNoSuppliedError
            End If
        End Sub

        ''' <summary>
        ''' Gets the question details and the demonstration list.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub UpdateVariables()
            _questionDetails = _dbConnection.GetQuestionDetail(_questionID)
            DemonstrationList = _dbConnection.GetImmitationStageSteps(_questionID)
            HasDemoStepsBeenSetUp = SetPracticeStage()
        End Sub

        ''' <summary>
        ''' Sets the items from the entry in the list.
        ''' </summary>
        ''' <returns>If possible, it returns true, else false.</returns>
        ''' <remarks></remarks>
        Private Function SetPracticeStage() As Boolean
            Dim result As Boolean
            If (_DemonstrationList.Any()) Then
                CountOfDemonstrationSteps = _DemonstrationList.Count()
                SetPracticeValues()
                result = True
            Else
                result = False
            End If
            Return result
        End Function

        ''' <summary>
        ''' Sets up the items from the list.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetPracticeValues()
            For Each practiceStageType As ImmitationStageListType In DemonstrationList
                DemonstrationStepDetails.Add(practiceStageType.DescriptionOfStage)
                DemonstrationStepRegEx.Add(practiceStageType.RegEx)
            Next
        End Sub

    End Class
End Namespace