using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TestFrameworkPortal.proxyClasses
{
    [DataContract]
    public class Token
    {
        [DataMember]
        public string AuthenticationToken
        {
            get;
            set;


        }



        [DataMember]
        public string ConnectionStr
        {
            get;
            set;
        }




    }
}