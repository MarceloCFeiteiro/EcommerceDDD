using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Configuration
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<CompraUsuario> CompraUsuarios { get; set; }

        public DbSet<ApplicationUser> Usuarios { get; set; }

        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConnectionConfigure());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        private string GetStringConnectionConfigure()
        {
            string strConn = "Server=tcp:servidorestudonetcore.database.windows.net,1433;Initial Catalog=devestudonetcore;Persist Security Info=False;User ID=Marcelo_Feiteiro;Password=Aioli@1002;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            return strConn;
        }
    }
}