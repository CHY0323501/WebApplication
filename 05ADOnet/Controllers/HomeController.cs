using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace _05ADOnet.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        private void executesql(string sql) {
            //因為sqlcommand鑄造在外面，原本應該要給參數，但外面不能打上參數因為沒有原本sqlcommandtext，要自己加上參數值
            cmd.CommandText = sql;
            cmd.Connection = Conn;

            Conn.Open();
            cmd.ExecuteNonQuery(); //執行sql指令
            Conn.Close();
        }
        private DataTable querysql(string sql)
        {
            SqlDataAdapter adp = new SqlDataAdapter(sql, Conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);


            return ds.Tables[0];
        }
        public ActionResult Index()
        {
            DataTable dt = querysql("select * from tStudent");
            return View(dt);
        }
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string id,string name,string email,int score)
        {
            string sql = "insert into tStudent values(@id,@name,@email,@score)";
           
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@name",name);
            cmd.Parameters.AddWithValue("@email",email);
            cmd.Parameters.AddWithValue("@score",score);
            //sqlcommand操作資料庫時，一定要開啟and關閉連線；但使用sqladapter來操作資料庫時，會自動開啟或關閉
            executesql(sql);

            return View();
        }
        public ActionResult Delete(string id) {
            string sql = "delete from tStudent where fStuId=@id";
            cmd.Parameters.AddWithValue("@id",id);
            executesql(sql);
            return RedirectToAction("Index");
        }
    }
}