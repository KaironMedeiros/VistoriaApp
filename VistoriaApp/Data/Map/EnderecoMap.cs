using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VistoriaApp.Models;

namespace VistoriaApp.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoModel>
    {
        public void Configure(EntityTypeBuilder<EnderecoModel> builder) 
        {
            builder.HasOne(x => x.Imovel).WithOne(x => x.Endereco).HasForeignKey<EnderecoModel>(x => x.ImovelId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
