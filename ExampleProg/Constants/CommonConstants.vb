Namespace Constants
    ''' <summary>
    ''' A collection of constants that are used throughout the application.
    ''' </summary>
    ''' <remarks>Constants.</remarks>
    Public Class CommonConstants
        Public Const NotAValidInput = "A value is required."
        Public Const NotAValidInteger = "A number is required."
        Public Const UserAlreadyExists = "That user name already exists."
        Public Const UserIsAvailable = "That user name is available."
        Public Const UserNameAndPasswordDoNotMatch = "User name or password are not recognized."

        Public Const ValidWebAddresRegEx = "((https?://|www\.)([-\w\.]+)+(:\d+)?(/([\w/_\.]*(\?\S+)?)?)?)"
        Public Const WebAddressNotValid = "The web address entered is not of a recognized standard."
        
        Public Const InsertNewQuestionError = "The question was not inserted due to problems with the subject, curriculum, keystage or explanation."
        Public Const InsertNewDemoStepError = "The demonstration step was not inserted."

        Public Const NewQuestionInsertedCorrectly = "The new question has been inserted."

        Public Const TrainingExplanationIdNotSuppliedError = "An explanation was not suppied.  No details are available."
        Public Const TrainingPracticeQuestionIdNoSuppliedError = "A question id must be supplied."

    End Class
End Namespace