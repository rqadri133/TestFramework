using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace TestFrameworkPortal.proxyClasses
{


    [DataContract]
    public class TestTable
    {
        [DataMember]
        public string TestTableName
        {
            get;
            set;

        }


        [DataMember]
        public Guid TestTableID
        {
            get;
            set;
        }  


        [DataMember]
        public List<TestColumn> TestColumns
        {
            get;
            set;

        }




    }





    [DataContract]
    public class TestColumn
    {
        [DataMember]
        public Guid  TestColumnID
        {
            get;
            set;

        }
        
        [DataMember]
        public string TestColumnName
        {
            get;
            set;

        }


        [DataMember]
        public string TestColumnType
        {
            get;
            set;

        }




    }

}