Imports ExampleProg.InputClasses.NewQuestionTypes
Imports ExampleProg.Interfaces
Imports System.Threading
Imports ExampleProg.Classes
Imports ExampleProg.Constants
Imports ExampleProg.QuestionTypes

Namespace InputClasses
    ''' <summary>
    ''' The New Question Input class.
    ''' Uses an interface, so it can be mocked for testing.
    ''' Instantiates all of the different new question types.
    ''' Validates using the different types and then inserts the new question into the database.
    ''' </summary>
    ''' <remarks>The New Question Input class.</remarks>
    Public Class NewQuestionInput
        Implements INewQuestionInput

#Region "Properties"

        Public Property SubjectType As SubjectTypeInput Implements INewQuestionInput.SubjectType
        Public Property CurriculumType As CurriculumTypeInput Implements INewQuestionInput.CurriculumType
        Public Property KeyStageType As KeyStageTypeInput Implements INewQuestionInput.KeyStageType
        Public Property ExplanationType As ExplanationTypeInput Implements INewQuestionInput.ExplanationType
        Public Property QuestionType As QuestionTypeInput Implements INewQuestionInput.QuestionType
        Public Property AnswerType As AnswerTypeInput Implements INewQuestionInput.AnswerType
        Public Property DemonstrationType As DemonstrationTypeInput Implements INewQuestionInput.DemonstrationType

        Private Property DBConnection As IDbConnector

        Public Property CanSubmit As Boolean Implements INewQuestionInput.CanSubmit

        Public Property NewQuestionInsertMessage As String Implements INewQuestionInput.NewQuestionInsertMessage
        Public Property InsertedSuccessfully As Boolean Implements INewQuestionInput.InsertedSuccessfully
#End Region

#Region "Constructor and setup of lists"
        ''' <summary>
        ''' The basic constructor.
        ''' </summary>
        ''' <param name="dbConnector"></param>
        ''' <remarks></remarks>
        Public Sub New(dbConnector As IDbConnector)
            DBConnection = dbConnector
            SetInputTypes()
        End Sub

        ''' <summary>
        ''' Sets up the different input classes.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetInputTypes()
            SubjectType = New SubjectTypeInput()
            CurriculumType = New CurriculumTypeInput()
            KeyStageType = New KeyStageTypeInput()
            ExplanationType = New ExplanationTypeInput(DBConnection)
            QuestionType = New QuestionTypeInput()
            AnswerType = New AnswerTypeInput()
            DemonstrationType = New DemonstrationTypeInput()
            DemonstrationType.ResetValuesToDefaults()
            CanSubmit = False
            NewQuestionInsertMessage = String.Empty
            InsertedSuccessfully = False
        End Sub

        ''' <summary>
        ''' Sets the lists from the database.
        ''' Uses multi-threading to populate the lists.
        ''' :-)
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetListsFromDatabase() Implements INewQuestionInput.SetListsFromDatabase
            Dim thread1 As New Thread(AddressOf PopulateSubjectList)
            Dim thread2 As New Thread(AddressOf PopulateCurriculumList)
            Dim thread3 As New Thread(AddressOf PopulateKeyStageList)
            Dim thread4 As New Thread(AddressOf PopulateExplanationList)

            thread1.Start()
            thread2.Start()
            thread3.Start()
            thread4.Start()
            thread1.Join()
            thread2.Join()
            thread3.Join()
            thread4.Join()
        End Sub

        ''' <summary>
        ''' Populates the subject list from thread 1.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub PopulateSubjectList()
            SubjectType.SubjectList = DBConnection.GetListOfSubjects()
        End Sub

        ''' <summary>
        ''' Populates the curriculum list from thread 2.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub PopulateCurriculumList()
            CurriculumType.CurriculumList = DBConnection.GetListOfCurriculum()
        End Sub

        ''' <summary>
        ''' Populates the key stage list from thread 3.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub PopulateKeyStageList()
            KeyStageType.KeyStageList = DBConnection.GetListOfKeyStages()
        End Sub

        ''' <summary>
        ''' Populates the explanation list from thread 4.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub PopulateExplanationList()
            ExplanationType.ExplanationList = DBConnection.GetListOfExplanations()
        End Sub

#End Region

