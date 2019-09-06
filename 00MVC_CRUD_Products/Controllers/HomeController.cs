//命名空間(NameSpace)
using _00MVC_CRUD_Products.Models;              //引用別的物件到此controller
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _00MVC_CRUD_Products.Controllers
{
    public class HomeController : Controller
    {
        //使用Entity建立DB物件
        dbProductEntities3 db = new dbProductEntities3();
        public ActionResult Index()
        {
            var product = db.tProduct.ToList();     //list為泛型，泛型和陣列很像，但泛型可以放入物件
            return View(product);      
        }
        //GET的Create Action
        public ActionResult Create()                
        {
            return View();
        }
        //POST的Create Action
        [HttpPost]                                  //將表單資料丟到伺服器端

        //取得資料，當資料有檔案時，要使用HttpPostedFileBase
        public ActionResult Create(string fId, string fName, decimal fPrice, HttpPostedFileBase fImg)
        {
            string imgname = "";
            if (fImg != null)
            {                                               //處理表單上傳的圖片
                if (fImg.ContentLength > 0)
                {
                    imgname = System.IO.Path.GetFileName(fImg.FileName);       //system.io為namespace；取得檔案檔名(副檔名也會取得)
                    fImg.SaveAs(Server.MapPath("~/images/" + imgname));          //由於不知道伺服器實體路徑，使用server.mappath，程式會將邏輯路徑轉為伺服器端的實體路徑
                    Console.WriteLine(Server.MapPath("~/images/" + imgname));
                }
            }
            //處理圖檔上傳(先丟到model，再丟到DB)

            tProduct product = new tProduct();      //將資料表鑄造為一個物件，欄位視為資料表的屬性
            product.fId = fId;
            product.fName = fName;
            product.fPrice = fPrice;
            product.fImg = imgname;
            
            db.tProduct.Add(product);                           //將資料寫到model
            db.SaveChanges();                                   //將資料寫入資料庫

            return RedirectToAction("Index");                            //新增完重新導向到首頁
        }
        //刪除資料(刪資料庫資料、刪資料夾檔案)
        public ActionResult Delete(string fId)                
        {
            var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();
            string imgname = product.fImg;
            if (imgname!="") {
                //刪除指定圖檔
                System.IO.File.Delete(Server.MapPath("~/images/") + imgname);
            }


            db.tProduct.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");               //導向Index的Action方法
        }
        //將原來該筆資料讀出來
        public ActionResult Edit(string fId)
        {
            var product = db.tProduct.Where(m=>m.fId== fId).FirstOrDefault();
            return View(product);
        }
       
        [HttpPost]                                  //將表單資料丟到伺服器端
        //將修改後的資料存到資料庫
        public ActionResult Edit(string fId, string fName, decimal fPrice, HttpPostedFileBase fImg,string oldImg)
        {
            string imgname = "";
            if (fImg != null)
            {                                               //處理表單上傳的圖片
                if (fImg.ContentLength > 0)
                {
                    if (oldImg !="") {
                        System.IO.File.Delete(Server.MapPath("~/images/") + oldImg);        //刪除舊有的圖檔
                    }
                    imgname = System.IO.Path.GetFileName(fImg.FileName);       //system.io為namespace；取得檔案檔名(副檔名也會取得)
                    fImg.SaveAs(Server.MapPath("~/images/" + imgname));          //由於不知道伺服器實體路徑，使用server.mappath，程式會將邏輯路徑轉為伺服器端的實體路徑
                }
            }
            else {
                imgname = oldImg;
            }
            //處理圖檔上傳(先丟到model，再丟到DB)

            var product = db.tProduct.Where(m => m.fId == fId).FirstOrDefault();

     
            product.fName = fName;
            product.fPrice = fPrice;
            product.fImg = imgname;

            db.SaveChanges();                                   //將資料寫入資料庫

            return RedirectToAction("Index");                    //導向Index的Action方法
        }
    }
}