USE [TestCaseManagementSystem]
GO

/****** Object: Table [dbo].[TestScriptParameter] Script Date: 12/27/2016 1:51:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[TestScriptParameter];

SELECT * FROM [dbo].[TestScriptParameterType];

INSERT  INTO  [dbo].[TestScriptParameterType] VALUES  (NEWID() , 'ListOf(NVARCHAR)' , 2000 , 0 , 0 ,GETDATE() , '79D9F53D-DF34-4AEB-85FF-1FA73C3DF20B');


INSERT  INTO  [dbo].[TestScriptParameterType] VALUES  (NEWID() , 'ListOf(DECIMAL)' , 15 , 0 , 0 ,GETDATE() , '79D9F53D-DF34-4AEB-85FF-1FA73C3DF20B');
  
  




GO
CREATE TABLE [dbo].[TestRobot] (
    [TestRobotID]        UNIQUEIDENTIFIER NOT NULL,
    [TestRobotName]     UNIQUEIDENTIFIER NOT NULL,
    [CreatedDate]                  DATETIME         NOT NULL,
    [CreatedBy]                    UNIQUEIDENTIFIER NOT NULL
);



DROP TABLE [dbo].[TestRobotAction]

CREATE TABLE [dbo].[TestPropertyAllocated] (
    [TestPropertyAllocatedID]        UNIQUEIDENTIFIER NOT NULL,
    [TestPropertyID] UNIQUEIDENTIFIER     NOT NULL,
	[TestClassID]     UNIQUEIDENTIFIER NOT NULL,

	[CreatedDate]                  DATETIME         NOT NULL,
    [CreatedBy]                    UNIQUEIDENTIFIER NOT NULL
);


CREATE TABLE [dbo].[TestActionDetails] (
    [TestRobotActionID]        UNIQUEIDENTIFIER NOT NULL,
    [TestRobotActionName]     Nvarchar(100) NOT NULL,
	[TestClassID]  UNIQUEIDENTIFIER NOT NULL,
    [CreatedDate]                  DATETIME         NOT NULL,
    [CreatedBy]                    UNIQUEIDENTIFIER NOT NULL
);















DROP TABLE [dbo].[TestRobotType]
CREATE TABLE [dbo].[TestRobotType] (
    [TestRobotTypeID]        UNIQUEIDENTIFIER NOT NULL,
    [TestRobotTypeName]     Nvarchar(2000) NOT NULL,
    [CreatedDate]                  DATETIME         NOT NULL,
    [CreatedBy]                    UNIQUEIDENTIFIER NOT NULL
);




SELECT * FROM [dbo].[User]






INSERT INTO  [dbo].[TestRobotType] VALUES ( NEWID() , 'Medical BONE SCANNER', GETDATE() ,   '79D9F53D-DF34-4AEB-85FF-1FA73C3DF20B');

INSERT INTO  [dbo].[TestRobotType] VALUES ( NEWID() , 'Heart Scanner Robot', GETDATE() ,   '79D9F53D-DF34-4AEB-85FF-1FA73C3DF20B');

INSERT INTO  [dbo].[TestRobotType] VALUES ( NEWID() , 'Power Turbines', GETDATE() ,   '79D9F53D-DF34-4AEB-85FF-1FA73C3DF20B');

     

