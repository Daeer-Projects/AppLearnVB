Namespace Constants
    ''' <summary>
    ''' The Database Constants that are used throughout the application.
    ''' Namely the stored procedure names used in the database.
    ''' </summary>
    ''' <remarks>Database Constants.</remarks>
    Public Class DatabaseConstants
        Public Const ApplicationConfigString = "AppConnect"

        Public Const DBConnecting = "Connecting..."
        Public Const DBFailedToConnect = "Failed."
        Public Const DBConnectedSuccesful = "Success."
        Public Const TestDBConnection = "users.TestConnection"

        Public Const CheckIfUserIsAvailble = "users.CheckIfUserIsAvailable"
        Public Const CheckIfUserIsInDatabase = "users.CheckIfUserIsInDatabase"
        Public Const ValidateUser = "users.ValidateUser"
        Public Const GetUserDetails = "users.GetUserDetails"
        Public Const CreateANewUser = "users.CreateNewUser"

        Public Const GetTheListOfSubjects = "curriculum.GetListOfSubjects"
        Public Const GetTheListOfCurriculums = "curriculum.GetListOfCurriculum"
        Public Const GetTheListOfKeyStages = "curriculum.GetListOfKeyStages"
        Public Const GetTheListOfExplanations = "curriculum.GetListOfExplanations"
        Public Const GetTheFilteredListOfCurriculums = "curriculum.GetFilteredListOfCurriculum"
        Public Const GetTheFilteredListOfExplanationsBySubject = "curriculum.GetFilteredListOfExplanationsBySubject"
        Public Const GetTheFilteredListOfExplanationsByCurriculum = "curriculum.GetFilteredListOfExplanationsByCurriculum"

        Public Const GetExplanationDescription = "curriculum.GetExplanationDetails"

        Public Const InsertNewSubject = "curriculum.InsertNewSubject"
        Public Const InsertNewCurriculum = "curriculum.InsertNewCurriculum"
        Public Const InsertNewKeyStage = "curriculum.InsertNewKeyStage"
        Public Const InsertNewExplanation = "curriculum.InsertNewExplanation"

        Public Const InsertNewQuestion = "questions.InsertNewQuestion"
        Public Const InsertNewDemoSteps = "questions.InsertNewDemonstrationStep"

        Public Const GetTrainingExplanationDetails = "questions.GetTrainingExplanationDetails"
        Public Const GetTrainingListOfQuestionIds = "questions.GetListOfQuestionIds"

        Public Const GetTrainingDemonstrationStepDetails = "questions.GetTrainingDemoStepDetailsList"
        Public Const GetFullTrainingImmitationSteps = "questions.GetImmitationSteps"

        Public Const GetTrainingQuestionDetail = "questions.GetTrainingQuestionDetail"
    End Class
End Namespace