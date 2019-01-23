Imports System.Configuration
Imports DapperWrapper
Imports ExampleProg.Constants
Imports ExampleProg.DatabaseClasses
Imports ExampleProg.InputClasses.Training
Imports ExampleProg.Interfaces
Imports ExampleProg.ProcedureReturnTypes

''' <summary>
''' In-complete page for selecting the training required.
''' Almost done, but needs work on the pages and completing the practice section.
''' </summary>
''' <remarks></remarks>
Public Class SelectTrainingView

    Dim WithEvents _dbConnector As IDbConnector
    Private Property SelectTrainingInput As ISelectTrainingInput
    Private _dbConnectionString As String
    Private _demoTraining As DemonstrationTraining
    Private _immitationTraining As ImmitationTraining
    Private _questionID As Integer

    ''' <summary>
    ''' Catches the on load event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SelectTrainingView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _dbConnectionString = ConfigurationManager.ConnectionStrings(DatabaseConstants.ApplicationConfigString).ConnectionString
        TopMost = False
        Initialize()
    End Sub

    ''' <summary>
    ''' Sets up the systems for the window.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Initialize()
        ClearSelectTrainingListBoxes()
        RemoveNewQuestionTabs()
        HideUnusedButtons()
        InitializeDatabase()
        SelectTrainingInput = New SelectTrainingInput(_dbConnector)
        _demoTraining = New DemonstrationTraining(_dbConnector)
        _immitationTraining = New ImmitationTraining(_dbConnector)
        _questionID = 0
        PopulateSubjectComboBox()
    End Sub

    ''' <summary>
    ''' Sets up the database connection.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitializeDatabase()
        Dim sqlExecutorFactory = New SqlExecutorFactory(_dbConnectionString)
        Dim newDatabaseConnection = New DatabaseConnectorWrapper(sqlExecutorFactory)
        _dbConnector = newDatabaseConnection
    End Sub

    ''' <summary>
    ''' Catches the cancel button click event.
    ''' Closes the window.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles SelectTrainingCancelButton.Click
        Close()
    End Sub

