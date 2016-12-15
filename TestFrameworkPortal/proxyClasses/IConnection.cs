using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;


namespace TestFrameworkPortal.proxyClasses
{
    interface IConnection
    {
        List<TestTable> GetAllTables(string connection_string);
        List<TestColumn> GetAllColumns(string connection_string, string table_name);
        TestCase RunTest(string connection_string, string expression);

    }


    public class  SqlServer : IConnection
    {
        List<TestTable> testTables = new List<TestTable>();

        public List<TestTable> GetAllTables(string connection_string)
        {
            SqlConnection connection = new SqlConnection(connection_string);
            DataSet ds = new DataSet();
            SqlCommand command = null;
          //  command.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(command);
            try
            {
                connection.Open();
                command = new SqlCommand("SELECT * FROM  INFORMATION_SCHEMA.Tables", connection);
                command.CommandTimeout = 120;
                //  command.ExecuteNonQuery();
                da = new SqlDataAdapter(command);
                da.Fill(ds);

            }
            catch (Exception excp)
            {


            }   
            finally
            {
                connection.Close();
            }

            if(ds.Tables.Count > 0)
            {
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    testTables.Add(new TestTable() { TestTableID = Guid.NewGuid(), TestTableName =  row["TABLE_NAME"].ToString() });

                }


            }

            return testTables;
        }

        public TestCase RunTest(string connection_string, string expression)
        {



        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection_string"></param>
        /// <param name="table_name"></param>
        /// <returns></returns>
        public List<TestColumn> GetAllColumns(string connection_string, string table_name)
        {
            SqlConnection connection = new SqlConnection(connection_string);
            DataSet ds = new DataSet();
            SqlCommand command = null;
            //  command.ExecuteNonQuery();
            SqlDataAdapter da = null;
            List<TestColumn> columns = new List<TestColumn>();


            string _filterExpression = " TABLE_NAME = " + "'" + table_name + "'";
            
            try
            {
                connection.Open();
                command = new SqlCommand("SELECT * FROM  INFORMATION_SCHEMA.Columns", connection);
                command.CommandTimeout = 120;
                //  command.ExecuteNonQuery();
                da = new SqlDataAdapter(command);
                da.Fill(ds);

            }
            catch (Exception excp)
            {


            }
            finally
            {
                connection.Close();
            }
            int _maxlength = 0;

            if (ds.Tables.Count > 0)
            {

                foreach (DataRow row in ds.Tables[0].Select(_filterExpression))
                {
                    if (row["CHARACTER_MAXIMUM_LENGTH"].ToString() != "" )
                    {
                        _maxlength = Convert.ToInt32(row["CHARACTER_MAXIMUM_LENGTH"]);
                    }

                    columns.Add(new TestColumn { TestColumnID = Guid.NewGuid(), TestColumnName = row["COLUMN_NAME"].ToString(), TestColumnType = row["DATA_TYPE"].ToString(), MaxLengthAllowed =  _maxlength });

                }


            }

            return columns;
        }

    }



    public class OracleServer : IConnection
    {
        public List<TestTable> GetAllTables(string connection_string)
        {

            // implementation required
            return new List<TestTable>();

        }


        public List<TestColumn> GetAllColumns(string connection_string, string table_name)
        {

            // implementation required
            return new List<TestColumn>();

        }
    }





}