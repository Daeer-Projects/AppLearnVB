Imports ExampleProg.Interfaces

Namespace InputClasses.Training
    ''' <summary>
    ''' The Demonstration stage of the training section.
    ''' </summary>
    ''' <remarks>Needs to keep track of the question ID and pass it up for the next stage.</remarks>
    Public Class DemonstrationTraining
        Private Property DBConnection As IDbConnector
        Private _subjectID As Integer
        Private _curriculumID As Integer
        Private _keyStageID As Integer
        Private _explanationID As Integer

        Property QuestionID As Integer
        Private _questionsList As IEnumerable(Of Integer)

        Private _demonstrationList As IEnumerable(Of String)
        Property DemonstrationStep As Integer
        Property DemonstrationStepDetails As String
        Property CountOfDemonstrationSteps As Integer

        Property HasDemoStepsBeenSetUp As Boolean

        ''' <summary>
        ''' The constructor.
        ''' </summary>
        ''' <param name="dbConnector">The database connection.</param>
        ''' <remarks>Sets the variables.</remarks>
        Public Sub New(dbConnector As IDbConnector)
            DBConnection = dbConnector
        End Sub

        ''' <summary>
        ''' Initialises the variables.
        ''' </summary>
        ''' <param name="subjectId"></param>
        ''' <param name="curriculumId"></param>
        ''' <param name="keyStageId"></param>
        ''' <param name="explanationId"></param>
        ''' <remarks></remarks>
        Public Sub Initialise(subjectId As Integer, curriculumId As Integer, keyStageId As Integer, explanationId As Integer)
            _subjectID = subjectId
            _curriculumID = curriculumId
            _keyStageID = keyStageId
            _explanationID = explanationId

            HasDemoStepsBeenSetUp = False
        End Sub

        ''' <summary>
        ''' Set the random question id that will be used for the rest of the steps.
        ''' </summary>
        ''' <remarks>Finds the question id for the demo we are going to use.</remarks>
        Public Sub SetRandomQuestionID()
            ' First we need to get a list of question ID's based on the other variables.
            _questionsList = DBConnection.GetListOfQuestionIdsForTraining(_subjectID, _curriculumID, _keyStageID, _explanationID)

            ' Then we need to randomise the list and select only 1.
            Dim randomiser As New Random()
            Dim randomId = randomiser.Next(0, _questionsList.Count())

            ' We then set that to the QuestionID.
            QuestionID = _questionsList.ElementAt(randomId)
        End Sub

        ''' <summary>
        ''' Sets up the demonstration list, steps and details ready for training.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetUpDemoSteps()
            ' Check that QuestionID has been set.
            If (QuestionID > 0) Then
                _demonstrationList = DBConnection.GetListOfDemoStepDetails(QuestionID)
                If (_demonstrationList.Any()) Then
                    CountOfDemonstrationSteps = _demonstrationList.Count()
                    DemonstrationStep = 0
                    DemonstrationStepDetails = _demonstrationList.ElementAt(DemonstrationStep)
                    HasDemoStepsBeenSetUp = True
                End If
            Else
                HasDemoStepsBeenSetUp = False
            End If
        End Sub

        ''' <summary>
        ''' Updating the step details for the next one in the list.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub NextStep()
            If (DemonstrationStep < (CountOfDemonstrationSteps - 1)) Then
                DemonstrationStep = DemonstrationStep + 1
                DemonstrationStepDetails = _demonstrationList.ElementAt(DemonstrationStep)
            End If
        End Sub

        ''' <summary>
        ''' Updating the step details for the previous one in the list.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub PreviousStep()
            If (DemonstrationStep > 0) Then
                DemonstrationStep = DemonstrationStep - 1
                DemonstrationStepDetails = _demonstrationList.ElementAt(DemonstrationStep)
            End If
        End Sub

        ''' <summary>
        ''' Checking to see if we have viewed all of the demo steps.
        ''' </summary>
        ''' <returns>True or False.</returns>
        ''' <remarks></remarks>
        Public Function CanProceed() As Boolean
            Dim result As Boolean
            If (DemonstrationStep = (CountOfDemonstrationSteps - 1)) Then
                result = True
            Else
                result = False
            End If
            Return result
        End Function

    End Class
End Namespace