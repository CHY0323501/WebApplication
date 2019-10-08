using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _04EF.Models;

namespace _04EF.Controllers
{
    public class ValidationController : Controller
    {
        dbStudentEntities db = new dbStudentEntities();
        // GET: Validation
        public ActionResult Index()
        {
            return View(db.tStudent.ToList());
        }
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tStudent student)
        {
            if (ModelState.IsValid) {               //確認所有驗證器都通過後會傳回true
                db.tStudent.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);       //當驗證不通過時，將表單的值保留必須將model當參數丟給view
        }
        public ActionResult Delete(string id) {
            var stu = db.tStudent.Where(a => a.fStuId == id).FirstOrDefault();
            db.tStudent.Remove(stu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}