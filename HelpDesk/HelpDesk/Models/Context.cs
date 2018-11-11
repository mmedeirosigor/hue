namespace HelpDesk.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    /* Classe context é responsavel por fazer as interaçoes entre os modelos e o banco de dados
     * sendo necessario apenas mapealos utilizando o objeto DbSete. 
     * BdSete é umma classe que implementa o entity Framework
     */
    public class Context : DbContext
    {
        public DbSet<Chamados> Chamados { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<TipoAtendimento> TipoAtendimento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }


        public Context()
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
    }
}
