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
            builder.HasKey(g => g.Id);

        }
    }
}