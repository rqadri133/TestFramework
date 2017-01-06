USE [TestCaseManagementSystem]
GO

/****** Object: Table [dbo].[TestClass] Script Date: 12/31/2016 2:24:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


DROP TABLE [dbo].[TestClass];

GO


CREATE TABLE [dbo].[TestClass] (
    [TestClassID]        UNIQUEIDENTIFIER NOT NULL,
    [TestClassName]      NVARCHAR (100)   NOT NULL,
    [TestClassNameSpace] NVARCHAR (100)   NOT NULL,
    [TestParentClassID]  UNIQUEIDENTIFIER NULL,
    [CreatedDate]        DATETIME         NOT NULL,
    [CreatedBy]          UNIQUEIDENTIFIER NOT NULL
);


