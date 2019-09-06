using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class hw2Controller : Controller
    {
        public void Q1(int N)
        {
            if (N == 2 || N == 3)
            {
                Response.Write(N + "是質數");
            }
            else if (N == 1)
            {
                Response.Write("1不是質數也不是合數，請輸入其他數字");
            }
            else if (N < 0)
            {
                Response.Write("請輸入其他正整數");
            }
            else
            {
                for (int i = 2; i < N; i++)
                {
                    if (N % i == 0)
                    {
                        Response.Write(N + "不是質數");
                        break;
                    }
                    else if (i == N - 1 && N % i != 0)
                    {
                        Response.Write(N + "是質數");
                    }
                }
            }
        }
        public string Q2(int a, int b)
        {
            int k = 0;
            int a2 = a, b2 = b;
            while (a % b != 0)
            {
                k = a % b;
                a = b;
                b = k;
            }
            return a2 + "和" + b2 + "的最大公因數為" + b;
        }
        public void Q3(int x)       //判斷是否為迴文，不使用函數及陣列
        {
            int round = 0, a = x;
            while (a >= 1)      //判斷位數
            {
                a /= 10;
                round++;
            }
            int check = 0;
            if (round % 2 == 1)     //位數為奇數時判斷迴文
            {
                if (x < 10 && x > 0)        //個位數字皆為迴文
                {
                    Response.Write(x + "是迴文");
                }
                else
                {
                    for (int i = 0; i < (round - 1) / 2; i++)   //依位數決定需執行幾次判斷
                    {
                        int times = 1, times2 = 1;
                        for (int j = round - 1; j >= 1; j--)    //依序取得數字左方數字，因不可使用次方函數
                        {
                            times *= 10;
                        }
                        if (x / times % 10 == x / times2 % 10)  //依序比較左右雙方數字是否一致
                        {
                            check++;
                            times2 *= 10;
                        }
                        else
                        {
                            Response.Write(x + "不是迴文");
                            break;
                        }
                    }
                }
                if (check > 0 && check == ((round - 1) / 2))
                {
                    Response.Write(x + "是迴文");
                }
            }
            else
            {
                for (int i = 0; i < round / 2; i++)   //依位數決定需執行幾次判斷
                {
                    int times = 1, times2 = 1;
                    for (int j = round - 1; j >= 1; j--)    //依序取得數字左方數字，因不可使用次方函數
                    {
                        times *= 10;
                    }
                    if (x / times % 10 == x / times2 % 10)  //依序比較左右雙方數字是否一致
                    {
                        check++;
                        times2 *= 10;
                    }
                    else
                    {
                        Response.Write(x + "不是迴文");
                        break;
                    }
                }
                if (check > 0 && check == round / 2)
                {
                    Response.Write(x + "是迴文");
                }
            }
        }
        public void Q4(string x)
        {
            string r = "";
            for (int i = x.Length - 1; i >= 0; i--)
            {
                r += x[i];
            }
            if (r == x)
            {
                Response.Write(x + "　是迴文");
            }
            else
            {
                Response.Write(x + "　不是迴文");
            }
        }
    }
}
