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
    public class AppLoggerMap : IEntityTypeConfiguration<AppLogger>
    {

        public void Configure(EntityTypeBuilder<AppLogger> builder)
        {
            //Table
            builder.ToTable("apploggers");

            //PK
            builder.HasKey(k => k.Id);

            //Property
            builder.Property(e => e.Id)
                .HasColumnType(MySQLDataTypes.INT());

            builder.Property(e => e.Message)
                .HasColumnType(MySQLDataTypes.TEXT());

            builder.Property(e => e.Template)
                .HasColumnType(MySQLDataTypes.TEXT());

            builder.Property(e => e.Level)
                .HasColumnType(MySQLDataTypes.VARCHAR(15));

            builder.Property(e => e.TimeStamp)
                .HasColumnType(MySQLDataTypes.VARCHAR(100));

            builder.Property(e => e.Exception)
                .HasColumnType(MySQLDataTypes.TEXT());

            builder.Property(e => e.Properties)
                .HasColumnType(MySQLDataTypes.TEXT());

            //Ignore
            builder.Ignore(i => i.ValidationResult);

        }
    }
}
