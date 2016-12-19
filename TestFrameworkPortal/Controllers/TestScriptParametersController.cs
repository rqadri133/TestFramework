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
    public class TestScriptParametersController : ApiController
    {
        private TMS db = new TMS();

        // GET: api/TestScriptParameters
        public IQueryable<TestScriptParameter> GetTestScriptParameters()
        {
            return db.TestScriptParameters;
        }

        // GET: api/TestScriptParameters/5
        [ResponseType(typeof(TestScriptParameter))]
        public IHttpActionResult GetTestScriptParameter(Guid id)
        {
            TestScriptParameter testScriptParameter = db.TestScriptParameters.Find(id);
            if (testScriptParameter == null)
            {
                return NotFound();
            }

            return Ok(testScriptParameter);
        }

        // PUT: api/TestScriptParameters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestScriptParameter(Guid id, TestScriptParameter testScriptParameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testScriptParameter.TestScriptParameterID)
            {
                return BadRequest();
            }

            db.Entry(testScriptParameter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestScriptParameterExists(id))
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

        // POST: api/TestScriptParameters
        [ResponseType(typeof(TestScriptParameter))]
        public IHttpActionResult PostTestScriptParameter(TestScriptParameter testScriptParameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TestScriptParameters.Add(testScriptParameter);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TestScriptParameterExists(testScriptParameter.TestScriptParameterID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = testScriptParameter.TestScriptParameterID }, testScriptParameter);
        }

        // DELETE: api/TestScriptParameters/5
        [ResponseType(typeof(TestScriptParameter))]
        public IHttpActionResult DeleteTestScriptParameter(Guid id)
        {
            TestScriptParameter testScriptParameter = db.TestScriptParameters.Find(id);
            if (testScriptParameter == null)
            {
                return NotFound();
            }

            db.TestScriptParameters.Remove(testScriptParameter);
            db.SaveChanges();

            return Ok(testScriptParameter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestScriptParameterExists(Guid id)
        {
            return db.TestScriptParameters.Count(e => e.TestScriptParameterID == id) > 0;
        }
    }
}