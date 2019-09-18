using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02Controller.Controllers
{
    public class SimpleBindController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string Pid,string Pname,int Price)
        {
            ViewBag.Pid = Pid;
            ViewBag.Pname = Pname;
            ViewBag.Price = Price;
            return View();
        }
    }
}