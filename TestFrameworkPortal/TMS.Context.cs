﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestFrameworkPortal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TMS : DbContext
    {
        public TMS()
            : base("name=TMS")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<ErrorLogger> ErrorLoggers { get; set; }
        public virtual DbSet<RegressFileTest> RegressFileTests { get; set; }
        public virtual DbSet<RegressFileTest1> RegressFileTests1 { get; set; }
        public virtual DbSet<TargetFramework> TargetFrameworks { get; set; }
        public virtual DbSet<TestCase> TestCases { get; set; }
        public virtual DbSet<TestCaseAssigned> TestCaseAssigneds { get; set; }
        public virtual DbSet<TestCaseAssigned1> TestCaseAssigneds1 { get; set; }
        public virtual DbSet<TestCas> TestCases1 { get; set; }
        public virtual DbSet<TestConnection> TestConnections { get; set; }
        public virtual DbSet<TestConnectionType> TestConnectionTypes { get; set; }
        public virtual DbSet<TestCycle> TestCycles { get; set; }
        public virtual DbSet<TestCycle1> TestCycles1 { get; set; }
        public virtual DbSet<TestDataModelFunction> TestDataModelFunctions { get; set; }
        public virtual DbSet<TestDataModelFunction1> TestDataModelFunctions1 { get; set; }
        public virtual DbSet<TestDataNodeAnaylysi> TestDataNodeAnaylysis { get; set; }
        public virtual DbSet<TestDataNodeTriggeredEvent> TestDataNodeTriggeredEvents { get; set; }
        public virtual DbSet<TestEnvironment> TestEnvironments { get; set; }
        public virtual DbSet<TestEnvironment1> TestEnvironments1 { get; set; }
        public virtual DbSet<TestExpressionInjection> TestExpressionInjections { get; set; }
        public virtual DbSet<TestExpressionInjection1> TestExpressionInjections1 { get; set; }
        public virtual DbSet<TestNode> TestNodes { get; set; }
        public virtual DbSet<TestNodeDetail> TestNodeDetails { get; set; }
        public virtual DbSet<TestNodeDetail1> TestNodeDetails1 { get; set; }
        public virtual DbSet<TestNode1> TestNodes1 { get; set; }
        public virtual DbSet<TestOperand> TestOperands { get; set; }
        public virtual DbSet<TestResultTemplate> TestResultTemplates { get; set; }
        public virtual DbSet<TestResultTemplate1> TestResultTemplates1 { get; set; }
        public virtual DbSet<TestScenario> TestScenarios { get; set; }
        public virtual DbSet<TestScript> TestScripts { get; set; }
        public virtual DbSet<TestScriptParameter> TestScriptParameters { get; set; }
        public virtual DbSet<TestTargetFrameworkVersion> TestTargetFrameworkVersions { get; set; }
        public virtual DbSet<TestType> TestTypes { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<TestClass> TestClasses { get; set; }
        public virtual DbSet<TestMicroController> TestMicroControllers { get; set; }
        public virtual DbSet<TestProperty> TestProperties { get; set; }
        public virtual DbSet<TestPropertyAllocated> TestPropertyAllocateds { get; set; }
        public virtual DbSet<TestRobot> TestRobots { get; set; }
        public virtual DbSet<TestRobotAction> TestRobotActions { get; set; }
        public virtual DbSet<TestRobotConfiguration> TestRobotConfigurations { get; set; }
        public virtual DbSet<TestRobotParameter> TestRobotParameters { get; set; }
        public virtual DbSet<TestRobotType> TestRobotTypes { get; set; }
        public virtual DbSet<TestScenario1> TestScenarios1 { get; set; }
        public virtual DbSet<TestScriptParameter1> TestScriptParameters1 { get; set; }
        public virtual DbSet<TestScriptParameterType> TestScriptParameterTypes { get; set; }
        public virtual DbSet<TestScriptParameterType1> TestScriptParameterTypes1 { get; set; }
        public virtual DbSet<TestScript1> TestScripts1 { get; set; }
        public virtual DbSet<TestType1> TestTypes1 { get; set; }
    }
}
