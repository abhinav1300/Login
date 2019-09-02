using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoginPage;

namespace LoginPage.Controllers
{
    public class OfficeDetailsTablesController : Controller
    {
        private OfficeEntities db = new OfficeEntities();

        // GET: OfficeDetailsTables
        public ActionResult Index()
        {
            return View(db.OfficeDetailsTable.ToList());
        }

        // GET: OfficeDetailsTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeDetailsTable officeDetailsTable = db.OfficeDetailsTable.Find(id);
            if (officeDetailsTable == null)
            {
                return HttpNotFound();
            }
            return View(officeDetailsTable);
        }

        // GET: OfficeDetailsTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfficeDetailsTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Designation,Salary")] OfficeDetailsTable officeDetailsTable)
        {
            if (ModelState.IsValid)
            {
                db.OfficeDetailsTable.Add(officeDetailsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(officeDetailsTable);
        }

        // GET: OfficeDetailsTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeDetailsTable officeDetailsTable = db.OfficeDetailsTable.Find(id);
            if (officeDetailsTable == null)
            {
                return HttpNotFound();
            }
            return View(officeDetailsTable);
        }

        // POST: OfficeDetailsTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Designation,Salary")] OfficeDetailsTable officeDetailsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(officeDetailsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(officeDetailsTable);
        }

        // GET: OfficeDetailsTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfficeDetailsTable officeDetailsTable = db.OfficeDetailsTable.Find(id);
            if (officeDetailsTable == null)
            {
                return HttpNotFound();
            }
            return View(officeDetailsTable);
        }

        // POST: OfficeDetailsTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfficeDetailsTable officeDetailsTable = db.OfficeDetailsTable.Find(id);
            db.OfficeDetailsTable.Remove(officeDetailsTable);
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
