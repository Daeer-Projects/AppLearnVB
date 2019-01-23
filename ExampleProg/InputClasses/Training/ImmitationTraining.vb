Imports ExampleProg.Interfaces
Imports ExampleProg.ProcedureReturnTypes
Imports System.Text.RegularExpressions

Namespace InputClasses.Training
    ''' <summary>
    ''' The immitation section of training.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ImmitationTraining
        Private ReadOnly _dbConnection As IDbConnector

        Private _questionID As Integer

        Property DemonstrationList As IEnumerable(Of ImmitationStageListType)
        Property DemonstrationStep As Integer
        Property DemonstrationStepDetails As String
        Property DemonstrationStepRegEx As String
        Property DemonstrationStepMark As Integer
        Property CountOfDemonstrationSteps As Integer
        Property HasDemoStepsBeenSetUp As Boolean

        Property DemoInput As String
        Property IsDemoInputCorrect As Boolean

        Property HasImmitationBeenCompleted As Boolean

        ''' <summary>
        ''' The basic constructor.
        ''' </summary>
        ''' <param name="dbConnection">The db connection.</param>
        ''' <remarks></remarks>
        Public Sub New(dbConnection As IDbConnector)
            _dbConnection = dbConnection
            HasImmitationBeenCompleted = False
        End Sub

        ''' <summary>
        ''' Gets the demo steps for the immitation stage.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub GetDemonstrationList(questionID As Integer)
            _questionID = questionID
            If (_questionID > 0) Then
                _DemonstrationList = _dbConnection.GetImmitationStageSteps(_questionID)
                HasDemoStepsBeenSetUp = SetImmitationStage()
            Else
                HasDemoStepsBeenSetUp = False
            End If
        End Sub

        ''' <summary>
        ''' Sets the items from the entry in the list.
        ''' </summary>
        ''' <returns>If possible, it returns true, else false.</returns>
        ''' <remarks></remarks>
        Private Function SetImmitationStage() As Boolean
            Dim result As Boolean
            If (_demonstrationList.Any()) Then
                CountOfDemonstrationSteps = _demonstrationList.Count()
                DemonstrationStep = 0
                SetImmitationValues(DemonstrationStep)
                result = True
            Else
                result = False
            End If
            Return result
        End Function

        ''' <summary>
        ''' Processes the input from the user.
        ''' </summary>
        ''' <param name="userInput">The string input from the user.</param>
        ''' <remarks></remarks>
        Public Sub ProcessInput(userInput As String)
            DemoInput = userInput
            If (HasDemoStepsBeenSetUp) Then
                IsDemoInputCorrect = Regex.IsMatch(DemoInput, DemonstrationStepRegEx)
                If (IsDemoInputCorrect) Then
                    NextStep()
                End If
            End If
        End Sub

        ''' <summary>
        ''' Sets up the next step of immitation.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub NextStep()
            If (DemonstrationStep < (CountOfDemonstrationSteps - 1)) Then
                DemonstrationStep = DemonstrationStep + 1
                SetImmitationValues(DemonstrationStep)
            Else
                HasImmitationBeenCompleted = True
            End If
        End Sub

        ''' <summary>
        ''' Sets up the items based on the current step.
        ''' </summary>
        ''' <param name="currentStep">The specific step in the list.</param>
        ''' <remarks></remarks>
        Private Sub SetImmitationValues(currentStep As Integer)
            DemonstrationStepDetails = _demonstrationList.ElementAt(currentStep).DescriptionOfStage
            DemonstrationStepRegEx = _demonstrationList.ElementAt(currentStep).RegEx
            DemonstrationStepMark = _demonstrationList.ElementAt(currentStep).StageMark
        End Sub

    End Class
End Namespace