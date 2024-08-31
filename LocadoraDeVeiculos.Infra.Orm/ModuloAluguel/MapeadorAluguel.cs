using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloAluguel
{
    public class MapeadorAluguel : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.ToTable("TBAluguel");

            builder.Property(a => a.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(a => a.PrecoTotal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(a => a.DataSaida)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(a => a.DataRetornoPrevista)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.HasQueryFilter(a => !a.Concluido || a.DataRetorno < DateTime.Now);

            builder.Property(a => a.CondutorId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(a => a.GrupoVeiculosId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(a => a.VeiculoId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(a => a.PlanoCobrancaId)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(a => a.Veiculo)
                .WithMany()
                .HasForeignKey(a => a.VeiculoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => new { a.DataSaida, Retorno = a.DataRetorno });
        }
    }
}