#Region "Selection"
    ''' <summary>
    ''' Catches the subject change and filteres the value through to the rest of the page.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SubjectListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SubjectListBox.SelectedIndexChanged
        SelectTrainingInput.SelectedSubjectText = SubjectListBox.Text
        SelectTrainingInput.SetSubjectID()
        SelectTrainingInput.PopulateUpdatedCurriculumList()
        PopulateCurriculumComboBox()
        PopulateKeyStageComboBox()
        SelectTrainingInput.PopulateUpdatedExplanationList()
        PopulateExplanationComboBox()
        CurriculumListBox.Enabled = True
        KeyStageListBox.Enabled = False
        ExplanationListBox.Enabled = False
        ExplanationButton.Enabled = False
    End Sub

    ''' <summary>
    ''' Catches the curriculum change event and filters on down.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CurriculumListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CurriculumListBox.SelectedIndexChanged
        SelectTrainingInput.SelectedCurriculumText = CurriculumListBox.Text
        SelectTrainingInput.SetCurriculumID()
        KeyStageListBox.Enabled = True
        ExplanationListBox.Enabled = False
        ExplanationButton.Enabled = False
    End Sub

    ''' <summary>
    ''' Catches the key stage changed event.
    ''' Filters on down.
    ''' We also need to ignore the key stage in the stored procedure.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub KeyStageListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles KeyStageListBox.SelectedIndexChanged
        SelectTrainingInput.SelectedKeyStageText = KeyStageListBox.Text
        SelectTrainingInput.SetKeyStageID()
        SelectTrainingInput.PopulateUpdatedExplanationList()
        PopulateExplanationComboBox()
        ExplanationListBox.Enabled = True
        ExplanationButton.Enabled = False
    End Sub

    ''' <summary>
    ''' Catches the explanation changed event.
    ''' Filters on down.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ExplanationListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ExplanationListBox.SelectedIndexChanged
        SelectTrainingInput.SelectedExplanationText = ExplanationListBox.Text
        SelectTrainingInput.SetExplanationID()
        ExplanationButton.Enabled = True
        AddTabPage(ExplanationTabPage)
    End Sub

    ''' <summary>
    ''' Catches the explanation button click.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ExplanationButton_Click(sender As Object, e As EventArgs) Handles ExplanationButton.Click
        TrainingTabControl.SelectTab(ExplanationTabPage)
    End Sub

#End Region

#Region "Explanation"
    ''' <summary>
    ''' Sets the explanation details tab page.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetExplanationDetails()
        Dim explanationTrainingType = New ExplanationTraining(SelectTrainingInput.SelectedExplanationID, _dbConnector)
        ExplanationTitleLabel.Text = explanationTrainingType.ExplanationTitle
        ExplanationTrainingTextBox.Text = explanationTrainingType.ExplanationDetails
    End Sub

    ''' <summary>
    ''' Catches the enter event to set up the rest of the process.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ExplanationTabPage_Enter(sender As Object, e As EventArgs) Handles ExplanationTabPage.Enter
        SetExplanationDetails()
        AddTabPage(DemonstrationTabPage)
        ExplanationButton.Enabled = False
        ExplanationButton.Visible = False
        DemoButton.Visible = True
        DemoButton.Enabled = True
    End Sub

    ''' <summary>
    ''' Catches the demo button click event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DemoButton_Click(sender As Object, e As EventArgs) Handles DemoButton.Click
        TrainingTabControl.SelectTab(DemonstrationTabPage)
    End Sub

#End Region

#Region "Demonstration"
    ''' <summary>
    ''' Catches the demo tab page enter event.
    ''' Checks the question id and if it is not set, randomises a value from the database.
    ''' Then sets the rest up after that.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DemonstrationTabPage_Enter(sender As Object, e As EventArgs) Handles DemonstrationTabPage.Enter
        If (_questionID < 1) Then
            _demoTraining.Initialise(SelectTrainingInput.SelectedSubjectID, _
                    SelectTrainingInput.SelectedCurriculumID, SelectTrainingInput.SelectedKeyStageID, _
                    SelectTrainingInput.SelectedExplanationID)

            _demoTraining.SetRandomQuestionID()
            _demoTraining.SetUpDemoSteps()
        End If

        If (_demoTraining.HasDemoStepsBeenSetUp) Then
            _questionID = _demoTraining.QuestionID
            DemoStepDetailsTextBox.Text = _demoTraining.DemonstrationStepDetails
            DemoAmountSteps.Text = _demoTraining.CountOfDemonstrationSteps.ToString()
            CheckIfDemoStepIsAtBounds()
        End If
    End Sub

    ''' <summary>
    ''' Catches the demo next button event.
    ''' Moves the demo step on one.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DemoNextButton_Click(sender As Object, e As EventArgs) Handles DemoNextButton.Click
        _demoTraining.NextStep()
        DemoStepDetailsTextBox.Text = _demoTraining.DemonstrationStepDetails

        CheckIfDemoStepIsAtBounds()
        If (_demoTraining.CanProceed()) Then
            AddTabPage(ImmitationTabPage)
            ImmitationButton.Visible = True
            ImmitationButton.Enabled = True
            DemoButton.Visible = False
            DemoButton.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Catches the demo previous step.
    ''' Moves the demo step back one for the user to go over the steps.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DemoPreviousButton_Click(sender As Object, e As EventArgs) Handles DemoPreviousButton.Click
        _demoTraining.PreviousStep()
        DemoStepDetailsTextBox.Text = _demoTraining.DemonstrationStepDetails

        CheckIfDemoStepIsAtBounds()
        If Not (_demoTraining.CanProceed()) Then
            ImmitationButton.Visible = False
            ImmitationButton.Enabled = False
            DemoButton.Visible = True
            DemoButton.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Catches the immitation button click.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ImmitationButton_Click(sender As Object, e As EventArgs) Handles ImmitationButton.Click
        TrainingTabControl.SelectTab(ImmitationTabPage)
    End Sub
#End Region

#Region "Immitation"
    ''' <summary>
    ''' Sets up the immitation section of the traininig.
    ''' Based on the question id set in the demo stage.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TrainingTabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TrainingTabControl.SelectedIndexChanged
        If (TrainingTabControl.SelectedTab.TabIndex = ImmitationTabPage.TabIndex) Then
            _immitationTraining.GetDemonstrationList(_questionID)
            ImmitationDemoTextBox.Text = _immitationTraining.DemonstrationStepDetails
        End If
    End Sub

    ''' <summary>
    ''' Cathces the immitation text box change event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ImmitationTextBox_TextChanged(sender As Object, e As EventArgs) Handles ImmitationTextBox.TextChanged
        If (ImmitationTextBox.Text.Length > 0) Then
            ImmitationCheckButton.Enabled = True
        Else
            ImmitationCheckButton.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Catches the immitation check button click event.
    ''' The user want to check their answer.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ImmitationCheckButton_Click(sender As Object, e As EventArgs) Handles ImmitationCheckButton.Click
        _immitationTraining.ProcessInput(ImmitationTextBox.Text)
        If (_immitationTraining.IsDemoInputCorrect) Then
            If (_immitationTraining.HasImmitationBeenCompleted) Then
                AddTabPage(PracticeTabPage)
                PracticeButton.Visible = True
                PracticeButton.Enabled = True
                ImmitationButton.Visible = False
                ImmitationButton.Enabled = False
            Else
                ImmitationDemoTextBox.Text = _immitationTraining.DemonstrationStepDetails
                ImmitationTextBox.Text = String.Empty
            End If
        End If
    End Sub

    ''' <summary>
    ''' Catches the practice button on click event.
    ''' Will display the practice page.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PracticeButton_Click(sender As Object, e As EventArgs) Handles PracticeButton.Click
        TrainingTabControl.SelectTab(PracticeTabPage)
    End Sub
