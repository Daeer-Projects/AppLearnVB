Imports ExampleProg.Constants

Namespace InputClasses.NewQuestionTypes
    ''' <summary>
    ''' The answer type input process.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class AnswerTypeInput
        Property CorrectAnswer As String
        Property InCorrectAnswerA As String
        Property InCorrectAnswerB As String
        Property InCorrectAnswerC As String

        Property InvalidCorrectAnswerMessage As String
        Property InvalidInCorrectAnswerAMessage As String
        Property InvalidInCorrectAnswerBMessage As String
        Property InvalidInCorrectAnswerCMessage As String

        Property IsValidCorrectAnswer As Boolean
        Property IsValidInCorrectAnswerA As Boolean
        Property IsValidInCorrectAnswerB As Boolean
        Property IsValidInCorrectAnswerC As Boolean

        Property CanProceed As Boolean

        ''' <summary>
        ''' The processor for the class.
        ''' Declars and sets up all the variables.
        ''' Sets the flags and messages based upon the values passed in.
        ''' </summary>
        ''' <param name="answer"></param>
        ''' <param name="wrongAnswerA"></param>
        ''' <param name="wrongAnswerB"></param>
        ''' <param name="wrongAnswerC"></param>
        ''' <remarks></remarks>
        Public Sub Process(answer As String, wrongAnswerA As String, wrongAnswerB As String, wrongAnswerC As String)
            CorrectAnswer = answer
            InCorrectAnswerA = wrongAnswerA
            InCorrectAnswerB = wrongAnswerB
            InCorrectAnswerC = wrongAnswerC

            InvalidCorrectAnswerMessage = String.Empty
            InvalidInCorrectAnswerAMessage = String.Empty
            InvalidInCorrectAnswerBMessage = String.Empty
            InvalidInCorrectAnswerCMessage = String.Empty

            IsValidCorrectAnswer = False
            IsValidInCorrectAnswerA = False
            IsValidInCorrectAnswerB = False
            IsValidInCorrectAnswerC = False

            SetValidTextFlags()
            SetInvalidMessages()
            SetCanProceed()
        End Sub

        ''' <summary>
        ''' Sets the valid flags.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetValidTextFlags()
            IsValidCorrectAnswer = Helpers.IsTextNotNull(CorrectAnswer)
            IsValidInCorrectAnswerA = Helpers.IsTextNotNull(InCorrectAnswerA)
            IsValidInCorrectAnswerB = Helpers.IsTextNotNull(InCorrectAnswerB)
            IsValidInCorrectAnswerC = Helpers.IsTextNotNull(InCorrectAnswerC)
        End Sub

        ''' <summary>
        ''' Sets the invalid messages.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetInvalidMessages()
            InvalidCorrectAnswerMessage = If(IsValidCorrectAnswer, String.Empty, CommonConstants.NotAValidInput)
            InvalidInCorrectAnswerAMessage = If(IsValidInCorrectAnswerA, String.Empty, CommonConstants.NotAValidInput)
            InvalidInCorrectAnswerBMessage = If(IsValidInCorrectAnswerB, String.Empty, CommonConstants.NotAValidInput)
            InvalidInCorrectAnswerCMessage = If(IsValidInCorrectAnswerC, String.Empty, CommonConstants.NotAValidInput)
        End Sub

        ''' <summary>
        ''' Sets the can proceed flag if all is okay.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetCanProceed()
            Dim arrayOfFlags(3) As Boolean
            arrayOfFlags(0) = IsValidCorrectAnswer
            arrayOfFlags(1) = IsValidInCorrectAnswerA
            arrayOfFlags(2) = IsValidInCorrectAnswerB
            arrayOfFlags(3) = IsValidInCorrectAnswerC
            CanProceed = Helpers.IsThereAFalseInArray(arrayOfFlags)
        End Sub
    End Class
End Namespace