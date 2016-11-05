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
    public class TestOperandsController : ApiController
    {
        private TMS db = new TMS();

        // GET: api/TestOperands
        public IQueryable<TestOperand> GetTestOperands()
        {
            return db.TestOperands;
        }

        // GET: api/TestOperands/5
        [ResponseType(typeof(TestOperand))]
        public IHttpActionResult GetTestOperand(Guid id)
        {
            TestOperand testOperand = db.TestOperands.Find(id);
            if (testOperand == null)
            {
                return NotFound();
            }

            return Ok(testOperand);
        }

        // PUT: api/TestOperands/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestOperand(Guid id, TestOperand testOperand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testOperand.TestOperandID)
            {
                return BadRequest();
            }

            db.Entry(testOperand).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestOperandExists(id))
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

        // POST: api/TestOperands
        [ResponseType(typeof(TestOperand))]
        public IHttpActionResult PostTestOperand(TestOperand testOperand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TestOperands.Add(testOperand);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TestOperandExists(testOperand.TestOperandID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = testOperand.TestOperandID }, testOperand);
        }

        // DELETE: api/TestOperands/5
        [ResponseType(typeof(TestOperand))]
        public IHttpActionResult DeleteTestOperand(Guid id)
        {
            TestOperand testOperand = db.TestOperands.Find(id);
            if (testOperand == null)
            {
                return NotFound();
            }

            db.TestOperands.Remove(testOperand);
            db.SaveChanges();

            return Ok(testOperand);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestOperandExists(Guid id)
        {
            return db.TestOperands.Count(e => e.TestOperandID == id) > 0;
        }
    }
}