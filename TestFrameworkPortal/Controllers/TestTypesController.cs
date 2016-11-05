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

namespace TestFrameworkPortal.Controllers
{
    public class TestTypesController : ApiController
    {
        private TMS db = new TMS();

        // GET: api/TestTypes
        public List<TestType> GetTestTypes()
        {
            return db.TestTypes.ToList<TestType>();
        }


        [Route("load/testtypes")]
        [HttpPost]
        public List<TestType> LoadTestTypes(proxyClasses.Token token)
        {
            Guid _authenticationToken;

            var _testtypes = new List<TestType>();
            Token selectedTokenized = null;
            if (!String.IsNullOrEmpty(token.AuthenticationToken))
            {
                // look for valid token 
                // never send IDs
                selectedTokenized = db.Tokens.ToList().Find(p => p.TokenDesc == token.AuthenticationToken);

                // User exist in session  

                if (selectedTokenized != null)
                {
                    _testtypes = db.TestTypes.ToList<TestType>();
                }

            }

            return _testtypes;

        }




        // GET: api/TestTypes/5
        [ResponseType(typeof(TestType))]
        public IHttpActionResult GetTestType(Guid id)
        {
            TestType testType = db.TestTypes.Find(id);
            if (testType == null)
            {
                return NotFound();
            }

            return Ok(testType);
        }

        // PUT: api/TestTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestType(Guid id, TestType testType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testType.TestTypeID)
            {
                return BadRequest();
            }

            db.Entry(testType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestTypeExists(id))
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

        // POST: api/TestTypes
        [ResponseType(typeof(TestType))]
        public IHttpActionResult PostTestType(TestType testType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            testType.TestTypeID = Guid.NewGuid();
            testType.CreatedDate = DateTime.Now;
            db.TestTypes.Add(testType);


            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TestTypeExists(testType.TestTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = testType.TestTypeID }, testType);
        }

        // DELETE: api/TestTypes/5
        [ResponseType(typeof(TestType))]
        public IHttpActionResult DeleteTestType(Guid id)
        {
            TestType testType = db.TestTypes.Find(id);
            if (testType == null)
            {
                return NotFound();
            }

            db.TestTypes.Remove(testType);
            db.SaveChanges();

            return Ok(testType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestTypeExists(Guid id)
        {
            return db.TestTypes.Count(e => e.TestTypeID == id) > 0;
        }
    }
}