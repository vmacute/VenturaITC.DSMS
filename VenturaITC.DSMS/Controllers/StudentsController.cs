using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using VenturaITC.DB.Repository.Class;
using VenturaITC.DSMS.Models;
using VenturaITC.DSMS.Utils;
using VenturaITC.DSMS.ViewModels;

namespace VenturaITC.DSMS.Controllers
{
    /// <summary>
    /// Represents the Student controller class.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20180103    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class StudentsController : BaseController
    {
        private _dsmsEntities db = new _dsmsEntities();


        /// <summary>
        /// Gets the list of students enrollment view model.
        /// </summary>
        /// <returns>The list of students enrollment view model.</returns>
        private List<StudentEnrolmentViewModel> GetStudentEnrolmentViewModelList(int studentID = 0)
        {
            List<StudentEnrolmentViewModel> studentsModels = new List<StudentEnrolmentViewModel>();

            try
            {
                List<student> studentList = db.students.ToList();

                if (studentID != 0)
                {
                    studentList = studentList.Where(m => m.id == studentID).ToList();
                }

                foreach (var student in studentList)
                {
                    student.documents.Where(m => m.student_id == 1);

                    List<document_type> docTypes = new List<document_type>();

                    foreach (var id in student.documents.Select(m => m.document_type_id).ToList())
                    {
                        docTypes.Add(db.document_type.Find(id));
                    }

                    StudentEnrolmentViewModel studentModel = new StudentEnrolmentViewModel
                    {
                        student_id = student.id,
                        full_name = student.full_name,
                        student_type_name = GetItemDescription("student_type", student.student_type.id)
                      //  category_name = GetItemDescription("categories", student.enrollments.Where(m => m.student_id == student.id).First().id)
                      //  documents = new SelectList(docTypes, "id", "name")


                    };

                    studentsModels.Add(studentModel);
                }

                return studentsModels;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Gets the description of a table item.
        /// </summary>
        /// <param name="tableEntry">The table entry.</param>
        /// <param name="id">The item ID.</param>
        /// <returns>The description of the specified item ID.</returns>
        private string GetItemDescription(string tableEntry, int itemID)
        {
            try
            {
                PropertyInfo info = db.GetType().GetProperty(tableEntry);
                IQueryable table = info.GetValue(db, null) as IQueryable;

                IQueryable query = table.AsQueryable().Where("id == @0", itemID);

                foreach (var item in query)
                {
                    //In this case, we just return the property value of the first element.
                    return item.GetType().GetProperty("name").GetValue(item, null).ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }

            return null;
        }



        /// <summary>
        /// Gets the Index view.
        /// </summary>
        /// <returns>The Index view.</returns>
        public ActionResult Index()
        {
            return View(GetStudentEnrolmentViewModelList());
        }

        /// <summary>
        /// Gets the Details view.
        /// </summary>
        /// <returns>The Details view.</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(GetStudentEnrolmentViewModelList((int)id).First());
        }

        /// <summary>
        /// Gets the Create view.
        /// </summary>
        /// <returns>The Create view.</returns>
        public ActionResult Create()
        {
            BindDropdownsOnGetView();
            return View();
        }

        /// <summary>
        /// Posts the Create view.
        /// </summary>
        /// <param name="model">The model that is rendered by the view.</param>
        /// <returns>The action method result.</returns>
        /// <remarks>
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        /// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// </remarks>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentEnrolmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Validations:
                if (model.student_type_id != 2 && model.amountToPay < model.minimumAmount)
                {
                    ShowErrorAlert(Resources.ResourcesMsgsError.AmountToPayLess);
                    BindDropdownsOnPostView(
                        model.academic_level_id,
                        model.marital_status_id,
                        model.province_of_birth_id,
                        model.student_type_id,
                        model.gender_id,
                        model.id_issuance_place,
                        model.category_id,
                        model.payment_type_id
                        );

                    return View();
                }

                //Insert student data:
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
                    email = model.email,
                    status_id = 1
                };

                db.students.Add(stud);

                //Insert documents:
                List<document> docs = new List<document>();

                if (model.picture != null)
                {
                    document picture = new document()
                    {
                        student_id = stud.id,
                        document_type_id = 1,
                        document_content = FileUtils.GetFileContent(model.picture)
                    };

                    docs.Add(picture);
                }

                if (model.IDCopy != null)
                {
                    document IDCopy = new document()
                    {
                        student_id = stud.id,
                        document_type_id = 2,
                        document_content = FileUtils.GetFileContent(model.IDCopy)
                    };

                    docs.Add(IDCopy);
                }

                if (model.medicalCertificate != null)
                {
                    document medicalCertificate = new document()
                    {
                        student_id = stud.id,
                        document_type_id = 3,
                        document_content = FileUtils.GetFileContent(model.medicalCertificate)
                    };

                    docs.Add(medicalCertificate);
                }

                if (model.militaryServiceStatement != null)
                {
                    document militaryServiceStatement = new document()
                    {
                        student_id = stud.id,
                        document_type_id = 4,
                        document_content = FileUtils.GetFileContent(model.militaryServiceStatement)
                    };

                    docs.Add(militaryServiceStatement);
                }

                if (model.criminalRecordCertificate != null)
                {
                    document criminalRecordCertificate = new document()
                    {
                        student_id = stud.id,
                        document_type_id = 5,
                        document_content = FileUtils.GetFileContent(model.criminalRecordCertificate)
                    };

                    docs.Add(criminalRecordCertificate);
                }

                if (docs.Count > 0)
                {
                    db.documents.AddRange(docs);
                }

                //Insert payment and enrollment data:
                payment paym = new payment()
                {
                    id = model.payment_id,
                    amount = model.amountToPay,
                    date = DateTime.Now,
                    user_id = LoginUtils.GetLoggedUserID()
                };

                //If is not full bursary, add the payment:
                if (model.student_type_id != 2)
                {
                    db.payments.Add(paym);
                }

                enrollment enroll = new enrollment()
                {
                    category_id = model.category_id,
                    payment_id = paym.id,
                    payment_type_id = model.payment_type_id,
                    student_id = stud.id,
                    date = DateTime.Now,
                    user_id = LoginUtils.GetLoggedUserID()
                };

                //For partial payment
                if (model.payment_type_id == 2)
                {
                    payment_installment paymInstall = new payment_installment()
                    {
                        payment_id = paym.id,
                        installment_id = 1,
                        enrollment_id = enroll.id
                    };
                }

                db.enrollments.Add(enroll);

                //Save all changes
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            BindDropdownsOnPostView(
                model.academic_level_id,
                model.marital_status_id,
                model.province_of_birth_id,
                model.student_type_id,
                model.gender_id,
                model.id_issuance_place,
                model.category_id,
                model.payment_type_id
                );

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

        /// <summary>
        /// Binds the dropdowns on the Get view method.
        /// </summary>
        private void BindDropdownsOnGetView()
        {
            try
            {
                ViewBag.academic_level_id = new SelectList(db.academic_level, "id", "name");
                ViewBag.marital_status_id = new SelectList(db.marital_status, "id", "name");
                ViewBag.province_of_birth_id = new SelectList(db.provinces, "id", "name");
                ViewBag.status_id = new SelectList(db.status, "id", "name");
                ViewBag.student_type_id = new SelectList(db.student_type, "id", "name");
                ViewBag.gender_id = new SelectList(db.genders, "id", "name");
                ViewBag.id_issuance_place = new SelectList(db.provinces, "id", "name");
                ViewBag.category_id = new SelectList(db.categories, "id", "name");
                ViewBag.payment_type_id = new SelectList(db.payment_type, "id", "name");
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        ///  Binds the dropdowns on the Post view method.
        /// </summary>
        /// <param name="st">The student model</param>
        /// <param name="category_id">The CategoryID.</param>
        /// <param name="payment_type_id">The payment type ID.</param>
        private void BindDropdownsOnPostView(
            int academic_level_id,
            int marital_status_id,
            int province_of_birth_id,
            int student_type_id,
            int gender_id,
            int id_issuance_place,
            int category_id,
            int payment_type_id)
        {
            try
            {
                ViewBag.academic_level_id = new SelectList(db.academic_level, "id", "name", academic_level_id);
                ViewBag.marital_status_id = new SelectList(db.marital_status, "id", "name", marital_status_id);
                ViewBag.province_of_birth_id = new SelectList(db.provinces, "id", "name", province_of_birth_id);
                ViewBag.student_type_id = new SelectList(db.student_type, "id", "name", student_type_id);
                ViewBag.gender_id = new SelectList(db.genders, "id", "name", gender_id);
                ViewBag.id_issuance_place = new SelectList(db.provinces, "id", "name", id_issuance_place);
                ViewBag.category_id = new SelectList(db.categories, "id", "name", category_id);
                ViewBag.payment_type_id = new SelectList(db.payment_type, "id", "name", payment_type_id);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
