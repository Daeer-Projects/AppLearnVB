Imports ExampleProg.Constants
Imports System.Text.RegularExpressions

Namespace InputClasses.NewQuestionTypes
    ''' <summary>
    ''' The question input class.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class QuestionTypeInput
        Property QuestionText As String
        Property WebAddressText As String
        Property SearchString As String

        Private _subjectText As String
        Private _curriculumText As String
        Private _keyStageText As String
        Private _explanationText As String

        Property InvalidQuestionMessage As String
        Property InvalidWebAddressMessage As String
        Property InvalidSearchStringMessage As String

        Property IsValidQuestion As Boolean
        Private Property IsValidWebAddress As Boolean
        Property IsValidSerchString As Boolean

        Property CanProceed As Boolean

        ''' <summary>
        ''' The processor for the class.
        ''' Declares the variables and defaults.
        ''' Calls the methods to process the new question.
        ''' </summary>
        ''' <param name="text"></param>
        ''' <param name="webAddress"></param>
        ''' <param name="subject"></param>
        ''' <param name="curriculum"></param>
        ''' <param name="keyStage"></param>
        ''' <param name="explanation"></param>
        ''' <remarks></remarks>
        Public Sub Process(text As String, webAddress As String, subject As String, curriculum As String, keyStage As String, explanation As String)
            QuestionText = text
            WebAddressText = webAddress
            SearchString = String.Empty

            _subjectText = subject
            _curriculumText = curriculum
            _keyStageText = keyStage
            _explanationText = explanation

            IsValidQuestion = False
            IsValidSerchString = False

            SetTextFlag()
            SetSearchString()
            SetSearchFlag()
            SetValidWebAddres()
            SetInvalidMessages()
            SetCanProceed()
        End Sub

        ''' <summary>
        ''' Sets the text flag.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetTextFlag()
            IsValidQuestion = Helpers.IsTextNotNull(QuestionText)
        End Sub

        ''' <summary>
        ''' Sets the search string, and formats it.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetSearchString()
            ' Send the inputs to a string formatter.
            Dim arrayOfStrings(3) As String
            arrayOfStrings(0) = _subjectText
            arrayOfStrings(1) = _curriculumText
            arrayOfStrings(2) = _keyStageText
            arrayOfStrings(3) = _explanationText
            SearchString = Helpers.FormatSearchString(arrayOfStrings).ToString()
        End Sub

        ''' <summary>
        ''' Sets the search flag in the string is okay.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetSearchFlag()
            Dim arrayOfFlags(3) As Boolean
            arrayOfFlags(0) = Helpers.IsTextNotNull(_subjectText)
            arrayOfFlags(1) = Helpers.IsTextNotNull(_curriculumText)
            arrayOfFlags(2) = Helpers.IsTextNotNull(_keyStageText)
            arrayOfFlags(3) = Helpers.IsTextNotNull(_explanationText)
            IsValidSerchString = Helpers.IsThereAFalseInArray(arrayOfFlags)
        End Sub

        ''' <summary>
        ''' Checks the web addres is a valid address, based on its formatting.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetValidWebAddres()
            ' We don't care if it is null.
            If (Helpers.IsTextNotNull(WebAddressText)) Then
                Dim regexObj As Regex = New Regex(CommonConstants.ValidWebAddresRegEx)
                IsValidWebAddress = regexObj.IsMatch(WebAddressText)
            Else
                IsValidWebAddress = True
            End If
        End Sub

        ''' <summary>
        ''' Sets the invalid messages.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetInvalidMessages()
            InvalidQuestionMessage = If(IsValidQuestion, String.Empty, CommonConstants.NotAValidInput)
            InvalidWebAddressMessage = If(IsValidWebAddress, String.Empty, CommonConstants.WebAddressNotValid)
            InvalidSearchStringMessage = If(IsValidSerchString, String.Empty, CommonConstants.NotAValidInput)
        End Sub

        ''' <summary>
        ''' Sets the can proceed flag if all is okay.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetCanProceed()
            Dim arrayOfBools(2) As Boolean
            arrayOfBools(0) = IsValidQuestion
            arrayOfBools(1) = IsValidWebAddress
            arrayOfBools(2) = IsValidSerchString
            CanProceed = Helpers.IsThereAFalseInArray(arrayOfBools)
        End Sub
    End Class
End Namespace