using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    public class UsuarioController : ApiController
    {
        public static Context db = new Context();
        // GET api/values
        public IEnumerable<Usuario> Get()

        {

            var t = db.Usuario.ToList(); ;

            return t;
        }
        // GET api/values/5
        public Usuario Get(string id)
        {
            
            return db.Usuario.ToList().Where(usuario => usuario.ID_usuario == id).First();
        }
        // POST api/values
        public HttpResponseMessage Post([FromBody]Usuario value)
        {
            if (value == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.Usuario.Add(value);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Usuario value)
        {
            if (value == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            db.Usuario.Add(value);
            db.Entry(value).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        // DELETE api/values/5
        public HttpResponseMessage Delete(string id)
        {
            var  usuario = db.Usuario.ToList().Where(u => u.ID_usuario == id).First();
            db.Usuario.Remove(usuario);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);

        }

    }
}
