using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HMS.Models
{
    public class Report_TypeController : Controller
    {
        private HMSEntities db = new HMSEntities();

        // GET: Report_Type
        public ActionResult Index()
        {
            return View(db.Report_Type.ToList());
        }

        // GET: Report_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report_Type report_Type = db.Report_Type.Find(id);
            if (report_Type == null)
            {
                return HttpNotFound();
            }
            return View(report_Type);
        }

        // GET: Report_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Report_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RT_ID,Name,Cost")] Report_Type report_Type)
        {
            if (ModelState.IsValid)
            {
                db.Report_Type.Add(report_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(report_Type);
        }

        // GET: Report_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report_Type report_Type = db.Report_Type.Find(id);
            if (report_Type == null)
            {
                return HttpNotFound();
            }
            return View(report_Type);
        }

        // POST: Report_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RT_ID,Name,Cost")] Report_Type report_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(report_Type);
        }

        // GET: Report_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report_Type report_Type = db.Report_Type.Find(id);
            if (report_Type == null)
            {
                return HttpNotFound();
            }
            return View(report_Type);
        }

        // POST: Report_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Report_Type report_Type = db.Report_Type.Find(id);
            db.Report_Type.Remove(report_Type);
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
