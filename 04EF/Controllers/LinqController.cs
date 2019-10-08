using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _04EF.Models;
using System.Data.Linq.SqlClient;

namespace _04EF.Controllers
{
    public class LinqController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        public string ShowEmployee()
        {
            //Linq擴充方法寫法
            var result = db.員工;
            //Linq查詢運算式原始寫法
            var result2 = from a in db.員工
                          select a;

            string show = "";
            foreach (var m in result)
            {
                show += "員工編號："+m.員工編號 + "</BR>";
                show += "員工姓名："+m.姓名 + "</BR>";
                show += "職稱："+m.職稱 + "<HR>";
            }
            return show;
        }
        public string ShowCustomerByaddress(string keyword)
        {
            //Linq擴充方法寫法
            var result = db.客戶.Where(x=>x.地址.Contains(keyword));        //等同於like '%'+keyword+'%'
            var result2 = db.客戶.Where(x => x.地址.StartsWith(keyword));    //等同於like keyword+'%'
            var result3 = db.客戶.Where(x => x.地址.EndsWith(keyword));    //等同於like '%'+keyword

            //Linq查詢運算式原始寫法
            var result4 = from a in db.客戶
                          where a.地址.Contains(keyword)
                          select a;

            string show = "";
            foreach (var m in result4)
            {
                show += "公司：" + m.公司名稱 + "<br />";
                show += "姓名：" + m.連絡人 + m.連絡人職稱 + "<br />";
                show += "地址：" + m.地址 + "<hr>";
            }
            return show;
        }
        public string ShowProduct() {
            //Linq擴充方法寫法
            var result2 = db.產品資料.Where(c => c.單價 > 30).OrderBy(c => c.單價).ThenByDescending(c=>c.庫存量);  //第二個以後的排序欄位要使用thenby不可使用orderby

            //Linq查詢運算式原始寫法
            var result = from b in db.產品資料
                         where b.單價>30
                         orderby b.單價 ascending,b.庫存量 descending
                         select b;

            string show = "";
            foreach (var m in result)
            {
                show += "產品：" + m.產品 + "<br />";
                show += "單價：" + m.單價 + "<br />";
                show += "庫存量："+ m.庫存量 + " <hr>";
            }
            return show;
        }
        public string ShowProductInfo() {
            //Linq擴充方法寫法
            var result2 = db.產品資料;

            string show = "";
                show += "平均單價：" + result2.Average(m=>m.單價) + "<br />";
                show += "單價總和：" + result2.Sum(m => m.單價) + "<br />";
                show += "產品筆數：" + result2.Count() + "<br />";
                show += "最高單價：" + result2.Max(m => m.單價) + "<br />";
                show += "最低單價：" + result2.Min(m => m.單價) + " <hr>";
            return show;
        }

        //使用已存在於SQL Server的資料庫來建立model
    }
}