#End Region

#Region "Practice"

#End Region

#Region "Populate Combo Boxes"
    ''' <summary>
    ''' Populates the subject list.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PopulateSubjectComboBox()
        SubjectListBox.Items.Clear()
        For Each subject As SubjectListType In SelectTrainingInput.SubjectList
            SubjectListBox.Items.Add(subject.SubjectDetail)
        Next
    End Sub

    ''' <summary>
    ''' Populates the curriculum list.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PopulateCurriculumComboBox()
        CurriculumListBox.Items.Clear()
        For Each curric As CurriculumListType In SelectTrainingInput.CurriculumList
            CurriculumListBox.Items.Add(curric.CurriculumDetails)
        Next
    End Sub

    ''' <summary>
    ''' Populates the key stage list.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PopulateKeyStageComboBox()
        KeyStageListBox.Items.Clear()
        For Each key As KeyStageListType In SelectTrainingInput.KeyStageList
            KeyStageListBox.Items.Add(key.KeyStageDetail)
        Next
    End Sub

    ''' <summary>
    ''' Populates the explanation list.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PopulateExplanationComboBox()
        ExplanationListBox.Items.Clear()
        For Each explan As ExplanationListType In SelectTrainingInput.ExplanationList
            ExplanationListBox.Items.Add(explan.ExplanationDetail)
        Next
    End Sub
#End Region

#Region "Misc Functions"
    ''' <summary>
    ''' Clears the selected combo box.
    ''' </summary>
    ''' <param name="box"></param>
    ''' <remarks></remarks>
    Private Shared Sub ClearComboBoxes(box As ListBox)
        box.Items.Clear()
        box.Text = String.Empty
    End Sub

    ''' <summary>
    ''' Clears all the training combo boxes.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearSelectTrainingListBoxes()
        ClearComboBoxes(SubjectListBox)
        ClearComboBoxes(CurriculumListBox)
        ClearComboBoxes(KeyStageListBox)
        ClearComboBoxes(ExplanationListBox)
    End Sub

    ''' <summary>
    ''' Removes the tab pages back to the current page.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RemoveNewQuestionTabs()
        TrainingTabControl.TabPages.Remove(ExplanationTabPage)
        TrainingTabControl.TabPages.Remove(DemonstrationTabPage)
        TrainingTabControl.TabPages.Remove(ImmitationTabPage)
        TrainingTabControl.TabPages.Remove(PracticeTabPage)
    End Sub

    ''' <summary>
    ''' Hides the buttons, as they are stacked on each other in the design view.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub HideUnusedButtons()
        DemoButton.Visible = False
        ImmitationButton.Visible = False
        PracticeButton.Visible = False
    End Sub

    ''' <summary>
    ''' Adds the next tab page to the control.
    ''' </summary>
    ''' <param name="nextPage"></param>
    ''' <remarks></remarks>
    Public Sub AddTabPage(nextPage As TabPage)
        Dim exists As Boolean
        exists = False
        For Each item As TabPage In TrainingTabControl.TabPages
            If (item.Name = nextPage.Name) Then
                exists = True
            End If
        Next

        If Not (exists) Then
            TrainingTabControl.TabPages.Add(nextPage)
        End If
    End Sub

    ''' <summary>
    ''' Checks if the demo step is at the bounds.
    ''' Disables the next or previous buttons.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckIfDemoStepIsAtBounds()
        If (_demoTraining.HasDemoStepsBeenSetUp) Then
            If (_demoTraining.DemonstrationStep < (_demoTraining.CountOfDemonstrationSteps - 1)) Then
                DemoNextButton.Enabled = True
            Else
                DemoNextButton.Enabled = False
            End If

            If (_demoTraining.DemonstrationStep > 0) Then
                DemoPreviousButton.Enabled = True
            Else
                DemoPreviousButton.Enabled = False
            End If
        End If
    End Sub
#End Region

End Class