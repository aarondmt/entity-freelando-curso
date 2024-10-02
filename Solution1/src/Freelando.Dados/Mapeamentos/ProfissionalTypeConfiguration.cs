using Freelando.Modelo;
using Freelando.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelando.Dados.Mapeamentos;
internal class ProfissionalTypeConfiguration : IEntityTypeConfiguration<Profissional>
{
    public void Configure(EntityTypeBuilder<Profissional> builder)
    {
        builder.ToTable("TB_Profissionais");
        builder.Property(e => e.Id).HasColumnName("Id_Profissional");
        builder
            .HasMany(e => e.Especialidades)
            .WithMany(e => e.Profissionais)
            .UsingEntity<ProfissionalEspecialidade>(
                l => l.HasOne(e => e.Especialidade).WithMany(e => e.ProfissionaisEspecialidades).HasForeignKey(e => e.EspecialidadeId),
                r => r.HasOne(e => e.Profissional).WithMany(e => e.ProfissionaisEspecialidades).HasForeignKey(e => e.ProfissionalId)
            );
    }
}
