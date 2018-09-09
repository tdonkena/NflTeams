using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NflTeamsService.Controllers
{
    public class TeamsController : ApiController
    {
        // GET: api/Teams
        public IEnumerable<Division> Get()
        {
            return GetDivisions();
        }

        [Route("api/Division/{name}")]
        public Division GetDivisionByName(string name)
        {
            return GetDivisions().FirstOrDefault(x => x.Name == name);
        }

        [Route("api/DivisionByTeam/{name}")]
        public Division GetDivisionByTeam(string name)
        {
            return GetDivisions().FirstOrDefault(x => x.Teams.FirstOrDefault(y => y.Name == name) != null);
        }

        // GET: api/Teams/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Teams
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Teams/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Teams/5
        public void Delete(int id)
        {
        }

        private Division[] GetDivisions()
        {
            return JsonConvert.DeserializeObject<Division[]>(File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/Teams.json")));
        }
    }
}
