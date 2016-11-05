using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworkConnectionService.Connection
{
    public class TestColumn
    {

        public Guid TestColumnID
        {
            get;
            set;

        }


        public string TestColumnName
        {
            get;
            set;

        }



        public string TestColumnType
        {
            get;
            set;

        }




    }



    public class TestTable
    {

        public string TestTableName
        {
            get;
            set;

        }



        public Guid TestTableID
        {
            get;
            set;
        }


        public List<TestColumn> TestColumns
        {
            get;
            set;

        }




    }


    public class TestDataModel
    {

     
        public Guid DataModelID
        {
            get;
            set;
        }


        public string DataModelName
        {
            get;
            set;
        }

        public string ModelScenarionDesc
        {
            get;
            set;

        }
        // conver this query to LINQ based
        public string DataModelQuery
        {
            get;
            set;

        }
        
        public List<TestTable> TestTables
        {
            get;
            set;

        }

    
       

    }
}
