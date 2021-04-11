using Airliquide.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airliquide.Infrastructure.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(x => x.Idade)
                .HasColumnName("Idade")
                .HasColumnType("int")
                .IsRequired();

            builder.HasKey(x => x.Id);
        }
    }
}
