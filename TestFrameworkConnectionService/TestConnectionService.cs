using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Reflection;
using TestFrameworkConnectionService.Connection;

namespace TestFrameworkConnectionService
{


    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
   [ServiceBehavior( ConcurrencyMode = ConcurrencyMode.Multiple )]   
    public class TestConnectionService : ITestConnectionService
    {
        // The Assembliess will be loaded to prvide the connections for any particular ConnectionType

        public TestDataModel ConnectReturnAllTables(string connectionStr, string ConType)
        {
            /* Implemnenation Required */

            return new TestDataModel();

        }


        public List<Assembly> LoadAllAssembliesForTheConnections<T>(List<T> node)
        {
            List<Assembly> allAssemblies = null;
            try
            {


            }
            catch(Exception excp)
            {



            }
            finally
            {


                
            }
            return allAssemblies;

        }


        #region "this will take connection string and return all tables along with Column Names with out data"
        public TestDataModel ConnectReturnAllTables(Connector connector)
        {
            // implmentation required  
            IConnection connection = null;
            switch(connector.ConnectionType)
            {
                case  "SqlServer" :
                    connection = new SQLServerConnection();
                    connector.ConnectionStringVal = connector.ConnectionStringVal;
                    connector.ConnectionType = connector.ConnectionType;
                    connection.Connect(connector);
                    break;

      
            }





            return new TestDataModel();
        }



        #endregion



        public List<Connector> ConnectService<T>(List<T> node)
        {

            List<Connector> nodes = new List<Connector>();
            try
            {


            }
            catch(Exception excp)
            {


            }
            finally
            {



            }

            return nodes; 

        }


        #region "Load connections from DB"
        private string GetConnectionString(Guid Id)
        {
            // implemen

            try
            {


            }
            catch(Exception excp)
            {


            }
            finally
            {


            }
            return "DummyConnection;lfdfdfd*";
        } 

        #endregion


        public IConnection ConnectDirect<T>(T node , Guid TokenId)  
        {
            IConnection connect = null;
            Connector connector = new Connector();
            connector.ConnectionStringVal = GetConnectionString(TokenId);

            switch(node.GetType().Name)
            {
                case "CloudConnection":
                    connect = new BigQueryEngineConnection();
                    connect.Connect(connector);
                    break;
                case "SQLServerConnection":
                    connect = new SQLServerConnection();
                    connect.Connect(connector);
                    break;

            }
            //this needs implementation for each case facroty 
            return connect;
        }






    }
}
