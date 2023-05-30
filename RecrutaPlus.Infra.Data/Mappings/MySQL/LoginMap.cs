using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecrutaPlus.Domain.Entities;
using RecrutaPlus.Infra.Data.Mappings.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrutaPlus.Infra.Data.Mappings.MySQL
{
    public class LoginMap : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            //Table
            builder.ToTable("usuarios");

            //PK
            builder.HasKey(k => k.UsuarioId);

            //Property
            builder.Property(e => e.UsuarioId)
                .HasColumnName("usuarioId")
                .HasColumnType(MySQLDataTypes.INT());

            builder.Property(e => e.Username)
                .HasColumnName("username")
                .IsRequired()
                .HasColumnType(MySQLDataTypes.VARCHAR(255));

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasColumnType(MySQLDataTypes.VARCHAR(255));

            builder.Property(e => e.Cadastro)
                .HasColumnName("Cadastro")
                .HasColumnType(MySQLDataTypes.DATETIME());

            builder.Property(e => e.CadastradoPor)
                .HasColumnName("CadastradoPor")
                .HasColumnType(MySQLDataTypes.VARCHAR(50));

            builder.Property(e => e.Edicao)
                .HasColumnName("Edicao")
                .HasColumnType(MySQLDataTypes.DATETIME());

            builder.Property(e => e.EditadoPor)
                .HasColumnName("EditadoPor")
                .HasColumnType(MySQLDataTypes.VARCHAR(50));

            builder.Property(e => e.VersionStamp)
                .HasColumnName("timeStamp")
                .IsRequired()
                .HasColumnType(MySQLDataTypes.DECIMAL());

            builder.Property(e => e.GuidStamp)
                .HasColumnName("GuidStamp")
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
                .WithMany(p => p.Logins)
                .HasForeignKey(d => d.FuncionarioId);
        }
    }
}
