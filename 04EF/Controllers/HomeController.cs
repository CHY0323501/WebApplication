using _04EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04EF.Controllers
{
    public class HomeController : Controller
    {
        public string ShowArrayDesc()
        {
            int[] score = new int[] { 79,51,100,66,79,35,68,81,44,62,0};
            string show = "";
            //Linq查詢運算式原始寫法(宣告一個動態變數來接)
            var result= from c in score
                        orderby c descending
                        select c;
            //Linq擴充方法寫法
            var result2 = score.OrderByDescending(x => x);

            //SQL select command
            //SelectList score from table1
            //order by score desc
            show = "遞減排序：";
            foreach (var m in result2) {
                show += m+" , ";
            }
            show += "</br>";
            show += "總和"+result2.Sum();

            return show;
        }
        public string ShowArrayAsc()
        {
            int[] score = new int[] { 79, 51, 100, 66, 79, 35, 68, 81, 44, 62, 0 };
            string show = "";
            //Linq查詢運算式原始寫法(宣告一個動態變數來接)
            var result = from c in score
                         orderby c
                         select c;
            //Linq擴充方法寫法
            var result2 = score.OrderBy(x => x);

            //SQL select command
            //select score from table1
            //order by score desc
            show = "遞減排序：";
            foreach (var m in result2)
            {
                show += m + " , ";
            }
            show += "</br>";
            show += "平均" + result2.Average();

            return show;
        }
        public string LoginMember(string uid,string pwd) {
            Member[] members = new Member[]
            {
                new Member{ UID="TONY",PWD="555",NAME="湯尼"},
                new Member{ UID="JUDY",PWD="666",NAME="豬蒂"},
                new Member{ UID="MARY",PWD="777",NAME="馬力"}
            };
            //Linq擴充方法寫法
            var result = members.Where(a => a.UID == uid && a.PWD == pwd).FirstOrDefault();
            //Linq查詢運算式原始寫法
            var result2 = (from a in members
                          where a.UID == uid && a.PWD == pwd
                          select a).FirstOrDefault();

            //SQL select command
            //select * from members
            //where UID=@uid and PWD=@pwd
            string show = "";
            if (result != null) {
                show = result.NAME + "歡迎登入";
            }
            else {
                show = "帳號或密碼錯誤";
            }

            return show;
        }
    }
}