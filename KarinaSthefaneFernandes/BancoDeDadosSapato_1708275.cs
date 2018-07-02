namespace KarinaSthefaneFernandes
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BancoDeDadosSapato_1708275 : DbContext
    {
        // Your context has been configured to use a 'BancoDeDadosSapato_1708275' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'KarinaSthefaneFernandes.BancoDeDadosSapato_1708275' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BancoDeDadosSapato_1708275' 
        // connection string in the application configuration file.
        public BancoDeDadosSapato_1708275()
            : base("name=BancoDeDadosSapato_1708275")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Sapato> Sapatos { get; set; }
        public virtual DbSet<PessoaFisica> PessoaFisicas { get; set; }
        public virtual DbSet<PessoaJuridica> PessoaJuridicas { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}