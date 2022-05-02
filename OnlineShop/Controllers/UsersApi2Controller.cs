using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineShop.Controllers
{
    public class UsersApi2Controller : ApiController
    {
        // GET: api/UsersApi2
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UsersApi2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UsersApi2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UsersApi2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UsersApi2/5
        public void Delete(int id)
        {
        }
    }
}
