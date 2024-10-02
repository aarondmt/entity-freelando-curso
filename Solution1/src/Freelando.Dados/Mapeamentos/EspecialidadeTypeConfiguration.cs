using Freelando.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelando.Dados.Mapeamentos;

internal class EspecialidadeTypeConfiguration : IEntityTypeConfiguration<Especialidade>
{
    public void Configure(EntityTypeBuilder<Especialidade> builder)
    {
        builder.ToTable("TB_Especialidades");
        builder.Property(e => e.Id).HasColumnName("Id_Especialidade");
        builder.Property(e => e.Descricao).HasColumnName("DS_Especialidade");
    }
}
