Imports ExampleProg.Constants
Imports ExampleProg.ProcedureReturnTypes

Namespace InputClasses.NewQuestionTypes
    ''' <summary>
    ''' The new subject type input class.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SubjectTypeInput

        Property SubjectID As Integer
        Property SubjectText As String

        Property IsNewSubject As Boolean
        Property InvalidMessage As String
        Property CanProceed As Boolean

        Property SubjectList As IEnumerable(Of SubjectListType)

        ''' <summary>
        ''' The processor for the class.
        ''' Declares the variables.
        ''' Calls the methods to set it up.
        ''' </summary>
        ''' <param name="text"></param>
        ''' <remarks></remarks>
        Public Sub Process(text As String)
            SubjectText = text

            SubjectID = 0
            IsNewSubject = False
            InvalidMessage = String.Empty
            CanProceed = False

            SetSubjectAndMessageFlags()
            SetSubjectID()
        End Sub

        ''' <summary>
        ''' Sets the falgs.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetSubjectAndMessageFlags()
            CanProceed = Helpers.Helpers.IsTextNotNull(SubjectText)
            InvalidMessage = If(CanProceed, String.Empty, CommonConstants.NotAValidInput)
        End Sub

        ''' <summary>
        ''' Sets the subject id from the details in the database.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetSubjectID()
            SubjectID = (From subject In SubjectList
                Where subject.SubjectDetail.ToLower().Equals(SubjectText.ToLower())
                Select subject.ID).FirstOrDefault()

            If (SubjectID = 0) Then
                IsNewSubject = True
            End If
        End Sub
    End Class
End Namespace