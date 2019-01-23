CREATE PROCEDURE [questions].[InsertNewQuestion]
    (
     @InsertType questions.QuestionInsertType READONLY
    )
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        BEGIN TRANSACTION
        INSERT  INTO questions.tblQuestion
                (
                 SubjectID,
                 CurriculumID,
                 KeyStageID,
                 ExplanationID,
                 Question,
                 Answer,
                 AmountOfSteps,
                 TotalMarks,
                 FalseAnswerA,
                 FalseAnswerB,
                 FalseAnswerC,
                 SearchString,
                 WebLink
                )
                SELECT  SelectedSubjectID, -- SubjectID - int
                        SelectedCurriculumID, -- CurriculumID - int
                        SelectedKeyStageID, -- KeyStageID - int
                        SelectedExplanationID, -- ExplanationID - int
                        NewQuestion, -- Question - varchar(200)
                        NewAnswer, -- Answer - varchar(1500)
                        AmountOfStepsSet, -- AmountOfSteps - int
                        TotalMarksSet, -- TotalMarks - int
                        NewFalseAnswerA, -- FalseAnswerA - varchar(1500)
                        NewFalseAnswerB, -- FalseAnswerB - varchar(1500)
                        NewFalseAnswerC, -- FalseAnswerC - varchar(1500)
                        NewSearchString, -- SearchString - varchar(300)
                        NewWebLink  -- WebLink - varchar(300)
                FROM    @InsertType;
                
        COMMIT TRANSACTION;

        SELECT  SCOPE_IDENTITY();

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
