using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookServiceSample.Controllers
{
    public class Test1Controller : ApiController
    {
        // GET api/test1
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/test1/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/test1
        public void Post([FromBody]string value)
        {
        }

        // PUT api/test1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/test1/5
        public void Delete(int id)
        {
        }
    }
}
