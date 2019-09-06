using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class _02StatementController : Controller
    {
        // GET: _02Statement
        public void Statement1()
        {
            int a = 10;
            a = 20;

            a += 10;
            a++;

            Response.Write("a="+a+"<HR>");
            //////////////////////////////////////////
            //浮點數問題
            int x = 123, y = 456;
            float z = 12.14567f;
            float result = 0;
            result = x + z;

            Response.Write("x+z=" + result+"<HR>");

            float xx = 10000.9f;
            double yy = 9999.3;
            Response.Write("xx+yy=" + ((decimal)xx+(decimal)yy));
            Response.Write("<HR>");
            Response.Write("xx-yy=" + ((decimal)xx - (decimal)yy));

        }
        public string ifStatement(int age)
        {
            if (age > 20)
                return "買全票";
            else if (age >6)
                return "買半票";
            else if(age>=0)
                return "免費入場";

            return "輸入年紀錯啦";

        }
        public string switchStatement(string color)
        {
            switch (color)
            {
                case "黃":
                    return "黃色";
                case "綠":
                    return "綠色";
                case "藍":
                    return "藍色";
            }
            return "這不是黃綠紅";
        }
        public void forStatement()
        {
            string[] arrRainbow = { "紅", "橙", "黃", "綠", "藍", "靛", "紫" };
            string[] arrColor = { "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet" };
            for (int i = 0; i<arrRainbow.Length;i++) {
                Response.Write("<span style='color:"+arrColor[i]+";font-size:3rem'>"+arrRainbow[i]+"</span>");
            }
        }
        public void foreachStatement()
        {
            string[] arrRainbow = { "紅", "橙", "黃", "綠", "藍", "靛", "紫" };
            string[] arrColor = { "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet" };
            int i = 0;
            foreach (string item in arrRainbow)
            {
                Response.Write("<span style='color:"+arrColor[i]+"'>"+item+"</span>");
                i++;
            }
        }
        public void Poker()
        {
            for (int i = 1; i <= 52; i++) {
                Response.Write("<img src='../poker_img/"+i+".gif'>");
            }
        }
        public void whileStatement()
        {
            int i = 1;
            while (i<=52) {
                Response.Write("<img src='../poker_img/" + i + ".gif'>");
                i++;
            }
        }
        public void dowhileStatement()
        {
            int i = 1;
            do {
                Response.Write("<img src='../poker_img/" + i + ".gif'>");
                i++;
            } while (i<=52);
        }
    }
}