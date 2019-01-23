Imports System.Text

Namespace Helpers
    ''' <summary>
    ''' A Helper class.
    ''' Used like a static class in C#.
    ''' A set of basic functions that are re-used throughout the application.
    ''' To prevent code being copied throughout.
    ''' </summary>
    ''' <remarks>A set of helper functions.</remarks>
    Public Module Helpers

        Public Function IsTextNotNull(value As String) As Boolean
            Dim result As Boolean
            result = True

            If (String.IsNullOrWhiteSpace(value)) Then
                result = False
            End If

            Return result
        End Function

        ''' <summary>
        ''' Checking for a null or zero.
        ''' If neither, then true is returned.
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns>True or false.</returns>
        Public Function IsDigitNotNullOrZero(value As Integer) As Boolean
            Dim result As Boolean
            result = True

            If (value = Nothing OrElse value < 1) Then
                result = False
            End If

            Return result
        End Function

        ''' <summary>
        ''' Goes through the array of booleans to find a single false.
        ''' </summary>
        ''' <param name="array"></param>
        ''' <returns>If there is one false, then it returns false.</returns>
        ''' <remarks></remarks>
        Public Function IsThereAFalseInArray(array As Array) As Boolean
            Dim result As Boolean = True
            Dim tempArray(array.Length) As Boolean
            array.CopyTo(tempArray, 0)
            For index As Integer = 0 To (array.Length - 1)
                If Not (tempArray(index)) Then
                    result = False
                End If
            Next

            Return result
        End Function

        ''' <summary>
        ''' Changes the enter key into a tab key.
        ''' </summary>
        ''' <param name="e"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function PerformTabOnEnter(ByVal e As KeyEventArgs) As Boolean
            Dim isEnter As Boolean
            isEnter = False
            If (e.KeyCode = Keys.Enter) Then
                isEnter = True
                SendKeys.Send("{TAB}")
            Else
                Return isEnter
            End If
            e.SuppressKeyPress = True 'this will prevent ding sound
            Return isEnter
        End Function

        ''' <summary>
        ''' Formats the search string into one fully formatted string.
        ''' </summary>
        ''' <param name="array"></param>
        ''' <returns>The formatted string.</returns>
        ''' <remarks></remarks>
        Public Function FormatSearchString(array As Array) As StringBuilder
            Dim formattedString = New StringBuilder

            For Each item As String In array
                Dim index As Int32 = array.IndexOf(array, item)

                If Not (item = "N/A") Then
                    formattedString.Append("""")
                    formattedString.Append(item)
                    formattedString.Append("""")
                    If Not (index = array.Length - 1) Then
                        formattedString.Append(" + ")
                    End If
                End If

            Next
            Return formattedString
        End Function

    End Module
End Namespace