using MacroTrackr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MacroTrackr.Controllers
{
    public class UserPrefController : ApiController
    {
        
        // GET: api/UserPref
        public IEnumerable<string> Get()
        {
            //UserPreference.Equals()
            return new string[] { "value1", "value2", "value3" };
        }

        // GET: api/UserPref/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserPref
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserPref/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserPref/5
        public void Delete(int id)
        {
        }
    }
}
