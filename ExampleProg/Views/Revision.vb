Imports System.Configuration
Imports DapperWrapper
Imports ExampleProg.Constants
Imports ExampleProg.DatabaseClasses
Imports ExampleProg.Interfaces

''' <summary>
''' Unfinished revision page.
''' </summary>
''' <remarks></remarks>
Public Class Revision

    Dim WithEvents _dbConnector As IDbConnector
    Private _dbConnectionString As String

    ''' <summary>
    ''' Catches the load event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Revision_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _dbConnectionString = ConfigurationManager.ConnectionStrings(DatabaseConstants.ApplicationConfigString).ConnectionString
        TopMost = False
        Initialize()
    End Sub

    ''' <summary>
    ''' Initialises the setting for the page.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()
        InitializeDatabase()
    End Sub

    ''' <summary>
    ''' Sets up the database connection for the window.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitializeDatabase()
        Dim sqlExecutorFactory = New SqlExecutorFactory(_dbConnectionString)
        Dim newDatabaseConnection = New DatabaseConnectorWrapper(sqlExecutorFactory)
        _dbConnector = newDatabaseConnection
    End Sub

    ''' <summary>
    ''' Catches the cancel click event.
    ''' Closes the window.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles RevisionCancelButton.Click
        Close()
    End Sub
End Class