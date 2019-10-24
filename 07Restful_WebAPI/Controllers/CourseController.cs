using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using _07Restful_WebAPI.Models;

namespace _07Restful_WebAPI.Controllers
{
    //繼承類別要為ApiController
    public class CourseController : ApiController
    {
        List<Course> Cour = new List<Course>
        {
            new Course{ ID=1,Name="ASP.nep MVC5",Hour=30},
            new Course{ ID=2,Name="ASP.nep WebForm",Hour=50},
            new Course{ ID=3,Name="ASP",Hour=20},
            new Course{ ID=4,Name="PHP",Hour=30},
            new Course{ ID=5,Name="Javasrcipt",Hour=24},
            new Course{ ID=6,Name="HTML5",Hour=15},
            new Course{ ID=7,Name="jQuery",Hour=12},
            new Course{ ID=8,Name="SQL Server",Hour=45},
            new Course{ ID=9,Name="Android APP",Hour=40},
            new Course{ ID=10,Name="Bootstrap",Hour=25},
        };
        public IEnumerable<Course> Get() {
            return Cour;
        }
    }
}