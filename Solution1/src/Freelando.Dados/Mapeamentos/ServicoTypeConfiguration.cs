using Freelando.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelando.Dados.Mapeamentos;
internal class ServicoTypeConfiguration : IEntityTypeConfiguration<Servico>
{
    public void Configure(EntityTypeBuilder<Servico> builder)
    {
        builder.ToTable("TB_Servivos");
        builder.Property(e => e.Id).HasColumnName("Id_Servico");
        builder.Property(e => e.Descricao).HasColumnName("DS_Projeto");
        builder
            .Property(e => e.Status)
            .HasConversion(
                fromObj => fromObj.ToString(),
                fromDb => (StatusServico)Enum.Parse(typeof(StatusServico), fromDb)
            );
        builder
            .HasOne(e => e.Contrato)
            .WithOne(e => e.Servico);
        builder
            .HasOne(e => e.Projeto)
            .WithMany(e => e.Servicos)
            .HasForeignKey(e => e.ProjetoId);
    }
}
