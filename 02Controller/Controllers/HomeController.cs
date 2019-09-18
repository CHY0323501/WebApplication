using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02Controller.Controllers
{
    public class HomeController : Controller
    {
        public string ShowArr() {
            int[] score = { 52,99,61,100,37,76};
            string show = "";
            int sum = 0;
            foreach (var m in score) {
                show+=m+", ";
                sum += m;
            }
            show += "<hr>";
            show += "總和:" + sum;
            return show;
        }
        public string ShowImg()
        {
            string show = "";
            for (int i = 1; i <= 8; i++) {
                show += "<img src='../images/images/" + i + ".jpg' width='150px'/>";
            }
            return show;
        }
        //string中若要加入變數可用format屬性，{0}對應後面第一個參數
        public string ShowImgIndex(int index)
        {
            string[] name = { "櫻桃鴨", "鴨油高麗菜", "鴨油麻婆豆腐", "櫻桃鴨握壽司", "片皮鴨捲三星蔥", "三杯鴨", "櫻桃鴨片肉", "慢火白菜燉鴨湯" };
            string show = string.Format("<p align='center'><img src='../images/images/{0}.jpg' width='150px'/><br>{1}</p>",index,name[index-1]);
            return show;
        }
        //氣泡排序
        public string ShowSortArr()
        {
            int[] score = { 52, 99, 61, 100, 37, 76 };
            score = Mysort(score);
            string show = "";
            foreach (var m in score)
            {
                show += m + "　";
            }
            return show;
        }
        int[] Mysort(int[] arrscore) {
            int change = 0;
            for (int i=arrscore.Length-1;i>0;i--)
            {
                for (int j=0;j<i;j++) {
                    change = 0;
                    if (arrscore[i] > arrscore[j]) {
                        change = arrscore[i];
                        arrscore[i] = arrscore[j];
                        arrscore[j] = change;
                    }
                }
            }
            return arrscore;
        }
        //使用linq排序
        public string ShowSortArr2()
        {
            int[] score = { 52, 99, 61, 100, 37, 76 };
            var result = from m in score
                         orderby m ascending
                         select m;

            //Array.Sort(score);    //內建函數排序
            string show = "";
            foreach (var m in result)
            {
                show += m + "　";
            }
            return show;
        }

    }
}