using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TestFrameworkPortal.Controllers
{

    [DataContract]
    public class UserInfo
    {



        [DataMember]
        public string APIToken
        {

            get;
            set;

        }

        [DataMember]
        
        public IQueryable<User> AllUsers
        {
            get;
            set;

        }

        [DataMember]
        public string UserID
        {

            get;
            set;

        }



        [DataMember]
        public string UserName
        {
            get;
            set;

        }


        [DataMember]
        public string Pwd
        {

            get;
            set;

        }


        [DataMember]
        
        public string EmailAddress
        {
            get;
            set;

        }



        [DataMember]
        public bool IsAdmin
        {
            get;
            set;

        }



    }
}