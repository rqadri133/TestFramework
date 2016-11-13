using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace TestFrameworkPortal.proxyClasses
{

    [DataContract]
    public class TestCaseProxy
    {
           
        [DataMember]
           public string TestCaseDescName { get; set; }
        [DataMember]
        public string  CreatedDate { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string  TestTypeID { get; set; }
    }


}