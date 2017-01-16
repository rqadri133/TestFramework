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
    public class TestScriptParameterTypesController : ApiController
    {
        private TMS db = new TMS();

        // GET: api/TestScriptParameterTypes
        public IQueryable<TestScriptParameterType> GetTestScriptParameterTypes()
        {

            return db.TestScriptParameterTypes;
        }

        // GET: api/TestScriptParameterTypes/5
        [ResponseType(typeof(TestScriptParameterType))]
        public IHttpActionResult GetTestScriptParameterType(Guid id)
        {
            TestScriptParameterType testScriptParameterType = db.TestScriptParameterTypes.Find(id);
            if (testScriptParameterType == null)
            {
                return NotFound();
            }

            return Ok(testScriptParameterType);
        }

        // PUT: api/TestScriptParameterTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestScriptParameterType(Guid id, TestScriptParameterType testScriptParameterType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testScriptParameterType.TestScriptParamterTypeID)
            {
                return BadRequest();
            }

            db.Entry(testScriptParameterType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestScriptParameterTypeExists(id))
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

        // POST: api/TestScriptParameterTypes
        [ResponseType(typeof(TestScriptParameterType))]
        public IHttpActionResult PostTestScriptParameterType(TestScriptParameterType testScriptParameterType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TestScriptParameterTypes.Add(testScriptParameterType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TestScriptParameterTypeExists(testScriptParameterType.TestScriptParamterTypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = testScriptParameterType.TestScriptParamterTypeID }, testScriptParameterType);
        }

        // DELETE: api/TestScriptParameterTypes/5
        [ResponseType(typeof(TestScriptParameterType))]
        public IHttpActionResult DeleteTestScriptParameterType(Guid id)
        {
            TestScriptParameterType testScriptParameterType = db.TestScriptParameterTypes.Find(id);
            if (testScriptParameterType == null)
            {
                return NotFound();
            }

            db.TestScriptParameterTypes.Remove(testScriptParameterType);
            db.SaveChanges();

            return Ok(testScriptParameterType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestScriptParameterTypeExists(Guid id)
        {
            return db.TestScriptParameterTypes.Count(e => e.TestScriptParamterTypeID == id) > 0;
        }
    }
}