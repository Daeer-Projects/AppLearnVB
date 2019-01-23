CREATE PROCEDURE [curriculum].[InsertNewExplanation]
    @CurriculumID INT,
    @Title VARCHAR(50),
    @Description VARCHAR(8000)
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        BEGIN TRANSACTION
        INSERT  INTO curriculum.tblExplanation
                (
                 CurriculumID,
                 Title,
                 DescriptionOfExplanation
                )
        VALUES  (
                 @CurriculumID,
                 @Title,
                 @Description
                );
                
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
