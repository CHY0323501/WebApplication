using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _02Controller.Models;

namespace _02Controller.Controllers
{
    public class ComplexBindController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //複雜模型繫結傳入的參數為model，故需先創建model，跟簡單繫結比起來，複雜模型可減少在輸入參數時要打很多次
        public ActionResult Create(Product p)
        {
            ViewBag.Pid =p.Pid;
            ViewBag.Pname = p.Pname;
            ViewBag.Price = p.Price;
            return View();
        }
    }
}