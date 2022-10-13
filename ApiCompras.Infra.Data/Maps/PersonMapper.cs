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
    public class PersonMapper : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("pessoa");
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();            
            builder.Property(x => x.Code)
                .HasColumnName("codigo")
                .UseSerialColumn();
            builder.Property(x => x.Name)
                .HasColumnName("nome");
            builder.Property(x => x.Document)
                .HasColumnName("documento");
            builder.Property(x => x.Phone)
                .HasColumnName("telefone");

            builder.HasMany(x => x.Puchases)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);
        }
    }
}
