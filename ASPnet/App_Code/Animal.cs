using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPnet.App_Code
{
    public abstract class Animal        //抽象方法
    {
        public string Name { get; set; }
        //public string Move(int m)
        //{
        //    return "移動了" + m + "公尺";
        //}
        //public abstract string Speak(); //抽象方法
    }
}