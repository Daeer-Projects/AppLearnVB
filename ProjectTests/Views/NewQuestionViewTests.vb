Imports System.Text
Imports System.Windows.Forms
Imports ExampleProg
Imports ExampleProg.Constants
Imports ExampleProg.InputClasses.NewQuestionTypes
Imports ExampleProg.Interfaces
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq

Namespace Views

    <TestClass()> Public Class NewQuestionViewTests

        ' These view tests will be completed when I implement an interface for the input types.
        ' Then I can mock them out for these view tests.

        '<TestMethod()> Public Sub test_do_subject_work_set_combo_box_text_to_invalid_string()
        '    ' Arrange.
        '    'Dim dbConnector = New Mock(Of IDbConnector)
        '    'Dim subjectType = New Mock(Of SubjectTypeInput)
        '    'subjectType.SetupProperty(Function(c) c.InvalidMessage, CommonConstants.NotAValidInput)
        '    'subjectType.Setup(Function(input) input.InvalidMessage).Returns(CommonConstants.NotAValidInput)

        '    Dim questionInput = New Mock(Of INewQuestionInput)
        '    'questionInput.Setup(Function(s) s.SubjectType.InvalidMessage).Returns(CommonConstants.NotAValidInput)

        '    Dim newQuestionView = New NewQuestionView
        '    'newQuestionView.Initialize()
        '    newQuestionView.NewQuestSubjectCombo.Text = String.Empty

        '    ' Act.
        '    'newQuestionView.DoSubjectWork()

        '    ' Assert.
        '    'Assert.AreEqual(newQuestionView.SubjectInvalid.Text, CommonConstants.NotAValidInput)
        'End Sub

    End Class
End Namespace