using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFrameworkPortal.CodeGeneration
{
    interface ICodeGenerator
    {

        bool GenerateCode(CodeConfiguration configuarions);
        bool InjectDependentClassCode(TestClassDepnedency classDependency);


        List<ClassMethod> ReturnAllMethodsOfClass(TestClassProxy objTestClass);
        // Where could be a type class of any Object later may used 
       // List<ClassMethod> ReturnAllMethodsOfClass<T>(T  objTestClass);


        string UpdateClassFunctionalityDescription(string message); 

        
 
       // bool GenerateCode<T>(T configuarions);

    }


    public class ClassMethod
    {
        public Guid MethodID
        {
            get;
            set;

        }

        public string AccessType
        {
            get;
            set;

        }


        public string MethodName
        {
            get;
            set;

        }

        public bool Tested
        {
            get;
            set;
        }

        public string MethodTestResults
        {

            get;
            set;

        }



        public string ClassEncapsulatesName
        {

            get;
            set;

        }



    }


    public class TestClassProxy
    {
            public string TestClassName { get; set; }
            public string TestClassTypeCode { get; set; }
            public string TestClassNameSpace { get; set; }
            public bool Generated { get; set; }
       
            public string TestParentClassID { get; set; }
            public System.DateTime CreatedDate { get; set; }
            public System.Guid CreatedBy { get; set; }
     }
   




    public class TestClassDepnedency
    {

        public TestClass DependentClass
        {
            get;
            set;
        }


        // which class to inject dependency as property or in Method
        public TestClass WrapperClass
        {
            get;
            set;

        }

        public string InjectToThisMethod
        {
            get;
            set;
        }

    }

    public class CodeConfiguration
    {

        public string CONFIG_CLASS_TYPE
        {
            get;
            set;
        }


        public string UseThisFrameWork
        {

            get;
            set;

        }


        public TestClassDepnedency  DependentClassToGenerate
        {
            get;
            set;
        }


        public TestClass ClassToGenerateCode
        {
            get;
            set;
        } 





        public List<TestPropertyAllocated> AllocatedProperties
        {

            get;
            set;

        }
        
        
        
           



    }





}