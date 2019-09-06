using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class hw4Controller : Controller
    {
        public ActionResult hw4_main()
        {
            return View();
        }

        [HttpPost]
        public ActionResult hw4_main(string ID)
        {
            string show_result = "";
            if (check_length(ref ID))                                   //當長度不符合時，檢查結束
            {
                if (firstchar(ref ID))                                  //當第一碼不為大寫英文時，檢查結束
                {
                    if (gender(ref ID))                                 //當性別碼不為1或2時，檢查結束
                    {
                        if (eightNum(ref ID))                           //當後八碼不為數字時，檢查結束
                        {
                            if (checkNum(ref ID))                       //判斷身分證合法性
                            {
                                show_result = "這是合法的身分證字號";
                            }
                            else
                            {
                                show_result = "此身份證字號不正確";
                            }
                        }else
                            show_result = "格式錯誤";
                    }
                    else
                        show_result = "格式錯誤";
                }
                else
                    show_result = "格式錯誤";
            }
            else
                show_result = "格式錯誤";
            ViewBag.Result = show_result;
            return View();
        }
        public bool check_length(ref string ID)
        {
            if (ID.Length != 10)                    //檢查身分證字號長度是否為10碼
            {
                return false;
            }
            return true;
        }
        public bool firstchar(ref string ID)
        {
            int first=Convert.ToByte(ID[0]);           //以ASCII碼檢查第一碼是否為大寫A-Z
            if (!(first >= 65 && first <= 90)) {
                return false;
            }

            //string search = "ABCDEFGHJKLMNPQRSTUVXYWZIO";           //其他比對方法
            //string storechar = search.Substring(0, 1);
            //if (storechar.Contains(search))
            //{
            //    return nextstep = true;
            //}

            return true;
        }
        public bool gender(ref string ID)
        {
            switch (Convert.ToString(ID[1])) {          //檢查性別碼是否為1或2
                case "1":
                case "2":
                    return true;
            }
            return false;
        }
        public bool eightNum(ref string ID)
        {
            int check_0to9 = 0;
            for (int i=2;i<=9;i++) {                //以ASCII碼檢查後八碼是否為數字0-9
                check_0to9 = Convert.ToByte(ID[i]);
                if (!(check_0to9 >= 48 && check_0to9 <= 57)) {
                    return false;
                }
            }
            return true;
        }
        public bool checkNum(ref string ID)
        {
            string change_id = "";
            int chartoNum = 10,sum=0;
            string[] check_arr = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "W", "Z", "I", "O" };
            int[] check_num = new int[] {1,9,8,7,6,5,4,3,2,1,1};      
            

            for (int i=0;i<check_arr.Length;i++) {                //英文轉數字
                if (check_arr[i] == Convert.ToString(ID[0])) {
                    change_id += i + chartoNum;
                }
            }
            change_id+=ID.Substring(1, 9);          //與原來的後九碼連接

            for (int j =0;j<check_num.Length;j++) {         //將每個身分證字號乘上對應的數字並加總
               sum+=Int16.Parse(change_id.Substring(j,1))*check_num[j];
            }
            if (sum%10==0) {                                //當總和可被10整除即為合法
                return true;
            }
            return false;
        }
    }
}