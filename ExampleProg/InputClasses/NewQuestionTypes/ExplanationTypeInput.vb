Imports ExampleProg.Constants
Imports ExampleProg.Interfaces
Imports ExampleProg.ProcedureReturnTypes

Namespace InputClasses.NewQuestionTypes

    ''' <summary>
    ''' The explanation type input.
    ''' For validating all of the explanation details entered by the user.
    ''' </summary>
    ''' <remarks>For validating the explanations.</remarks>
    Public Class ExplanationTypeInput
        Private ReadOnly _dbConnector As IDbConnector

        Property ExplanationID As Integer
        Property ExplanationTitle As String
        Property ExplanationText As String

        Property IsNewExplanation As Boolean
        Private Property IsValidTitle As Boolean
        Private Property IsValidDetail As Boolean
        Property InvalidTitleMessage As String
        Property InvalidDetailMessage As String
        Property CanProceed As Boolean

        Property ExplanationList As IEnumerable(Of ExplanationListType)

        ''' <summary>
        ''' The basic constructor.
        ''' </summary>
        ''' <param name="dbConnector"></param>
        ''' <remarks></remarks>
        Public Sub New(dbConnector As IDbConnector)
            _dbConnector = dbConnector
            ExplanationList = _dbConnector.GetListOfExplanations()
        End Sub

        ''' <summary>
        ''' The processor for the class.
        ''' </summary>
        ''' <param name="title"></param>
        ''' <param name="text"></param>
        ''' <remarks></remarks>
        Public Sub Process(title As String, text As String)
            ExplanationTitle = title

            ExplanationID = 0
            ExplanationText = text
            IsNewExplanation = False
            IsValidDetail = False
            IsValidTitle = False
            InvalidTitleMessage = String.Empty
            InvalidDetailMessage = String.Empty
            CanProceed = False

            SetExplanationTitleFlags()
            SetExplanationID()
            SetExplanationDetails()
            SetExplanationValidFlags()
            SetMessageFlags()
        End Sub

        ''' <summary>
        ''' Sets the title flag.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetExplanationTitleFlags()
            IsValidTitle = Helpers.IsTextNotNull(ExplanationTitle)
        End Sub

        ''' <summary>
        ''' Sets the explanation id from the explanation set.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetExplanationID()
            ExplanationID = (From explan In ExplanationList
                Where explan.ExplanationDetail.ToLower().Equals(ExplanationTitle.ToLower())
                Select explan.ID).FirstOrDefault()

            If (ExplanationID = 0) Then
                IsNewExplanation = True
            End If
        End Sub

        ''' <summary>
        ''' Sets the details for the explantion from the details in the database.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetExplanationDetails()
            If Not (IsNewExplanation) Then
                ExplanationText = _dbConnector.GetExplanationDetailsById(ExplanationID)
            End If
        End Sub

        ''' <summary>
        ''' Sets the explanation valid flags.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetExplanationValidFlags()
            IsValidDetail = Helpers.IsTextNotNull(ExplanationText)
            Dim arrayOfIsValidTypes(1) As Boolean
            arrayOfIsValidTypes(0) = IsValidTitle
            arrayOfIsValidTypes(1) = IsValidDetail
            CanProceed = Helpers.IsThereAFalseInArray(arrayOfIsValidTypes)
        End Sub

        ''' <summary>
        ''' Sets the message flags.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetMessageFlags()
            InvalidTitleMessage = If(IsValidTitle, String.Empty, CommonConstants.NotAValidInput)
            InvalidDetailMessage = If(IsValidDetail, String.Empty, CommonConstants.NotAValidInput)
        End Sub
    End Class

End Namespace