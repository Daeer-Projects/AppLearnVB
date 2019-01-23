CREATE PROCEDURE [curriculum].[InsertNewKeyStage]
    @KeyStageDetails VARCHAR(50)
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        BEGIN TRANSACTION
        INSERT  INTO curriculum.tblKeyStage
                (KeyStageValue)
        VALUES  (@KeyStageDetails);
                
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
