Imports ExampleProg.Constants
Imports ExampleProg.ProcedureReturnTypes

Namespace InputClasses.NewQuestionTypes
    ''' <summary>
    ''' The curriculum type input class.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CurriculumTypeInput

        Property CurriculumID As Integer
        Property CurriculumText As String

        Property IsNewCurriculum As Boolean
        Property InvalidMessage As String
        Property CanProceed As Boolean

        Property CurriculumList As IEnumerable(Of CurriculumListType)

        ''' <summary>
        ''' The processor for the class.
        ''' Declares the variables.
        ''' Sets the flags and messages.
        ''' </summary>
        ''' <param name="text"></param>
        ''' <remarks></remarks>
        Public Sub Process(text As String)
            CurriculumText = text

            CurriculumID = 0
            IsNewCurriculum = False
            InvalidMessage = String.Empty
            CanProceed = False

            SetCurriculumAndMessageFlags()
            SetCurriculumID()
        End Sub

        ''' <summary>
        ''' Sets the flags.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetCurriculumAndMessageFlags()
            CanProceed = Helpers.Helpers.IsTextNotNull(CurriculumText)
            InvalidMessage = If(CanProceed, String.Empty, CommonConstants.NotAValidInput)
        End Sub

        ''' <summary>
        ''' Sets the curriculum id.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetCurriculumID()
            CurriculumID = (From curriculum In CurriculumList
                Where curriculum.CurriculumDetails.ToLower().Equals(CurriculumText.ToLower())
                Select curriculum.ID).FirstOrDefault()

            If (CurriculumID = 0) Then
                IsNewCurriculum = True
            End If
        End Sub
    End Class
End Namespace