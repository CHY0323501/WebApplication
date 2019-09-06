using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class hw3Controller : Controller
    {
        public void poker_main()
        {
            int[] pokerNum = new int[52];
            playgame(ref pokerNum);
            shufflePoker(ref pokerNum);
            getPoker(ref pokerNum);
        }
        public void playgame(ref int[] pokerNum) {          //將牌輸入至陣列
            
            for (int i = 0; i < pokerNum.Length; i++)
            {
                pokerNum[i] = i;
            }
            
        }
        public void shufflePoker(ref int[] pokerNum)         //傳址呼叫；隨機交換陣列中兩數進行洗牌
        {       
            Random R = new Random();
            int tem = 0, ran = 0;
            for (int j = 0; j < pokerNum.Length; j++)               
            {      
                ran = R.Next(0, 52);
                tem = pokerNum[j];
                pokerNum[j] = pokerNum[ran];
                pokerNum[ran] = tem;
            }
            
        }
        public void getPoker(ref int[] pokerNum) {              //發牌
            string p1 = "", p2 = "", p3 = "", p4 = "";
            int index = 0;
            for (int k = 0; k <pokerNum.Length; k++)
            {
                index = pokerNum[k] + 1;
                switch (k % 4)
                {
                    case 0:
                        p1 += "<img src='../poker_img/" + index + ".gif'>";
                        break;
                    case 1:
                        p2 += "<img src='../poker_img/" + index + ".gif'>";
                        break;
                    case 2:
                        p3 += "<img src='../poker_img/" + index + ".gif'>";
                        break;
                    case 3:
                        p4 += "<img src='../poker_img/" + index + ".gif'>";
                        break;
                }
            }
            Response.Write("第一位玩家<br>" + p1+ "<br><br>" + "第二位玩家<br>" + p2+ "<br><br>"+ "第三位玩家<br>" + p3+ "<br><br>"+ "第四位玩家<br>" + p4);
        }
    }
}