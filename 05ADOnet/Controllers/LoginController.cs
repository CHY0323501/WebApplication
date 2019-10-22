using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace _05ADOnet.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString);
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string account,string pw)
        {
            string sql = "select * from tStudent where fEmail=@account and fStuId=@pw";
            SqlCommand cmd = new SqlCommand(sql,Conn);
            cmd.Parameters.AddWithValue("@account", account);
            cmd.Parameters.AddWithValue("@pw", pw);
            SqlDataReader rd;

            Conn.Open();
            rd=cmd.ExecuteReader();
            if (rd.Read())      //移動資料指標，寫一次rd.read()相當於fitch next；回傳結果為true/false;
            {
                Session["id"]=rd["fStuID"].ToString();      //用在記錄登入狀態，當登入狀態時才能執行某些功能

                Conn.Close();
                return RedirectToAction("Index","Home");
            }
                Conn.Close();
                ViewBag.loginerr = "帳號或密碼有誤";
                return View();
        }
        public ActionResult Logout() {
            Session.Clear();        //清除登入狀態
            return RedirectToAction("Index","Home");
        }
    }
}