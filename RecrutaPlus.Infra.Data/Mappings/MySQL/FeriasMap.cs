using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Safety.Domain.Entities;
using Safety.Infra.Data.Mappings.DataTypes;

namespace Safety.Infra.Data.Mappings.MySQL
{
    public class FeriasMap : IEntityTypeConfiguration<Ferias>
    {
        private readonly BoolToStringConverter _boolToStringConverter = new BoolToStringConverter("N", "S");

        public void Configure(EntityTypeBuilder<Ferias> builder)
        {
            //Table
            builder.ToTable("ferias");

            //PK
            builder.HasKey(k => k.FeriasId); //ajusta aqui tambem

            //Property
            builder.Property(e => e.FeriasId)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.INT());

            builder.Property(e => e.ValorHoraExtra)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.DECIMAL(20, 2));

            builder.Property(e => e.Dependentes)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.INT());

            builder.Property(e => e.DiasFerias)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.INT());

            builder.Property(e => e.AbonoPecuniario)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.CHAR(1));

            builder.Property(e => e.DecimoTerceiro)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.CHAR(1));

            builder.Property(e => e.Cadastro)
                .HasColumnType(MySQLDataTypes.DATETIME());

            builder.Property(e => e.CadastradoPor)
                .HasColumnType(MySQLDataTypes.VARCHAR(50));

            builder.Property(e => e.Edicao)
                .HasColumnType(MySQLDataTypes.DATETIME());

            builder.Property(e => e.EditadoPor)
                .HasColumnType(MySQLDataTypes.VARCHAR(50));

            builder.Property(e => e.VersionStamp)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.DECIMAL(20, 2));

            builder.Property(e => e.GuidStamp)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.CHAR(36));

            //Ignore
            builder.Ignore(i => i.ValidationResult);

            //AlternateKey
            builder.HasAlternateKey(a => a.GuidStamp);

            //Index
            builder.HasIndex(d => d.FuncionarioId);

            //FK
            builder.HasOne(d => d.Funcionario)
                .WithMany(p => p.Feriass)
                .HasForeignKey(d => d.FuncionarioId);
        }
    }
}
