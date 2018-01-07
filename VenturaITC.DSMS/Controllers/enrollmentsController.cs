using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VenturaITC.DSMS.Models;

namespace VenturaITC.DSMS.Controllers
{
    public class enrollmentsController : Controller
    {
        private dsmsEntities db = new dsmsEntities();

        // GET: enrollments
        public ActionResult Index()
        {
            var enrollments = db.enrollments.Include(e => e.category).Include(e => e.payment).Include(e => e.payment_type).Include(e => e.student).Include(e => e.user);
            return View(enrollments.ToList());
        }

        // GET: enrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enrollment enrollment = db.enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: enrollments/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.categories, "id", "name");
            ViewBag.payment_id = new SelectList(db.payments, "id", "id");
            ViewBag.payment_type_id = new SelectList(db.payment_type, "id", "name");
            ViewBag.student_id = new SelectList(db.students, "id", "full_name");
            ViewBag.user_id = new SelectList(db.users, "id", "username");
            return View();
        }

        // POST: enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,student_id,category_id,payment_type_id,payment_id,user_id")] enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.categories, "id", "name", enrollment.category_id);
            ViewBag.payment_id = new SelectList(db.payments, "id", "id", enrollment.payment_id);
            ViewBag.payment_type_id = new SelectList(db.payment_type, "id", "name", enrollment.payment_type_id);
            ViewBag.student_id = new SelectList(db.students, "id", "full_name", enrollment.student_id);
            ViewBag.user_id = new SelectList(db.users, "id", "username", enrollment.user_id);
            return View(enrollment);
        }

        // GET: enrollments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enrollment enrollment = db.enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.categories, "id", "name", enrollment.category_id);
            ViewBag.payment_id = new SelectList(db.payments, "id", "id", enrollment.payment_id);
            ViewBag.payment_type_id = new SelectList(db.payment_type, "id", "name", enrollment.payment_type_id);
            ViewBag.student_id = new SelectList(db.students, "id", "full_name", enrollment.student_id);
            ViewBag.user_id = new SelectList(db.users, "id", "username", enrollment.user_id);
            return View(enrollment);
        }

        // POST: enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,student_id,category_id,payment_type_id,payment_id,user_id")] enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.categories, "id", "name", enrollment.category_id);
            ViewBag.payment_id = new SelectList(db.payments, "id", "id", enrollment.payment_id);
            ViewBag.payment_type_id = new SelectList(db.payment_type, "id", "name", enrollment.payment_type_id);
            ViewBag.student_id = new SelectList(db.students, "id", "full_name", enrollment.student_id);
            ViewBag.user_id = new SelectList(db.users, "id", "username", enrollment.user_id);
            return View(enrollment);
        }

        // GET: enrollments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enrollment enrollment = db.enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            enrollment enrollment = db.enrollments.Find(id);
            db.enrollments.Remove(enrollment);
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
