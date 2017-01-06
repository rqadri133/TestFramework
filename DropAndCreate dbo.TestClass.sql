USE [TestCaseManagementSystem]
GO

/****** Object: Table [dbo].[TestClass] Script Date: 1/4/2017 12:57:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[TestClass];


GO
CREATE TABLE [dbo].[TestClass] (
    [TestClassID]        UNIQUEIDENTIFIER NOT NULL,
    [TestClassName]      NVARCHAR (100)   NOT NULL,
	[TestClassTypeCode] NVARCHAR(50) NOT NULL,
    [TestClassNameSpace] NVARCHAR (100)   NOT NULL,
    [TestParentClassID]  UNIQUEIDENTIFIER NULL,
    [CreatedDate]        DATETIME         NOT NULL,
    [CreatedBy]          UNIQUEIDENTIFIER NOT NULL
);


