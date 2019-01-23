Imports ExampleProg.Constants
Imports ExampleProg.InputClasses.NewQuestionTypes
Imports ExampleProg.ProcedureReturnTypes
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace NewQuestTypeTests

    <TestClass()> Public Class KeyStageTypeInputTests

        <TestMethod()> Public Sub process_sets_can_proceed_to_true()
            ' Arrange.
            Dim keyStageTypeInput = New KeyStageTypeInput()

            Dim keystage1 = New KeyStageListType()
            keystage1.ID = 1
            keystage1.KeyStageDetail = "KS1"
            Dim keystage2 = New KeyStageListType()
            keystage2.ID = 2
            keystage2.KeyStageDetail = "KS2"

            ' Faking out the list.
            Dim list = New List(Of KeyStageListType)
            list.Add(keystage1)
            list.Add(keystage2)
            keyStageTypeInput.KeyStageList = list

            ' Act.
            keyStageTypeInput.Process("KS1")

            ' Assert.
            Assert.IsTrue(keyStageTypeInput.CanProceed)
        End Sub

        <TestMethod()> Public Sub process_sets_can_proceed_to_false()
            ' Arrange.
            Dim keyStageTypeInput = New KeyStageTypeInput()

            ' Faking out the list.
            keyStageTypeInput.KeyStageList = New List(Of KeyStageListType)

            ' Act.
            keyStageTypeInput.Process(String.Empty)

            ' Assert.
            Assert.IsFalse(keyStageTypeInput.CanProceed)
        End Sub

        <TestMethod()> Public Sub process_sets_invalid_message_flag_to_empty_string()
            ' Arrange.
            Dim keyStageTypeInput = New KeyStageTypeInput()

            ' Faking out the list.
            keyStageTypeInput.KeyStageList = New List(Of KeyStageListType)

            ' Act.
            keyStageTypeInput.Process("hello")

            ' Assert.
            Assert.AreEqual(String.Empty, keyStageTypeInput.InvalidMessage)
        End Sub

        <TestMethod()> Public Sub process_sets_invalid_message_flag_to_not_a_valid_input()
            ' Arrange.
            Dim keyStageTypeInput = New KeyStageTypeInput()

            ' Faking out the list.
            keyStageTypeInput.KeyStageList = New List(Of KeyStageListType)

            ' Act.
            keyStageTypeInput.Process(String.Empty)

            ' Assert.
            Assert.AreEqual(CommonConstants.NotAValidInput, keyStageTypeInput.InvalidMessage)
        End Sub

        <TestMethod()> Public Sub process_sets_key_stage_id_correctly()
            ' Arrange.
            Dim keyStageTypeInput = New KeyStageTypeInput()

            Dim keystage1 = New KeyStageListType()
            keystage1.ID = 1
            keystage1.KeyStageDetail = "Basic"
            Dim keystage2 = New KeyStageListType()
            keystage2.ID = 2
            keystage2.KeyStageDetail = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of KeyStageListType)
            list.Add(keystage1)
            list.Add(keystage2)
            keyStageTypeInput.KeyStageList = list

            ' Act.
            keyStageTypeInput.Process("Basic")

            ' Assert.
            Assert.AreEqual(1, keyStageTypeInput.KeyStageID)
        End Sub

        <TestMethod()> Public Sub process_sets_key_stage_id_to_zero_if_key_stage_not_in_list()
            ' Arrange.
            Dim keyStageTypeInput = New KeyStageTypeInput()

            Dim keystage1 = New KeyStageListType()
            keystage1.ID = 1
            keystage1.KeyStageDetail = "Basic"
            Dim keystage2 = New KeyStageListType()
            keystage2.ID = 2
            keystage2.KeyStageDetail = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of KeyStageListType)
            list.Add(keystage1)
            list.Add(keystage2)
            keyStageTypeInput.KeyStageList = list

            ' Act.
            keyStageTypeInput.Process("Manic")

            ' Assert.
            Assert.AreEqual(0, keyStageTypeInput.KeyStageID)
        End Sub

        <TestMethod()> Public Sub process_sets_is_new_key_stage_if_key_stage_not_in_list()
            'Arrange.
            Dim keyStageTypeInput = New KeyStageTypeInput()

            Dim keystage1 = New KeyStageListType()
            keystage1.ID = 1
            keystage1.KeyStageDetail = "Basic"
            Dim keystage2 = New KeyStageListType()
            keystage2.ID = 2
            keystage2.KeyStageDetail = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of KeyStageListType)
            list.Add(keystage1)
            list.Add(keystage2)
            keyStageTypeInput.KeyStageList = list

            ' Act.
            keyStageTypeInput.Process("Manic")

            ' Assert.
            Assert.IsTrue(keyStageTypeInput.IsNewKeyStage)
        End Sub

        <TestMethod()> Public Sub process_sets_key_stage_id_correctly_if_input_is_lower_case()
            ' Arrange.
            Dim keyStageTypeInput = New KeyStageTypeInput()

            Dim keystage1 = New KeyStageListType()
            keystage1.ID = 1
            keystage1.KeyStageDetail = "Basic"
            Dim keystage2 = New KeyStageListType()
            keystage2.ID = 2
            keystage2.KeyStageDetail = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of KeyStageListType)
            list.Add(keystage1)
            list.Add(keystage2)
            keyStageTypeInput.KeyStageList = list

            ' Act.
            keyStageTypeInput.Process("advanced")

            ' Assert.
            Assert.AreEqual(2, keyStageTypeInput.KeyStageID)
        End Sub

        <TestMethod()> Public Sub process_sets_key_stage_id_correctly_if_input_is_upper_case()
            ' Arrange.
            Dim keyStageTypeInput = New KeyStageTypeInput()

            Dim keystage1 = New KeyStageListType()
            keystage1.ID = 1
            keystage1.KeyStageDetail = "Basic"
            Dim keystage2 = New KeyStageListType()
            keystage2.ID = 2
            keystage2.KeyStageDetail = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of KeyStageListType)
            list.Add(keystage1)
            list.Add(keystage2)
            keyStageTypeInput.KeyStageList = list

            ' Act.
            keyStageTypeInput.Process("ADVANCED")

            ' Assert.
            Assert.AreEqual(2, keyStageTypeInput.KeyStageID)
        End Sub

        <TestMethod()> Public Sub process_sets_key_stage_id_correctly_if_input_is_mixed_case()
            ' Arrange.
            Dim keyStageTypeInput = New KeyStageTypeInput()

            Dim keystage1 = New KeyStageListType()
            keystage1.ID = 1
            keystage1.KeyStageDetail = "Basic"
            Dim keystage2 = New KeyStageListType()
            keystage2.ID = 2
            keystage2.KeyStageDetail = "Advanced"

            ' Faking out the list.
            Dim list = New List(Of KeyStageListType)
            list.Add(keystage1)
            list.Add(keystage2)
            keyStageTypeInput.KeyStageList = list

            ' Act.
            keyStageTypeInput.Process("AdVaNcEd")

            ' Assert.
            Assert.AreEqual(2, keyStageTypeInput.KeyStageID)
        End Sub

    End Class
End Namespace