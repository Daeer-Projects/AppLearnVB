USE [App4Learn]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--  Comments here are associated with the test.
--  For test case examples, see: http://tsqlt.org/user-guide/tsqlt-tutorial/
CREATE PROCEDURE [InsertNewQuestion].[test CheckIDReturnedIsLatestID]
AS
BEGIN
    SET NOCOUNT ON;
  --Assemble
  --  This section is for code that sets up the environment. It often
  --  contains calls to methods such as tSQLt.FakeTable and tSQLt.SpyProcedure
  --  along with INSERTs of relevant data.
  --  For more information, see http://tsqlt.org/user-guide/isolating-dependencies/
  
    DECLARE @insert questions.QuestionInsertType;
    DECLARE @expectedID INT = 3;
    DECLARE @actualID INT;

    INSERT  INTO @insert
            (
             SelectedSubjectID,
             SelectedCurriculumID,
             SelectedKeyStageID,
             SelectedExplanationID,
             NewQuestion,
             NewAnswer,
             AmountOfStepsSet,
             TotalMarksSet,
             NewFalseAnswerA,
             NewFalseAnswerB,
             NewFalseAnswerC,
             NewSearchString,
             NewWebLink
            )
    VALUES  (
             1, -- SelectedSubjectID - int
             1, -- SelectedCurriculumID - int
             1, -- SelectedKeyStageID - int
             1, -- SelectedExplanationID - int
             'What is what?', -- NewQuestion - varchar(200)
             'This', -- NewAnswer - varchar(1500)
             1, -- AmountOfStepsSet - int
             5, -- TotalMarksSet - int
             'That', -- NewFalseAnswerA - varchar(1500)
             'What', -- NewFalseAnswerB - varchar(1500)
             'No', -- NewFalseAnswerC - varchar(1500)
             'Somthing, else, here', -- NewSearchString - varchar(300)
             'www.bbc.co.uk/bitsize'  -- NewWebLink - varchar(300)
            );

    EXEC tSQLt.FakeTable
        @TableName = N'questions.tblQuestion', -- nvarchar(max)
        @Identity = 1, -- bit
        @ComputedColumns = 0, -- bit
        @Defaults = 0; -- bit
    
    INSERT  INTO questions.tblQuestion
            (SubjectID, CurriculumID, KeyStageID, ExplanationID, Question,
             Answer, AmountOfSteps, TotalMarks, FalseAnswerA, FalseAnswerB,
             FalseAnswerC, SearchString, WebLink)
    VALUES  (1, -- SubjectID - int
             1, -- CurriculumID - int
             1, -- KeyStageID - int
             1, -- ExplanationID - int
             'Um?', -- Question - varchar(200)
             '2', -- Answer - varchar(1500)
             1, -- AmountOfSteps - int
             5, -- TotalMarks - int
             '3', -- FalseAnswerA - varchar(1500)
             '4', -- FalseAnswerB - varchar(1500)
             '5', -- FalseAnswerC - varchar(1500)
             NULL, -- SearchString - varchar(300)
             NULL  -- WebLink - varchar(300)
             ),
            (1, -- SubjectID - int
             2, -- CurriculumID - int
             1, -- KeyStageID - int
             4, -- ExplanationID - int
             'What?', -- Question - varchar(200)
             'No', -- Answer - varchar(1500)
             2, -- AmountOfSteps - int
             4, -- TotalMarks - int
             'Yes', -- FalseAnswerA - varchar(1500)
             'Um', -- FalseAnswerB - varchar(1500)
             'Kind of', -- FalseAnswerC - varchar(1500)
             NULL, -- SearchString - varchar(300)
             NULL  -- WebLink - varchar(300)
             );

  --Act
  --  Execute the code under test like a stored procedure, function or view
  --  and capture the results in variables or tables.
  
    EXEC questions.InsertNewQuestion
        @InsertType = @insert; -- QuestionInsertType
  
    SET @actualID = (SELECT quest.ID
                     FROM   questions.tblQuestion AS quest
                     WHERE  quest.Question = 'What is what?'
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
