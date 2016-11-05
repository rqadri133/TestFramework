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
    public class TestCasesController : ApiController
    {
        private TMS db = new TMS();

        // GET: api/TestCases
        public IQueryable<TestCase> GetTestCases()
        {
            return db.TestCases;
        }

        // GET: api/TestCases/5
        [ResponseType(typeof(TestCase))]
        public IHttpActionResult GetTestCase(Guid id)
        {
            TestCase testCase = db.TestCases.Find(id);
            if (testCase == null)
            {
                return NotFound();
            }

            return Ok(testCase);
        }

        // PUT: api/TestCases/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestCase(Guid id, TestCase testCase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testCase.TestCaseID)
            {
                return BadRequest();
            }

            db.Entry(testCase).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestCaseExists(id))
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

        // POST: api/TestCases
        [ResponseType(typeof(TestCase))]
        public IHttpActionResult PostTestCase(TestCase testCase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            testCase.TestCaseID = Guid.NewGuid();
            db.TestCases.Add(testCase);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TestCaseExists(testCase.TestCaseID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = testCase.TestCaseID }, testCase);
        }

        // DELETE: api/TestCases/5
        [ResponseType(typeof(TestCase))]
        public IHttpActionResult DeleteTestCase(Guid id)
        {
            TestCase testCase = db.TestCases.Find(id);
            if (testCase == null)
            {
                return NotFound();
            }

            db.TestCases.Remove(testCase);
            db.SaveChanges();

            return Ok(testCase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestCaseExists(Guid id)
        {
            return db.TestCases.Count(e => e.TestCaseID == id) > 0;
        }
    }
}