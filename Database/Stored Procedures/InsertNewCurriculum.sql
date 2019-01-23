CREATE PROCEDURE [curriculum].[InsertNewCurriculum]
    @SubjectID INT,
    @CurriculumDetail VARCHAR(50)
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        BEGIN TRANSACTION
        INSERT  INTO curriculum.tblCurriculum
                (SubjectID, TypeOfStudy)
        VALUES  (@SubjectID, @CurriculumDetail);
                
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
