USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [AppAccess]    Script Date: 09/01/2015 13:48:14 ******/
CREATE LOGIN [AppAccess] WITH PASSWORD=N'@ppAcc355', DEFAULT_DATABASE=[App4Learn], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO

ALTER LOGIN [AppAccess] DISABLE
GO


