using _06ViewModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _06ViewModel.ViewModels
{
    public class EmpTitle
    {
        public List<員工> Employee { get; set; }
        public List<職稱列表> JobTitle { get; set; }
    }
}