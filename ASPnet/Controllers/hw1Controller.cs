using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class hw1Controller : Controller
    {
        // GET: hw1
        public void Q1()
        {
            int a = 42; float b = 2.5f;
            Response.Write(a+"+"+b+"=" + (a + b) + "<BR>");
            Response.Write(a+"-"+b+"=" + (a - b) + "<BR>");
            Response.Write(a+"*"+b+"=" + (a * b) + "<BR>");
            Response.Write(a+"/"+b+"=" + (a / b) + "<BR>");
            Response.Write(a+"%"+b+"=" + (a % b) );
        }
        public string Q2(float tem)
        {
            float result = 0;
            result = tem * 9 / 5 + 32;
            return "華氏溫度為" + result;
        }
        public void Q3(int X, int Y)
        {
            X = X ^ Y;
            Y = X ^ Y;
            X = X ^ Y;
            Response.Write("交換後X為" + X + "<br>交換後Y為" + Y);
        }
        public void Q4(decimal score)
        {
            score = Math.Floor(score / 10);
            switch (score)
            {
                case 10:
                case 9:
                    Response.Write("等第：優等");
                    break;
                case 8:
                    Response.Write("等第：甲等");
                    break;
                case 7:
                    Response.Write("等第：乙等");
                    break;
                case 6:
                    Response.Write("等第：丙等");
                    break;
                default:
                    Response.Write("等第：丁等");
                    break;
            }
        }
        public void Q5(int N)
        {
            for (int i = 1; i <= N; i++)
            {
                if (i % 5 != 0)
                {
                    Response.Write(i + " ");
                }
            }
        }
        public void Q6(int N)
        {
            int sum = 0;
            for (int i = 1; i <= N; i++)
            {
                if (i % 3 != 0)
                {
                    sum += i;
                }
            }
            Response.Write("總和為" + sum);
        }
        public void Q7(int N)
        {
            string star = "*";
            string sum = "";
            for (int i = 1; i <= N; i++)
            {
                sum += star;
                Response.Write(sum + "<BR>");
            }
        }
        public void Q8()
        {
            for (int x = 1; x <= 9; x++)
            {
                for (int y = 1; y <= 9; y++)
                {
                    Response.Write(x + "*" + y + "=" + (x * y) + "  ");
                }
                Response.Write("<br>");
            }
        }
    }
}