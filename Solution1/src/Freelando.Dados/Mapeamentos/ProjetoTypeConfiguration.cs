using Freelando.Modelo;
using Freelando.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelando.Dados.Mapeamentos;
internal class ProjetoTypeConfiguration : IEntityTypeConfiguration<Projeto>
{
    public void Configure(EntityTypeBuilder<Projeto> builder)
    {
        builder.ToTable("TB_Projetos");
        builder.HasKey(t => t.Id).HasName("PK_Projeto");
        builder.Property(e => e.Id).HasColumnName("Id_Projeto");
        builder.Property(e => e.Descricao).HasColumnType("nvarchar(200)").HasColumnName("DS_Projeto");
        builder
            .Property(e => e.Status)
            .HasConversion(fromObj => fromObj.ToString(), fromDb => (StatusProjeto)Enum.Parse(typeof(StatusProjeto), fromDb));
        builder
            .HasOne(e => e.Cliente)
            .WithMany(c => c.Projetos)
            .HasForeignKey("Id_Cliente");
        builder
            .HasMany(e => e.Especialidades)
            .WithMany(e => e.Projetos)
            .UsingEntity<ProjetoEspecialidade>(
                l => l
                    .HasOne(e => e.Especialidade)
                    .WithMany(e => e.ProjetosEspecialidades)
                    .HasForeignKey(e => e.EspecialidadeId),
                r => r
                    .HasOne(e => e.Projeto)
                    .WithMany(e => e.ProjetosEspecialidades)
                    .HasForeignKey(e => e.ProjetoId)
            );
    }
}
