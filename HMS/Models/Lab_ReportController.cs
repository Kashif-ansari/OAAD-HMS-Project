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
    public class Lab_ReportController : Controller
    {
        private HMSEntities db = new HMSEntities();

        // GET: Lab_Report
        public ActionResult Index()
        {
            var lab_Report = db.Lab_Report.Include(l => l.Report_Type);
            return View(lab_Report.ToList());
        }

        // GET: Lab_Report/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab_Report lab_Report = db.Lab_Report.Find(id);
            if (lab_Report == null)
            {
                return HttpNotFound();
            }
            return View(lab_Report);
        }

        // GET: Lab_Report/Create
        public ActionResult Create()
        {
            ViewBag.RT_ID = new SelectList(db.Report_Type, "RT_ID", "Name");
            return View();
        }

        // POST: Lab_Report/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LR_ID,RT_ID,Cost")] Lab_Report lab_Report)
        {
            if (ModelState.IsValid)
            {
                db.Lab_Report.Add(lab_Report);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RT_ID = new SelectList(db.Report_Type, "RT_ID", "Name", lab_Report.RT_ID);
            return View(lab_Report);
        }

        // GET: Lab_Report/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab_Report lab_Report = db.Lab_Report.Find(id);
            if (lab_Report == null)
            {
                return HttpNotFound();
            }
            ViewBag.RT_ID = new SelectList(db.Report_Type, "RT_ID", "Name", lab_Report.RT_ID);
            return View(lab_Report);
        }

        // POST: Lab_Report/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LR_ID,RT_ID,Cost")] Lab_Report lab_Report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lab_Report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RT_ID = new SelectList(db.Report_Type, "RT_ID", "Name", lab_Report.RT_ID);
            return View(lab_Report);
        }

        // GET: Lab_Report/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lab_Report lab_Report = db.Lab_Report.Find(id);
            if (lab_Report == null)
            {
                return HttpNotFound();
            }
            return View(lab_Report);
        }

        // POST: Lab_Report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lab_Report lab_Report = db.Lab_Report.Find(id);
            db.Lab_Report.Remove(lab_Report);
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
