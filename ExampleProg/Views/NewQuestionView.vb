Imports DapperWrapper
Imports ExampleProg.Classes
Imports ExampleProg.Constants
Imports ExampleProg.DatabaseClasses
Imports ExampleProg.InputClasses
Imports ExampleProg.Interfaces
Imports ExampleProg.ProcedureReturnTypes
Imports System.Configuration

''' <summary>
''' This is the back end of the NewQuestionView page.
''' All of the functions and button clicks on the page are executed here.
''' 
''' Collects, validates and then inserts the new question into the database.
''' </summary>
''' <remarks>New Question View class.</remarks>
Public Class NewQuestionView

#Region "Properties"
    Private _newQuestionInputSetup As INewQuestionInput
    Dim WithEvents _dbConnector As IDbConnector
    Private _dbConnectionString As String

    Private Property AmountOfNewQuestionTabs As Integer
    Private _currentNewQuestionTab As Integer
    Private _hasGoneBackOnNewQuestionTab As Boolean
#End Region

#Region "Load"
    ''' <summary>
    ''' When the page is loaded, this method is called.  Sets the TopMost to false, so that other pages can be viewed.
    ''' It then initialises all of the objects that are required to insert a new question.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Sets up all the objects on load.</remarks>
    Private Sub NewQuestionView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _dbConnectionString = ConfigurationManager.ConnectionStrings(DatabaseConstants.ApplicationConfigString).ConnectionString
        TopMost = False
        Initialize()
    End Sub

    ''' <summary>
    ''' Initialises all of the objects that are required when inserting a new question.
    ''' Calls all the other set up methods.
    ''' </summary>
    ''' <remarks>Calls the other set up methods.</remarks>
    Public Sub Initialize()
        InitializeDatabase()
        ClearAllNewQuestionComboBoxes()
        SetNewQuestionSettings()
        PopulateComboBoxesWithData()
        ClearNewQuestionInvalidBoxes()
        DemoListGrid.Rows.Clear()

        RemoveNewQuestionTabs()
        AmountOfNewQuestionTabs = NewQuestionTabControl.Controls.Count() - 1
        CheckIfNewQuestionTabIsAtBounds()
        _hasGoneBackOnNewQuestionTab = False
    End Sub

    ''' <summary>
    ''' Initialises the Dapper Factory.
    ''' Sets up the connection so that any of the other methods can connect to the database.
    ''' </summary>
    ''' <remarks>Database connection set up.</remarks>
    Private Sub InitializeDatabase()
        Dim sqlExecutorFactory = New SqlExecutorFactory(_dbConnectionString)
        Dim newDatabaseConnection = New DatabaseConnectorWrapper(sqlExecutorFactory)
        _dbConnector = newDatabaseConnection
    End Sub

    ''' <summary>
    ''' Initialises the New Question Input object.
    ''' Uses that object to get a list of the subject, curriculum, key stage and explanations.
    ''' </summary>
    ''' <remarks>Creates the New Question Input object.</remarks>
    Private Sub SetNewQuestionSettings()
        _newQuestionInputSetup = New NewQuestionInput(_dbConnector)
        _newQuestionInputSetup.SetListsFromDatabase()
    End Sub
#End Region

#Region "New Question"
    ''' <summary>
    ''' Used when the tab at the top of the page is changed.
    ''' Sets the current tab, checks if it is at the bounds.
    ''' Checks if the user has gone backwards.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Tab selection.</remarks>
    Private Sub NewQuestionTab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles NewQuestionTabControl.SelectedIndexChanged
        _currentNewQuestionTab = NewQuestionTabControl.SelectedIndex
        CheckIfNewQuestionTabIsAtBounds()

        SetHasGoneBackwards()
    End Sub

    ''' <summary>
    ''' Catches the changes to the subject selection.
    ''' Uses the subjects collected during initialisation.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Selects the subject.</remarks>
    Private Sub NewQuestSubjectCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles NewQuestSubjectCombo.SelectedIndexChanged
        DoSubjectWork()
    End Sub

    ''' <summary>
    ''' Catches the key presses in the combo box.
    ''' Looks for the tab key being presses, then checks that a value is entered.
    ''' Then calls the Do Subject Work methods.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Catches the key press.</remarks>
    Private Sub NewQuestSubjectCombo_KeyDown(sender As Object, e As KeyEventArgs) Handles NewQuestSubjectCombo.KeyDown
        Dim subjectEntered As Boolean
        subjectEntered = Helpers.Helpers.PerformTabOnEnter(e)
        If (subjectEntered) Then
            DoSubjectWork()
        End If
    End Sub

    ''' <summary>
    ''' Checks the subject combo box has a value and uses that to move on.
    ''' Uses the Subject Input class to validate the input, and then set the process.
    ''' If validation fails, then it will display the error message and not allow the user to continue.
    ''' </summary>
    ''' <remarks>Subject validation.</remarks>
    Public Sub DoSubjectWork()
        ' Need to check if we have gone backwards.
        If (_hasGoneBackOnNewQuestionTab) Then
            RemoveNewQuestionTabsTo(CurriculumTabPage)
            ClearTextBoxesFromTabPage(ExplanationTabPage)
            ClearTextBoxesFromTabPage(QuestionTabPage)
            ClearTextBoxesFromTabPage(AnswerPage)
            ClearTextBoxesFromTabPage(DemonstrationTabPage)
            DemoListGrid.Rows.Clear()
            _newQuestionInputSetup.DemonstrationType.ResetValuesToDefaults()
        End If
        _newQuestionInputSetup.SubjectType.Process(NewQuestSubjectCombo.Text)

        SubjectInvalid.Text = _newQuestionInputSetup.SubjectType.InvalidMessage

        If (_newQuestionInputSetup.SubjectType.CanProceed) Then
            AddTabPage(CurriculumTabPage)
            ClearComboBoxes(NewQuestCurriculumCombo)
            _newQuestionInputSetup.UpdateOtherLists()
            PopulateCurriculumComboBox()
            NewQuestionTabControl.SelectTab(CurriculumTabPage)
        End If
    End Sub

    ''' <summary>
    ''' Catches the curriculum combo box key press.
    ''' Looks for the tab key and then passes the flow onto the Do Curriculum Work method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NewQuestCurriculumCombo_KeyDown(sender As Object, e As KeyEventArgs) Handles NewQuestCurriculumCombo.KeyDown
        Dim curriculumEntered As Boolean
        curriculumEntered = Helpers.Helpers.PerformTabOnEnter(e)
        If (curriculumEntered) Then
            DoCurriculumWork()
        End If
    End Sub

    ''' <summary>
    ''' Catches the selected index if a new value is not entered.
    ''' Passes the flow onto the Do Curriculum Work method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Selects the curriculum index.</remarks>
    Private Sub NewQuestCurriculumCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles NewQuestCurriculumCombo.SelectedIndexChanged
        DoCurriculumWork()
    End Sub

    ''' <summary>
    ''' Does the curriculum validation.
    ''' Sets the error message if the input is not valid.
    ''' Allows the user to carry on with entering the rest of the new question.
    ''' </summary>
    ''' <remarks>Validates the curriculum input.</remarks>
    Public Sub DoCurriculumWork()
        ' Need to check if we have gone backwards.
        If (_hasGoneBackOnNewQuestionTab) Then
            RemoveNewQuestionTabsTo(KeyStageTabPage)
            ClearTextBoxesFromTabPage(ExplanationTabPage)
            ClearTextBoxesFromTabPage(QuestionTabPage)
            ClearTextBoxesFromTabPage(AnswerPage)
            ClearTextBoxesFromTabPage(DemonstrationTabPage)
            DemoListGrid.Rows.Clear()
            _newQuestionInputSetup.DemonstrationType.ResetValuesToDefaults()
        End If

        _newQuestionInputSetup.CurriculumType.Process(NewQuestCurriculumCombo.Text)

        CurriculumInvalid.Text = _newQuestionInputSetup.CurriculumType.InvalidMessage

        If (_newQuestionInputSetup.CurriculumType.CanProceed) Then
            AddTabPage(KeyStageTabPage)
            ClearComboBoxes(NewQuestExplanCombo)
            _newQuestionInputSetup.UpdateExplanation()
            PopulateExplanationComboBox()
            NewQuestionTabControl.SelectTab(KeyStageTabPage)
        End If
    End Sub

    ''' <summary>
    ''' Catches the Key Stage combo box key press.
    ''' Looks for the tab key.
    ''' Passes the flow onto the Do Key Stage Work method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Key Stage combo box key press.</remarks>
    Private Sub NewQuestKeyCombo_KeyDown(sender As Object, e As KeyEventArgs) Handles NewQuestKeyCombo.KeyDown
        Dim keyStageEntered As Boolean
        keyStageEntered = Helpers.Helpers.PerformTabOnEnter(e)
        If (keyStageEntered) Then
            DoKeyStageWork()
        End If
    End Sub

    ''' <summary>
    ''' Collects the index of the Key Stage selected.
    ''' Passes the input onto the Do Key Stage Work Method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Key Stage index selected.</remarks>
    Private Sub NewQuestKeyCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles NewQuestKeyCombo.SelectedIndexChanged
        DoKeyStageWork()
    End Sub

    ''' <summary>
    ''' Does the Key Stage validation.
    ''' Dispays the error message if the input is not valid.
    ''' Allows the user to continue if all is OK.
    ''' </summary>
    ''' <remarks>Key Stage Validation.</remarks>
    Public Sub DoKeyStageWork()
        ' Need to check if we have gone backwards.
        If (_hasGoneBackOnNewQuestionTab) Then
            RemoveNewQuestionTabsTo(ExplanationTabPage)
            ClearTextBoxesFromTabPage(ExplanationTabPage)
            ClearTextBoxesFromTabPage(QuestionTabPage)
            ClearTextBoxesFromTabPage(AnswerPage)
            ClearTextBoxesFromTabPage(DemonstrationTabPage)
            DemoListGrid.Rows.Clear()
            _newQuestionInputSetup.DemonstrationType.ResetValuesToDefaults()
        End If

        _newQuestionInputSetup.KeyStageType.Process(NewQuestKeyCombo.Text)

        KeyStageInvalid.Text = _newQuestionInputSetup.KeyStageType.InvalidMessage

        If (_newQuestionInputSetup.KeyStageType.CanProceed) Then
            AddTabPage(ExplanationTabPage)
            NewQuestionTabControl.SelectTab(ExplanationTabPage)
        End If
    End Sub

    ''' <summary>
    ''' Catches the Explanation combo box key press.
    ''' Looks for the tab key.
    ''' Passes the flow onto the Do Explanation Work method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Explanation key press.</remarks>
    Private Sub NewQuestExplanCombo_KeyDown(sender As Object, e As KeyEventArgs) Handles NewQuestExplanCombo.KeyDown
        Dim explanationTitleEntered As Boolean
        explanationTitleEntered = Helpers.Helpers.PerformTabOnEnter(e)
        If (explanationTitleEntered) Then
            DoExplanationWork()
        End If
    End Sub

    ''' <summary>
    ''' Sets the index of the selected Explanation combo box.
    ''' Passes the flow onto the Do Explanation Work method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Sets the index of the Explanation.</remarks>
    Private Sub NewQuestExplanCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles NewQuestExplanCombo.SelectedIndexChanged, ExplanationBox.Leave
        DoExplanationWork()
    End Sub

    ''' <summary>
    ''' Does the Explanation validation.
    ''' Displays the error message if the input is not valid.
    ''' Allows the user to carry on if the input is OK.
    ''' </summary>
    ''' <remarks>Explanation validation.</remarks>
    Public Sub DoExplanationWork()
        ' Need to check if we have gone backwards.
        If (_hasGoneBackOnNewQuestionTab) Then
            RemoveNewQuestionTabsTo(QuestionTabPage)
            ClearTextBoxesFromTabPage(QuestionTabPage)
            ClearTextBoxesFromTabPage(AnswerPage)
            ClearTextBoxesFromTabPage(DemonstrationTabPage)
            DemoListGrid.Rows.Clear()
            _newQuestionInputSetup.DemonstrationType.ResetValuesToDefaults()
        End If

        _newQuestionInputSetup.ExplanationType.Process(NewQuestExplanCombo.Text, ExplanationBox.Text)

        ExplanationInvalid.Text = _newQuestionInputSetup.ExplanationType.InvalidTitleMessage
        ExplanationDetailInvalid.Text = _newQuestionInputSetup.ExplanationType.InvalidDetailMessage
        ExplanationBox.Text = _newQuestionInputSetup.ExplanationType.ExplanationText

        If (_newQuestionInputSetup.ExplanationType.CanProceed) Then
            AddTabPage(QuestionTabPage)
        End If
    End Sub

    ''' <summary>
    ''' Calls the do question stuff when the user leaves the question box.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub QuestionBox_Leave(sender As Object, e As EventArgs) Handles QuestionBox.Leave
        DoQuestionStuff()
    End Sub

    ''' <summary>
    ''' Catches the web address box key down event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub WebAddressBox_KeyDown(sender As Object, e As KeyEventArgs) Handles WebAddressBox.KeyDown
        Helpers.Helpers.PerformTabOnEnter(e)
    End Sub

    ''' <summary>
    ''' Catches the search string box key down event.
    ''' Checks the input and calls the do question stuff.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SearchStringBox_KeyDown(sender As Object, e As KeyEventArgs) Handles SearchStringBox.KeyDown
        Dim searchStringEntered As Boolean
        searchStringEntered = Helpers.Helpers.PerformTabOnEnter(e)
        If (searchStringEntered) Then
            DoQuestionStuff()
        End If
    End Sub

    ''' <summary>
    ''' Catches the web address leave event.
    ''' Calls the do question stuff.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub WebAddressBox_Leave(sender As Object, e As EventArgs) Handles WebAddressBox.Leave
        DoQuestionStuff()
    End Sub

    ''' <summary>
    ''' The main do question process.
    ''' Checks if the tab has gone backwards.
    ''' Clears the tabs if necessary.
    ''' Processes the new question details.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DoQuestionStuff()
        ' Need to check if we have gone backwards.
        If (_hasGoneBackOnNewQuestionTab) Then
            RemoveNewQuestionTabsTo(AnswerPage)
            ClearTextBoxesFromTabPage(AnswerPage)
            ClearTextBoxesFromTabPage(DemonstrationTabPage)
            DemoListGrid.Rows.Clear()
            _newQuestionInputSetup.DemonstrationType.ResetValuesToDefaults()
        End If

        _newQuestionInputSetup.QuestionType.Process(QuestionBox.Text, WebAddressBox.Text, NewQuestSubjectCombo.Text,
                                                      NewQuestCurriculumCombo.Text, NewQuestKeyCombo.Text,
                                                      NewQuestExplanCombo.Text)

        QuestionInvalidLabel.Text = _newQuestionInputSetup.QuestionType.InvalidQuestionMessage
        SearchStringInvalidLabel.Text = _newQuestionInputSetup.QuestionType.InvalidSearchStringMessage
        InvalidWebAddressLabel.Text = _newQuestionInputSetup.QuestionType.InvalidWebAddressMessage
        SearchStringBox.Text = _newQuestionInputSetup.QuestionType.SearchString

        ' If we can proceed, then add the tab and go to it.
        If (_newQuestionInputSetup.QuestionType.CanProceed) Then
            AddTabPage(AnswerPage)
        End If
    End Sub

    ''' <summary>
    ''' Catches the correct answer box key down event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Shared Sub CorrectAnswerBox_KeyDown(sender As Object, e As KeyEventArgs) Handles CorrectAnswerBox.KeyDown
        Helpers.Helpers.PerformTabOnEnter(e)
    End Sub

    ''' <summary>
    ''' Catches the wrong answer a key down event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Shared Sub InCorrectBoxA_KeyDown(sender As Object, e As KeyEventArgs) Handles InCorrectBoxA.KeyDown
        Helpers.Helpers.PerformTabOnEnter(e)
    End Sub

    ''' <summary>
    ''' Catches the wrong answer b key down event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Shared Sub InCorrectBoxB_KeyDown(sender As Object, e As KeyEventArgs) Handles InCorrectBoxB.KeyDown
        Helpers.Helpers.PerformTabOnEnter(e)
    End Sub

    ''' <summary>
    ''' Catches the wrong answer c leave event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub InCorrectBoxC_Leave(sender As Object, e As EventArgs) Handles InCorrectBoxC.Leave
        DoAnswerStuff()
    End Sub

    ''' <summary>
    ''' Catches the wrong answer c key down event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub InCorrectBoxC_KeyDown(sender As Object, e As KeyEventArgs) Handles InCorrectBoxC.KeyDown
        Dim lastAnswerEntered As Boolean
        lastAnswerEntered = Helpers.Helpers.PerformTabOnEnter(e)
        If (lastAnswerEntered) Then
            DoAnswerStuff()
        End If
    End Sub

    ''' <summary>
    ''' The do answer stuff process.
    ''' Checks if the user has gone backwards.
    ''' Clears the tabs up to the next point.
    ''' Then processes all the answer details.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DoAnswerStuff()
        ' Need to check if we have gone backwards.
        If (_hasGoneBackOnNewQuestionTab) Then
            RemoveNewQuestionTabsTo(DemonstrationTabPage)
            ClearTextBoxesFromTabPage(DemonstrationTabPage)
            DemoListGrid.Rows.Clear()
            _newQuestionInputSetup.DemonstrationType.ResetValuesToDefaults()
        End If

        _newQuestionInputSetup.AnswerType.Process(CorrectAnswerBox.Text, InCorrectBoxA.Text, InCorrectBoxB.Text, InCorrectBoxC.Text)

        InvalidCorrectAnswerLabel.Text = _newQuestionInputSetup.AnswerType.InvalidCorrectAnswerMessage
        InvalidInCorrectLabelA.Text = _newQuestionInputSetup.AnswerType.InvalidInCorrectAnswerAMessage
        InvalidInCorrectLabelB.Text = _newQuestionInputSetup.AnswerType.InvalidInCorrectAnswerBMessage
        InvalidInCorrectLabelC.Text = _newQuestionInputSetup.AnswerType.InvalidInCorrectAnswerCMessage

        If (_newQuestionInputSetup.AnswerType.CanProceed) Then
            AddTabPage(DemonstrationTabPage)
            NewQuestionTabControl.SelectTab(DemonstrationTabPage)
        End If
    End Sub

    ''' <summary>
    ''' Catches the demonstration details key down event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DemonstrationDetailsBox_KeyDown(sender As Object, e As KeyEventArgs) Handles DemonstrationDetailsBox.KeyDown
        Dim demoDetailsEntered As Boolean
        demoDetailsEntered = Helpers.Helpers.PerformTabOnEnter(e)
        If (demoDetailsEntered) Then
            CheckDemoDetails()
        End If
    End Sub

    ''' <summary>
    ''' Catches the reg ex box key down event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RegExBox_KeyDown(sender As Object, e As KeyEventArgs) Handles RegExBox.KeyDown
        Dim regExDetailsEntered As Boolean
        regExDetailsEntered = Helpers.Helpers.PerformTabOnEnter(e)
        If (regExDetailsEntered) Then
            CheckRegExDetails()
        End If
    End Sub

    ''' <summary>
    ''' Catches the demonstration step mark box key down event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DemoStepMarkBox_KeyDown(sender As Object, e As KeyEventArgs) Handles DemoStepMarkBox.KeyDown
        Dim markEntered As Boolean
        markEntered = Helpers.Helpers.PerformTabOnEnter(e)
        If (markEntered) Then
            CheckMarkDetails()
        End If
    End Sub

    ''' <summary>
    ''' Catches the demonstration details leave box event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DemonstrationDetailsBox_Leave(sender As Object, e As EventArgs) Handles DemonstrationDetailsBox.Leave
        CheckDemoDetails()
    End Sub

    ''' <summary>
    ''' Catches the reg ex box leave event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RegExBox_Leave(sender As Object, e As EventArgs) Handles RegExBox.Leave
        CheckRegExDetails()
    End Sub

    ''' <summary>
    ''' Catches the demonstration step mark box leave event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DemoStepMarkBox_Leave(sender As Object, e As EventArgs) Handles DemoStepMarkBox.Leave
        CheckMarkDetails()
    End Sub

    ''' <summary>
    ''' Checks the demonstraion details and inserts the details into the main list.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckDemoDetails()
        _newQuestionInputSetup.DemonstrationType.InsertNextStepDetails(DemonstrationDetailsBox.Text)

        InvalidDemonstrationLabel.Text = _newQuestionInputSetup.DemonstrationType.InvalidDemoDetailsMessage
        If (_newQuestionInputSetup.DemonstrationType.IsValidDemoDetails) Then
            _newQuestionInputSetup.DemonstrationType.SetRegEx()
            RegExBox.Text = _newQuestionInputSetup.DemonstrationType.RegExDetails
        End If
    End Sub

    ''' <summary>
    ''' Checks the reg ex details and inserts the details into the list.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckRegExDetails()
        _newQuestionInputSetup.DemonstrationType.UpdateRegEx(RegExBox.Text)
        InvalidRegExLabel.Text = _newQuestionInputSetup.DemonstrationType.InvalidRegExDetailsMessage
    End Sub

    ''' <summary>
    ''' Checks the mark details into the list.
    ''' If all is okay, we enable the insert button.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckMarkDetails()
        _newQuestionInputSetup.DemonstrationType.InsertMark(DemoStepMarkBox.Text)
        InvalidDemoMarkLabel.Text = _newQuestionInputSetup.DemonstrationType.InvalidMarkMessage
        ' If all ok, now we enable the insert button.
        If (_newQuestionInputSetup.DemonstrationType.CanInsertDetailsToList) Then
            DemonstrationInsertButton.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Inserts the demo step into the list.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DemonstrationInsertButton_Click(sender As Object, e As EventArgs) Handles DemonstrationInsertButton.Click
        DoDemostrationStuff()
        ' If the demo inserted fine, then we need to clear the text boxes
        ClearTextBoxesFromTabPage(DemonstrationTabPage)
        DemonstrationInsertButton.Enabled = False
    End Sub

    ''' <summary>
    ''' Gathers all the details for the demo step and inserts it into the list.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DoDemostrationStuff()
        ' Add demo steps to the demo type input list.
        Dim insertedOkay = _newQuestionInputSetup.DemonstrationType.AddDetailsToList()

        If (insertedOkay) Then
            SetDemoListGrid()

            ' If we have one demo step inserted, we can finish.
            FinishedDemoDetailsButton.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Updates the grid view with the demo step inserted.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDemoListGrid()

        ' Clear out the current rows.
        DemoListGrid.Rows.Clear()

        ' Update the demo table row.
        For Each demoStep As DemonstrationStep In _newQuestionInputSetup.DemonstrationType.DemonstrationList
            DemoListGrid.Rows.Add(demoStep.StepDetails, demoStep.StepRegEx, demoStep.StepMark)

            ' Update the total amount of steps.
            AmountOfStepsLabel.Text = _newQuestionInputSetup.DemonstrationType.AmountOfSteps.ToString()

        Next
    End Sub

    ''' <summary>
    ''' Catches the demo grid cell click event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DemoListGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DemoListGrid.CellClick
        DemoListGrid.CurrentRow.Selected = True
    End Sub

    ''' <summary>
    ''' Catches the demo grid key down event.
    ''' If it is a delete, then we need to delete that step from the list.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DemoListGrid_KeyDown(sender As Object, e As KeyEventArgs) Handles DemoListGrid.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            Dim currentRow = DemoListGrid.CurrentRow()
            Dim currentDetail = currentRow.Cells(0).Value.ToString()

            ' Send the current step to newDemoTypeInput to remove the current item from
            ' DemostrationList.
            Dim hasBeenRemoved = _newQuestionInputSetup.DemonstrationType.RemoveStepFromList(currentDetail)

            If (hasBeenRemoved) Then
                SetDemoListGrid()
            End If

        End If
    End Sub

    ''' <summary>
    ''' Catches the finished demo detail button click.
    ''' Sets up the review page.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FinishedDemoDetailsButton_Click(sender As Object, e As EventArgs) Handles FinishedDemoDetailsButton.Click
        ' Enable the next tab page.
        AddTabPage(ReviewPage)
        NewQuestionTabControl.SelectTab(ReviewPage)
        SetReviewDetails()
    End Sub

    ''' <summary>
    ''' Sets up the review page with all the details entered into the previous pages.
    ''' Logic is missing here if the user changes anything.
    ''' We could set all the values as non-editable.
    ''' That would mean going back through each step again, just to change one value.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetReviewDetails()
        ' None of this has any logic checking in yet.
        ' We will need to do something if a value changes here.
        ReviewSubjectIDBox.Text = _newQuestionInputSetup.SubjectType.SubjectID.ToString()
        ReviewSubjectDetailsBox.Text = _newQuestionInputSetup.SubjectType.SubjectText
        InvalidReviewSubjectLabel.Text = _newQuestionInputSetup.SubjectType.InvalidMessage

        ReviewCurriculumIDBox.Text = _newQuestionInputSetup.CurriculumType.CurriculumID.ToString()
        ReviewCurriculumDetailsBox.Text = _newQuestionInputSetup.CurriculumType.CurriculumText
        InvalidReviewCurriculumLabel.Text = _newQuestionInputSetup.CurriculumType.InvalidMessage

        ReviewKeyStageIDBox.Text = _newQuestionInputSetup.KeyStageType.KeyStageID.ToString()
        ReviewKeyStageDetailsBox.Text = _newQuestionInputSetup.KeyStageType.KeyStageText
        InvalidReviewKeyStageLabel.Text = _newQuestionInputSetup.KeyStageType.InvalidMessage

        ReviewExplanationIDBox.Text = _newQuestionInputSetup.ExplanationType.ExplanationID.ToString()
        ReviewExplanationTitleBox.Text = _newQuestionInputSetup.ExplanationType.ExplanationTitle
        ReviewExplanationDetailsBox.Text = _newQuestionInputSetup.ExplanationType.ExplanationText
        InvalidReviewExplanationLabel.Text = _newQuestionInputSetup.ExplanationType.InvalidDetailMessage

        ReviewQuestionBox.Text = _newQuestionInputSetup.QuestionType.QuestionText
        ReviewQuestionWebAddressBox.Text = _newQuestionInputSetup.QuestionType.WebAddressText
        ReviewQuestionSearchBox.Text = _newQuestionInputSetup.QuestionType.SearchString
        InvalidReviewQuestionLabel.Text = _newQuestionInputSetup.QuestionType.InvalidQuestionMessage

        ReviewCorrectAnswerBox.Text = _newQuestionInputSetup.AnswerType.CorrectAnswer
        ReviewWrongAnswerABox.Text = _newQuestionInputSetup.AnswerType.InCorrectAnswerA
        ReviewWrongAnswerBBox.Text = _newQuestionInputSetup.AnswerType.InCorrectAnswerB
        ReviewWrongAnswerCBox.Text = _newQuestionInputSetup.AnswerType.InCorrectAnswerC
        InvalidReviewAnswerLabel.Text = _newQuestionInputSetup.AnswerType.InvalidCorrectAnswerMessage

        ' Clear out the current rows.
        ReviewDemoGridBox.Rows.Clear()

        ' Update the demo table row.
        For Each demoStep As DemonstrationStep In _newQuestionInputSetup.DemonstrationType.DemonstrationList
            ReviewDemoGridBox.Rows.Add(demoStep.StepDetails, demoStep.StepRegEx, demoStep.StepMark)
        Next
        ReviewTotalMarksBox.Text = _newQuestionInputSetup.DemonstrationType.DemonstrationTotalMarks.ToString()

        _newQuestionInputSetup.Process()

        If (_newQuestionInputSetup.CanSubmit) Then
            SubmitButton.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Here we insert the new question into the database.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Inserting the question.</remarks>
    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        _newQuestionInputSetup.InsertNewQuestion()
        If (_newQuestionInputSetup.InsertedSuccessfully) Then
            MsgBox(_newQuestionInputSetup.NewQuestionInsertMessage, Buttons:=MsgBoxStyle.OkOnly)
            Close()
        Else
            MsgBox(_newQuestionInputSetup.NewQuestionInsertMessage, Buttons:=MsgBoxStyle.OkOnly)
        End If
    End Sub

