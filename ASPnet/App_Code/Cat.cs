﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPnet.App_Code
{
    public class Cat: Animal, IAnimalSpeak, IAnimalMove
    {
        public string Move(int m)
        {
            return "移動了" + m + "公尺";
        }
        public string Speak()
        {
            return "喵喵喵";
        }
    }
}