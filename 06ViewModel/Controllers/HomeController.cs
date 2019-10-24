using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _06ViewModel.Models;
using System.Data.Entity;       //當實體資料表無關聯時，仍要建立關聯需先引入此namespace

namespace _06ViewModel.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities1 db = new NorthwindEntities1();
        public ActionResult Index()
        {
            //Linq，當model中的xml檔沒有將相關聯的資料表建立關聯時，寫linq才需要寫join，
            //關聯linq寫法一：
            //var sql = from a in db.員工
            //          join b in db.職稱
            //          on a.職稱 equals b.職稱代碼
            //          select new { a.員工編號, a.姓名, b.職稱1, a.出生日期 };
            ///////////////////////////////////
            
            //var sql = from a in db.員工
            //          from b in db.職稱
            //          select new { a.員工編號, a.姓名, b.職稱1, a.出生日期 };

            var sql = db.員工;

            

            return View(sql.ToList());
        }
        public ActionResult Create() {
            //1.不使用helper要產生下拉式選單時的做法如下：
            //ViewBag.職稱=db.職稱列表.ToList();

            //2.要讓helper自動產生下拉式選單時，實做需用以下的selectlist物件，第二個參數在view中的value相當於【@item.職稱代碼】，第三個參數為下拉式選單要出現的資料的欄位名稱
            ViewBag.職稱 = new SelectList(db.職稱列表, "職稱代碼","職稱");
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