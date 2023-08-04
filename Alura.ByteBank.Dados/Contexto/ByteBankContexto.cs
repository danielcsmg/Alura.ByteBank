using Alura.ByteBank.Dados.Secure;
using Alura.ByteBank.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace Alura.ByteBank.Dados.Contexto
{
    public class ByteBankContexto:DbContext
    {
        public DbSet<ContaCorrente> ContaCorrentes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<UsuarioApp> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Use as configurações abaixo para usar seu banco de dados
            //var builder = new MySqlConnectionStringBuilder
            //{
            //    Server = "servidor aqui",
            //    Database = "nome do banco de dados",
            //    UserID = "usuario",
            //    Password = "senha",
            //    SslMode = MySqlSslMode.Required,
            //};
            //string stringconexao = builder.ConnectionString;

            var builder = new MySqlConnectionConfig();

            string stringconexao = builder.Connection;
            optionsBuilder.UseMySql(stringconexao, 
                                    ServerVersion.AutoDetect(stringconexao));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Identificador);
                entity.Property(e => e.Profissao).IsRequired();
                entity.Property(e => e.CPF).IsRequired();               
            });

            modelBuilder.Entity<Agencia>(entity =>
            {
                entity.ToTable("agencia");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Numero).IsRequired();
                entity.Property(e => e.Endereco);
                entity.Property(e => e.Identificador);
                entity.Property(e => e.Nome).IsRequired();
                
            });

            modelBuilder.Entity<ContaCorrente>(entity =>
            {
                entity.ToTable("conta_corrente");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Numero).IsRequired();
                entity.Property(e => e.Identificador);
                entity.Property(e => e.PixConta);
                entity.Property(e => e.Saldo);
                entity.HasOne(d => d.Cliente).WithMany(p => p.Contas);
                entity.HasOne(d => d.Agencia).WithMany(p => p.Contas);
            });

            modelBuilder.Entity<UsuarioApp>(entity =>
            {
                entity.ToTable("usuario");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserName).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Senha).IsRequired();                
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
