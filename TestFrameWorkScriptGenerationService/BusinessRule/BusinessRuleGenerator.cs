using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameWorkScriptGenerationService.BusinessRule
{
    public class BusinessRuleGenerator
    {

        public static List<TestScript> GenerateCodeForApplicableRule(TestScript script)
        {
            IBusinessRule ruleCheck = null;
            List<TestScript> codedScripts = null;
            switch(script.RuleType)
            {
                case "QueryRule":
                    ruleCheck = new QueryExpressionsDBRule();
                   break;
                case "FileRule":
                    ruleCheck = new CompareFilesOnlyBusiness();
                    break;

                case "ComplexRule":
                    ruleCheck = new ComplexExpressionsDBRule();
                    break;
             }

            codedScripts = ruleCheck.GenerateCodeForThisRule(script);

            return codedScripts;

        }

    }
}
