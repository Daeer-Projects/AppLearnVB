CREATE PROCEDURE [InsertNewDemonstrationStep].[Setup]
AS
BEGIN
    SET NOCOUNT ON;
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.

    EXEC tSQLt.FakeTable
        @TableName = N'questions.tblDemonstrationStage', -- nvarchar(max)
        @Identity = 1, -- bit
        @ComputedColumns = 0, -- bit
        @Defaults = 0; -- bit
        
    CREATE TABLE InsertNewDemonstrationStep.Expected
        (
         ID INT,
         DescriptionOfStage VARCHAR(4000),
         RegEx VARCHAR(2000),
         StageMark INT,
         QuestionID INT
        );
    
    CREATE TABLE InsertNewDemonstrationStep.Actual
        (
         ID INT,
         DescriptionOfStage VARCHAR(4000),
         RegEx VARCHAR(2000),
         StageMark INT,
         QuestionID INT
        );

END;
