using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    public class FuncionarioController : ApiController
    {
        public static Context db = new Context();
        // GET api/values
        public IEnumerable<Funcionario> Get()
        {
            return db.Funcionario.ToList();
        }
        // GET api/values/5
        public Funcionario Get(string id)
        {
            return db.Funcionario.ToList().Where(funcionario => funcionario.Cod_Funcionario == id).First();
        }
        // POST api/values
        public HttpResponseMessage Post([FromBody]Funcionario value)
        {
            if (value == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            db.Funcionario.Add(value);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Funcionario value)
        {
            if (value == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            db.Funcionario.Add(value);
            db.Entry(value).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        // DELETE api/values/5
        public HttpResponseMessage Delete(string id)
        {
            var chamado = db.Funcionario.ToList().Where(c => c.Cod_Funcionario == id).First();
            db.Funcionario.Remove(chamado);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}
