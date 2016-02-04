using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMSgrupp3.Models;
using LMSgrupp3.Repository;


namespace LMSgrupp3.Controllers
{
    public class TeacherModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private StudentRepository repo = new StudentRepository();

        // GET: TeacherModels
        public ActionResult Index()
        {
            return View(repo.ShowAllTeachers());
        }

        // GET: TeacherModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherModel teacherModel = db.TeacherModels.Find(id);
            if (teacherModel == null)
            {
                return HttpNotFound();
            }
            return View(teacherModel);
        }

        // GET: TeacherModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmplymentNumber,Name,Adress,Town,ZipCode,Email")] TeacherModel teacherModel)
        {
            repo.Create(teacherModel);

            return View(teacherModel);
        }

        // GET: TeacherModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherModel teacherModel = db.TeacherModels.Find(id);
            if (teacherModel == null)
            {
                return HttpNotFound();
            }
            return View(teacherModel);
        }

        // POST: TeacherModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmplymentNumber,Name,Adress,Town,ZipCode,Email")] TeacherModel teacherModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacherModel);
        }

        // GET: TeacherModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherModel teacherModel = db.TeacherModels.Find(id);
            if (teacherModel == null)
            {
                return HttpNotFound();
            }
            return View(teacherModel);
        }

        // POST: TeacherModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TeacherModel teacherModel = db.TeacherModels.Find(id);
            db.TeacherModels.Remove(teacherModel);
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
