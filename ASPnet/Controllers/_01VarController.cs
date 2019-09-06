using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class _01VarController : Controller
    {
        // GET: _01Var
        public string Index()
        {
            //字串
            string w = "hello bitxx";
            return w;
        }
        public string boolIndex(bool gender)
        {
            //布林
            bool w = gender;
            if (w)
                return "男生";
            
            return "女生";
        }
        public string stringIndex(string name,bool gender)
        {
            //傳入字串參數及boolean參數
            string w = "";
            if (gender)
                w = "男性";
            else
                w = "女性";
            return "<h1 style='color: red;font-family:微軟正黑體'>"+name+"您好，您的性別為"+w+"</h1>";
        }
        public void numberIndex()
        {
            //數值    
            byte a = 255;       //0-255整數值
            sbyte b = 127;      //含正負數的八位元整數 -128~+127
            short c = 123;      //含正負數的16位元整數  -32768~+32767
            int d = 555;        //含正負數的32位元整數  -2147483648~+2147483647
            long e = 777777;    //含正負數的64位元整數  
            //////////////////////////////////
            ushort f = 65535;   //16位元正整數 0~65535
            uint g = 66666;     //32位元正整數 
            ulong h = 66666;    //64位元正整數 
            /////////////////////////////////
            float i = 444.2354f;               //要使用float，數值後方必須加上f，否則他會視為double浮點數值
            double j = 123.45678912034;


        }
    }
}