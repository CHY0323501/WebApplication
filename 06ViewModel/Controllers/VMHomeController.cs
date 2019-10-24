using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using _06ViewModel.Models;
using _06ViewModel.ViewModels;

namespace _06ViewModel.Controllers
{
    public class VMHomeController : Controller
    {
        NorthwindEntities1 db = new NorthwindEntities1();
        // GET: VMHome
        public ActionResult Index(int jobTitle=1)
        {
            ViewBag.jobTitle123 = db.職稱列表.Where(a => a.職稱代碼 == jobTitle).FirstOrDefault().職稱;
            ViewBag.jobTitleID = jobTitle;

            EmpTitle Et = new EmpTitle() {
                Employee = db.員工.Where(a=>a.職稱==jobTitle).ToList(),
                JobTitle = db.職稱列表.ToList()
            };
            return View(Et);
        }
        public ActionResult Create(int? jobTitle)       //打?表示允許參數允許null
        {
            if (jobTitle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.jobTitleID = jobTitle;
            return View();
        }
        [HttpPost]
        public ActionResult Create(員工 emp, int jobTitle)
        {
            emp.職稱 = jobTitle;
            db.員工.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index", new { jobTitle = jobTitle });
        }
        public ActionResult Details(int? empid,int jobTitle)
        {
            if (empid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.jobTitle123 = db.職稱列表.Where(a => a.職稱代碼 == jobTitle).FirstOrDefault().職稱;
            ViewBag.jobTitleID = jobTitle;

            EmpTitle Et = new EmpTitle()
            {
                Employee = db.員工.Where(a => a.員工編號 == empid).ToList(),
                JobTitle = db.職稱列表.Where(a=>a.職稱代碼== jobTitle).ToList()
            };
            return View(Et);
        }
        public ActionResult Delete(int id, int jobTitle)
        {
            var emp=db.員工.Where(a => a.員工編號 == id).FirstOrDefault();
            db.員工.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index", new { jobTitle = jobTitle });
        }
    }
}