using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebMotors.Domain.Entities;

namespace WebMotors.Infra.Database.EntityConfiguration
{
    public class AnuncioWebMotorsEntityTypeConfiguration : IEntityTypeConfiguration<AnuncioWebmotors>
    {
        public void Configure(EntityTypeBuilder<AnuncioWebmotors> builder)
        {
            builder.ToTable("tb_AnuncioWebmotors");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Marca).HasMaxLength(45).IsRequired();
            builder.Property(a => a.Modelo).HasMaxLength(45).IsRequired();
            builder.Property(a => a.Versao).HasMaxLength(45).IsRequired();
            builder.Property(a => a.Ano).IsRequired();
            builder.Property(a => a.Quilometragem).IsRequired();
            builder.Property(a => a.Observacao).IsRequired();

        }
    }
}