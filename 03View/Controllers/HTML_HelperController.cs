using _03View.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03View.Controllers
{
    public class HTML_HelperController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Member member,string ValidationCode)
        {
            //判斷驗證碼輸入正確性
            if (Session["code"].ToString() == ValidationCode)
            {
                string msg = "";
                msg = "註冊資料如下：<br>" +
                    "帳號：" + member.userid + "<br>" +
                    "密碼：" + member.pwd + "<br>" +
                    "姓名：" + member.name + "<br>" +
                    "信箱：" + member.email + "<br>" +
                    "生日：" + member.birthday.ToShortDateString();
                ViewBag.msg = msg;
                
            }
            else {
                ViewBag.msg = "驗證碼錯誤";
            }
            return View(member);

        }
        public ActionResult getCode() {
            string code=GetRandomCode(6);
            //把驗證碼的字串丟到session中，session的生命週期到瀏覽器關閉為止
            Session["code"] = code;

            //用bitmap來畫圖，給width及height參數
            System.Drawing.Bitmap img = new System.Drawing.Bitmap(code.Length * 25, 40);
            //用bitmap 產生一個Graphics物件
            Graphics g = Graphics.FromImage(img);
            //rgb值隨機產生
            Random r = new Random();
            int red = r.Next(0,256);
            int green = r.Next(0,256);
            int blue = r.Next(0,256);
            //預設是黑色，用clear清掉並指定背景色
            g.Clear(Color.FromArgb(1, red, green, blue));
            //畫噪音點
            for (int i = 0; i < 300; i++)
            {
                int x1 = r.Next(img.Width);
                int y1 = r.Next(img.Height);
                //兩點座標連線
                img.SetPixel(x1,y1,Color.FromArgb(r.Next(256)));
            }
            //畫條噪音線(給兩點座標)
            for (int i=0;i<50;i++) {
                int x1 = r.Next(img.Width);
                int y1 = r.Next(img.Height);
                int x2 = r.Next(img.Width);
                int y2 = r.Next(img.Height);
                //兩點座標連線
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }
            //產生驗證圖的邊框，用矩形物件產生一個矩形
            Rectangle Myrec = new Rectangle(0,0,img.Width,img.Height);
            red = r.Next(0, 256);
            green = r.Next(0, 256);
            blue = r.Next(0, 256);
            Color color1 = Color.FromArgb(red, green, blue);

            red = r.Next(0, 256);
            green = r.Next(0, 256);
            blue = r.Next(0, 256);
            Color color2 = Color.FromArgb(red, green, blue);

            //文字的顏色(漸層色)
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(Myrec,color1,color2,1.2f);
            //設定字型
            Font font = new Font("Arial Black", 20, FontStyle.Bold);
            //把字串畫進矩形
            g.DrawString(code, font, brush, 5, 5);
            //畫外框線
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, img.Width - 1, img.Height - 1);

            Image image = img;
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            return File(ms.GetBuffer(), "image/jpeg");
        }
        string GetRandomCode(int n) {
            string[] arrLetter = {"A", "B", "C", "D", "E", "F", "G", "H","J", "K", "M", "N", "P", "Q","R","S","T","W","X","Y"
            ,"a","b","c","d","e","f","g","h","j","k","m","n","p","r","s","t","w","x","y","1","2","3","4","5","6","7","8","9","0"};

            Random r = new Random();
            int a = 0;
            string strCode = "";
            for (int i=0;i<n;i++) {
                a= r.Next(0, arrLetter.Length);
                strCode += arrLetter[a];
            }

            return strCode;
        }
    }
}