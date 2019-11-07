using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPnet.App_Code
{
    public class SuperMan:Person
    {
        string style;
        public string Style {
            get {
                return style;
            } set {
                style = value;
            }
        }
        public string Fly()
        {
            return "I can fly high";
        }
        /// <summary>
        /// 請傳入飛了幾公里遠
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public string Fly(int h)
        {
            return "我飛了" + h + "公里遠";
        }
    }
}