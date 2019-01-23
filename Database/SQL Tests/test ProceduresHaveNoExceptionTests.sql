--  Comments here are associated with the test.
--  For test case examples, see: http://tsqlt.org/user-guide/tsqlt-tutorial/
CREATE PROCEDURE [DatabaseIntegrityChecks].[test ProceduresHaveNoExceptionTests]
AS
BEGIN
    SET NOCOUNT ON;
  --Assemble
  --  This section is for code that sets up the environment. It often
  --  contains calls to methods such as tSQLt.FakeTable and tSQLt.SpyProcedure
  --  along with INSERTs of relevant data.
  --  For more information, see http://tsqlt.org/user-guide/isolating-dependencies/
  
    DECLARE @ProcedureCount INT;
    DECLARE @ListOfProcedures VARCHAR(MAX);

    CREATE TABLE #Exception
        (
         ProcedureName VARCHAR(128)
        );

    INSERT  INTO #Exception
            (
             ProcedureName
            )
            SELECT  r.SPECIFIC_NAME
            FROM    INFORMATION_SCHEMA.ROUTINES AS r
            WHERE   r.ROUTINE_TYPE = 'PROCEDURE'
                    AND r.SPECIFIC_SCHEMA IN ('curriculum', 'questions',
                                              'users')
                    AND r.ROUTINE_NAME NOT IN (
                    SELECT  SUBSTRING(p.name, 6,
                                      LEN(p.name) - 5 - CHARINDEX(' ',
                                                              REVERSE(p.name)))
                    FROM    sys.procedures AS p
                    WHERE   p.name LIKE 'test%NoException')
            ORDER BY r.ROUTINE_NAME;

  --Act
  --  Execute the code under test like a stored procedure, function or view
  --  and capture the results in variables or tables.
  
    SET @ProcedureCount = (SELECT   COUNT(ProcedureName)
                           FROM     #Exception
                          );

    SET @ListOfProcedures = (SELECT SUBSTRING((SELECT   ProcedureName + ', '
                                               FROM     #Exception
                                              FOR
                                               XML PATH('')
                                              ), 1, 1000)
                            );

  --Assert
  --  Compare the expected and actual values, or call tSQLt.Fail in an IF statement.  
  --  Available Asserts: tSQLt.AssertEquals, tSQLt.AssertEqualsString, tSQLt.AssertEqualsTable
  --  For a complete list, see: http://tsqlt.org/user-guide/assertions/
    IF (@ProcedureCount > 0)
        BEGIN
            EXEC tSQLt.Fail
                @Message0 = N'The following stored procedures are missing from these tests: ', -- nvarchar(max)
                @Message1 = @ListOfProcedures, -- nvarchar(max)
                @Message2 = N' please create tests for these procedures!', -- nvarchar(max)
                @Message3 = N' The total amount of procedures: ', -- nvarchar(max)
                @Message4 = @ProcedureCount, -- nvarchar(max)
                @Message5 = N'.'; -- nvarchar(max)        
        END;
  
END;

