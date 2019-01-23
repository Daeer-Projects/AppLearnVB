--  Comments here are associated with the test.
--  For test case examples, see: http://tsqlt.org/user-guide/tsqlt-tutorial/
CREATE PROCEDURE [InsertNewCurriculum].[test CheckIDReturnedIsLatestID]
AS
BEGIN
    SET NOCOUNT ON;
  --Assemble
  --  This section is for code that sets up the environment. It often
  --  contains calls to methods such as tSQLt.FakeTable and tSQLt.SpyProcedure
  --  along with INSERTs of relevant data.
  --  For more information, see http://tsqlt.org/user-guide/isolating-dependencies/
  
    DECLARE @id INT = 1;
    DECLARE @details VARCHAR(50) = 'Some rubbish here';
    DECLARE @expectedID INT = 3;
    DECLARE @actualID INT;

    EXEC tSQLt.FakeTable
        @TableName = N'curriculum.tblSubject',
        @Identity = 1, -- bit
        @ComputedColumns = 0, -- bit
        @Defaults = 0; -- bit
   
    EXEC tSQLt.FakeTable
        @TableName = N'curriculum.tblCurriculum',
        @Identity = 1, -- bit
        @ComputedColumns = 0, -- bit
        @Defaults = 0; -- bit
    
    INSERT  INTO curriculum.tblSubject
            (SubjectDetail)
    VALUES  ('Banana Peeling');

    INSERT  INTO curriculum.tblCurriculum
            (SubjectID, TypeOfStudy)
    VALUES  (1, 'Peel'),
            (1, 'Eat');

  --Act
  --  Execute the code under test like a stored procedure, function or view
  --  and capture the results in variables or tables.
  
    EXEC curriculum.InsertNewCurriculum
        @SubjectID = @id,
        @CurriculumDetail = @details;

    SET @actualID = (SELECT curric.ID
                     FROM   curriculum.tblCurriculum AS curric
                     WHERE  curric.TypeOfStudy = @details
                    );

  --Assert
  --  Compare the expected and actual values, or call tSQLt.Fail in an IF statement.  
  --  Available Asserts: tSQLt.AssertEquals, tSQLt.AssertEqualsString, tSQLt.AssertEqualsTable
  --  For a complete list, see: http://tsqlt.org/user-guide/assertions/
    EXEC tSQLt.AssertEquals
        @Expected = @expectedID, -- sql_variant
        @Actual = @actualID, -- sql_variant
        @Message = N'ID inserted does not match the expected ID.'; -- nvarchar(max)
    
END;
