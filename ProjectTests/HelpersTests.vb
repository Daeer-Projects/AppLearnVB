Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ExampleProg.Helpers

''' <summary>
''' A set of tests for the Helpers class.
''' </summary>
''' <remarks>Tests.</remarks>
<TestClass()> Public Class HelpersTests

    <TestMethod()> Public Sub test_if_text_not_null_returns_true()
        ' Arrange.
        Dim actual

        ' Act.
        actual = IsTextNotNull("hello")

        ' Assert.
        Assert.IsTrue(actual)
    End Sub

    <TestMethod()> Public Sub test_if_text_not_null_returns_false()
        ' Arrange.
        Dim actual

        ' Act.
        actual = IsTextNotNull(String.Empty)

        ' Assert.
        Assert.IsFalse(actual)
    End Sub

    <TestMethod()> Public Sub test_is_digit_null_or_zero_returns_true_with_positive_digit()
        ' Arrange,

        ' Act.

        ' Assert.
        Assert.IsTrue(IsDigitNotNullOrZero(1))
    End Sub

    <TestMethod()> Public Sub test_is_digit_null_or_zero_returns_false_with_null()
        ' Arrange,

        ' Act.

        ' Assert.
        Assert.IsFalse(IsDigitNotNullOrZero(Nothing))
    End Sub

    <TestMethod()> Public Sub test_is_digit_null_or_zero_returns_false_with_zero()
        ' Arrange,

        ' Act.

        ' Assert.
        Assert.IsFalse(IsDigitNotNullOrZero(0))
    End Sub

    <TestMethod()> Public Sub test_is_digit_null_or_zero_returns_false_with_negative_digit()
        ' Arrange,

        ' Act.

        ' Assert.
        Assert.IsFalse(IsDigitNotNullOrZero(-1))
    End Sub

    <TestMethod()> Public Sub test_is_there_a_false_in_array_returns_true()
        ' Arrange.
        Dim array(6) As Boolean
        Dim result
        array(0) = True
        array(1) = True
        array(2) = True
        array(3) = True
        array(4) = True
        array(5) = True
        array(6) = True

        ' Act.
        result = IsThereAFalseInArray(array)

        ' Assert.
        Assert.IsTrue(result)
    End Sub

    <TestMethod()> Public Sub test_is_there_a_false_in_array_returns_false()
        ' Arrange.
        Dim array(6) As Boolean
        Dim result
        array(0) = True
        array(1) = True
        array(2) = False
        array(3) = True
        array(4) = True
        array(5) = True
        array(6) = True

        ' Act.
        result = IsThereAFalseInArray(array)

        ' Assert.
        Assert.IsFalse(result)
    End Sub

    <TestMethod()> Public Sub test_are_all_values_false_in_array_returns_false()
        ' Arrange.
        Dim array(6) As Boolean
        Dim result
        array(0) = False
        array(1) = False
        array(2) = False
        array(3) = False
        array(4) = False
        array(5) = False
        array(6) = False

        ' Act.
        result = IsThereAFalseInArray(array)

        ' Assert.
        Assert.IsFalse(result)
    End Sub

    <TestMethod()> Public Sub test_format_string_returns_nice_string()
        ' Arrange.
        Const expected As String = """Maths"" + ""Basics"" + ""KS1"" + ""A simple addition"""
        Dim array(3) As String
        array(0) = "Maths"
        array(1) = "Basics"
        array(2) = "KS1"
        array(3) = "A simple addition"

        ' Act.
        Dim result = FormatSearchString(array)

        ' Assert.
        Assert.AreEqual(expected, result.ToString())
    End Sub

    <TestMethod()> Public Sub test_format_string_returns_nice_string_skipping_na()
        ' Arrange.
        Const expected As String = """Maths"" + ""Basics"" + ""A simple addition"""
        Dim array(3) As String
        array(0) = "Maths"
        array(1) = "Basics"
        array(2) = "N/A"
        array(3) = "A simple addition"

        ' Act.
        Dim result = FormatSearchString(array)

        ' Assert.
        Assert.AreEqual(expected, result.ToString())
    End Sub

End Class