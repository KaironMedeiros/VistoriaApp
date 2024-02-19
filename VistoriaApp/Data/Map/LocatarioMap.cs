using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VistoriaApp.Models;

namespace VistoriaApp.Data.Map
{
    public class LocatarioMap : IEntityTypeConfiguration<LocatarioModel>
    {
        public void Configure(EntityTypeBuilder<LocatarioModel> builder)
        {
            builder.HasOne(x => x.Imovel).WithOne(x => x.Locatario).HasForeignKey<LocatarioModel>(x => x.ImovelId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
