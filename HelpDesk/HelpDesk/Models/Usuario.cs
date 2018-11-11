
namespace HelpDesk.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public partial class Usuario 
    {
        [System.ComponentModel.DataAnnotations.Key] // System informa que é a chave primaria, porque nao foi utiizada nomenclatura padrao no banco que seria ID
        public string ID_usuario { get; set; }
        public char Acesso { get; set; }        
        public string Senha { get; set; }

        private static Context db = new Context();

        public static string Login(String email, String senha)
        {
            Usuario usuario = null;
            try {
                Cliente cliente = null;
                
                cliente = db.Cliente.ToList().Where(c => c.Email_Contato == email).FirstOrDefault();

                if (cliente != null)
                {
                    usuario = db.Usuario.ToList().Where(u => u.ID_usuario == cliente.ID_usuario).FirstOrDefault();

                    if (usuario.Senha == senha)
                        return usuario.ID_usuario;
                }

                Funcionario funcionario = null;
                funcionario = db.Funcionario.ToList().Where(f => f.Email_Contato == email).FirstOrDefault();

                if (funcionario != null)
                {
                    usuario = db.Usuario.ToList().Where(u => u.ID_usuario == funcionario.ID_usuario).FirstOrDefault();
                    return usuario.ID_usuario;
                }

                return null;

            } catch (Exception ex)
            {
                return null;
            }
        }

    }
}