--  Comments here are associated with the test.
--  For test case examples, see: http://tsqlt.org/user-guide/tsqlt-tutorial/
ALTER PROCEDURE [ProceduresDoNotThrowExceptions].[test CreateNewUser NoException]
AS
BEGIN
    --Assemble
    --  This section is for code that sets up the environment. It often
    --  contains calls to methods such as tSQLt.FakeTable and tSQLt.SpyProcedure
    --  along with INSERTs of relevant data.
    --  For more information, see http://tsqlt.org/user-guide/isolating-dependencies/
    SET NOCOUNT ON;

    DECLARE @user VARCHAR(50) = 'tiggerz';
    DECLARE @pass VARCHAR(50) = '42';
    DECLARE @first VARCHAR(50) = 'tiggr';
    DECLARE @middle VARCHAR(50) = 'um';
    DECLARE @last VARCHAR(50) = 'bounce';

    --Act
    --  Execute the code under test like a stored procedure, function or view
    --  and capture the results in variables or tables.
  
    EXEC tSQLt.ExpectNoException
        @Message = N'CreateNewUser threw an exception.'; -- nvarchar(max)
  
    --Assert
    --  Compare the expected and actual values, or call tSQLt.Fail in an IF statement.  
    --  Available Asserts: tSQLt.AssertEquals, tSQLt.AssertEqualsString, tSQLt.AssertEqualsTable
    --  For a complete list, see: http://tsqlt.org/user-guide/assertions/
    EXEC users.CreateNewUser
        @UserName = @user,
        @Password = @pass,
        @FirstName = @first,
        @MiddleName = @middle,
        @LastName = @last;

END;





