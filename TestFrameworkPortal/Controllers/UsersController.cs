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



/** Infosys Product Contribuitions BY SQRT Incubator **/

namespace TestFrameworkPortal.Controllers
{
    public class UsersController : ApiController
    {
        private TMS db = new TMS();


        // GET: api/Users

        [Route("login/User")]
        [ResponseType(typeof(UserInfo))]
        [HttpPost]
        public IHttpActionResult Login(UserInfo userInfo)
        {

            bool _IsMatchedFound = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = db.Users.ToList<User>().Find(p => p.LoginName == userInfo.UserName);

            IQueryable<User> allUsers = null;

            UserInfo usr = new UserInfo();
            if (userInfo != null)
            {

                _IsMatchedFound = Security.SecurityLogin.ValidatePassword(userInfo.Pwd, user.PasswordHash);
                Token alreadyExist = null;
                Token tokenBase = null;

                if (_IsMatchedFound)
                {

                    allUsers = db.Users.AsQueryable<User>().Where (p=>p.FirstName !=null || p.FirstName !="");
                    if (alreadyExist == null)
                    {

                        usr.UserID = Security.SecurityLogin.CreateHash(user.UserID.ToString());
                        tokenBase = db.Tokens.Add(new Token() { TokenID = Guid.NewGuid(), CreatedBy = user.UserID, CreatedDate = System.DateTime.Now, TokenDesc = usr.UserID });
                    }
                    else
                    {
                        alreadyExist = db.Tokens.ToList().Find(p => p.CreatedBy == user.UserID);
                        usr.UserID = alreadyExist.TokenDesc;

                    }

                }
                else
                {
                    return NotFound();

                }


            }



       
            
            
            db.SaveChanges();
            usr.IsAdmin = false;
             // Dont send admin screen any more its for the display prototype          
            return Ok(usr);
                
                
        }
        [Route("getallusers/user")]
        [ResponseType(typeof(User))]
        [HttpPost]
        public List<User> GetAllUsersInformation(string token)
        {

            Guid passedtoken  = Guid.Parse(token);
            User authUser  = db.Users.ToList().Find(p => p.UserID == passedtoken);
            List<TestFrameworkPortal.User> users = new List<TestFrameworkPortal.User>();
            if (authUser != null)
                users = db.Users.ToList<User>();
           

            return users ;
        }

        [Route("login/fulluser")]
        public IHttpActionResult fullusers(string token)
        {

            Guid passedtoken = Guid.Parse(token);
            User authUser = db.Users.ToList().Find(p => p.UserID == passedtoken);
            List<TestFrameworkPortal.User> users = new List<TestFrameworkPortal.User>();
            if (authUser != null)
                users = db.Users.ToList<User>();


            return Ok(users);
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(Guid id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(Guid id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user.UserID = Guid.NewGuid();
            user.PasswordHash = Security.SecurityLogin.CreateHash(user.PasswordHash);


            db.Users.Add(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(Guid id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(Guid id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }
    }
}
