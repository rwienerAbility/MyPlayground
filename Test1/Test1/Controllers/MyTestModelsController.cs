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
using Test1.Models;

namespace Test1.Controllers
{
    public class MyTestModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MyTestModels
        public IQueryable<MyTestModel> GetMyTestModels()
        {
            return db.MyTestModels;
        }

        // GET: api/MyTestModels/5
        [ResponseType(typeof(MyTestModel))]
        public IHttpActionResult GetMyTestModel(int id)
        {
            MyTestModel myTestModel = db.MyTestModels.Find(id);
            if (myTestModel == null)
            {
                return NotFound();
            }

            return Ok(myTestModel);
        }

        // PUT: api/MyTestModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMyTestModel(int id, MyTestModel myTestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myTestModel.Id)
            {
                return BadRequest();
            }

            db.Entry(myTestModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyTestModelExists(id))
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

        // POST: api/MyTestModels
        [ResponseType(typeof(MyTestModel))]
        public IHttpActionResult PostMyTestModel(MyTestModel myTestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MyTestModels.Add(myTestModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = myTestModel.Id }, myTestModel);
        }

        // DELETE: api/MyTestModels/5
        [ResponseType(typeof(MyTestModel))]
        public IHttpActionResult DeleteMyTestModel(int id)
        {
            MyTestModel myTestModel = db.MyTestModels.Find(id);
            if (myTestModel == null)
            {
                return NotFound();
            }

            db.MyTestModels.Remove(myTestModel);
            db.SaveChanges();

            return Ok(myTestModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MyTestModelExists(int id)
        {
            return db.MyTestModels.Count(e => e.Id == id) > 0;
        }
    }
}