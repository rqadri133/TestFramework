using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestFrameworkPortal.proxyClasses;
using System.Web.Http.Description;
using TestFrameworkPortal;

namespace TestFrameworkPortal.Controllers
{
    public class TestConnectionTypesController : ApiController
    {
        private TMS db = new TMS();

        // GET: api/TestConnectionTypes
        public IQueryable<TestConnectionType> GetTestConnectionTypes()
        {
            return db.TestConnectionTypes;
        }

        [Route("testconnectiontype/LoadAll")]
        [HttpPost]
        public List<TestConnectionType> GetTestConnectionTypes(proxyClasses.Token token)
        {

            // so dont use id you are asking him to hack all by sending ids use generated Tokens
            Guid _authenticationToken ;
            User selectedTokenized = null;
            var _connectiontypes = new List<TestConnectionType>();
            Token _toFind = null;

            if(!String.IsNullOrEmpty(token.AuthenticationToken))
            {
                _toFind =  db.Tokens.ToList().Find(p => p.TokenDesc == token.AuthenticationToken);
                                    
                // User exist in session  

                if (_toFind != null)
                {
                    _connectiontypes = db.TestConnectionTypes.ToList<TestConnectionType>();
                }

            }
            return _connectiontypes;

        }



        // GET: api/TestConnectionTypes/5
        [ResponseType(typeof(TestConnectionType))]
        public IHttpActionResult GetTestConnectionType(Guid id)
        {
            TestConnectionType testConnectionType = db.TestConnectionTypes.Find(id);
            if (testConnectionType == null)
            {
                return NotFound();
            }

            return Ok(testConnectionType);
        }

        // PUT: api/TestConnectionTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestConnectionType(Guid id, TestConnectionType testConnectionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testConnectionType.TestConnectionTypeID)
            {
                return BadRequest();
            }

            db.Entry(testConnectionType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestConnectionTypeExists(id))
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

        // POST: api/TestConnectionTypes
        [ResponseType(typeof(TestConnectionType))]
        public IHttpActionResult PostTestConnectionType(TestConnectionType testConnectionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TestConnectionTypes.Add(testConnectionType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TestConnectionTypeExists(testConnectionType.TestConnectionTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = testConnectionType.TestConnectionTypeID }, testConnectionType);
        }

        // DELETE: api/TestConnectionTypes/5
        [ResponseType(typeof(TestConnectionType))]
        public IHttpActionResult DeleteTestConnectionType(Guid id)
        {
            TestConnectionType testConnectionType = db.TestConnectionTypes.Find(id);
            if (testConnectionType == null)
            {
                return NotFound();
            }

            db.TestConnectionTypes.Remove(testConnectionType);
            db.SaveChanges();

            return Ok(testConnectionType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestConnectionTypeExists(Guid id)
        {
            return db.TestConnectionTypes.Count(e => e.TestConnectionTypeID == id) > 0;
        }
    }
}
