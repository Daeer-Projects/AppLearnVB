Imports ExampleProg.Constants
Imports ExampleProg.InputClasses.Training
Imports ExampleProg.Interfaces
Imports ExampleProg.ProcedureReturnTypes
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq

Namespace TrainingTests

    <TestClass()> Public Class ExplanationTrainingTests
        Private _explanationTraining As ExplanationTraining
        Private _mockDb As Mock(Of IDbConnector)

#Region "Explanation Setups"

        Private Function GetValidExplanationDetails() As GetExplanationDetailsType
            Dim explanation = New GetExplanationDetailsType()
            explanation.ID = 1
            explanation.Title = "Hello"
            explanation.DescriptionOfExplanation = "A very long description..."

            Return explanation
        End Function

        Private Function GetInValidExplanationDetails() As GetExplanationDetailsType
            Dim explanation = New GetExplanationDetailsType()
            explanation.ID = 0
            explanation.Title = String.Empty
            explanation.DescriptionOfExplanation = String.Empty

            Return explanation
        End Function

#End Region

        <TestMethod()> Public Sub test_new_explanation_training_with_id_returns_explanation_title()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(e) e.GetExplanationDetailsForTraining(It.IsAny(Of Integer))).Returns(GetValidExplanationDetails())

            ' Act.
            _explanationTraining = New ExplanationTraining(1, _mockDb.Object)

            ' Assert.
            Assert.AreEqual(GetValidExplanationDetails().Title, _explanationTraining.ExplanationTitle)
        End Sub

        <TestMethod()> Public Sub test_new_explanation_training_with_id_returns_explanation_details()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(e) e.GetExplanationDetailsForTraining(It.IsAny(Of Integer))).Returns(GetValidExplanationDetails())

            ' Act.
            _explanationTraining = New ExplanationTraining(1, _mockDb.Object)

            ' Assert.
            Assert.AreEqual(GetValidExplanationDetails().DescriptionOfExplanation, _explanationTraining.ExplanationDetails)
        End Sub

        <TestMethod()> Public Sub test_new_explanation_training_without_id_sets_error_message()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            
            ' Act.
            _explanationTraining = New ExplanationTraining(0, _mockDb.Object)

            ' Assert.
            Assert.AreEqual(CommonConstants.TrainingExplanationIdNotSuppliedError, _explanationTraining.ExplanationTitle)
        End Sub

        <TestMethod()> Public Sub test_new_explanation_training_with_id_does_not_return_correct_explanation_title()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(e) e.GetExplanationDetailsForTraining(It.IsAny(Of Integer))).Returns(GetInValidExplanationDetails())

            ' Act.
            _explanationTraining = New ExplanationTraining(1, _mockDb.Object)

            ' Assert.
            Assert.AreNotEqual(GetValidExplanationDetails().Title, _explanationTraining.ExplanationTitle)
        End Sub

        <TestMethod()> Public Sub test_new_explanation_training_with_id_does_not_return_correct_explanation_details()
            ' Arrange.
            _mockDb = New Mock(Of IDbConnector)()
            _mockDb.Setup(Function(e) e.GetExplanationDetailsForTraining(It.IsAny(Of Integer))).Returns(GetInValidExplanationDetails())

            ' Act.
            _explanationTraining = New ExplanationTraining(1, _mockDb.Object)

            ' Assert.
            Assert.AreNotEqual(GetValidExplanationDetails().DescriptionOfExplanation, _explanationTraining.ExplanationDetails)
        End Sub

    End Class
End Namespace