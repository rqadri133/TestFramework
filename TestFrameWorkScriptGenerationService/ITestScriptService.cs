using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TestFrameWorkScriptGenerationService
{
    
    public enum CodeGenerationInstruction
    {
        ExistingAssembly = 101 ,
        GenerateNewAssembly = 102,
        GenerateSQLQueryCheckOnlyZeroPlatform = 103 ,
        InjectRemainingCode = 104,
        DeleteAnOverRideCode =105,
        ExecuteOnly = 106 ,
        ExecuteAndSendReport = 107,
        GenerateReportForProvidedID = 108

    }


    public enum PlateForm
    {

        DotNetFrameWork = 4201,
        JavaFrameWork  = 4202,
   
    }

     

    /* SYED QADRI 
     * 
     * Emplid
     * 722862*/



    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITestScriptervice
    {
        [OperationContract]
         TestScript CreateScript<T>(T obj , CodeGenerationInstruction codeInstructions) ;

        // TODO: Add your service operations here


        [OperationContract]
        TestScript UpdateScript<T>(T obj , CodeGenerationInstruction codeInstructions);
                


        [OperationContract]
        TestScript DeleteScript<T>(T obj, CodeGenerationInstruction codeInstructions);



        [OperationContract]
        TestScript InjectCodeLineScript<T>(TestScript script, CodeGenerationInstruction codeInstructions);


        [OperationContract]
        TestScript ExecuteScript<T>(TestScript script, CodeGenerationInstruction codeInstructions);



        [OperationContract]
         TestReport ScriptReport<T>(TestScript script, CodeGenerationInstruction codeInstructions);


        [OperationContract]
        TestExpression GenerateRegexExpression(TestExpression ruleExpression);



    }

    public class  CodeLine
    {
        public int LinIndex
        {
            get;
            set;

        }

        public string CodeExtensionType
        {
            get;
            set;

        }

        public string LineContent
        {
            get;
            set;

        }


        public bool LineParsed
        {
            get;
            set;

        }

        public string TranslateCodeExpressionToCSharpLine
        {
            get;
            set;

        }


        public string TranslateCodeExpressionToJavaLine
        {
            get;
            set;

        }




        public string TranslateCodeExpressionToVB
        {
            get;
            set;

        }


    }



    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "TestFrameWorkScriptGenerationService.ContractType".
    [DataContract]
    public class TestScript
    {
        
        [DataMember]
        public string TestScriptFilePath
        {
            get;
            set;

        }

        // Any Script identified generated in C# target is .NET (Just for Now)
        // Any Script identified genertaed in JAva target is JRE 

        [DataMember]
        public TestFrameWorkScriptGenerationService.BusinessRule.TestConfigurationSettings  TestAndRunOnThisEnvironment
        {

            get;
            set;


        }



        // test only for define points  and generate test script this property is just a prototype for a while

        [DataMember]
        public List<TestFrameWorkScriptGenerationService.BusinessRule.BusinessTestPoint> BusinessTestPoints
        {
            get;
            set;

        }

        // so the parent script is a meta data script itself
        [DataMember]
        public List<TestScript> GeneratedScriptsFromMasterScript
        {
            get;
            set;

        }


        [DataMember]
        public string RuleType
        {
            get;
            set;
        }


        [DataMember]
        public string TestScriptFileExtension
        {
            get;
            set;

        }

        [DataMember]
        public List<TestExpression> TestExpressions
        {
            get;
            set;

        }

        [DataMember]
        public List<string> SyntaxExpression
        {

            get;
            set;

        }


        [DataMember]
        public string SourceFilePathToCompare
        {
            get;
            set;


        }

        [DataMember]
        public string DestinationFilePathToCompare
        {
            get;
            set;

        }


        public List<string> FileRuleCheckFilterExpressions
        {
            get;
            set;
        }



        [DataMember]
        public string TestScriptParametersJSON
        {
            get;
            set;

        }

        [DataMember]
        public bool TestScriptFileCreated
        {

            get;
            set;

        }



        [DataMember]
        public bool TestScriptFileExecuted
        {

            get;
            set;

        }


        [DataMember]
        public string TestScriptFileName
        {
            get;
            set;

        }


        [DataMember]

        public List<CodeLine> CodeLines
        {
            get;
            set;

        }



    }




    [DataContract]
    public class TestExpression
    {

        [DataMember]
        public string TestExpressionRule
        {
            get;
            set;

        }

        [DataMember]
        public string TestExpressionName
        {

            get;
            set;

        }

        [DataMember]
        public string ExpressionValidationRegex
        {
            get;
            set;

        }

        [DataMember]
        public bool ExpressionPassedSyntaxRule
        {

            get;
            set;

        }

        [DataMember]
        public Guid SourceTableID
        {

            get;
            set;

        }

        [DataMember]
        public Guid DestTableID
        {

            get;
            set;

        }



        [DataMember]
        public Guid SourceSchemaDefined
        {

            get;
            set;

        }




        [DataMember]
        public Guid DestSchemaDefined
        {

            get;
            set;

        }



        [DataMember]
        public Guid SourceColumnID
        {

            get;
            set;

        }


        [DataMember]
        public string SourceValueToCheck
        {

            get;
            set;

        }




        [DataMember]
        public string DestinationValueToCheck
        {

            get;
            set;

        }




        [DataMember]
        public string OpertorAppliedInBetweenColumns
        {

            get;
            set;

        }


        [DataMember]
        public Guid MatchToColumnID
        {

            get;
            set;

        }



        [DataMember]
        public bool IsMatchFound
        {

            get;
            set;

        }


        public int ExpressionIndexToken
        {
            get;
            set;

        }


        public string GeneratedExpressionByService
        {
            get;
            set;

        }

        // A URL TO PICK VALUE FROM with non sql services or just cloud services
        public string ExpressionServiceURLSource_NONSQL
        {
            get;
            set;

        }

        // A URL TO CHECK VALUE TO 
        public string ExpressionServiceURLTARGET_NONSQL
        {
            get;
            set;

        }


        public bool IsPassed
        {
            get;
            set;

        }

        public string Results
        {
            get;
            set;

        }




    }



    [DataContract]
    public class TestReport
    {

        [DataMember]
        public Guid TestReportID
        {
            get;
            set;

        }

        [DataMember]
        public string TestReportName
        {

            get;
            set;

        }

        [DataMember]
        public Guid TestScriptID
        {

            get;
            set;

        }



        [DataMember]
        public string TestResultsJson  
        {

            get;
            set;

        }







    }

}
