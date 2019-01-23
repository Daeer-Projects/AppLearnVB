Imports ExampleProg.InputClasses.NewQuestionTypes

Namespace Interfaces
    ''' <summary>
    ''' The New Question Input Interface.
    ''' </summary>
    ''' <remarks>New Question Input Interface.</remarks>
    Public Interface INewQuestionInput
        Property SubjectType As SubjectTypeInput
        Property CurriculumType As CurriculumTypeInput
        Property KeyStageType As KeyStageTypeInput
        Property ExplanationType As ExplanationTypeInput
        Property QuestionType As QuestionTypeInput
        Property AnswerType As AnswerTypeInput
        Property DemonstrationType As DemonstrationTypeInput
        Property CanSubmit As Boolean
        Property NewQuestionInsertMessage As String
        Property InsertedSuccessfully As Boolean

        Sub SetListsFromDatabase()
        Sub UpdateOtherLists()
        Sub UpdateExplanation()
        Sub Process()
        Sub InsertNewQuestion()
    End Interface
End Namespace