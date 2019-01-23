Imports ExampleProg.Constants
Imports ExampleProg.InputClasses.NewQuestionTypes
Imports ExampleProg.Interfaces
Imports ExampleProg.ProcedureReturnTypes
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq

Namespace NewQuestTypeTests

    <TestClass()> Public Class ExplanationTypeInputTests

        <TestMethod()> Public Sub process_sets_invalid_title_message_flag_to_empty_string()
            ' Arrange.
            Dim dbConnector = New Mock(Of IDbConnector)
            Dim explanationTypeInput = New ExplanationTypeInput(dbConnector.Object)

            ' Faking out the list.
            explanationTypeInput.ExplanationList = New List(Of ExplanationListType)

            ' Act.
            explanationTypeInput.Process("hello", "Key Stage 1")

            ' Assert.
            Assert.AreEqual(String.Empty, explanationTypeInput.InvalidTitleMessage)
        End Sub

        <TestMethod()> Public Sub process_sets_invalid_title_message_flag_to_not_a_valid_input()
            ' Arrange.
            Dim dbConnector = New Mock(Of IDbConnector)
            Dim explanationTypeInput = New ExplanationTypeInput(dbConnector.Object)

            ' Faking out the list.
            explanationTypeInput.ExplanationList = New List(Of ExplanationListType)

            ' Act.
            explanationTypeInput.Process(String.Empty, String.Empty)

            ' Assert.
            Assert.AreEqual(CommonConstants.NotAValidInput, explanationTypeInput.InvalidTitleMessage)
        End Sub

        <TestMethod()> Public Sub process_sets_explanation_id_correctly()
            ' Arrange.
            Dim dbConnector = New Mock(Of IDbConnector)
            Dim explanationTypeInput = New ExplanationTypeInput(dbConnector.Object)

            Dim explanation1 = New ExplanationListType()
            explanation1.ID = 1
            explanation1.ExplanationDetail = "Basic"
            Dim explanation2 = New ExplanationListType()
            explanation2.ID = 2
            explanation2.ExplanationDetail = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of ExplanationListType)
            list.Add(explanation1)
            list.Add(explanation2)
            explanationTypeInput.ExplanationList = list

            ' Act.
            explanationTypeInput.Process("Basic", String.Empty)

            ' Assert.
            Assert.AreEqual(1, explanationTypeInput.ExplanationID)
        End Sub

        <TestMethod()> Public Sub process_sets_explanation_id_to_zero_if_key_stage_not_in_list()
            ' Arrange.
            Dim dbConnector = New Mock(Of IDbConnector)
            Dim explanationTypeInput = New ExplanationTypeInput(dbConnector.Object)

            Dim explanation1 = New ExplanationListType()
            explanation1.ID = 1
            explanation1.ExplanationDetail = "Basic"
            Dim explanation2 = New ExplanationListType()
            explanation2.ID = 2
            explanation2.ExplanationDetail = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of ExplanationListType)
            list.Add(explanation1)
            list.Add(explanation2)
            explanationTypeInput.ExplanationList = list

            ' Act.
            explanationTypeInput.Process("Manic", String.Empty)

            ' Assert.
            Assert.AreEqual(0, explanationTypeInput.ExplanationID)
        End Sub

        <TestMethod()> Public Sub process_sets_explanation_id_correctly_if_input_is_lower_case()
            ' Arrange.
            Dim dbConnector = New Mock(Of IDbConnector)
            Dim explanationTypeInput = New ExplanationTypeInput(dbConnector.Object)

            Dim explanation1 = New ExplanationListType()
            explanation1.ID = 1
            explanation1.ExplanationDetail = "Basic"
            Dim explanation2 = New ExplanationListType()
            explanation2.ID = 2
            explanation2.ExplanationDetail = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of ExplanationListType)
            list.Add(explanation1)
            list.Add(explanation2)
            explanationTypeInput.ExplanationList = list

            ' Act.
            explanationTypeInput.Process("advanced", String.Empty)

            ' Assert.
            Assert.AreEqual(2, explanationTypeInput.ExplanationID)
        End Sub

        <TestMethod()> Public Sub process_sets_explanation_id_correctly_if_input_is_upper_case()
            ' Arrange.
            Dim dbConnector = New Mock(Of IDbConnector)
            Dim explanationTypeInput = New ExplanationTypeInput(dbConnector.Object)

            Dim explanation1 = New ExplanationListType()
            explanation1.ID = 1
            explanation1.ExplanationDetail = "Basic"
            Dim explanation2 = New ExplanationListType()
            explanation2.ID = 2
            explanation2.ExplanationDetail = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of ExplanationListType)
            list.Add(explanation1)
            list.Add(explanation2)
            explanationTypeInput.ExplanationList = list

            ' Act.
            explanationTypeInput.Process("ADVANCED", String.Empty)

            ' Assert.
            Assert.AreEqual(2, explanationTypeInput.ExplanationID)
        End Sub

        <TestMethod()> Public Sub process_sets_explanation_id_correctly_if_input_is_mixed_case()
            ' Arrange.
            Dim dbConnector = New Mock(Of IDbConnector)
            Dim explanationTypeInput = New ExplanationTypeInput(dbConnector.Object)

            Dim explanation1 = New ExplanationListType()
            explanation1.ID = 1
            explanation1.ExplanationDetail = "Basic"
            Dim explanation2 = New ExplanationListType()
            explanation2.ID = 2
            explanation2.ExplanationDetail = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of ExplanationListType)
            list.Add(explanation1)
            list.Add(explanation2)
            explanationTypeInput.ExplanationList = list

            ' Act.
            explanationTypeInput.Process("AdVaNcEd", String.Empty)

            ' Assert.
            Assert.AreEqual(2, explanationTypeInput.ExplanationID)
        End Sub

        <TestMethod()> Public Sub process_sets_invalid_detail_message_flag_to_empty_string()
            ' Arrange.
            Dim dbConnector = New Mock(Of IDbConnector)
            Dim explanationTypeInput = New ExplanationTypeInput(dbConnector.Object)

            ' Faking out the list.
            explanationTypeInput.ExplanationList = New List(Of ExplanationListType)

            ' Act.
            explanationTypeInput.Process("hello", "Key Stage 1")

            ' Assert.
            Assert.AreEqual(String.Empty, explanationTypeInput.InvalidDetailMessage)
        End Sub

        <TestMethod()> Public Sub process_sets_invalid_detail_message_flag_to_not_a_valid_input()
            ' Arrange.
            Dim dbConnector = New Mock(Of IDbConnector)
            Dim explanationTypeInput = New ExplanationTypeInput(dbConnector.Object)

            ' Faking out the list.
            explanationTypeInput.ExplanationList = New List(Of ExplanationListType)

            ' Act.
            explanationTypeInput.Process(String.Empty, String.Empty)

            ' Assert.
            Assert.AreEqual(CommonConstants.NotAValidInput, explanationTypeInput.InvalidDetailMessage)
        End Sub

        <TestMethod()> Public Sub process_sets_details_from_db_if_id_exists()
            ' Arrange.
            ' Faking out the list.
            Dim explanation1 = New ExplanationListType()
            explanation1.ID = 1
            explanation1.ExplanationDetail = "Basic"
            Dim explanation2 = New ExplanationListType()
            explanation2.ID = 2
            explanation2.ExplanationDetail = "Advanced"
            Dim explanationList = New List(Of ExplanationListType)
            explanationList.Add(explanation1)
            explanationList.Add(explanation2)

            Dim dbConnector = New Mock(Of IDbConnector)
            dbConnector.Setup(Function(c) c.GetListOfExplanations).Returns(explanationList)
            Const explanationDetails As String = "A details explanation of Advance."
            dbConnector.Setup(Function(d) d.GetExplanationDetailsById(It.IsAny(Of Integer))).Returns(explanationDetails)

            Dim explanationTypeInput = New ExplanationTypeInput(dbConnector.Object)

            ' Act.
            explanationTypeInput.Process("Advanced", String.Empty)

            ' Assert.
            Assert.AreEqual(explanationDetails, explanationTypeInput.ExplanationText)
        End Sub

        <TestMethod()> Public Sub process_sets_can_proceed_to_true()
            ' Arrange.
            Dim dbConnector = New Mock(Of IDbConnector)
            Dim explanationTypeInput = New ExplanationTypeInput(dbConnector.Object)

            Dim explanation1 = New ExplanationListType()
            explanation1.ID = 1
            explanation1.ExplanationDetail = "KS1"
            Dim explanation2 = New ExplanationListType()
            explanation2.ID = 2
            explanation2.ExplanationDetail = "KS2"

            Const explanationDetails As String = "A details explanation of KS1."
            dbConnector.Setup(Function(d) d.GetExplanationDetailsById(It.IsAny(Of Integer))).Returns(explanationDetails)

            ' Faking out the list.
            Dim list = New List(Of ExplanationListType)
            list.Add(explanation1)
            list.Add(explanation2)
            explanationTypeInput.ExplanationList = list

            ' Act.
            explanationTypeInput.Process("KS1", String.Empty)

            ' Assert.
            Assert.IsTrue(explanationTypeInput.CanProceed)
        End Sub

        <TestMethod()> Public Sub process_sets_can_proceed_to_false_with_empty_title()
            ' Arrange.
            Dim dbConnector = New Mock(Of IDbConnector)
            Dim explanationTypeInput = New ExplanationTypeInput(dbConnector.Object)

            ' Faking out the list.
            explanationTypeInput.ExplanationList = New List(Of ExplanationListType)

            ' Act.
            explanationTypeInput.Process(String.Empty, "Key Stage 1")

            ' Assert.
            Assert.IsFalse(explanationTypeInput.CanProceed)
        End Sub

        <TestMethod()> Public Sub process_sets_can_proceed_to_false_with_empty_detail()
            ' Arrange.
            Dim dbConnector = New Mock(Of IDbConnector)
            Dim explanationTypeInput = New ExplanationTypeInput(dbConnector.Object)

            ' Faking out the list.
            explanationTypeInput.ExplanationList = New List(Of ExplanationListType)

            ' Act.
            explanationTypeInput.Process("KS1", String.Empty)

            ' Assert.
            Assert.IsFalse(explanationTypeInput.CanProceed)
        End Sub

        <TestMethod()> Public Sub process_sets_is_new_explanation_if_explanation_not_in_list()
            'Arrange.
            Dim dbConnector = New Mock(Of IDbConnector)
            Dim explanationTypeInput = New ExplanationTypeInput(dbConnector.Object)

            Dim explanation1 = New ExplanationListType()
            explanation1.ID = 1
            explanation1.ExplanationDetail = "Basic"
            Dim explanation2 = New ExplanationListType()
            explanation2.ID = 2
            explanation2.ExplanationDetail = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of ExplanationListType)
            list.Add(explanation1)
            list.Add(explanation2)
            explanationTypeInput.ExplanationList = list

            ' Act.
            explanationTypeInput.Process("Manic", String.Empty)

            ' Assert.
            Assert.IsTrue(explanationTypeInput.IsNewExplanation)
        End Sub

        <TestMethod()> Public Sub process_sets_explanation_list()
            ' Arrange.
            ' Faking out the list.
            Dim explanation1 = New ExplanationListType()
            explanation1.ID = 1
            explanation1.ExplanationDetail = "Basic"
            Dim explanation2 = New ExplanationListType()
            explanation2.ID = 2
            explanation2.ExplanationDetail = "Advanced"
            Dim explanationList = New List(Of ExplanationListType)
            explanationList.Add(explanation1)
            explanationList.Add(explanation2)

            Dim otherList As IEnumerable(Of ExplanationListType)
            otherList = explanationList

            Dim dbConnector = New Mock(Of IDbConnector)
            dbConnector.Setup(Function(c) c.GetListOfExplanations()).Returns(otherList)

            Dim explanationTypeInput = New ExplanationTypeInput(dbConnector.Object)

            ' Act.
            explanationTypeInput.Process("Advanced", String.Empty)
            Dim result = explanationList.SequenceEqual(explanationTypeInput.ExplanationList)

            ' Assert.
            Assert.IsTrue(result)
        End Sub

    End Class
End Namespace