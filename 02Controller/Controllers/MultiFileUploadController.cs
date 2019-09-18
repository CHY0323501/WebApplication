using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02Controller.Controllers
{
    public class MultiFileUploadController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase[] photo)          //傳多值的表單皆宣告為陣列物件!!!!!!!!!!
        {
            string fileName = "";
            for (int i=0;i<photo.Length;i++) {
                HttpPostedFileBase f = photo[i];
                if (f != null) {
                    if (f.ContentLength>0)          //可用contentlength來限制檔案的大小
                    {
                        //fileName = f.FileName;
                        ////因為IE瀏覽器選擇檔案後瀏覽器並沒有自動省去使用者的檔案路徑，故使用getfilename取得去掉路徑後的檔名+副檔名，需要先引入path的命名空間
                        //fileName = Path.GetFileName(fileName);

                        //避免檔名重複導致覆蓋原有相同檔名的檔案，做以下處理
                        //因為datetime中格式為2019/09/17 15:24，但是windows檔名不可以有/及:，故使用replace來處理
                        fileName = DateTime.Now.ToString().Replace("/","").Replace(":","").Replace(" ","").Replace("上午","").Replace("下午","") + (i + 1).ToString() + ".jpg";
                        f.SaveAs(Server.MapPath("~/Photos/" + fileName));       //一般網站的路徑都是邏輯路徑，要實際存檔案一定要轉成伺服器的實體路徑才可存到伺服器中
                    }
                }
            }
            return RedirectToAction("ShowPhotos");
        }
        public string ShowPhotos()
        {
            string show = "";
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Photos/"));     //diretoryInfo路徑一樣要用伺服器的實體路徑
            FileInfo[] fInfo = dir.GetFiles();          //由於getfiles回傳為陣列，故在宣告時要宣告為陣列，用來取得路徑內的所有檔案
            foreach (FileInfo result in fInfo)      //in fInfo可改為in dir.GetFiles()
            {
                //show += "<a href='../Photos/" + result.Name + "'><img src='../Photos/" + result.Name + "'width='90' /></a>";
                show += string.Format("<a href='../Photos/{0}'><img src='../Photos/{0}'width='90' /></a>",result.Name);
            }
            show += "<p><a href='Create'>再次上傳圖片</a></p>";
            return show;
        }
    }
}