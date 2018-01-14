using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VenturaITC.DSMS.Classes;
using VenturaITC.DSMS.Models;
using VenturaITC.DSMS.Utils;
using VenturaITC.Security;

namespace VenturaITC.DSMS.Controllers
{
    public class UsersController : BaseController
    {
        private dsmsEntities db = new dsmsEntities();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.db_data_status).Include(u => u.user_role);
            return View(users.ToList());
        }


        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.status = new SelectList(db.db_data_status, "name", "description");
            ViewBag.role = new SelectList(db.user_role, "name", "description");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "username,full_name,cell_phone,email,role,locked,disabled,password,must_change_password,last_password_change,logged,last_login,current_login_attempts,registration_date,registration_user,status,_password,_passwordConfirm")] user user)
        {
            if (ModelState.IsValid)
            {
                if (UserUtils.ExistUsername(user.username))
                {
                    ShowErrorAlert(Resources.ResourcesMsgsError.AlreadyExistsUsername);
                }
                else
                {
                    user.locked = false;
                    user.disabled = false;
                    user.password = Authentication.HashPassword(SecurityUtils.FormatPassword(user._password));
                    user.must_change_password = true;
                    user.logged = false;
                    user.current_login_attempts = 0;
                    user.registration_date = DateTime.Now;
                    user.registration_user = "VAM";
                    user.status = Enumeration.DatabaseDataStatus.ACTIVE.ToString();

                    db.users.Add(user);
                    db.SaveChanges();

                    ShowSuccessAlert(Resources.ResourcesMsgsSuccess.SucessSaveUser);
                }
            }

            ViewBag.status = new SelectList(db.db_data_status, "name", "description", user.status);
            ViewBag.role = new SelectList(db.user_role, "name", "description", user.role);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.status = new SelectList(db.db_data_status, "name", "description", user.status);
            ViewBag.role = new SelectList(db.user_role, "name", "description", user.role);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "username,full_name,cell_phone,email,role,locked,disabled,password,must_change_password,last_password_change,logged,last_login,current_login_attempts,registration_date,registration_user,status,_password,_passwordConfirm")] user user)
        {
            ModelState["_password"].Errors.Clear();
            ModelState["_passwordConfirm"].Errors.Clear();

            if (ModelState.IsValid)
            {
                user dbUser = db.users.Find(user.username);
                if (user == null)
                {
                    return HttpNotFound();
                }

                dbUser.full_name = user.full_name;
                dbUser.cell_phone = user.cell_phone;
                dbUser.email = user.email;
                dbUser.role = user.role;
                dbUser.locked = user.locked;
                dbUser.disabled = user.disabled;
                dbUser.logged = user.logged;
                dbUser.status = user.status;

                //Workaround to prevent validation errors on db.SaveChanges() .
                dbUser._password = "User.0001";
                dbUser._passwordConfirm = "User.0001";

                db.Entry(dbUser).State = EntityState.Modified;
                db.SaveChanges();

                ShowSuccessAlert(Resources.ResourcesMsgsSuccess.SucessSaveUser);
            }

            ViewBag.status = new SelectList(db.db_data_status, "name", "description", user.status);
            ViewBag.role = new SelectList(db.user_role, "name", "description", user.role);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ShowResetUserPassword(string id)
        {
            user user = db.users.Find(id);
              return PartialView("_ResetUserPassword", user);
        }

        [HttpPost]
        public ActionResult ResetUserPassword(user user)
        {
            if (ModelState.IsValid)
            {
               
                if (user == null)
                {
                    return HttpNotFound();
                }

                //dbUser.full_name = user.full_name;
                //dbUser.cell_phone = user.cell_phone;
                //dbUser.email = user.email;
                //dbUser.role = user.role;
                //dbUser.locked = user.locked;
                //dbUser.disabled = user.disabled;
                //dbUser.logged = user.logged;
                //dbUser.status = user.status;

                ////Workaround to prevent validation errors on db.SaveChanges() .
                //dbUser._password = "User.0001";
                //dbUser._passwordConfirm = "User.0001";

                //db.Entry(dbUser).State = EntityState.Modified;
                //db.SaveChanges();

                ShowSuccessAlert(Resources.ResourcesMsgsSuccess.SucessSaveUser);
            }

            return View();

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
