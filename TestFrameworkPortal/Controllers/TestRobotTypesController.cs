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
    public class TestRobotTypesController : ApiController
    {
        private TMS db = new TMS();


        [Route("testrobottypes/LoadAll")]
        [HttpPost]
        public List<TestRobotType> GetTestRobotTypes(proxyClasses.Token token)
        {

            // so dont use id you are asking him to hack all by sending ids use generated Tokens
            Guid _authenticationToken;
            User selectedTokenized = null;
            var _robotypes = new List<TestRobotType>();

            Token _toFind = null;

            if (!String.IsNullOrEmpty(token.AuthenticationToken))
            {
                _toFind = db.Tokens.ToList().Find(p => p.TokenDesc == token.AuthenticationToken);

                // User exist in session  

                if (_toFind != null)
                {
                    _robotypes = db.TestRobotTypes.ToList<TestRobotType>();
                }

            }
            return _robotypes;

        }


        // GET: api/TestRobotTypes
        public IQueryable<TestRobotType> GetTestRobotTypes()
        {
            return db.TestRobotTypes;
        }

        // GET: api/TestRobotTypes/5
        [ResponseType(typeof(TestRobotType))]
        public IHttpActionResult GetTestRobotType(Guid id)
        {
            TestRobotType testRobotType = db.TestRobotTypes.Find(id);
            if (testRobotType == null)
            {
                return NotFound();
            }

            return Ok(testRobotType);
        }

        // PUT: api/TestRobotTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestRobotType(Guid id, TestRobotType testRobotType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testRobotType.TestRobotTypeID)
            {
                return BadRequest();
            }

            db.Entry(testRobotType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestRobotTypeExists(id))
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

        // POST: api/TestRobotTypes
        [ResponseType(typeof(TestRobotType))]
        public IHttpActionResult PostTestRobotType(TestRobotType testRobotType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TestRobotTypes.Add(testRobotType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TestRobotTypeExists(testRobotType.TestRobotTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = testRobotType.TestRobotTypeID }, testRobotType);
        }

        // DELETE: api/TestRobotTypes/5
        [ResponseType(typeof(TestRobotType))]
        public IHttpActionResult DeleteTestRobotType(Guid id)
        {
            TestRobotType testRobotType = db.TestRobotTypes.Find(id);
            if (testRobotType == null)
            {
                return NotFound();
            }

            db.TestRobotTypes.Remove(testRobotType);
            db.SaveChanges();

            return Ok(testRobotType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestRobotTypeExists(Guid id)
        {
            return db.TestRobotTypes.Count(e => e.TestRobotTypeID == id) > 0;
        }
    }
}