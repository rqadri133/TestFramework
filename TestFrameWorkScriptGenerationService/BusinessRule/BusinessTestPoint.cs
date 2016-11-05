using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameWorkScriptGenerationService.BusinessRule
{
    public class BusinessTestPoint
    {
        public int Sequence
        {
            get;
            set;
        }

        public string TestPointDescriptions
        {
            get;set;
        }


     

        // Any generic Product classification for any industry 
        public int ProductID
        {
            get;
            set;

        }


        public decimal PrecisionErrorRate
        {
            get;
            set;

        }


        public decimal MustComapreToValue
        {
            get;
            set;
        }



    }
}
