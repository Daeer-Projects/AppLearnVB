Imports ExampleProg.Constants
Imports ExampleProg.ProcedureReturnTypes

Namespace InputClasses.NewQuestionTypes
    ''' <summary>
    ''' The key stage input class for inserting a new key stage.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class KeyStageTypeInput

        Property KeyStageID As Integer
        Property KeyStageText As String

        Property IsNewKeyStage As Boolean
        Property InvalidMessage As String
        Property CanProceed As Boolean

        Property KeyStageList As IEnumerable(Of KeyStageListType)

        ''' <summary>
        ''' The processor for the class.
        ''' </summary>
        ''' <param name="text"></param>
        ''' <remarks></remarks>
        Public Sub Process(text As String)
            KeyStageText = text

            KeyStageID = 0
            IsNewKeyStage = False
            InvalidMessage = String.Empty
            CanProceed = False

            SetKeyStageAndMessageFlags()
            SetKeyStageID()
        End Sub

        ''' <summary>
        ''' Sets the message flags.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetKeyStageAndMessageFlags()
            CanProceed = Helpers.Helpers.IsTextNotNull(KeyStageText)
            InvalidMessage = If(CanProceed, String.Empty, CommonConstants.NotAValidInput)
        End Sub

        ''' <summary>
        ''' Sets the key stage id from the key stage details in the database.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetKeyStageID()
            KeyStageID = (From keystage In KeyStageList
                Where keystage.KeyStageDetail.ToLower().Equals(KeyStageText.ToLower())
                Select keystage.ID).FirstOrDefault()

            If (KeyStageID = 0) Then
                IsNewKeyStage = True
            End If
        End Sub
    End Class
End Namespace