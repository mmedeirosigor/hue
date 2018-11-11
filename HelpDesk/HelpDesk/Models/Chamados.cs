namespace HelpDesk.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

  
    public partial class Chamados 
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Cod_Chamado { get; set; }
       
        public string Desc_Chamado { get; set; }
        
        public Nullable<System.DateTime> Data { get; set; }
        
        public string Cod_Produto { get; set; }
      
        public string Cod_Atendimento { get; set; }
        
        public virtual TipoAtendimento TipoAtendimento { get; set; }
       
        public virtual Produto Produto { get; set; }

        private static Context db = new Context();


        public List<Chamados> GetListByUsuer(string cod)
            
        {
            try
            {
                List<Chamados> list = new List<Chamados>();

                List<Chamados> chamados = db.Chamados.ToList();

                foreach (Chamados c in chamados)
                {
                    c.Produto = db.Produto.ToList().Where(p => p.Cod_Produto == c.Cod_Produto).ToList<Produto>().FirstOrDefault();
                    c.TipoAtendimento =  db.TipoAtendimento.ToList().Where(tipoAtendimento => tipoAtendimento.Cod_Atendimento == c.Cod_Atendimento).First();
                    if (c.Produto.Cod_Cliente == cod)
                        list.Add(c);
                }


                return list.OrderByDescending(c => c.Data).ToList(); ;
            }
            catch
            {
                return null;
            }

        }

        public List<Chamados> GetList()

        {
            
            List<Chamados> chamados = db.Chamados.ToList().OrderByDescending(c => c.Data).ToList();

            return chamados;

        }
    }
}
