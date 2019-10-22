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
//04-1 Linq練習
//04-1-1 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//04-1-2 指定控制器名稱為HomeController,並開啟HomeController
//04-1-3 建立一般方法ShowAryDesc()-整數陣列遞減排序
//04-1-4 執行並測試 http://localhost:53468/Home/ShowAryDesc (port可能不同)
//04-1-5 建立一般方法ShowAryAsc()-整數陣列遞增排序
//04-1-6 執行並測試 http://localhost:53468/Home/ShowAryAsc (port可能不同)
//04-1-7 在Controllers資料夾上按右鍵,選擇加入,新增項目,程式碼,選擇類別,名稱鍵入Member.cs
//04-1-8 在Member class中輸入下列欄位
//04-1-9 在HomeController中建立一般方法LoginMember()
//04-1-10 執行並測試 http://localhost:53468/Home/LoginMember?uid=tom&pwd=123 (port可能不同)


//04-2 Entity FrameWork
//04-2-1 建立NorthWind.mdb資料庫Model
//       在Models上按右鍵,選擇加入,新增項目,資料,ADO.NET實體資料模型
//       來自資料庫的EF Designer
//       連接NorthWind.mdf資料庫,連線名稱不修改,按下一步按鈕
//       選擇Entity Framework 6.x, 按下一步按鈕
//       資料表"全選", 按完成鈕
//       若跳出詢問方法按確定鈕
//04-2-3 在專案上按右鍵,建置
//04-2-4 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//04-2-5 指定控制器名稱為LinqController,並開啟LinqController
//04-2-6 using _04EF.Models
//04-2-7 於LinqController建立DB物件
//04-2-8 建立一般方法ShowEmployee()-查詢所有員工記錄
//04-2-9 執行並測試 http://localhost:53468/Home/ShowEmployee (port可能不同)
//04-2-10 建立一般方法ShowCustomerByAddress()-找出客戶地址中含有keyword關鍵字的客戶記錄
//04-2-11 執行並測試 http://localhost:53468/Home/ShowCustomerByAddress?keywork=xxxxx (port可能不同)
//04-2-12 建立一般方法ShowProduct()-查詢單價大於30的產品，並依單價做遞增排序，庫存量做遞減排序
//04-2-13 執行並測試 http://localhost:53468/Home/ShowProduct (port可能不同)
//04-2-14 建立一般方法ShowProductInfo()-查詢產品平均價、總合、筆數，最高價和最低價資訊
//04-2-15 執行並測試 http://localhost:53468/Home/ShowProductInfo (port可能不同)

//04-2-16 建立建立在SQL Server伺服器上的NorthWind.mdb資料庫Model
//        在Models上按右鍵,選擇加入,新增項目,資料,ADO.NET實體資料模型
//        來自資料庫的EF Designer
//        連接NorthWind.mdf資料庫,連線名稱不修改,按下一步按鈕
//        選擇Entity Framework 6.x, 按下一步按鈕
//        資料表"全選", 按完成鈕
//        若跳出詢問方法按確定鈕
//04-2-17 在專案上按右鍵,建置
//04-2-18 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//04-2-19 指定控制器名稱為Linq2Controller,並開啟LinqController
//04-2-20 using _04EF.Models
//04-2-21 於Linq2Controller建立DB物件
//04-2-22 將LinqController內的4個方法複製至Linq2Controller,並測試結果

//04-3 在Model建立驗證功能
//04-3-1 建立dbStudent.mdb資料庫Model
//       在Models上按右鍵,選擇加入,新增項目,資料,ADO.NET實體資料模型
//       來自資料庫的EF Designer
//       連接dbStudent.mdf資料庫,連線名稱不修改,按下一步按鈕
//       選擇Entity Framework 6.x, 按下一步按鈕
//       資料表"全選", 按完成鈕
//       若跳出詢問方法按確定鈕
//04-3-2 在專案上按右鍵,建置
//04-3-3 展開dbStudentModel.edmx, 再展開dbStudentModel.tt, 找到tStudent.cs並開啟此檔
//04-3-4 using System.ComponentModel 及 System.ComponentModel.DataAnnotations
//04-3-5 在原程式中加入驗證功能標籤 
//04-3-6 在Controllers資料夾上按右鍵,加入,控制器,選擇 MVC5Controller-Empty
//04-3-7 指定控制器名稱為VilidationController,並開啟VilidationController
//04-3-8 using _04EF.Models
//04-3-9 於VilidationController建立DB物件,並撰寫Index、Create、Delete的Action
//04-3-10 在public ActionResult Index()上按右鍵,新增檢視,建立Index View
//04-3-11 進行下列設定:
//        View name:Index
//        Template:List
//        Model class:tStudent(_04Ef.Models)
//        Data context class:dbStudentEntities(_04Ef.Models)
//        勾選Use a layout pages
//        按下Add
//04-3-12 修改英文文字為中文與表格中的內容
//04-3-13 執行並測試
//04-3-14 在public ActionResult Create()上按右鍵,新增檢視,建立Create View
//04-3-15 進行下列設定:
//        View name:Create
//        Template:Empty(without model)
//        Model class:tStudent(_04Ef.Models)
//        Data context class:dbStudentEntities(_04Ef.Models)
//        勾選Use a layout pages
//        按下Add
//04-3-16 修改英文文字為中文
//04-3-17 執行並測試