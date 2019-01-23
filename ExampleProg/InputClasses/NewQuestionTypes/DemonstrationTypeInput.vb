Imports ExampleProg.Classes
Imports ExampleProg.Constants
Imports Regextra

Namespace InputClasses.NewQuestionTypes
    ''' <summary>
    ''' The Demonstration Type Input class.
    ''' Does all of the validation for the demo steps.
    ''' Collects and maintains a list of the demo steps.
    ''' </summary>
    ''' <remarks>The Demo Step.</remarks>
    Public Class DemonstrationTypeInput
        Private _demonstrationDetails As String
        Private _demonstrationStepMark As Integer
        Property DemonstrationTotalMarks As Integer

        Property RegExDetails As String
        Property AmountOfSteps As Integer

        Property DemonstrationList As List(Of DemonstrationStep)

        Property IsValidDemoDetails As Boolean
        Property InvalidDemoDetailsMessage As String
        Property IsValidRegExDetails As Boolean
        Property InvalidRegExDetailsMessage As String
        Property IsValidMark As Boolean
        Property InvalidMarkMessage As String

        Property CanInsertDetailsToList As Boolean

        ''' <summary>
        ''' Resets the values to their defaults.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ResetValuesToDefaults()
            _demonstrationDetails = String.Empty
            RegExDetails = String.Empty
            _demonstrationStepMark = 0

            DemonstrationList = New List(Of DemonstrationStep)
            AmountOfSteps = DemonstrationList.Count

            IsValidDemoDetails = False
            IsValidRegExDetails = False
            InvalidDemoDetailsMessage = String.Empty
            InvalidRegExDetailsMessage = String.Empty
        End Sub

        ''' <summary>
        ''' Gets the demonstration details.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDemoDetails() As String
            Return _demonstrationDetails
        End Function

        ''' <summary>
        ''' Inserts the next step details.String`
        ''' </summary>
        ''' <param name="demoDetails"></param>
        ''' <remarks></remarks>
        Public Sub InsertNextStepDetails(demoDetails As String)
            _demonstrationDetails = demoDetails
            IsValidDemoDetails = Helpers.IsTextNotNull(_demonstrationDetails)
            InvalidDemoDetailsMessage = If(IsValidDemoDetails, String.Empty, CommonConstants.NotAValidInput)
        End Sub

        ''' <summary>
        ''' Sets the reg ex for the demonstration step.
        ''' Uses a third party plug in to generate the reg ex.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetRegEx()
            RegExDetails = PassphraseRegex.That.IncludesText(_demonstrationDetails).ToRegex().Pattern
            SetRegExFlags()
        End Sub

        ''' <summary>
        ''' Updates the reg ex if the user prefers a different pattern.
        ''' </summary>
        ''' <param name="newRegEx"></param>
        ''' <remarks></remarks>
        Public Sub UpdateRegEx(newRegEx As String)
            RegExDetails = newRegEx
            SetRegExFlags()
        End Sub

        ''' <summary>
        ''' Insert the mark for the step.
        ''' </summary>
        ''' <param name="mark"></param>
        ''' <remarks></remarks>
        Public Sub InsertMark(mark As String)
            IsValidMark = Integer.TryParse(mark, _demonstrationStepMark)
            InvalidMarkMessage = If(IsValidMark, String.Empty, CommonConstants.NotAValidInteger)
            SetCanInsert()
        End Sub

        ''' <summary>
        ''' Sets the reg ex flags.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetRegExFlags()
            IsValidRegExDetails = Helpers.IsTextNotNull(RegExDetails)
            InvalidRegExDetailsMessage = If(IsValidRegExDetails, String.Empty, CommonConstants.NotAValidInput)
        End Sub

        ''' <summary>
        ''' Sets the can insert flag if all is okay.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetCanInsert()
            Dim arrayOfIsValidTypes(2) As Boolean
            arrayOfIsValidTypes(0) = IsValidDemoDetails
            arrayOfIsValidTypes(1) = IsValidRegExDetails
            arrayOfIsValidTypes(2) = IsValidMark
            CanInsertDetailsToList = Helpers.IsThereAFalseInArray(arrayOfIsValidTypes)
        End Sub

        ''' <summary>
        ''' Adds the new details to the list.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AddDetailsToList() As Boolean
            Dim result As Boolean
            Dim demoStep = New DemonstrationStep
            If (CanInsertDetailsToList) Then
                demoStep.StepDetails = _demonstrationDetails
                demoStep.StepRegEx = RegExDetails
                demoStep.StepMark = _demonstrationStepMark

                DemonstrationList.Add(demoStep)
                AmountOfSteps = DemonstrationList.Count
                DemonstrationTotalMarks += _demonstrationStepMark

                result = True
            Else
                result = False
            End If

            Return result
        End Function

        ''' <summary>
        ''' Deletes the selected step.
        ''' </summary>
        ''' <param name="stepDetail"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function RemoveStepFromList(stepDetail As String) As Boolean
            Dim result = False

            ' Check the count.
            AmountOfSteps = DemonstrationList.Count

            ' Delete the step.
            DemonstrationList = DemonstrationList _
                                .Where(Function(item) item.StepDetails <> stepDetail) _
                                .ToList()

            If (DemonstrationList.Count < AmountOfSteps) Then
                result = True
                ' Reset the count of steps.
                AmountOfSteps = DemonstrationList.Count
            End If

            Return result
        End Function

    End Class
End Namespace