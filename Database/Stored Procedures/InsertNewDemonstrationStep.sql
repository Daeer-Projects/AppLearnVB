CREATE PROCEDURE [questions].[InsertNewDemonstrationStep]
    (
     @DemoInsert questions.DemonstrationInsertType READONLY,
     @QuestionID INT
    )
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        BEGIN TRANSACTION
        INSERT  INTO questions.tblDemonstrationStage
                (
                 DescriptionOfStage, -- DescriptionOfStage - varchar(4000)
                 RegEx, -- RegEx - varchar(2000)
                 StageMark, -- StageMark - int
                 QuestionID  -- QuestionID - int
                )
                SELECT  DemonstrationStageInsert,
                        RegExInsert,
                        StageMarkInsert,
                        @QuestionID
                FROM    @DemoInsert;
                        
        COMMIT TRANSACTION;

    END TRY
    BEGIN CATCH

        IF (@@TRANCOUNT > 0)
            BEGIN
                ROLLBACK TRANSACTION;
            END;
        THROW;
    END CATCH;

END;

GO
