using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _07Restful_WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // index
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // read
        public string Get(int id)
        {
            return "value";
        }

        // create
        public void Post([FromBody]string value)
        {
        }

        // update
        public void Put(int id, [FromBody]string value)
        {
        }

        // delete
        public void Delete(int id)
        {
        }
    }
}
