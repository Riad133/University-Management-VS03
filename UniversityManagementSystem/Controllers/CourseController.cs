using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private ProjectDBContext db = new ProjectDBContext();

        // GET: Course
        public ActionResult Index()
        {
            var course = db.Course.Include(c => c.Department).Include(c => c.Semester);
            return View(course.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentCode");
            ViewBag.SemesterId = new SelectList(db.Semester, "SemesterId", "SemesterId");
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,Code,Credit,Name,Description,DepartmentId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Course.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentCode", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.Semester, "SemesterId", "SemesterId", course.SemesterId);
            return View(course);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentCode", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.Semester, "SemesterId", "SemesterId", course.SemesterId);
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,Code,Credit,Name,Description,DepartmentId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentCode", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.Semester, "SemesterId", "SemesterId", course.SemesterId);
            return View(course);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Course.Find(id);
            db.Course.Remove(course);
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

        [HttpPost]
        public JsonResult DoesCodeExist(string Code)
        {

            return Json((!db.Course.Any(x => x.Code == Code)), JsonRequestBehavior.AllowGet);
        }

    }
}
