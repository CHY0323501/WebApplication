using _03View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03View.Controllers
{
    public class bootstrap_practiceController : Controller
    {
        public ActionResult Index()
        {
            string[] id = { "A01", "A02", "A03", "A04", "A05", "A06", "A07" };

            string[] name = { "瑞豐夜市", "新堀江商圈", "六合夜市", "青年夜市", "花園夜市", "大東夜市", "武聖夜市" };

            string[] address = { "高雄市左營區裕誠路", "高雄市新興區玉衡里", "台灣高雄市新興區六合二路",
                "高雄市前鎮區凱旋四路758號", "台南市北區海安路三段533號", "台南市東區林森路一段276號",
                "台南市中西區武聖路69巷42號" };
            List<NightMarket> list = new List<NightMarket>();
            for (int i = 0; i < id.Length; i++)
            {
                //宣告一筆新資料時，要鑄造一個物件，若有100筆要建100次，且每次物件名稱要不同，若將一筆資料輸入完後先丟到list泛型中儲存(一格裡面存了id、name、address，很像json)，
                //下一次建造相同物件時就可以相同名稱了，如果不先丟到list中這筆資料會一直被新的資料覆蓋
                NightMarket nightMarket = new NightMarket();
                nightMarket.id = id[i];
                nightMarket.name = name[i];
                nightMarket.address = address[i];
                list.Add(nightMarket);
            }

            return View(list);
        }
    }
}