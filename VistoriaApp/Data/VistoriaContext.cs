using Microsoft.EntityFrameworkCore;
using VistoriaApp.Data.Map;
using VistoriaApp.Models;

namespace VistoriaApp.Data
{
    public class VistoriaContext : DbContext
    {
        public VistoriaContext(DbContextOptions<VistoriaContext> options) : base(options) { }

        public DbSet<AmbienteModel> Ambiente { get; set;}
        public DbSet<EnderecoModel> Endereco { get; set;}
        public DbSet<ImovelModel> Imovel { get; set;}
        public DbSet<LocatarioModel> Locatario { get; set;}
        public DbSet<VistoriadorModel> Vistoriador { get; set;}
        public DbSet<VistoriaModel> Vistoria { get; set;}
        public DbSet<UsuarioModel> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new LocatarioMap());
            modelBuilder.ApplyConfiguration(new VistoriaMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
