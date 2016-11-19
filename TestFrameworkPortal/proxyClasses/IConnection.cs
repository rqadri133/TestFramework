using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFrameworkPortal.proxyClasses
{
    interface IConnection
    {

        List<TestTable> GetAllTables(string connection_string);
    }


    public class  SqlServer : IConnection
    {
        List<TestTable> testTables = new List<TestTable>();

        public List<TestTable> GetAllTables(string connection_string)
        {

            try
            {


            }
            catch(Exception excp)
            {


            }   
            finally
            {

            }  

        }
    }



    public class OracleServer : IConnection
    {
        public List<TestTable> GetAllTables(string connection_string)
        {

            // implementation required
            return new List<TestTable>();

        }
    }





}