using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPnet.App_Code;


namespace ASPnet.Controllers
{
    public class ObjectController : Controller
    {
        Animal animal;
        // GET: Object
        public ActionResult Index()
        {
            //鑄造person物件並命名為Jack，並自訂各屬性的值
            Person Jack = new Person();
            Jack.Name = "Jack Wang";
            Jack.Age = 18;
            Jack.Gender = true;
            Jack.Height = 180.5M;       //decimal數字後方要加上M，否則會被當成float
            Jack.Weight = 72;
            //person的方法如下
            Jack.Speak();       //沒傳參數的結果會顯示 我的名字是Jack Wang
            Jack.Jump();        //沒傳參數的結果會顯示 Jack Wang嚇了一跳
            Jack.Walk(10);      //傳參數的結果會顯示 Jack Wang走了10步

            //再鑄造一個Person物件並命名為Mary，並自訂各屬性的值
            Person Mary = new Person();
            Mary.Name = "Mary Lee";
            Mary.Age = 17;
            Mary.Gender = false;
            Mary.Height = 168;      
            Mary.Weight = 53.1M;
            Mary.Speak(5);
            Mary.Jump(30,50);       //多載方法顯示 跳了30公尺高50公尺遠


            //鑄造物件時直接給值的寫法
            Person John = new Person("John Lin", 20, true);


            var avg = (Jack.Age + Mary.Age) / 2;

            //////////////////////////////
            //superman繼承person，故superman可以擁有所有person的成員
            SuperMan Clock = new SuperMan();
            Clock.Walk(55);
            Clock.Fly(20);        //多載方法顯示 飛了20公里遠


            return View();
        }
        public ActionResult ploymophism()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ploymophism(string type) {
            
            Dog dog = new Dog();
            Cat cat = new Cat();

            //要判斷是狗還是貓，只需要把值丟給父物件，並呼叫方法即可，因speak已在dog及cat中實作
            if (type == "d")
            {
                animal = dog;
            }
            else if (type == "c")
            {
                animal = cat.ToString;
            }

            ViewBag.Result = animal.Speak();

                return View();
        }
    }
}