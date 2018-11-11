using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    public class TipoAtendimentoController : ApiController
    {
        public static Context db = new Context();
        // GET api/values
        public IEnumerable<TipoAtendimento> Get()
        {
            return db.TipoAtendimento.ToList();
        }
        // GET api/values/5
        public TipoAtendimento Get(string id)
        {
            return db.TipoAtendimento.ToList().Where(tipoAtendimento => tipoAtendimento.Cod_Atendimento == id).First();
        }
        // POST api/values
        public TipoAtendimento Post([FromBody]TipoAtendimento value)
        {
            if (value == null)
                return null;

            var tipo = db.TipoAtendimento.ToList();
            value.Cod_Atendimento = (tipo.Count() + 1).ToString();
            value.Data = DateTime.Now;
            db.TipoAtendimento.Add(value);
            db.SaveChanges();
            
            return value;
        }
        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]TipoAtendimento value)
        {
            if (value == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            db.TipoAtendimento.Add(value);
            db.Entry(value).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        // DELETE api/values/5
        public HttpResponseMessage Delete(string id)
        {
            var chamado = db.TipoAtendimento.ToList().Where(c => c.Cod_Atendimento == id).First();
            db.TipoAtendimento.Remove(chamado);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}
