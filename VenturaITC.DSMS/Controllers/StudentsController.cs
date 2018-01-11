using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VenturaITC.DSMS.Models;
using VenturaITC.DSMS.ViewModels;

namespace VenturaITC.DSMS.Controllers
{
    public class StudentsController : Controller
    {
        private dsmsEntities db = new dsmsEntities();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.students.Include(s => s.academic_level).Include(s => s.gender).Include(s => s.marital_status).Include(s => s.province).Include(s => s.province1).Include(s => s.status).Include(s => s.student_type);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            BindDropdownsOnCreate();
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentEnrolmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (dsmsEntities db = new dsmsEntities())
                {
                    //Insert student data.
                    student stud = new student()
                    {
                        student_type_id = model.student_type_id,
                        full_name = model.full_name,
                        birth_date = model.birth_date,
                        marital_status_id = model.marital_status_id,
                        gender_id = model.gender_id,
                        place_of_birth = model.place_of_birth,
                        province_of_birth_id = model.province_of_birth_id,
                        fathers_name = model.fathers_name,
                        mothers_name = model.mothers_name,
                        address = model.address,
                        id_number = model.id_number,
                        id_issuance_place = model.id_issuance_place,
                        id_issuance_date = model.id_issuance_date,
                        id_expiry_date = model.id_expiry_date,
                        academic_level_id = model.academic_level_id,
                        job_title = model.job_title,
                        phone_number = model.phone_number,
                        cell_phone1 = model.cell_phone1,
                        cell_phone2 = model.cell_phone2,
                        email = model.email
                    };

                    db.students.Add(stud);
                    //db.SaveChanges();


                    //Insert enrollment data
                    payment paym = new payment()
                    {
                        id=model.payment_id,
                        amount = model.amountToPay,
                        date = DateTime.Now,
                    };

                    enrollment enroll = new enrollment()
                    {
                        category_id = model.category_id,
                        payment_id = paym.id,
                        payment_type_id=model.payment_type_id,
                        student_id=stud.id
                    };

                    document doc = new document()
                    {

                    };

                    //Insert documents.
                    if (model.picture!=null)
                    {

                    }
                }

                return RedirectToAction("Index");
            }
            //BindDropdownsOnUpdate(student);

            return View();
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            //if (student == null)
            //{
            //    return HttpNotFound();
            //}
            //InitializeDropdowns(student);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "number,student_type_id,full_name,first_name,last_name,birth_date,marital_status_id,gender_id,place_of_birth,province_of_birth_id,fathers_name,mothers_name,address,id_number,id_issuance_place,id_issuance_date,id_expiry_date,academic_level_id,job_title,phone_number,cell_phone1,cell_phone2,email,status_id")] student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //  InitializeDropdowns(student);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
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

        private void BindDropdownsOnCreate()
        {
            ViewBag.academic_level_id = new SelectList(db.academic_level, "id", "name");
            ViewBag.marital_status_id = new SelectList(db.marital_status, "id", "name");
            ViewBag.province_of_birth_id = new SelectList(db.provinces, "id", "name");
            ViewBag.status_id = new SelectList(db.status, "id", "name");
            ViewBag.student_type_id = new SelectList(db.student_type, "id", "name");
            ViewBag.gender_id = new SelectList(db.genders, "id", "name");
            ViewBag.id_issuance_place = new SelectList(db.provinces, "id", "name");

            //For enrollment data
            ViewBag.category_id = new SelectList(db.categories, "id", "name");
            ViewBag.payment_type_id = new SelectList(db.payment_type, "id", "name");
        }

        private void BindDropdownsOnUpdate(StudentEnrolmentViewModel student)
        {
            ViewBag.academic_level_id = new SelectList(db.academic_level, "id", "name", student.academic_level_id);
            ViewBag.marital_status_id = new SelectList(db.marital_status, "id", "name", student.marital_status_id);
            ViewBag.province_of_birth_id = new SelectList(db.provinces, "id", "name", student.province_of_birth_id);
            // ViewBag.status_id = new SelectList(db.status, "id", "name", student.status_id);
            ViewBag.student_type_id = new SelectList(db.student_type, "id", "name", student.student_type_id);
            ViewBag.gender_id = new SelectList(db.genders, "id", "name", student.gender_id);
            ViewBag.id_issuance_place = new SelectList(db.provinces, "id", "name", student.id_issuance_place);

            //For enrollment data
            ViewBag.category_id = new SelectList(db.categories, "id", "name", student.category_id);
            ViewBag.payment_type_id = new SelectList(db.payment_type, "id", "name", student.payment_type_id);
        }
    }
}
