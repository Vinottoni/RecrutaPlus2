using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Safety.Domain.Entities;
using Safety.Infra.Data.Mappings.DataTypes;

namespace Safety.Infra.Data.Mappings.MySQL
{
    public class CargoMap : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            //Table
            builder.ToTable("cargos");

            //PK
            builder.HasKey(k => k.CargoId);

            //Property
            builder.Property(e => e.CargoId)
                .HasColumnType(MySQLDataTypes.INT());

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.VARCHAR(255));

            builder.Property(e => e.Descricao)
                .HasColumnType(MySQLDataTypes.TEXT());

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
                .HasColumnType(MySQLDataTypes.DECIMAL());

            builder.Property(e => e.GuidStamp)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.CHAR(36));

            //Ignore
            builder.Ignore(i => i.ValidationResult);

            //AlternateKey
            builder.HasAlternateKey(a => a.GuidStamp);

            //Index
            //builder.HasIndex(d => d.Descricao);

        }
    }
}
