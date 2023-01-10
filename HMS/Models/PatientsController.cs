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
    public class PatientsController : Controller
    {
        private HMSEntities db = new HMSEntities();

        // GET: Patients
        public ActionResult Index()
        {
            var patients = db.Patients.Include(p => p.Disease).Include(p => p.Doctor).Include(p => p.Lab_Report).Include(p => p.Room);
            return View(patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            ViewBag.Disease_ID = new SelectList(db.Diseases, "Disease_ID", "Name");
            ViewBag.D_ID = new SelectList(db.Doctors, "D_ID", "D_Name");
            ViewBag.LR_ID = new SelectList(db.Lab_Report, "LR_ID", "LR_ID");
            ViewBag.Room_ID = new SelectList(db.Rooms, "Room_ID", "Room_ID");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "P_ID,P_Name,D_ID,Disease_ID,LR_ID,Room_ID")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Disease_ID = new SelectList(db.Diseases, "Disease_ID", "Name", patient.Disease_ID);
            ViewBag.D_ID = new SelectList(db.Doctors, "D_ID", "D_Name", patient.D_ID);
            ViewBag.LR_ID = new SelectList(db.Lab_Report, "LR_ID", "LR_ID", patient.LR_ID);
            ViewBag.Room_ID = new SelectList(db.Rooms, "Room_ID", "Room_ID", patient.Room_ID);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.Disease_ID = new SelectList(db.Diseases, "Disease_ID", "Name", patient.Disease_ID);
            ViewBag.D_ID = new SelectList(db.Doctors, "D_ID", "D_Name", patient.D_ID);
            ViewBag.LR_ID = new SelectList(db.Lab_Report, "LR_ID", "LR_ID", patient.LR_ID);
            ViewBag.Room_ID = new SelectList(db.Rooms, "Room_ID", "Room_ID", patient.Room_ID);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "P_ID,P_Name,D_ID,Disease_ID,LR_ID,Room_ID")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Disease_ID = new SelectList(db.Diseases, "Disease_ID", "Name", patient.Disease_ID);
            ViewBag.D_ID = new SelectList(db.Doctors, "D_ID", "D_Name", patient.D_ID);
            ViewBag.LR_ID = new SelectList(db.Lab_Report, "LR_ID", "LR_ID", patient.LR_ID);
            ViewBag.Room_ID = new SelectList(db.Rooms, "Room_ID", "Room_ID", patient.Room_ID);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
