using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _05ADOnet.Controllers
{
    public class DefaultController : Controller
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        private DataTable querysql(string sql) {
            SqlDataAdapter adp = new SqlDataAdapter(sql, Conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);


           return ds.Tables[0];
        }
        public string ShowEmployee() {
            
            //接著到web config中新增連線字串，若在controller寫連線字串，其他controller無法使用；
            //偷吃步自動產生連線字串的方式：可使用webform的控制項資料>sqlsource，拉到form標籤中，點畫面下方的設計選擇資料來源，之後會在webconfig產生連線字串
            string sql = "select 員工編號,姓名,稱呼,職稱 from 員工";
            DataTable dt = querysql(sql);
            string str = "";
            //讀資料
            //for寫法
            //for (int i=0;i<dt.Rows.Count;i++) {
            //    str += "員工編號" + dt.Rows[i]["員工編號"]+"<br>";     //第幾列的第幾欄，欄位可指定欄位名稱
            //    str += "員工姓名" + dt.Rows[i]["姓名"] + "<br>";
            //    str += "稱呼" + dt.Rows[i]["稱呼"] + "<br>";
            //    str += "職稱" + dt.Rows[i]["職稱"] + "<hr>";
            //}
            //foreach寫法
            foreach (DataRow row in dt.Rows) {           //要使用datarow物件一定要先有datatable物件
                str += "員工編號" + row["員工編號"] + "<br>";     //第幾列的第幾欄，欄位可指定欄位名稱
                str += "員工姓名" + row["姓名"] + "<br>";
                str += "稱呼" + row["稱呼"] + "<br>";
                str += "職稱" + row["職稱"] + "<hr>";
            }
            return str;
            //若要查看有無取到資料，可下中斷點在此class的結尾大括弧，執行偵錯模式，在網址打上controller及action name，等中斷點變成黃色底色時，在ds變數右鍵，新增監看式，在值的欄位點擊放大鏡
                           
        }
        public string ShowProduct()
        {
            string sql = "select 產品,單價,庫存量 from 產品資料 where 單價>30 order by 單價,庫存量 desc";
            DataTable dt = querysql(sql);
            string str = "";
            //讀資料
            //for寫法
            //for (int i=0;i<dt.Rows.Count;i++) {
            //    str += "產品" + dt.Rows[i]["產品"]+"<br>";    
            //    str += "單價" + dt.Rows[i]["單價"] + "<br>";
            //    str += "庫存" + dt.Rows[i]["庫存量"] + "<hr>";
            //}
            //foreach寫法
            foreach (DataRow row in dt.Rows)
            {           
                str += "產品" + row["產品"] + "<br>";     
                str += "單價" + row["單價"] + "<br>";
                str += "庫存" + row["庫存量"] + "<hr>";
            }
            return str;

        }
        public string ShowCustomerByaddress(string keyword)
        {
            string sql = "select 公司名稱,連絡人,連絡人職稱,地址 from 客戶 where 地址 like @kw";
            SqlDataAdapter adp = new SqlDataAdapter(sql, Conn);
            //避免資料隱碼攻擊的做法如下（把變數換成parameter）
            adp.SelectCommand.Parameters.AddWithValue("@kw","%"+keyword+"%");

            DataSet ds = new DataSet();
            adp.Fill(ds);


            DataTable dt = ds.Tables[0];
            string str = "";
            //讀資料
            //for寫法
            //for (int i=0;i<dt.Rows.Count;i++) {
            //    str += "公司名稱" + dt.Rows[i]["公司名稱"]+"<br>";     
            //    str += "連絡人" + dt.Rows[i]["連絡人"] + "<br>";
            //    str += "連絡人職稱" + dt.Rows[i]["連絡人職稱"] + "<br>";
            //    str += "地址" + dt.Rows[i]["地址"] + "<hr>";
            //}
            //foreach寫法
            foreach (DataRow row in dt.Rows)
            {           
                str += "公司名稱" + row["公司名稱"] + "<br>";     
                str += "連絡人" + row["連絡人"] + "<br>";
                str += "連絡人職稱" + row["連絡人職稱"] + "<br>";
                str += "地址" + row["地址"] + "<hr>";
            }
            return str;

        }
    }
}