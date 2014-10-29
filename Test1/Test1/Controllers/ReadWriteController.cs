using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Test1.Controllers
{
    public class ReadWriteController : ApiController
    {
        // GET: api/ReadWrite
        public IEnumerable<int> Get()
        {
            return new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
        }

        // GET: api/ReadWrite/5
        public int Get(int id)
        {
            return id * 10;
        }

        // POST: api/ReadWrite
        public void Post([FromBody]int value)
        {
        }

        // PUT: api/ReadWrite/5
        public void Put(int id, [FromBody]int value)
        {
        }

        // DELETE: api/ReadWrite/5
        public void Delete(int id)
        {
        }
    }
}
