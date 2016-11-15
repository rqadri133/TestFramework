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


namespace TestFrameworkPortal
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]

    public class TestConnectionData
    {
        public Guid TestConnectionTypeID { get; set; }
        [DataMember]
        public string TestConnctionTypeName { get; set; }
        [DataMember]
        public System.DateTime CreatedDate { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
}