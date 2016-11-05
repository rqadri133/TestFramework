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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITestConnectionService
    {
        // Send the required number of connections needed to be connected
        [OperationContract]
         List<Connector>  ConnectService<T>(List<T> node);
        [OperationContract]
        TestDataModel ConnectReturnAllTables(string connectionStr , string ConType);

        // TODO: Add your service operations here
        [OperationContract]
        List<Assembly> LoadAllAssembliesForTheConnections<T>(List<T> node);

        [OperationContract]
        IConnection ConnectDirect<T>( T node , Guid Id);



    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "TestFrameworkConnectionService.ContractType".
    [DataContract]
    public class Connector
    {


        
        [DataMember]
        public string ConnectionStringVal
        {
            get;
            set;

        }


        [DataMember]
        public bool Connected   
       {
            get;
            set;
        }



        [DataMember]

        public string ConnectionType
        {
            get;
            set;

        }

        [DataMember]
        public string ClassName
        {

            get;
            set;
        }

        [DataMember]
        public string AssemblyName
        {
            get;
            set;
        }

        [DataMember]
        public string Schema
        {
            get;
            set;

        }


    }
}
