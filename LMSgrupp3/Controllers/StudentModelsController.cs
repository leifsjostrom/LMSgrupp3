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
    public class StudentModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private StudentRepository repo = new StudentRepository();

        // GET: StudentModels
        public ActionResult Index()
        {
            return View(repo.ShowAll().ToList());
        }

        // GET: StudentModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModel studentModel = db.StudentModels.Find(id);
            if (studentModel == null)
            {
                return HttpNotFound();
            }
            return View(studentModel);
        }

        // GET: StudentModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentNumber,Name,Adress,Town,ZipCode,Email")] StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                repo.Create(studentModel);
                //db.StudentModels.Add(studentModel);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentModel);
        }

        // GET: StudentModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModel studentModel = db.StudentModels.Find(id);
            if (studentModel == null)
            {
                return HttpNotFound();
            }
            return View(studentModel);
        }

        // POST: StudentModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentNumber,Name,Adress,Town,ZipCode,Email")] StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentModel);
        }

        // GET: StudentModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModel studentModel = db.StudentModels.Find(id);
            if (studentModel == null)
            {
                return HttpNotFound();
            }
            return View(studentModel);
        }

        // POST: StudentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudentModel studentModel = db.StudentModels.Find(id);
            db.StudentModels.Remove(studentModel);
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
