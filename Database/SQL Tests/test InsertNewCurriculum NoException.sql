--  Comments here are associated with the test.
--  For test case examples, see: http://tsqlt.org/user-guide/tsqlt-tutorial/
CREATE PROCEDURE [ProceduresDoNotThrowExceptions].[test InsertNewCurriculum NoException]
AS
BEGIN
    SET NOCOUNT ON;
  --Assemble
  --  This section is for code that sets up the environment. It often
  --  contains calls to methods such as tSQLt.FakeTable and tSQLt.SpyProcedure
  --  along with INSERTs of relevant data.
  --  For more information, see http://tsqlt.org/user-guide/isolating-dependencies/
  
    DECLARE @subject INT = 1;
    DECLARE @detail VARCHAR(50) = 'Banana Peeling';

  --Act
  --  Execute the code under test like a stored procedure, function or view
  --  and capture the results in variables or tables.
  
    EXEC tSQLt.ExpectNoException
        @Message = N'InsertNewCurriculum threw an exception.'; -- nvarchar(max)
  
  --Assert
  --  Compare the expected and actual values, or call tSQLt.Fail in an IF statement.  
  --  Available Asserts: tSQLt.AssertEquals, tSQLt.AssertEqualsString, tSQLt.AssertEqualsTable
  --  For a complete list, see: http://tsqlt.org/user-guide/assertions/
    EXEC curriculum.InsertNewCurriculum
        @SubjectID = @subject,
        @CurriculumDetail = @detail;
  
END;
