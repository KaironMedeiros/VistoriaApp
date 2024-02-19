using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VistoriaApp.Models;

namespace VistoriaApp.Data.Map
{
    public class VistoriaMap : IEntityTypeConfiguration<VistoriaModel>
    {
        public void Configure(EntityTypeBuilder<VistoriaModel> builder)
        {
            builder.HasOne(x => x.Vistoriador).WithMany(x => x.Vistoria).HasForeignKey(x => x.VistoriadorId);
            builder.HasOne(x => x.Imovel).WithOne(x => x.Vistoria).HasForeignKey<VistoriaModel>(x => x.ImovelId);
        }
    }
}
