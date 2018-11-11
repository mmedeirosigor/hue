
namespace HelpDesk.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente 
    {

        [System.ComponentModel.DataAnnotations.Key]
        public string Cod_Cliente { get; set; }
        public string Nome { get; set; }
        public string Razao_Social { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Email_Contato { get; set; }
        public string End_Completo { get; set; }
        public string Telefone { get; set; }
        public char Stat_Cliente { get; set; }
        public string ID_usuario { get; set; }
    
        public virtual Usuario Usuario { get; set; }
       
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
