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
using TestFrameworkPortal.CodeGeneration;
namespace TestFrameworkPortal.Controllers
{
    public class TestClassesController : ApiController
    {
        private TMS db = new TMS();

        // GET: api/TestClasses
        public IQueryable<TestClass> GetTestClasses()
        {
            return db.TestClasses;
        }

        // GET: api/TestClasses/5
        [ResponseType(typeof(TestClass))]
        public IHttpActionResult GetTestClass(Guid id)
        {
            TestClass testClass = db.TestClasses.Find(id);
            if (testClass == null)
            {
                return NotFound();
            }

            return Ok(testClass);
        }

        // PUT: api/TestClasses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestClass(Guid id, TestClass testClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testClass.TestClassID)
            {
                return BadRequest();
            }

            db.Entry(testClass).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestClassExists(id))
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

        // POST: api/TestClasses
        [ResponseType(typeof(TestClass))]
        public IHttpActionResult PostTestClass(proxyClasses.TestClassProxy testClass )
        {
            ICodeGenerator codegen = null;
            bool _generated = false;

            Token selectedTokenized = null;

            CodeConfiguration configuration = new CodeConfiguration();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Check Tokenization here 
            // Don't save any data without valid tokens
            if (!String.IsNullOrEmpty(testClass.TokenID))
            {
                // look for valid token 
                // never send IDs
                 selectedTokenized = db.Tokens.ToList().Find(p => p.TokenDesc == testClass.TokenID);

                // User exist in session  
                // Validated Tokenization then move on

                if (selectedTokenized != null)
                {
                    db.TestClasses.Add(new TestClass() { TestClassID = Guid.NewGuid(), TestClassName = testClass.TestClassName, TestClassNameSpace = testClass.TestClassNameSpace, TestClassTypeCode = testClass.TestClassTypeCode, TestParentClassID = null, CreatedBy = selectedTokenized.CreatedBy });
                    try
                    {
                        if (testClass.TestClassTypeCode == "C#")
                        {
                            codegen = new CSharpClassGenerator();
                            configuration.CONFIG_CLASS_TYPE = testClass.TestClassTypeCode;
                            configuration.UseThisFrameWork = ".NET FRAMEWORK";
                            configuration.AllocatedProperties = testClass.AllocatedProperties;
                        }

                        _generated = codegen.GenerateCode(configuration);
                        db.SaveChanges();
                    }
                    catch (DbUpdateException)
                    {
                        if (TestClassExists(testClass.TestClassID))
                        {
                            return Conflict();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = testClass.TestClassID }, testClass);
        }

        // DELETE: api/TestClasses/5
        [ResponseType(typeof(TestClass))]
        public IHttpActionResult DeleteTestClass(Guid id)
        {
            TestClass testClass = db.TestClasses.Find(id);
            if (testClass == null)
            {
                return NotFound();
            }

            db.TestClasses.Remove(testClass);
            db.SaveChanges();

            return Ok(testClass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestClassExists(Guid id)
        {
            return db.TestClasses.Count(e => e.TestClassID == id) > 0;
        }
    }
}