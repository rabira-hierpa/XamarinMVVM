using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebServicesDemo.Models;

namespace WebServicesDemo.Controllers
{
    public class EmployeeesController : ApiController
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: api/Employeees
        public IQueryable<Employeee> GetEmployeees()
        {
            return db.Employeees;
        }

        // GET: api/Employeees/5
        [ResponseType(typeof(Employeee))]
        public IHttpActionResult GetEmployeee(int id)
        {
            Employeee employeee = db.Employeees.Find(id);
            if (employeee == null)
            {
                return NotFound();
            }

            return Ok(employeee);
        }

        // PUT: api/Employeees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployeee(int id, Employeee employeee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeee.Id)
            {
                return BadRequest();
            }

            db.Entry(employeee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeeExists(id))
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

        // POST: api/Employeees
        [ResponseType(typeof(Employeee))]
        public IHttpActionResult PostEmployeee(Employeee employeee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employeees.Add(employeee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employeee.Id }, employeee);
        }

        // DELETE: api/Employeees/5
        [ResponseType(typeof(Employeee))]
        public IHttpActionResult DeleteEmployeee(int id)
        {
            Employeee employeee = db.Employeees.Find(id);
            if (employeee == null)
            {
                return NotFound();
            }

            db.Employeees.Remove(employeee);
            db.SaveChanges();

            return Ok(employeee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeeExists(int id)
        {
            return db.Employeees.Count(e => e.Id == id) > 0;
        }
    }
}