Imports ExampleProg.ProcedureReturnTypes

Namespace Interfaces
    ''' <summary>
    ''' The Select Training Input Interface.
    ''' </summary>
    ''' <remarks>Select Training Interface.</remarks>
    Public Interface ISelectTrainingInput
        Property SubjectList As IEnumerable(Of SubjectListType)
        Property CurriculumList As IEnumerable(Of CurriculumListType)
        Property KeyStageList As IEnumerable(Of KeyStageListType)
        Property ExplanationList As IEnumerable(Of ExplanationListType)

        Property SelectedSubjectID As Integer
        Property SelectedCurriculumID As Integer
        Property SelectedKeyStageID As Integer
        Property SelectedExplanationID As Integer

        Property SelectedSubjectText As String
        Property SelectedCurriculumText As String
        Property SelectedKeyStageText As String
        Property SelectedExplanationText As String

        Sub PopulateSubjectList()
        Sub PopulateCurriculumList()
        Sub PopulateKeyStageList()
        Sub PopulateExplanationList()
        
        Sub PopulateUpdatedCurriculumList()
        Sub PopulateUpdatedExplanationList()

        Sub SetSubjectID()
        Sub SetCurriculumID()
        Sub SetKeyStageID()
        Sub SetExplanationID()

    End Interface
End Namespace