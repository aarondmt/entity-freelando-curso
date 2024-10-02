using Freelando.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelando.Dados.Mapeamentos;
internal class ProjetoEspecialidadeTypeConfiguration : IEntityTypeConfiguration<ProjetoEspecialidade>
{
    public void Configure(EntityTypeBuilder<ProjetoEspecialidade> builder)
    {
        builder.ToTable("TB_Especialidade_Projeto");
        builder.Property(e => e.ProjetoId).HasColumnName("Id_Projeto");
        builder.Property(e => e.EspecialidadeId).HasColumnName("Id_Especialidade");
    }
}
