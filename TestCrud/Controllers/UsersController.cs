using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestCrud.Models;

namespace TestCrud.Controllers
{
    public class UsersController : Controller
    {
        private TestCrudEntities db = new TestCrudEntities();

        // GET: Users
        public ActionResult Index()
        {
            var user = db.User.Include(u => u.UserType);
            return View(user.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.IdUserType = new SelectList(db.UserType, "Id", "Name");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password,ModificationDate,CreatationDate,IdUserType")] User user)
        {
            if (ModelState.IsValid)
            {
                user.CreatationDate = DateTime.Now;
                user.ModificationDate = DateTime.Now;
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUserType = new SelectList(db.UserType, "Id", "Name", user.IdUserType);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUserType = new SelectList(db.UserType, "Id", "Name", user.IdUserType);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,ModificationDate,CreatationDate,Password,IdUserType")] User user)
        {
            if (ModelState.IsValid)
            {
                user.CreatationDate = DateTime.Now;
                user.ModificationDate = DateTime.Now;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUserType = new SelectList(db.UserType, "Id", "Name", user.IdUserType);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginCredentials credentials)
        {
            var user = db.User.FirstOrDefault(u => u.Password.Equals(credentials.Password) && u.UserName.Equals(credentials.UserName));
            if (user != null)
            {
                if (user.UserType.Name == "Administrador")
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Usuario o contraseña incorrecta";
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
