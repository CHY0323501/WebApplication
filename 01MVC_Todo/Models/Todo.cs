using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01MVC_Todo.Models
{
    public class Todo
    {

        public int ID { get; set; }   //大括號表示封裝，封裝表示不要讓人看到
        public string title { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
    }
}