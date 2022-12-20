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
using WebAppTrue.Models;

namespace WebAppTrue.Controllers
{
    public class EmplyeesController : ApiController
    {
        private chatAPIEntities db = new chatAPIEntities();


        // GET: api/Emplyees
        public IHttpActionResult GetEmplyee()
        {
            return Ok(db.Emplyee.ToList().ConvertAll(i => new ResponeEmployee(i)));
        }

        // GET: api/Emplyees/5
        [ResponseType(typeof(Emplyee))]
        public IHttpActionResult GetEmplyee(int id)
        {
            Emplyee emplyee = db.Emplyee.Find(id);
            if (emplyee == null)
            {
                return NotFound();
            }

            return Ok(emplyee);
        }

        // PUT: api/Emplyees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmplyee(int id, Emplyee emplyee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emplyee.id)
            {
                return BadRequest();
            }

            db.Entry(emplyee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmplyeeExists(id))
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

        //POST: api/Emplyees
        [ResponseType(typeof(Emplyee))]
        public IHttpActionResult PostEmplyee(Emplyee emplyee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Emplyee.Add(emplyee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emplyee.id }, emplyee);
        }

        //DELETE: api/Emplyees/5
        [ResponseType(typeof(Emplyee))]
        public IHttpActionResult DeleteEmplyee(int id)
        {
            Emplyee emplyee = db.Emplyee.Find(id);
            if (emplyee == null)
            {
                return NotFound();
            }

            db.Emplyee.Remove(emplyee);
            db.SaveChanges();

            return Ok(emplyee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmplyeeExists(int id)
        {
            return db.Emplyee.Count(e => e.id == id) > 0;
        }

        [Route("api/Login")]
        [ResponseType(typeof(ResponeEmployee))]
        public IHttpActionResult Login([FromBody] Data data)
        {
            var user = db.Emplyee.ToList().Where(i => i.userName == data.userName && i.password == data.password).FirstOrDefault(); 
            //классическая авторизация, ничего сложного
            
            //тут проверка, если пользователь пустой - выкидывает в 404 ошибку, если пользователь не пустой то статус 200
            if(user == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(new ResponeEmployee(user));
            }
        }

        public class Data
        {
            public string userName { get; set; }
            public string password { get; set; }
        }
    }
}