#Region "Subject Changes"
        ''' <summary>
        ''' Updates the lists from the subjects.
        ''' Uses multi-threading again.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub UpdateOtherLists() Implements INewQuestionInput.UpdateOtherLists
            Dim thread1 As New Thread(AddressOf UpdateCurriculumList)
            Dim thread2 As New Thread(AddressOf UpdateExplanationList)

            thread1.Start()
            thread2.Start()
            thread1.Join()
            thread2.Join()
        End Sub

        ''' <summary>
        ''' Updates the curriculum list.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub UpdateCurriculumList()
            CurriculumType.CurriculumList = DBConnection.GetUpdatedListOfCurriculum(SubjectType.SubjectID)
        End Sub

        ''' <summary>
        ''' Updates the explanation list.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub UpdateExplanationList()
            ExplanationType.ExplanationList = DBConnection.GetUpdatedListOfExplanations(SubjectType.SubjectID)
        End Sub
#End Region

#Region "Curriculum Changes"
        ''' <summary>
        ''' Updates the explanation list from the curriculum selected.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub UpdateExplanation() Implements INewQuestionInput.UpdateExplanation
            ExplanationType.ExplanationList = DBConnection.GetUpdatedExplanationsByCurriculum(CurriculumType.CurriculumID)
        End Sub
#End Region

        ''' <summary>
        ''' Process the details in the class.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Process() Implements INewQuestionInput.Process
            SetCanSubmit()
        End Sub

        ''' <summary>
        ''' Sets the can submit flag from the other class can proceed flags.
        ''' All need to be true for the can submit flag to be set to true.
        ''' Otherwise the new question will not be created.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetCanSubmit()
            Dim arrayOfFlags(6) As Boolean
            arrayOfFlags(0) = SubjectType.CanProceed
            arrayOfFlags(1) = CurriculumType.CanProceed
            arrayOfFlags(2) = KeyStageType.CanProceed
            arrayOfFlags(3) = ExplanationType.CanProceed
            arrayOfFlags(4) = QuestionType.CanProceed
            arrayOfFlags(5) = AnswerType.CanProceed
            arrayOfFlags(6) = DemonstrationType.CanInsertDetailsToList
            CanSubmit = Helpers.IsThereAFalseInArray(arrayOfFlags)
        End Sub

        ''' <summary>
        ''' Inserts the new question into the database with all of the demo steps.
        ''' </summary>
        ''' <remarks>Inserts the question.</remarks>
        Public Sub InsertNewQuestion() Implements INewQuestionInput.InsertNewQuestion
            ' Check if parts are new, and insert them.
            InsertNewQuestionTypes()

            ' Check that we do not have any nulls or 0 in any of the IDs.
            Dim canContiune As Boolean = SetCanContiune()
            
            If (canContiune) Then
                Dim question = SetUpQuestionInsertTypes()

                ' Insert the new question first and get the id of the record inserted.
                Dim questionID = DBConnection.InsertNewQuestion(question)
                Dim isQuestionValid = Helpers.IsDigitNotNullOrZero(questionID)
                If (isQuestionValid) Then
                    Dim insertedOkay As Boolean = GetInsertedOkay(questionID)
                    If Not (insertedOkay) Then
                        NewQuestionInsertMessage = CommonConstants.InsertNewDemoStepError
                    Else
                        NewQuestionInsertMessage = CommonConstants.NewQuestionInsertedCorrectly
                        InsertedSuccessfully = True
                    End If
                Else
                    NewQuestionInsertMessage = CommonConstants.InsertNewQuestionError
                End If
            Else
                NewQuestionInsertMessage = CommonConstants.InsertNewQuestionError
            End If
        End Sub

        ''' <summary>
        ''' Inserts the new subjects, curriculums, key stage and explanation.
        ''' If they are not new, it keeps the original ID's set before.
        ''' </summary>
        ''' <remarks>For setting the ID's.</remarks>
        Private Sub InsertNewQuestionTypes()
            If (SubjectType.IsNewSubject) Then
                SubjectType.SubjectID = DBConnection.InsertNewSubject(SubjectType.SubjectText)
            End If

            If (CurriculumType.IsNewCurriculum) Then
                CurriculumType.CurriculumID = DBConnection.InsertNewCurriculum(SubjectType.SubjectID, CurriculumType.CurriculumText)
            End If

            If (KeyStageType.IsNewKeyStage) Then
                KeyStageType.KeyStageID = DBConnection.InsertNewKeyStage(KeyStageType.KeyStageText)
            End If

            If (ExplanationType.IsNewExplanation) Then
                ExplanationType.ExplanationID = DBConnection.InsertNewExplanation(CurriculumType.CurriculumID, ExplanationType.ExplanationTitle, ExplanationType.ExplanationText)
            End If
        End Sub

        ''' <summary>
        ''' Checks that all of the ID's are set.
        ''' </summary>
        ''' <returns>If OK to carry on.</returns>
        ''' <remarks>Getting ready for the rest of the insert steps.</remarks>
        Private Function SetCanContiune() As Boolean
            Dim arrayOfFlags(3) As Boolean
            arrayOfFlags(0) = Helpers.IsDigitNotNullOrZero(SubjectType.SubjectID)
            arrayOfFlags(1) = Helpers.IsDigitNotNullOrZero(CurriculumType.CurriculumID)
            arrayOfFlags(2) = Helpers.IsDigitNotNullOrZero(KeyStageType.KeyStageID)
            arrayOfFlags(3) = Helpers.IsDigitNotNullOrZero(ExplanationType.ExplanationID)
            Return Helpers.IsThereAFalseInArray(arrayOfFlags)
        End Function

        ''' <summary>
        ''' Sets up the variables into the database user defined type.
        ''' </summary>
        ''' <returns>The question insert type.</returns>
        ''' <remarks>Sets it all up from all of the different objects.</remarks>
        Private Function SetUpQuestionInsertTypes() As QuestionInsertType
            Dim newQuestion = New QuestionInsertType
            newQuestion.SelectedSubjectID = SubjectType.SubjectID
            newQuestion.SelectedCurriculumID = CurriculumType.CurriculumID
            newQuestion.SelectedKeyStageID = KeyStageType.KeyStageID
            newQuestion.SelectedExplanationID = ExplanationType.ExplanationID

            newQuestion.NewQuestion = QuestionType.QuestionText
            newQuestion.NewAnswer = AnswerType.CorrectAnswer

            newQuestion.AmountOfStepsSet = DemonstrationType.AmountOfSteps
            newQuestion.TotalMarksSet = DemonstrationType.DemonstrationTotalMarks

            newQuestion.NewFalseAnswerA = AnswerType.InCorrectAnswerA
            newQuestion.NewFalseAnswerB = AnswerType.InCorrectAnswerB
            newQuestion.NewFalseAnswerC = AnswerType.InCorrectAnswerC

            newQuestion.NewSearchString = QuestionType.SearchString
            newQuestion.NewWebLink = QuestionType.WebAddressText
            Return newQuestion
        End Function

        ''' <summary>
        ''' Inserts the demo steps into the database.
        ''' Keeps a records of any false returns.
        ''' Then goes through that list to return true or false.
        ''' </summary>
        ''' <param name="questionID"></param>
        ''' <returns>True or false.</returns>
        ''' <remarks>Sets the demo steps and checks all is OK.</remarks>
        Private Function GetInsertedOkay(questionID As Integer) As Boolean
            ' Setting up initial checks.
            Dim insertedList = New List(Of Boolean)
            'Dim isQuestionValid = Helpers.IsDigitNotNullOrZero(questionID)
            Dim isDemoStepsCountValid = Helpers.IsDigitNotNullOrZero(DemonstrationType.DemonstrationList.Count)
            'insertedList.Add(isQuestionValid)
            insertedList.Add(isDemoStepsCountValid)

            ' Now for the demo inserts.
            If (isDemoStepsCountValid) Then
                ' Insert all of the demo steps using the id of the new question.
                For Each demo As DemonstrationStep In DemonstrationType.DemonstrationList
                    Dim demoStep = New DemonstrationStepType

                    demoStep.DemonstrationStageInsert = demo.StepDetails
                    demoStep.RegExInsert = demo.StepRegEx
                    demoStep.StageMarkInsert = demo.StepMark

                    insertedList.Add(DBConnection.InsertNewDemoStep(demoStep, questionID))
                Next
            End If

            ' So now we check that all went ok...
            Return Helpers.IsThereAFalseInArray(insertedList.ToArray())
        End Function
    End Class
End Namespace