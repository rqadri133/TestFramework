using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFrameworkPortal.CodeGeneration
{
    interface ICodeGenerator
    {

        bool GenerateCode(CodeConfiguration configuarions);

       // bool GenerateCode<T>(T configuarions);

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