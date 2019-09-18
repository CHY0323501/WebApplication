using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _01MVC_Todo.Models;                   //1引入資料庫(model)命名空間

namespace _01MVC_Todo.Controllers
{
    public class HomeController : Controller
    {
        //2建立db物件
        TodoContext db = new TodoContext();
        //撈出todoes資料表的資料，回給view
        public ActionResult Index()                     
        {
            //3資料若要排序，必須在丟進泛型前排序(指定依哪個欄位排序)，使用linq語法；lambda的【X=>X】可自訂要用甚麼字
            //將資料放到list的寫法：
            var todoes = db.Todoes.OrderBy(x=>x.Date).ToList();
            //Linq語法土法煉鋼寫法，結果同上(select寫在最後)
            //var todo = from t in db.Todoes
            //           orderby t.Date
            //           select t;
            
      
            //將資料丟給view
            return View(todoes);                        
        }
        public ActionResult Create() {

            return View();
        }
        [HttpPost]
        public ActionResult Create(string title,string Img,DateTime Date) {
            Todo todo = new Todo();
            todo.title = title;
            todo.Image = Img;
            todo.Date = Date;
            

            db.Todoes.Add(todo);                //把todo物件傳給model
            db.SaveChanges();                   //請model將資料寫入資料庫

            //保留上次傳來的表單內容狀態(date無法保留)
            //ViewBag.title2 = title;
            //ViewBag.Img = Img;
            //ViewBag.Date = Date;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ID) {
            //若只取得一筆資料，使用firstordefault，取得多筆資料可丟到list
            //linq取得一筆資料(寫法1)：
            var todo=db.Todoes.Where(m => m.ID == ID).FirstOrDefault();
            //linq取得一筆資料(寫法2)：
            //var todo2 = from t in db.Todoes
            //            where t.ID == ID
            //            select t;
            db.Todoes.Remove(todo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int ID) {
            var todo = db.Todoes.Where(m => m.ID == ID).FirstOrDefault();
            return View(todo);
        }
        [HttpPost]
        //修改MODEL資料以及寫入資料庫
        public ActionResult Edit(int ID,string title, string Img, DateTime Date)
        {
            //LINQ語法
            var todo = db.Todoes.Where(m => m.ID == ID).FirstOrDefault();
            //修改model資料
            todo.title = title;
            todo.Image = Img;
            todo.Date = Date;
            
            //修改db
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}