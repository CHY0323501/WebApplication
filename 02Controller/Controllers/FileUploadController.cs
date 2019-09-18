using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02Controller.Controllers
{
    public class FileUploadController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase photo)
        {
            string fileName = "";
            if (photo!=null) {
                if (photo.ContentLength>0) {                //可用contentlength來限制檔案的大小
                    fileName = photo.FileName;
                    //因為IE瀏覽器選擇檔案後瀏覽器並沒有自動省去使用者的檔案路徑，故使用getfilename取得去掉路徑後的檔名+副檔名，需要先引入path的命名空間
                    fileName = Path.GetFileName(fileName);   
                    
                    photo.SaveAs(Server.MapPath("~/Photos/"+fileName));         //一般網站的路徑都是邏輯路徑，要實際存檔案一定要轉成伺服器的實體路徑才可存到伺服器中

                }
            }
            return RedirectToAction("ShowPhotos");
        }
        public string ShowPhotos() {
            string show = "";
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Photos/"));     //diretoryInfo路徑一樣要用伺服器的實體路徑
            FileInfo[] fInfo = dir.GetFiles();          //由於getfiles回傳為陣列，故在宣告時要宣告為陣列
            foreach (FileInfo result in fInfo) {
                show += "<a href='../Photos/"+result.Name+"'><img src='../Photos/" + result.Name + "'width='90' /></a>";
            }
            show += "<p><a href='Create'>再次上傳圖片</a></p>";
            return show;
        }
    }
}