using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebServicesDemo.Models;

namespace WebServicesDemo.Controllers
{
    public class EmployeeesMvcController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: EmployeeesMvc
        public ActionResult Index()
        {
            return View(db.Employeees.ToList());
        }

        // GET: EmployeeesMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeee employeee = db.Employeees.Find(id);
            if (employeee == null)
            {
                return HttpNotFound();
            }
            return View(employeee);
        }

        // GET: EmployeeesMvc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeesMvc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Department")] Employeee employeee)
        {
            if (ModelState.IsValid)
            {
                db.Employeees.Add(employeee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeee);
        }

        // GET: EmployeeesMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeee employeee = db.Employeees.Find(id);
            if (employeee == null)
            {
                return HttpNotFound();
            }
            return View(employeee);
        }

        // POST: EmployeeesMvc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Department")] Employeee employeee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeee);
        }

        // GET: EmployeeesMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeee employeee = db.Employeees.Find(id);
            if (employeee == null)
            {
                return HttpNotFound();
            }
            return View(employeee);
        }

        // POST: EmployeeesMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employeee employeee = db.Employeees.Find(id);
            db.Employeees.Remove(employeee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
