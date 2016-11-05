using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TestFrameWorkScriptGenerationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
      
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple )]
    public class TestScriptService : ITestScriptervice
    {
        public TestScript CreateScript<T>(T obj, CodeGenerationInstruction codeInstructions)
        {
            // Implementtaion required 
            try
            {



            }
            catch(Exception excp)
            {


            }
            finally
            {



            }


            return new TestScript();

        }

        // TODO: Add your service operations here


        
        public TestScript UpdateScript<T>(T obj, CodeGenerationInstruction codeInstructions)
        {


            // Implementtaion required 

            try
            {


            }
            catch (Exception excp)
            {


            }
            finally
            {



            }

            return new TestScript();




        }



        public TestScript DeleteScript<T>(T obj, CodeGenerationInstruction codeInstructions)
        {


            // Implementtaion required 

            try
            {


            }
            catch (Exception excp)
            {


            }
            finally
            {



            }


            return new TestScript();



        }
        
        public TestScript InjectCodeLineScript<T>(TestScript script, CodeGenerationInstruction codeInstructions)
        {
            // Implementtaion required 

            try
            {


            }
            catch (Exception excp)
            {


            }
            finally
            {



            }


            return new TestScript();


        }

        public TestScript ExecuteScript<T>(TestScript script, CodeGenerationInstruction codeInstructions)
        {
            // Implementtaion required 

            try
            {


            }
            catch (Exception excp)
            {


            }
            finally
            {



            }


            return new TestScript();


        }

        public TestReport ScriptReport<T>(TestScript script, CodeGenerationInstruction codeInstructions)
        {
            // Implementation required 



            try
            {


            }
            catch (Exception excp)
            {


            }
            finally
            {



            }

            // Implementation required Empty Object

            return new TestReport();


        }



        public TestExpression GenerateRegexExpression(TestExpression ruleExpression)
        {

            /* 
             * implementaion required with case Factory Type 
             * 
             * 
             */


            return new TestExpression();


        }







    }
}
