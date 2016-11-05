using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestFrameWorkScriptGenerationService.BusinessRule
{
    interface IBusinessRule
    {
        List<TestScript> GenerateCodeForThisRule(TestScript script);
    }

    public class CompareFilesOnlyBusiness : IBusinessRule
    {

        // suppose there are 100 expression this will create 100 test scripts on server 
        public List<TestScript> GenerateCodeForThisRule(TestScript script)
        {
            // only generated codee for File Comparisons 
           
            //continue tonight all night  real fuc begin    
            // use Assertions 
            return new List<TestScript>();

        }
    }



    public class ComplexExpressionsDBRule : IBusinessRule
    {

        // suppose there are 100 expression this will create 100 test scripts on server 
        public List<TestScript> GenerateCodeForThisRule(TestScript script)
        {
            // only generated codee for File Comparisons 
            //continue tonight all night  real fuc begin    
            // use Assertions 
            return new List<TestScript>();

        }

    }




    public class QueryExpressionsDBRule : IBusinessRule
    {

        // suppose there are 100 expression this will create 100 test scripts on server 
        public List<TestScript> GenerateCodeForThisRule(TestScript script)
        {

            // execute query and store to DT then passs to the Test Script to compare an assertion model
            // Generate code to compare query model and specic columns defined under expression for each column create a test script
            return new List<TestScript>();

        }






    }

    public class TestPointRule : IBusinessRule
    {
        // one parent script will spawn several scripts on purpose defined
        // suppose there are 100 expression this will create 100 test scripts on server 
        public List<TestScript> GenerateCodeForThisRule(TestScript script)
        {
            // Generate code to compare query model and specic columns defined under expression for each column create a test script
            return new List<TestScript>();

        }






    }



}



