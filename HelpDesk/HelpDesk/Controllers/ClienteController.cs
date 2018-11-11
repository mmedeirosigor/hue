using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    public class ClienteController : ApiController
    {
        public static Context db = new Context();
        
        // GET api/values
        public IEnumerable<Cliente> Get()
        {
            
            return db.Cliente.ToList();
        }
        // GET api/values/5
        public Cliente Get(string id)
        {
            return db.Cliente.ToList().Where(Cliente => Cliente.Cod_Cliente == id).First();
        }
        // POST api/values
        public HttpResponseMessage Post([FromBody]Cliente value)
        {
            if (value == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.Cliente.Add(value);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Cliente value)
        {
            if (value == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            db.Cliente.Add(value);
            db.Entry(value).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        // DELETE api/values/5
        public HttpResponseMessage Delete(string id)
        {
            var chamado = db.Cliente.ToList().Where(c => c.Cod_Cliente == id).First();
            db.Cliente.Remove(chamado);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}
