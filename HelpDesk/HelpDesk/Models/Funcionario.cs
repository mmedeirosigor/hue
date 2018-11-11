namespace HelpDesk.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Funcionario 
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Cod_Funcionario { get; set; }
        public string Nome_Completo { get; set; }
        public string Nome_Tratamento { get; set; }
        public string CPF { get; set; }
        public string End_Completo { get; set; }
        public string Telefone { get; set; }
        public string Email_Contato { get; set; }
        public char Stat_Funcionario { get; set; }
        public string ID_usuario { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
