/****** Object:  Schema [DatabaseIntegrityChecks]    Script Date: 14/02/2015 16:58:58 ******/
CREATE SCHEMA [DatabaseIntegrityChecks]
GO

EXEC sys.sp_addextendedproperty
    @name = N'tSQLt.TestClass',
    @value = 1,
    @level0type = N'SCHEMA',
    @level0name = N'DatabaseIntegrityChecks'
GO
