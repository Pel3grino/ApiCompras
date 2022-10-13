using ApiCompras.Domain.Entitie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCompras.Infra.Data.Mapper
{
    public class PuchaseMapper : IEntityTypeConfiguration<Puchase>
    {
        public void Configure(EntityTypeBuilder<Puchase> builder)
        {
            builder.ToTable("compras");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();
            builder.Property(x => x.PersonId)
                .HasColumnName("idpessoa");
            builder.Property(x => x.ProductId)
                .HasColumnName("idproduto");
            builder.Property(x => x.Code)
                .HasColumnName("numero");
            builder.Property(x => x.Date)
                .HasColumnName("datacompra");

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Puchases);
            builder.HasOne(x => x.Product)
                .WithMany(x => x.Puchases);
        }
    }
}
