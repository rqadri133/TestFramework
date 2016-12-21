USE [TestCaseManagementSystem]
GO

/****** Object: Table [dbo].[TestScriptParameterType] Script Date: 12/20/2016 8:48:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[TestScriptParameterType];


GO


CREATE TABLE [dbo].[TestScriptParameterType] (
    [TestScriptParamterTypeID]    UNIQUEIDENTIFIER NOT NULL,
    [TestScriptParameterTypeName] NVARCHAR (200)   NULL,
	[Length]					  int  Null ,
	[IsClass]				  	  bit ,
	[IsPrecisionAllowed]	      bit , 	
    [CreatedDate]                 DATETIME         NOT NULL,
    [CreatedBy]                   UNIQUEIDENTIFIER NOT NULL
);


