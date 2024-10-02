using Freelando.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelando.Dados.Mapeamentos;
internal class CandidaturaTypeConfiguration : IEntityTypeConfiguration<Candidatura>
{
    public void Configure(EntityTypeBuilder<Candidatura> builder)
    {
        builder.ToTable("TB_Candidaturas");
        builder.Property(e => e.Id).HasColumnName("Id_Candidatura");
        builder.Property(e => e.ServicoId).HasColumnName("ID_Servico");
        builder.Property(e => e.ValorProposto).HasColumnName("Valor_Proposto");
        builder.Property(e => e.DescricaoProposta).HasColumnName("DS_Proposta");
        builder
            .Property(e => e.DuracaoProposta)
            .HasColumnName("Duracao_Proposta")
            .HasConversion(
                fromObj => fromObj.ToString(),
                fromDb => (DuracaoEmDias)Enum.Parse(typeof(DuracaoEmDias), fromDb)
                );
        builder
            .Property(e => e.Status)
            .HasConversion(
                fromObj => fromObj.ToString(), 
                fromDb => (StatusCandidatura)Enum.Parse(typeof(StatusCandidatura), fromDb)
                );
        builder
            .HasOne(e => e.Servico)
            .WithMany(e => e.Candidaturas)
            .HasForeignKey(e => e.ServicoId);
    }
}
