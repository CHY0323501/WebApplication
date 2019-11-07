using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPnet.App_Code
{
    //物件導向範例
    //若有人要使用此類別，需using namespace ASPnet.App_Code
    public class Person     //沒寫修飾詞預設為private，宣告【類別】需有class
    {
        //field欄位(一個值)，不給使用類別的人動，要給使用者動的要封裝成屬性，欄位其實可不寫，可直接寫封裝屬性
        string name;
        int age;
        bool gender;
        decimal height;
        decimal weight;

        //建構子(無回傳值，可不寫void)
        public Person()
        {
            name = "第一名";
        }
        public Person(string Name, int Age)
        {
            name = Name;
            age = Age;
        }
        public Person(string Name, int Age, bool Gender)
        {
            name = Name;
            age = Age;
            gender = Gender;
        }
        public Person(string Name, int Age, bool Gender, decimal H)
        {
            name = Name;
            age = Age;
            gender = Gender;
            height = H;
        }
        public Person(string Name, int Age, bool Gender, decimal H,decimal W)
        {
            name = Name;
            age = Age;
            gender = Gender;
            height = H;
            weight = W;
        }
        public Person(string Name,decimal H, decimal W)
        {
            name = Name;
            height = H;
            weight = W;
        }



        //Attribute屬性(一個值)，可以給使用者動的值
        //以下為封裝屬性，GET表示可以取出來用、SET表示可以指定值給他
        public string Name {
            get {
                if (string.IsNullOrEmpty(name))
                {
                    name = "無名氏";
                }
                return name;
            }
            set {
                if (!string.IsNullOrEmpty(value)) {
                    name = value;
                }
            }
        }
        public int Age {
            get {
                return age;
            }
            set {
                if (value < 0)
                    age = 0;
                else
                    age = value;
            }
        }
        public bool Gender {
            get {
                return gender;
            }
            set {
                gender = value;
            }
        }
        public decimal Height {
            get {
                return height;
            }
            set {
                if (value < 0)
                    height = 1;
                else
                    height = value;
            }
        }
        public decimal Weight {
            get {
                return weight;
            }
            set {
                if (value < 0)
                    weight = 1;
                else
                    weight = value;
            }
        }


        //方法
        //Speak多載
        public string Speak() {
            return "我的名字" + name;
        }
        /// <summary>
        /// 請傳入要說的話
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string Speak(string content) {
            return name + "說" + content;
        }
        /// <summary>
        /// 請傳入目前幾年級
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string Speak(int n)
        {
            return String.Format("{0}說我現在{1}年級", name, n); 
        }

        //Jump多載
        public string Jump() {
            return name + "嚇了一跳";
        }
        /// <summary>
        /// 請傳入跳了幾公尺高
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public string Jump(int h)
        {
            return name + "跳了"+h+"公尺高";
        }
        /// <summary>
        /// 請傳入跳了幾公尺高及跳了幾公尺遠
        /// </summary>
        /// <param name="h"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public string Jump(int h,int w)
        {
            return name + "跳了" + h + "公尺高" + w + "公尺遠";
        }
        public string Walk(int m)
        {
            return name + "走了"+m+"步";
        }
    }
}