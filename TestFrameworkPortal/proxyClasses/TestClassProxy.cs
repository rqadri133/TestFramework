using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFrameworkPortal.proxyClasses
{
    public class TestClassProxy
    {
            public Guid TestClassID { get; set; }
            public string TestClassName { get; set; }
            public string TestClassTypeCode { get; set; }
            public string TokenID { get; set; }
            public string TestClassNameSpace { get; set; }
            public Guid TestParentClassID { get; set; }
            public System.DateTime CreatedDate { get; set; }
            public List<TestPropertyAllocated> AllocatedProperties { get; set; } 
            public System.Guid CreatedBy { get; set; }
    }
}