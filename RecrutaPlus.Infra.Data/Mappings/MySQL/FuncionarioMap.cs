using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecrutaPlus.Domain.Entities;
using RecrutaPlus.Infra.Data.Mappings.DataTypes;

namespace RecrutaPlus.Infra.Data.Mappings.MySQL
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        private readonly BoolToStringConverter _boolToStringConverter = new BoolToStringConverter("N", "S");

        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            //Table
            builder.ToTable("funcionarios");

            //PK
            builder.HasKey(k => k.FuncionarioId); //ajusta aqui tambem

            //Property
            builder.Property(e => e.FuncionarioId)
                .HasColumnType(MySQLDataTypes.INT());

            builder.Property(e => e.CPF)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.VARCHAR(11));

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.VARCHAR(255));

            builder.Property(e => e.Telefone)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.VARCHAR(20));

            builder.Property(e => e.DataNascimento)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.DATE());

            builder.Property(e => e.Endereco)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.VARCHAR(255));

            builder.Property(e => e.RG)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.VARCHAR(45));

            builder.Property(e => e.Genero)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.INT());

            builder.Property(e => e.CEP)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.VARCHAR(20));

            builder.Property(e => e.Educacao)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.INT());

            builder.Property(e => e.Ativo)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.BOOLEAN())
                .HasConversion(_boolToStringConverter);

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.VARCHAR(255));

            builder.Property(e => e.Salario)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.DECIMAL(20,2));

            builder.Property(e => e.ValorPorHora)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.DECIMAL(20, 2));

            builder.Property(e => e.QuantidadeHoraMes)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.INT());

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType(MySQLDataTypes.VARCHAR(255));

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
            builder.HasIndex(d => d.CargoId);

            //FK
            builder.HasOne(d => d.Cargo)
                .WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.CargoId);
        }
    }
}
