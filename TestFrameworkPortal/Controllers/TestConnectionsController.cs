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
using TestFrameworkPortal.proxyClasses;
using Security;

namespace TestFrameworkPortal.Controllers
{
    public class TestConnectionsController : ApiController
    {
        private TMS db = new TMS();

        // GET: api/TestConnections
        public IQueryable<TestConnection> GetTestConnections()
        {
            return db.TestConnections;
        }
        

        // GET: api/TestConnections/5
        [ResponseType(typeof(TestConnection))]
        public IHttpActionResult GetTestConnection(Guid id)
        {
            TestConnection testConnection = db.TestConnections.Find(id);
            if (testConnection == null)
            {
                return NotFound();
            }

            return Ok(testConnection);
        }

        

        [Route("testconnections/LoadAll")]
        [HttpPost]
        public List<TestConnection> GetTestConnection(proxyClasses.Token token)
        {
            Guid _authenticationToken;
        
            var _connections = new List<TestConnection>();
            Token selectedTokenized = null;
            if (!String.IsNullOrEmpty(token.AuthenticationToken))
            {
                // look for valid token 
                // never send IDs
                selectedTokenized = db.Tokens.ToList().Find(p => p.TokenDesc == token.AuthenticationToken);

                // User exist in session  

                if (selectedTokenized != null)
                {
                    _connections = db.TestConnections.ToList<TestConnection>();
                }

            }
            return _connections;

        }

        [Route("'associated/loadAllTables")]
        [HttpPost]
        public List<TestTable> GetAllTables(proxyClasses.Token token)
        {
            Guid _authenticationToken;
            User selectedTokenized = null;
            var _connections = new List<TestConnection>();

            if (!String.IsNullOrEmpty(token.AuthenticationToken))
            {
                _authenticationToken = Guid.Parse(token.AuthenticationToken);
                selectedTokenized = db.Users.ToList().Find(p => p.UserID == _authenticationToken);
                // User exist in session  
                if (selectedTokenized != null)
                {
                         // token.ConnectionStr 
                      //   _connections = db.TestConnections.ToList<TestConnection>();
                      // Call connection service to load all tables 
                      // implementation required 

                }

            }
            return  new List<TestTable>();

        }




        // PUT: api/TestConnections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestConnection(Guid id, TestConnection testConnection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testConnection.TestConnectionID)
            {
                return BadRequest();
            }

            db.Entry(testConnection).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestConnectionExists(id))
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

        // POST: api/TestConnections
        [ResponseType(typeof(TestConnection))]
        public IHttpActionResult PostTestConnection(TestConnection testConnection)
        {
            testConnection.TestConnectionID = Guid.NewGuid();
            testConnection.CreatedDate = System.DateTime.Now;
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TestConnections.Add(testConnection);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TestConnectionExists(testConnection.TestConnectionID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = testConnection.TestConnectionID }, testConnection);
        }

        // DELETE: api/TestConnections/5
        [ResponseType(typeof(TestConnection))]
        public IHttpActionResult DeleteTestConnection(Guid id)
        {
            TestConnection testConnection = db.TestConnections.Find(id);
            if (testConnection == null)
            {
                return NotFound();
            }

            db.TestConnections.Remove(testConnection);
            db.SaveChanges();

            return Ok(testConnection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestConnectionExists(Guid id)
        {
            return db.TestConnections.Count(e => e.TestConnectionID == id) > 0;
        }
    }
}
