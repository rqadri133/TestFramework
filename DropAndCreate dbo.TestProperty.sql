USE [TestCaseManagementSystem]
GO

/****** Object: Table [dbo].[TestProperty] Script Date: 1/4/2017 4:17:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[TestProperty];


GO
CREATE TABLE [dbo].[TestProperty] (
    [TestPropertyID]            UNIQUEIDENTIFIER NOT NULL,
    [TestScriptParameterTypeID] UNIQUEIDENTIFIER NOT NULL,
    [TestPropertyName]          NVARCHAR (100)   NOT NULL,
	[TestPropertyValueToCheck]  NVARCHAR (2000)   NOT NULL,
	[TestPropertyValueFound]    NVARCHAR (2000)   NOT NULL,
    [CreatedDate]               DATETIME         NOT NULL,
    [CreatedBy]                 UNIQUEIDENTIFIER NOT NULL
);


