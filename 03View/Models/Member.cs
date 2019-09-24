using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03View.Models
{
    public class Member
    {
        public string userid { get; set; }
        public string name { get; set; }
        public string pwd { get; set; }
        public string email { get; set; }
        public DateTime birthday { get; set; }
    }
}