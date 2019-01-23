USE [App4Learn]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--  Comments here are associated with the test.
--  For test case examples, see: http://tsqlt.org/user-guide/tsqlt-tutorial/
ALTER PROCEDURE [InsertNewDemonstrationStep].[test CheckCountIsIncreasedWithMultipleInserts]
AS
BEGIN
    SET NOCOUNT ON;
  --Assemble
  --  This section is for code that sets up the environment. It often
  --  contains calls to methods such as tSQLt.FakeTable and tSQLt.SpyProcedure
  --  along with INSERTs of relevant data.
  --  For more information, see http://tsqlt.org/user-guide/isolating-dependencies/
  
    DECLARE @DemoStepInsert questions.DemonstrationInsertType;
    DECLARE @question INT = 6;
    DECLARE @expected INT = 3;
    DECLARE @actual INT;

    INSERT  INTO @DemoStepInsert
            (DemonstrationStageInsert, RegExInsert, StageMarkInsert)
    VALUES  ('A very long demo step.', '$/d/s Some reg ex here./s/d/$2', 5),
            ('Another long demo step.', '$/d/s Some more reg ex here./s/d/$2', 5),
            ('Yet another long demo step.', '$/d/s Some more reg ex here./s/d/$2', 5);
                            
  --Act
  --  Execute the code under test like a stored procedure, function or view
  --  and capture the results in variables or tables.
    
    EXEC questions.InsertNewDemonstrationStep
        @DemoInsert = @DemoStepInsert,
        @QuestionID = @question;

    SET @actual = (SELECT   COUNT(demos.ID)
                   FROM     questions.tblDemonstrationStage AS demos
                  );

  --Assert
  --  Compare the expected and actual values, or call tSQLt.Fail in an IF statement.  
  --  Available Asserts: tSQLt.AssertEquals, tSQLt.AssertEqualsString, tSQLt.AssertEqualsTable
  --  For a complete list, see: http://tsqlt.org/user-guide/assertions/

    EXEC tSQLt.AssertEquals
        @Expected = @expected, -- sql_variant
        @Actual = @actual, -- sql_variant
        @Message = N'The expected tabld count does not match the actual.'; -- nvarchar(max)
      
END;

