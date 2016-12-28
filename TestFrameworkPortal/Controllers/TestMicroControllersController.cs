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
    public class TestMicroControllersController : ApiController
    {
        private TMS db = new TMS();

        // GET: api/TestMicroControllers
        public IQueryable<TestMicroController> GetTestMicroControllers()
        {
            return db.TestMicroControllers;
        }

        // GET: api/TestMicroControllers/5
        [ResponseType(typeof(TestMicroController))]
        public IHttpActionResult GetTestMicroController(Guid id)
        {
            TestMicroController testMicroController = db.TestMicroControllers.Find(id);
            if (testMicroController == null)
            {
                return NotFound();
            }

            return Ok(testMicroController);
        }

        // PUT: api/TestMicroControllers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestMicroController(Guid id, TestMicroController testMicroController)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testMicroController.TestMicroControllerID)
            {
                return BadRequest();
            }

            db.Entry(testMicroController).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestMicroControllerExists(id))
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

        // POST: api/TestMicroControllers
        [ResponseType(typeof(TestMicroController))]
        public IHttpActionResult PostTestMicroController(TestMicroController testMicroController)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TestMicroControllers.Add(testMicroController);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TestMicroControllerExists(testMicroController.TestMicroControllerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = testMicroController.TestMicroControllerID }, testMicroController);
        }

        // DELETE: api/TestMicroControllers/5
        [ResponseType(typeof(TestMicroController))]
        public IHttpActionResult DeleteTestMicroController(Guid id)
        {
            TestMicroController testMicroController = db.TestMicroControllers.Find(id);
            if (testMicroController == null)
            {
                return NotFound();
            }

            db.TestMicroControllers.Remove(testMicroController);
            db.SaveChanges();

            return Ok(testMicroController);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestMicroControllerExists(Guid id)
        {
            return db.TestMicroControllers.Count(e => e.TestMicroControllerID == id) > 0;
        }
    }
}