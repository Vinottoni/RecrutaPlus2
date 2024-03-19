using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safety.Infra.Data.Mappings.DataTypes
{
    public struct MySQLDataTypes
    {
        //Numeric Data Types
        public static string INT() => "INT";
        public static string TINYINT() => "TINYINT";
        public static string SMALLINT() => "SMALLINT";
        public static string MEDIUMINT() => "MEDIUMINT";
        public static string BIGINT() => "BIGINT";

        public static string FLOAT() => "FLOAT";
        public static string DOUBLE() => "DOUBLE";
        public static string DECIMAL() => "DECIMAL";
        public static string DECIMAL(int tamanho, int digito) => $"DECIMAL({tamanho},{digito})";

        public static string BIT() => "BIT";
        public static string BOOLEAN() => "BOOLEAN";

        //Date and Time Types
        public static string DATE() => "DATE";
        public static string DATETIME() => "DATETIME";
        public static string TIMESTAMP() => "TIMESTAMP";
        public static string TIME() => "TIME";

        //String Types
        public static string CHAR(int tamanho) => $"CHAR({tamanho})";
        public static string VARCHAR(int tamanho) => $"VARCHAR({tamanho})";

        public static string NCHAR(int tamanho) => $"NCHAR({tamanho})";
        public static string NVARCHAR(int tamanho) => $"NVARCHAR({tamanho})";

        public static string BINARY(int tamanho) => $"BINARY({tamanho})";
        public static string VARBINARY(int tamanho) => $"VARBINARY({tamanho})";

        public static string BLOB() => "BLOB";
        public static string TEXT() => "TEXT";
        public static string TINYBLOB() => "TINYBLOB";
        public static string TINYTEXT() => "TINYTEXT";
        public static string MEDIUMBLOB() => "MEDIUMBLOB";
        public static string MEDIUMTEXT() => "MEDIUMTEXT";
        public static string LONGBLOB() => "LONGBLOB";
        public static string LONGTEXT() => "LONGTEXT";
        public static string ENUM() => "ENUM";
        public static string SET() => "SET";

        //Spatial Data Types
        public static string GEOMETRY() => "GEOMETRY";
        public static string POINT() => "POINT";
        public static string LINESTRING() => "LINESTRING";
        public static string POLYGON() => "POLYGON";
        public static string GEOMETRYCOLLECTION() => "GEOMETRYCOLLECTION";
        public static string MULTILINESTRING() => "MULTILINESTRING";
        public static string MULTIPOINT() => "MULTIPOINT";
        public static string MULTIPOLYGON() => "MULTIPOLYGON";

        //JSON Data Types
        public static string JSON() => "JSON";
    }
}
