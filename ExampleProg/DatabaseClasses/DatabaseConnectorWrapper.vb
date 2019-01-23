Imports Dapper
Imports DapperWrapper
Imports ExampleProg.Classes
Imports ExampleProg.Constants
Imports ExampleProg.Interfaces
Imports ExampleProg.ProcedureReturnTypes
Imports ExampleProg.QuestionTypes

Namespace DatabaseClasses
    ''' <summary>
    ''' The Database Connector Wrapper.
    ''' All the calls to the database go through this class.
    ''' It wraps the Dapper Factory, to keep the database access to one single point.
    ''' </summary>
    ''' <remarks>Database Connection.</remarks>
    Public Class DatabaseConnectorWrapper
        Implements IDbConnector

        Private ReadOnly _dbExecutorFactory As IDbExecutorFactory
        Private _databaseConnectionStatus As String

        ''' <summary>
        ''' The basic constructor.
        ''' </summary>
        ''' <param name="dbExecutorFactory"></param>
        ''' <remarks></remarks>
        Public Sub New(dbExecutorFactory As IDbExecutorFactory)
            _dbExecutorFactory = dbExecutorFactory
            TestDatabaseConnection()
        End Sub

        ''' <summary>
        ''' A simple check for the db connection.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub TestDatabaseConnection()
            Dim result As Boolean
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                result = db.Query(Of Boolean)(DatabaseConstants.TestDBConnection, commandType:=CommandType.StoredProcedure).FirstOrDefault()
            Catch ex As Exception
                result = False
            End Try
            _databaseConnectionStatus = If(result, DatabaseConstants.DBConnectedSuccesful, DatabaseConstants.DBFailedToConnect)
        End Sub

        ''' <summary>
        ''' Gets the db connection status.
        ''' </summary>
        ''' <returns>True or false.</returns>
        ''' <remarks></remarks>
        Public Function DBConnectionStatus() As String Implements IDbConnector.DBConnectionStatus
            Return _databaseConnectionStatus
        End Function

