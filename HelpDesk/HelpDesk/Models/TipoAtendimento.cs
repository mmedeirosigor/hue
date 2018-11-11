namespace HelpDesk.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoAtendimento 
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Cod_Atendimento { get; set; }
        public string Descricao { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public string Prioridade { get; set; }
    }
}
