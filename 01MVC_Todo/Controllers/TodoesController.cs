﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _01MVC_Todo.Models;

namespace _01MVC_Todo.Controllers
{
    public class TodoesController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

    }
}
