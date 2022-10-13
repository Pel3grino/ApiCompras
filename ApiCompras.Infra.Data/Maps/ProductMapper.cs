using ApiCompras.Domain.Entitie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Infra.Data.Maps
{
    public class ProductMapper : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("produto")
                .HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();
            builder.Property(x => x.Code)
                .HasColumnName("codigo")
                .UseSerialColumn();
            builder.Property(x => x.Name)
                .HasColumnName("nome");
            builder.Property(x => x.CodErp)
                .HasColumnName("codigoerp");
            builder.Property(x => x.Price)
                .HasColumnName("preco");

            builder.HasMany(x => x.Puchases)
                .WithOne(p => p.Product)
                .HasForeignKey(x => x.ProductId);
               
                
        }
    }
}
