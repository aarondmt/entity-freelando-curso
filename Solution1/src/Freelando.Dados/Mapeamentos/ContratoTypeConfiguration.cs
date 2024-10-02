using Freelando.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Freelando.Dados.Mapeamentos;
internal class ContratoTypeConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> builder)
    {
        builder.ToTable("TB_Contratos");
        builder.Property(e => e.Id).HasColumnName("Id_Contrato");
        builder.Property(e => e.ServicoId).HasColumnName("ID_Servico");
        builder.Property(e => e.ProfissionalId).HasColumnName("ID_Profissional");
        builder.OwnsOne(e => e.Vigencia, vigencia =>
        {
            vigencia.Property(e => e.DataInicio).HasColumnName("Data_Inicio");
            vigencia.Property(e => e.DataEncerramento).HasColumnName("Data_Encerramento");
        });
        builder
            .HasOne(e => e.Servico)
            .WithOne(e => e.Contrato)
            .HasForeignKey<Contrato>(e => e.Id);
        builder
            .HasOne(e => e.Profissional)
            .WithMany(e => e.Contratos)
            .HasForeignKey(e => e.ProfissionalId);
    }
}
