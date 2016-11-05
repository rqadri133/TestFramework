using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestFrameworkPortal;
using System.Security.Principal;

namespace TestFrameworkPortal.Controllers
{
    public class TokenSystemController : ApiController
    {


        private TMS db = new TMS();


        // GET: api/Users

        [Route("authenticate/User")]
        public IHttpActionResult Authenticate(UserInfo userInfo)
        {

            Guid _userToken = Guid.Parse( userInfo.APIToken);

           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = db.Users.ToList<User>().Find(p => p.UserID == _userToken );
            List<User> allUsers = new List<TestFrameworkPortal.User>(); 

            if(user != null) 
            {

                allUsers = db.Users.ToList<User>();



            }

            return Ok(allUsers);


        }

    }
}
