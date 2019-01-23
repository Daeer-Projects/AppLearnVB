/****** Object:  Schema [InsertNewKeyStage]    Script Date: 09/02/2015 20:38:16 ******/
CREATE SCHEMA [InsertNewKeyStage]
GO

EXEC sys.sp_addextendedproperty
    @name = N'tSQLt.TestClass',
    @value = 1,
    @level0type = N'SCHEMA',
    @level0name = N'InsertNewKeyStage'
GO