#Region "UserConnections"

        ''' <summary>
        ''' DB script to check if the user name is availble.
        ''' </summary>
        ''' <param name="userName"></param>
        ''' <returns>True or false.</returns>
        ''' <remarks></remarks>
        Public Function IsUserNameAvailable(userName As String) As Boolean Implements IDbConnector.IsUserNameAvailable
            Dim result As Boolean
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@UserName", userName)

                result = db.Query(Of Boolean)(DatabaseConstants.CheckIfUserIsAvailble, dynamicParameters, commandType:=CommandType.StoredProcedure).FirstOrDefault()
            Catch ex As Exception
                result = False
            End Try
            Return result
        End Function

        ''' <summary>
        ''' DB check if the user name already exists.
        ''' </summary>
        ''' <param name="userName"></param>
        ''' <returns>True or false.</returns>
        ''' <remarks></remarks>
        Public Function DoesUserNameAlreadyExists(userName As String) As Boolean Implements IDbConnector.DoesUserNameAlreadyExists
            Dim result As Boolean
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@UserName", userName)

                result = db.Query(Of Boolean)(DatabaseConstants.CheckIfUserIsInDatabase, dynamicParameters, commandType:=CommandType.StoredProcedure).FirstOrDefault()
            Catch ex As Exception
                result = False
            End Try
            Return result
        End Function

        ''' <summary>
        ''' DB get for the user id.
        ''' </summary>
        ''' <param name="userName"></param>
        ''' <param name="password"></param>
        ''' <returns>The id of the user from the details.</returns>
        ''' <remarks></remarks>
        Public Function GetUserIdOfValidUser(userName As String, password As String) As Integer Implements IDbConnector.GetUserIdOfValidUser
            Dim userId As Integer
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@UserName", userName)
                dynamicParameters.Add("@Password", password)

                userId = db.Query(Of Integer)(DatabaseConstants.ValidateUser, dynamicParameters, commandType:=CommandType.StoredProcedure).FirstOrDefault()
            Catch ex As Exception
                userId = -1
            End Try
            Return userId
        End Function

        ''' <summary>
        ''' DB get for the full user details.
        ''' </summary>
        ''' <param name="user"></param>
        ''' <returns>The user.</returns>
        ''' <remarks></remarks>
        Public Function GetUserDetails(user As IUserClass) As UserClass Implements IDbConnector.GetUserDetails
            Try

                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@UserID", user.UserId)

                user = db.Query(Of UserClass)(DatabaseConstants.GetUserDetails, dynamicParameters, commandType:=CommandType.StoredProcedure).FirstOrDefault()
            Catch ex As Exception
                user = New UserClass
            End Try
            Return CType(user, UserClass)
        End Function

        ''' <summary>
        ''' DB create a new user in the database.
        ''' </summary>
        ''' <param name="user"></param>
        ''' <returns>True or false.</returns>
        ''' <remarks></remarks>
        Public Function CreateNewUser(user As IUserClass) As Boolean Implements IDbConnector.CreateNewUser
            ' Validation for all of the values here are done in the NewUserInput class.
            Dim success As Boolean
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@UserName", user.UserName)
                dynamicParameters.Add("@Password", user.Password)
                dynamicParameters.Add("@FirstName", user.FirstName)
                dynamicParameters.Add("@MiddleName", user.MiddleName)
                dynamicParameters.Add("@LastName", user.LastName)

                db.Execute(DatabaseConstants.CreateANewUser, dynamicParameters, commandType:=CommandType.StoredProcedure)

                success = True
            Catch ex As Exception
                success = False
            End Try

            Return success
        End Function

#End Region

#Region "Insert Question"

        ''' <summary>
        ''' DB get - gets the list of subjects in the database.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetListOfSubjects() As IEnumerable(Of SubjectListType) Implements IDbConnector.GetListOfSubjects
            Dim list As IEnumerable(Of SubjectListType)
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                list = db.Query(Of SubjectListType)(DatabaseConstants.GetTheListOfSubjects, commandType:=CommandType.StoredProcedure)
            Catch ex As Exception
                list = New List(Of SubjectListType)
            End Try
            Return list
        End Function

        ''' <summary>
        ''' DB get - gets the list of curriculums in the database.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetListOfCurriculum() As IEnumerable(Of CurriculumListType) Implements IDbConnector.GetListOfCurriculum
            Dim list As IEnumerable(Of CurriculumListType)
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                list = db.Query(Of CurriculumListType)(DatabaseConstants.GetTheListOfCurriculums, commandType:=CommandType.StoredProcedure)
            Catch ex As Exception
                list = New List(Of CurriculumListType)
            End Try
            Return list
        End Function

        ''' <summary>
        ''' DB get - gets the list of key stages in the database.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetListOfKeyStages() As IEnumerable(Of KeyStageListType) Implements IDbConnector.GetListOfKeyStages
            Dim list As IEnumerable(Of KeyStageListType)
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                list = db.Query(Of KeyStageListType)(DatabaseConstants.GetTheListOfKeyStages, commandType:=CommandType.StoredProcedure)
            Catch ex As Exception
                list = New List(Of KeyStageListType)
            End Try
            Return list
        End Function

        ''' <summary>
        ''' DB get - gets the list of explanations in the database.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetListOfExplanations() As IEnumerable(Of ExplanationListType) Implements IDbConnector.GetListOfExplanations
            Dim list As IEnumerable(Of ExplanationListType)
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                list = db.Query(Of ExplanationListType)(DatabaseConstants.GetTheListOfExplanations, commandType:=CommandType.StoredProcedure)
            Catch ex As Exception
                list = New List(Of ExplanationListType)
            End Try
            Return list
        End Function

        ''' <summary>
        ''' DB get - gets a list of curriculumns associated with a specific subject.
        ''' </summary>
        ''' <param name="subjectID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUpdatedListOfCurriculum(subjectID As Integer) As IEnumerable(Of CurriculumListType) Implements IDbConnector.GetUpdatedListOfCurriculum
            Dim list As IEnumerable(Of CurriculumListType)
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@SubjectID", subjectID)

                list = db.Query(Of CurriculumListType)(DatabaseConstants.GetTheFilteredListOfCurriculums, dynamicParameters, commandType:=CommandType.StoredProcedure)
            Catch ex As Exception
                list = New List(Of CurriculumListType)
            End Try
            Return list
        End Function

        ''' <summary>
        ''' DB get - gets a list of explanations associated with a specific subject.
        ''' </summary>
        ''' <param name="subjectID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUpdatedListOfExplanations(subjectID As Integer) As IEnumerable(Of ExplanationListType) Implements IDbConnector.GetUpdatedListOfExplanations
            Dim list As IEnumerable(Of ExplanationListType)
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@SubjectID", subjectID)

                list = db.Query(Of ExplanationListType)(DatabaseConstants.GetTheFilteredListOfExplanationsBySubject, dynamicParameters, commandType:=CommandType.StoredProcedure)
            Catch ex As Exception
                list = New List(Of ExplanationListType)
            End Try
            Return list
        End Function

        ''' <summary>
        ''' DB get - gets a list of explanations associated with a specific curriculum.
        ''' </summary>
        ''' <param name="curriculumID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUpdatedExplanationsByCurriculum(curriculumID As Integer) As IEnumerable(Of ExplanationListType) Implements IDbConnector.GetUpdatedExplanationsByCurriculum
            Dim list As IEnumerable(Of ExplanationListType)
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@CurriculumID", curriculumID)

                list = db.Query(Of ExplanationListType)(DatabaseConstants.GetTheFilteredListOfExplanationsByCurriculum, dynamicParameters, commandType:=CommandType.StoredProcedure)
            Catch ex As Exception
                list = New List(Of ExplanationListType)
            End Try
            Return list
        End Function

        ''' <summary>
        ''' DB get - gets the explanation details based on the id provided.
        ''' </summary>
        ''' <param name="explanationID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetExplanationDetailsById(explanationID As Integer) As String Implements IDbConnector.GetExplanationDetailsById
            Dim result As String
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@ExplanationID", explanationID)

                result = db.Query(Of String)(DatabaseConstants.GetExplanationDescription, dynamicParameters, commandType:=CommandType.StoredProcedure).FirstOrDefault()
            Catch ex As Exception
                result = String.Empty
            End Try
            Return result
        End Function

        ''' <summary>
        ''' DB - inserts a new subject.
        ''' </summary>
        ''' <param name="subjectText"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertNewSubject(subjectText As String) As Integer Implements IDbConnector.InsertNewSubject
            Dim subjectID As Integer
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@SubjectDetail", subjectText)

                subjectID = db.Query(Of Integer)(DatabaseConstants.InsertNewSubject, dynamicParameters, commandType:=CommandType.StoredProcedure).FirstOrDefault()
            Catch ex As Exception
                subjectID = 0
            End Try
            Return subjectID
        End Function

        ''' <summary>
        ''' DB - inserts a new curriculum.
        ''' </summary>
        ''' <param name="subjectID"></param>
        ''' <param name="curriculumText"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertNewCurriculum(subjectID As Integer, curriculumText As String) As Integer Implements IDbConnector.InsertNewCurriculum
            Dim curriculumID As Integer
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@SubjectID", subjectID)
                dynamicParameters.Add("@CurriculumDetail", curriculumText)

                curriculumID = db.Query(Of Integer)(DatabaseConstants.InsertNewCurriculum, dynamicParameters, commandType:=CommandType.StoredProcedure).FirstOrDefault()
            Catch ex As Exception
                curriculumID = 0
            End Try
            Return curriculumID
        End Function

        ''' <summary>
        ''' DB - inserts a new key stage.
        ''' </summary>
        ''' <param name="keyStageText"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertNewKeyStage(keyStageText As String) As Integer Implements IDbConnector.InsertNewKeyStage
            Dim keyStageID As Integer
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@KeyStageDetails", keyStageText)

                keyStageID = db.Query(Of Integer)(DatabaseConstants.InsertNewKeyStage, dynamicParameters, commandType:=CommandType.StoredProcedure).FirstOrDefault()
            Catch ex As Exception
                keyStageID = 0
            End Try
            Return keyStageID
        End Function

        ''' <summary>
        ''' DB - inserts a new explanation.
        ''' </summary>
        ''' <param name="curriculumID"></param>
        ''' <param name="explanationTitle"></param>
        ''' <param name="explanationText"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertNewExplanation(curriculumID As Integer, explanationTitle As String, explanationText As String) As Integer Implements IDbConnector.InsertNewExplanation
            Dim explanationID As Integer
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@CurriculumID", curriculumID)
                dynamicParameters.Add("@Title", explanationTitle)
                dynamicParameters.Add("@Description", explanationText)

                explanationID = db.Query(Of Integer)(DatabaseConstants.InsertNewExplanation, dynamicParameters, commandType:=CommandType.StoredProcedure).FirstOrDefault()
            Catch ex As Exception
                explanationID = 0
            End Try
            Return explanationID
        End Function

        ''' <summary>
        ''' DB - inserts a new question.
        ''' </summary>
        ''' <param name="question"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertNewQuestion(question As QuestionInsertType) As Integer Implements IDbConnector.InsertNewQuestion
            Dim questionID As Integer
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@SelectedSubjectID", question.SelectedSubjectID)
                dynamicParameters.Add("@SelectedCurriculumID", question.SelectedCurriculumID)
                dynamicParameters.Add("@SelectedKeyStageID", question.SelectedKeyStageID)
                dynamicParameters.Add("@SelectedExplanationID", question.SelectedExplanationID)
                dynamicParameters.Add("@NewQuestion", question.NewQuestion)
                dynamicParameters.Add("@NewAnswer", question.NewAnswer)
                dynamicParameters.Add("@AmountOfStepsSet", question.AmountOfStepsSet)
                dynamicParameters.Add("@TotalMarksSet", question.TotalMarksSet)
                dynamicParameters.Add("@NewFalseAnswerA", question.NewFalseAnswerA)
                dynamicParameters.Add("@NewFalseAnswerB", question.NewFalseAnswerB)
                dynamicParameters.Add("@NewFalseAnswerC", question.NewFalseAnswerC)
                dynamicParameters.Add("@NewSearchString", question.NewSearchString)
                dynamicParameters.Add("@NewWebLink", question.NewWebLink)

                questionID = db.Query(Of Integer)(DatabaseConstants.InsertNewQuestion, dynamicParameters, commandType:=CommandType.StoredProcedure).FirstOrDefault()
            Catch ex As Exception
                questionID = 0
            End Try
            Return questionID
        End Function

        ''' <summary>
        ''' DB - inserts a new demonstration step.
        ''' </summary>
        ''' <param name="demo"></param>
        ''' <param name="questionID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertNewDemoStep(demo As DemonstrationStepType, questionID As Integer) As Boolean Implements IDbConnector.InsertNewDemoStep
            Dim insertedCorrect As Boolean
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@DemonstrationStageInsert", demo.DemonstrationStageInsert)
                dynamicParameters.Add("@RegExInsert", demo.RegExInsert)
                dynamicParameters.Add("@StageMarkInsert", demo.StageMarkInsert)
                dynamicParameters.Add("@QuestionID", questionID)

                db.Query(DatabaseConstants.InsertNewDemoSteps, dynamicParameters, commandType:=CommandType.StoredProcedure).FirstOrDefault()
                insertedCorrect = True
            Catch ex As Exception
                insertedCorrect = False
            End Try
            Return insertedCorrect
        End Function
#End Region

#Region "Training Section"

        ''' <summary>
        ''' DB get - gets the explanation details for training.
        ''' </summary>
        ''' <param name="explanationID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetExplanationDetailsForTraining(explanationID As Integer) As GetExplanationDetailsType Implements IDbConnector.GetExplanationDetailsForTraining
            Dim explanation As GetExplanationDetailsType
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@SelectedExplanationID", explanationID)

                explanation = db.Query(Of GetExplanationDetailsType)(DatabaseConstants.GetTrainingExplanationDetails, dynamicParameters, commandType:=CommandType.StoredProcedure).FirstOrDefault()
            Catch ex As Exception
                explanation = New GetExplanationDetailsType
            End Try
            Return explanation
        End Function

        ''' <summary>
        ''' DB get - gets a list of question ids for training.
        ''' </summary>
        ''' <param name="subjectID"></param>
        ''' <param name="curriculumID"></param>
        ''' <param name="keyStageID"></param>
        ''' <param name="explanationID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetListOfQuestionIdsForTraining(subjectID As Integer, curriculumID As Integer, keyStageID As Integer, explanationID As Integer) As IEnumerable(Of Integer) Implements IDbConnector.GetListOfQuestionIdsForTraining
            Dim list As IEnumerable(Of Integer)
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@SubjectID", subjectID)
                dynamicParameters.Add("@CurriculumID", curriculumID)
                dynamicParameters.Add("@KeyStageID", keyStageID)
                dynamicParameters.Add("@ExplanationID", explanationID)

                list = db.Query(Of Integer)(DatabaseConstants.GetTrainingListOfQuestionIds, dynamicParameters, commandType:=CommandType.StoredProcedure)
            Catch ex As Exception
                list = New List(Of Integer)()
            End Try
            Return list
        End Function

        ''' <summary>
        ''' DB get - gets the list of demo steps for the question.
        ''' </summary>
        ''' <param name="questionID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetListOfDemoStepDetails(questionID As Integer) As IEnumerable(Of String) Implements IDbConnector.GetListOfDemoStepDetails
            Dim list As IEnumerable(Of String)
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@QuestionID", questionID)

                list = db.Query(Of String)(DatabaseConstants.GetTrainingDemonstrationStepDetails, dynamicParameters, commandType:=CommandType.StoredProcedure)
            Catch ex As Exception
                list = New List(Of String)
            End Try
            Return list
        End Function

        ''' <summary>
        ''' DB get - gets a list of imitation stage steps.
        ''' </summary>
        ''' <param name="questionID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetImmitationStageSteps(questionID As Integer) As IEnumerable(Of ImmitationStageListType) Implements IDbConnector.GetImmitationStageSteps
            Dim list As IEnumerable(Of ImmitationStageListType)
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@QuestionID", questionID)

                list = db.Query(Of ImmitationStageListType)(DatabaseConstants.GetFullTrainingImmitationSteps, dynamicParameters, commandType:=CommandType.StoredProcedure)
            Catch ex As Exception
                list = New List(Of ImmitationStageListType)
            End Try
            Return list
        End Function

        ''' <summary>
        ''' DB get - gets the question details for the practice session.
        ''' </summary>
        ''' <param name="questionID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetQuestionDetail(questionID As Integer) As QuestionDetailsReturnType Implements IDbConnector.GetQuestionDetail
            Dim question As QuestionDetailsReturnType
            Try
                Dim db = _dbExecutorFactory.CreateExecutor()
                Dim dynamicParameters = New DynamicParameters()
                dynamicParameters.Add("@QuestionID", questionID)

                question = db.Query(Of QuestionDetailsReturnType)(DatabaseConstants.GetTrainingQuestionDetail, dynamicParameters, commandType:=CommandType.StoredProcedure).FirstOrDefault()
            Catch ex As Exception
                question = New QuestionDetailsReturnType()
            End Try
            Return question
        End Function

#End Region

    End Class
End Namespace