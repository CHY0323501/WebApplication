using _03View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03View.Controllers
{
    public class HTML_HeplerController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Member member)
        {
            string msg = "";
            msg = "註冊資料如下：<br>" +
                "帳號：" +member.userid+ "<br>"+
                "密碼：" +member.pwd+"<br>" +
                "姓名：" +member.name+"<br>" +
                "信箱：" +member.email+"<br>" +
                "生日：" +member.birthday.ToShortDateString();
            ViewBag.msg = msg;
            return View(member);
        }
    }
}