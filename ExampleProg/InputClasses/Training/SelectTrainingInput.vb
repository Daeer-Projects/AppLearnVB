Imports ExampleProg.Interfaces
Imports ExampleProg.ProcedureReturnTypes

Namespace InputClasses.Training
    ''' <summary>
    ''' Select the training from the list of options.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SelectTrainingInput
        Implements ISelectTrainingInput

        Property SubjectList As IEnumerable(Of SubjectListType) Implements ISelectTrainingInput.SubjectList
        Property CurriculumList As IEnumerable(Of CurriculumListType) Implements ISelectTrainingInput.CurriculumList
        Property KeyStageList As IEnumerable(Of KeyStageListType) Implements ISelectTrainingInput.KeyStageList
        Property ExplanationList As IEnumerable(Of ExplanationListType) Implements ISelectTrainingInput.ExplanationList
        Private Property DBConnection As IDbConnector

        Property SelectedSubjectID As Integer Implements ISelectTrainingInput.SelectedSubjectID
        Property SelectedCurriculumID As Integer Implements ISelectTrainingInput.SelectedCurriculumID
        Property SelectedKeyStageID As Integer Implements ISelectTrainingInput.SelectedKeyStageID
        Property SelectedExplanationID As Integer Implements ISelectTrainingInput.SelectedExplanationID

        Property SelectedSubjectText As String Implements ISelectTrainingInput.SelectedSubjectText
        Property SelectedCurriculumText As String Implements ISelectTrainingInput.SelectedCurriculumText
        Property SelectedKeyStageText As String Implements ISelectTrainingInput.SelectedKeyStageText
        Property SelectedExplanationText As String Implements ISelectTrainingInput.SelectedExplanationText

        ''' <summary>
        ''' The basic constructor.
        ''' </summary>
        ''' <param name="dbConnector"></param>
        ''' <remarks></remarks>
        Public Sub New(dbConnector As IDbConnector)
            DBConnection = dbConnector
            InitialiseVariables()
            PopulateSubjectList()
            PopulateKeyStageList()
        End Sub

        ''' <summary>
        ''' Initalises all the variables.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub InitialiseVariables()
            SelectedSubjectID = 0
            SelectedCurriculumID = 0
            SelectedKeyStageID = 0
            SelectedExplanationID = 0
        End Sub


#Region "Set up lists"
        ''' <summary>
        ''' Gets the list of subjects from the database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub PopulateSubjectList() Implements ISelectTrainingInput.PopulateSubjectList
            SubjectList = DBConnection.GetListOfSubjects()
        End Sub

        ''' <summary>
        ''' Gets the list of curriculum from the database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub PopulateCurriculumList() Implements ISelectTrainingInput.PopulateCurriculumList
            CurriculumList = DBConnection.GetListOfCurriculum()
        End Sub

        ''' <summary>
        ''' Gets the list of key stages from the database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub PopulateKeyStageList() Implements ISelectTrainingInput.PopulateKeyStageList
            KeyStageList = DBConnection.GetListOfKeyStages()
        End Sub

        ''' <summary>
        ''' Gets the list of explanations from the database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub PopulateExplanationList() Implements ISelectTrainingInput.PopulateExplanationList
            ExplanationList = DBConnection.GetListOfExplanations()
        End Sub

        ''' <summary>
        ''' Gets the updated curriculum list from the subject selected.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub PopulateUpdatedCurriculumList() Implements ISelectTrainingInput.PopulateUpdatedCurriculumList
            CurriculumList = DBConnection.GetUpdatedListOfCurriculum(SelectedSubjectID)
        End Sub

        ''' <summary>
        ''' Gets the updated explanation list from the curriculum selected.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub PopulateUpdatedExplanationList() Implements ISelectTrainingInput.PopulateUpdatedExplanationList
            ExplanationList = DBConnection.GetUpdatedExplanationsByCurriculum(SelectedCurriculumID)
        End Sub
#End Region

#Region "Set ID's"
        ''' <summary>
        ''' Sets the subject id from the details in the database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetSubjectID() Implements ISelectTrainingInput.SetSubjectID
            SelectedSubjectID = (From subject In SubjectList
                Where subject.SubjectDetail.ToLower().Equals(SelectedSubjectText.ToLower())
                Select subject.ID).FirstOrDefault()
        End Sub

        ''' <summary>
        ''' Sets the curriculum id from the details in the database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetCurriculumID() Implements ISelectTrainingInput.SetCurriculumID
            SelectedCurriculumID = (From curric In CurriculumList
                                    Where curric.CurriculumDetails.ToLower().Equals(SelectedCurriculumText.ToLower())
                                    Select curric.ID).FirstOrDefault()
        End Sub

        ''' <summary>
        ''' Sets the key stage id from the details in the database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetKeyStageID() Implements ISelectTrainingInput.SetKeyStageID
            SelectedKeyStageID = (From keyStage In KeyStageList
                        Where keyStage.KeyStageDetail.ToLower().Equals(SelectedKeyStageText.ToLower())
                        Select keyStage.ID).FirstOrDefault()
        End Sub

        ''' <summary>
        ''' Sets the explanation id from the details in the database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetExplanationID() Implements ISelectTrainingInput.SetExplanationID
            SelectedExplanationID = (From explanation In ExplanationList
            Where explanation.ExplanationDetail.ToLower().Equals(SelectedExplanationText.ToLower())
            Select explanation.ID).FirstOrDefault()
        End Sub
#End Region

    End Class
End Namespace