#End Region

#Region "Misc Functions"
    ''' <summary>
    ''' Catches the cancel button click.
    ''' This closes the window.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NewQuestCancelButton_Click(sender As Object, e As EventArgs) Handles NewQuestCancelButton.Click
        Close()
    End Sub

    ''' <summary>
    ''' Clears the invalid labels.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearNewQuestionInvalidBoxes()
        SubjectInvalid.Text = String.Empty
        CurriculumInvalid.Text = String.Empty
        KeyStageInvalid.Text = String.Empty
        ExplanationInvalid.Text = String.Empty
        QuestionInvalid.Text = String.Empty
    End Sub

    ''' <summary>
    ''' Clears the combo box selected.
    ''' </summary>
    ''' <param name="box"></param>
    ''' <remarks></remarks>
    Public Shared Sub ClearComboBoxes(box As ComboBox)
        box.Items.Clear()
        box.Text = String.Empty
    End Sub

    ''' <summary>
    ''' Clears all of the combo boxes.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearAllNewQuestionComboBoxes()
        ClearComboBoxes(NewQuestSubjectCombo)
        ClearComboBoxes(NewQuestCurriculumCombo)
        ClearComboBoxes(NewQuestKeyCombo)
        ClearComboBoxes(NewQuestExplanCombo)
    End Sub

    ''' <summary>
    ''' Clears the text boxes text from the tab page.
    ''' </summary>
    ''' <param name="page"></param>
    ''' <remarks></remarks>
    Private Sub ClearTextBoxesFromTabPage(page As TabPage)
        For Each item As Control In page.Controls
            If (TypeOf item Is TextBox) Then
                item.Text = String.Empty
            End If
        Next
    End Sub
#End Region

#Region "Populate Combo Boxes"
    ''' <summary>
    ''' Populates the boxes with data from the main class.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PopulateComboBoxesWithData()
        PopulateSubjectComboBox()
        PopulateCurriculumComboBox()
        PopulateKeyStageComboBox()
        PopulateExplanationComboBox()
    End Sub

    ''' <summary>
    ''' Populates the subject list.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PopulateSubjectComboBox()
        For Each subject As SubjectListType In _newQuestionInputSetup.SubjectType.SubjectList
            NewQuestSubjectCombo.Items.Add(subject.SubjectDetail)
        Next
    End Sub

    ''' <summary>
    ''' Populates the curriculum list.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PopulateCurriculumComboBox()
        For Each curric As CurriculumListType In _newQuestionInputSetup.CurriculumType.CurriculumList
            NewQuestCurriculumCombo.Items.Add(curric.CurriculumDetails)
        Next
    End Sub

    ''' <summary>
    ''' Populates the key stage list.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PopulateKeyStageComboBox()
        For Each key As KeyStageListType In _newQuestionInputSetup.KeyStageType.KeyStageList
            NewQuestKeyCombo.Items.Add(key.KeyStageDetail)
        Next
    End Sub

    ''' <summary>
    ''' Populates the explanation list.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PopulateExplanationComboBox()
        For Each explan As ExplanationListType In _newQuestionInputSetup.ExplanationType.ExplanationList
            NewQuestExplanCombo.Items.Add(explan.ExplanationDetail)
        Next
    End Sub
#End Region

#Region "New Question Navigation"
    ''' <summary>
    ''' Catches the next button click.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click
        NewQuestionTabControl.SelectTab(_currentNewQuestionTab + 1)
    End Sub

    ''' <summary>
    ''' Catches the previous button click.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PreviousButton_Click(sender As Object, e As EventArgs) Handles PreviousButton.Click
        NewQuestionTabControl.SelectTab(_currentNewQuestionTab - 1)
    End Sub

    ''' <summary>
    ''' Checks to see if the current tab is at the bounds to disable the next or previous buttons.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckIfNewQuestionTabIsAtBounds()
        If (_currentNewQuestionTab = 0) Then
            PreviousButton.Enabled = False
        Else
            PreviousButton.Enabled = True
        End If

        If (_currentNewQuestionTab = (AmountOfNewQuestionTabs)) Then
            NextButton.Enabled = False
        Else
            NextButton.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Checks if the user has selected a tab page 2 steps back from where they started.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetHasGoneBackwards()
        Dim gap = AmountOfNewQuestionTabs - _currentNewQuestionTab
        If (gap >= 2) Then
            _hasGoneBackOnNewQuestionTab = True
        Else
            _hasGoneBackOnNewQuestionTab = False
        End If
    End Sub
#End Region

#Region "Tab Controls"
    ''' <summary>
    ''' Removes the tab pages from the tab control, so they get added in order.
    ''' The user can only go one way, and not jump around the pages.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RemoveNewQuestionTabs()
        NewQuestionTabControl.TabPages.Remove(CurriculumTabPage)
        NewQuestionTabControl.TabPages.Remove(KeyStageTabPage)
        NewQuestionTabControl.TabPages.Remove(ExplanationTabPage)
        NewQuestionTabControl.TabPages.Remove(QuestionTabPage)
        NewQuestionTabControl.TabPages.Remove(AnswerPage)
        NewQuestionTabControl.TabPages.Remove(DemonstrationTabPage)
        NewQuestionTabControl.TabPages.Remove(ReviewPage)
    End Sub

    ''' <summary>
    ''' Removes the tab pages from the control to the current tab.
    ''' </summary>
    ''' <param name="currentTab"></param>
    ''' <remarks></remarks>
    Public Sub RemoveNewQuestionTabsTo(currentTab As TabPage)
        Dim indexOfCurrentTab = NewQuestionTabControl.TabPages(currentTab.Name).TabIndex
        For index As Integer = AmountOfNewQuestionTabs To indexOfCurrentTab Step -1
            NewQuestionTabControl.TabPages.RemoveAt(index)
        Next
        AmountOfNewQuestionTabs = NewQuestionTabControl.Controls.Count() - 1
    End Sub

    ''' <summary>
    ''' Adds the tab page to the control.
    ''' </summary>
    ''' <param name="nextPage"></param>
    ''' <remarks></remarks>
    Public Sub AddTabPage(nextPage As TabPage)
        Dim exists As Boolean
        exists = False
        For Each item As TabPage In NewQuestionTabControl.TabPages
            If (item.Name = nextPage.Name) Then
                exists = True
            End If
        Next

        If Not (exists) Then
            NewQuestionTabControl.TabPages.Add(nextPage)
            AmountOfNewQuestionTabs = NewQuestionTabControl.Controls.Count() - 1
            CheckIfNewQuestionTabIsAtBounds()
        End If
    End Sub
#End Region

End Class