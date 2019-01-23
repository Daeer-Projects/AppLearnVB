Imports ExampleProg.Constants
Imports ExampleProg.Interfaces

Namespace InputClasses.Training

    ''' <summary>
    ''' Gets the explanation details for the training.
    ''' </summary>
    ''' <remarks>A simple class.</remarks>
    Public Class ExplanationTraining
        Property ExplanationTitle As String
        Property ExplanationDetails As String

        Private Property DBConnection As IDbConnector

        ''' <summary>
        ''' Basic constructor for the training explanation class.
        ''' </summary>
        ''' <param name="explanationID">The id of the explanation to be displayed.</param>
        ''' <param name="dbConnector">The database connection.</param>
        ''' <remarks>Sets the title and details based on the explanation id.</remarks>
        Public Sub New(explanationID As Integer, dbConnector As IDbConnector)
            DBConnection = dbConnector

            If (explanationID > 0) Then
                SetExplanationDetailsFromId(explanationID)
            Else
                ExplanationTitle = CommonConstants.TrainingExplanationIdNotSuppliedError
            End If
        End Sub

        ''' <summary>
        ''' Gets the details from the database and sets the properties.
        ''' </summary>
        ''' <param name="explanationID">The id of the explanation to be displayed.</param>
        ''' <remarks>Sets the details of the explanation.</remarks>
        Private Sub SetExplanationDetailsFromId(explanationID As Integer)
            Dim explanationDetailsType = DBConnection.GetExplanationDetailsForTraining(explanationID)
            ExplanationTitle = explanationDetailsType.Title
            ExplanationDetails = explanationDetailsType.DescriptionOfExplanation
        End Sub

    End Class
End Namespace