using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _06ViewModel.Models;

namespace _06ViewModel.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities1 db = new NorthwindEntities1();
        public ActionResult Index()
        {
            //Linq，建立fk關聯
            //from a in db.員工
            //join b in db.職稱
            //on a.職稱 equals b.職稱代碼
            //select new { a.員工編號, a.姓名, b.職稱1, a.出生日期 }

            return View(db.員工.ToList());
        }
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(員工 emp)
        {
            db.員工.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}