using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        List<string> fruits = new List<string>() { "apple", "banana", "mango" };

        public IEnumerable<string> Get()
        {
            return fruits;
        }

        // GET api/values/5
        public string Get(int id)
        {
            //if (id == 1) return "vivo";
            //else if (id == 2) return "samsung";
            //else if (id == 3) return "nokia";
            //else return "oppo";
            return fruits[id];

        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            fruits.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            fruits[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            fruits.RemoveAt(id);
        }
    }
}
