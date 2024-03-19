using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Safety.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AppLoggers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Template = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Level = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeStamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Exception = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Properties = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLoggers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cargos",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CadastradoPor = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Edicao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    EditadoPor = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VersionStamp = table.Column<decimal>(type: "DECIMAL(20,0)", nullable: false),
                    GuidStamp = table.Column<Guid>(type: "CHAR(36)", nullable: false, collation: "ascii_general_ci"),
                    FeriasId = table.Column<int>(type: "INT", nullable: true),
                    FuncionarioId = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargos", x => x.CargoId);
                    table.UniqueConstraint("AK_cargos_GuidStamp", x => x.GuidStamp);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ferias",
                columns: table => new
                {
                    FeriasId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FuncionarioId = table.Column<int>(type: "INT", nullable: false),
                    ValorHoraExtra = table.Column<decimal>(type: "DECIMAL(20,2)", nullable: false),
                    Dependentes = table.Column<int>(type: "INT", nullable: false),
                    DiasFerias = table.Column<int>(type: "INT", nullable: false),
                    AbonoPecuniario = table.Column<string>(type: "CHAR(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DecimoTerceiro = table.Column<string>(type: "CHAR(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SalarioLiquido = table.Column<decimal>(type: "DECIMAL(20,2)", nullable: false),
                    INSS = table.Column<decimal>(type: "DECIMAL(20,2)", nullable: false),
                    IRRF = table.Column<decimal>(type: "DECIMAL(20,2)", nullable: false),
                    Cadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CadastradoPor = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Edicao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    EditadoPor = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VersionStamp = table.Column<decimal>(type: "DECIMAL(20,2)", nullable: false),
                    GuidStamp = table.Column<Guid>(type: "CHAR(36)", nullable: false, collation: "ascii_general_ci"),
                    LoginUsuarioId = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ferias", x => x.FeriasId);
                    table.UniqueConstraint("AK_ferias_GuidStamp", x => x.GuidStamp);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CargoId = table.Column<int>(type: "INT", nullable: false),
                    FeriasId = table.Column<int>(type: "INT", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RG = table.Column<string>(type: "VARCHAR(45)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF = table.Column<string>(type: "VARCHAR(11)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateOnly>(type: "DATE", nullable: false),
                    Genero = table.Column<int>(type: "INT", nullable: false),
                    CEP = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Endereco = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Educacao = table.Column<int>(type: "INT", nullable: false),
                    Ativo = table.Column<string>(type: "CHAR(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Salario = table.Column<decimal>(type: "DECIMAL(20,2)", nullable: false),
                    Cadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CadastradoPor = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Edicao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    EditadoPor = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VersionStamp = table.Column<decimal>(type: "DECIMAL(20,0)", nullable: false),
                    GuidStamp = table.Column<Guid>(type: "CHAR(36)", nullable: false, collation: "ascii_general_ci"),
                    LoginUsuarioId = table.Column<int>(type: "INT", nullable: true),
                    ValorPorHora = table.Column<decimal>(type: "DECIMAL(20,2)", nullable: false),
                    QuantidadeHoraMes = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.FuncionarioId);
                    table.UniqueConstraint("AK_funcionarios_GuidStamp", x => x.GuidStamp);
                    table.ForeignKey(
                        name: "FK_funcionarios_cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "cargos",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_funcionarios_ferias_FeriasId",
                        column: x => x.FeriasId,
                        principalTable: "ferias",
                        principalColumn: "FeriasId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FuncionarioId = table.Column<int>(type: "INT", nullable: false),
                    Username = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CadastradoPor = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Edicao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    EditadoPor = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VersionStamp = table.Column<decimal>(type: "DECIMAL(20,0)", nullable: false),
                    GuidStamp = table.Column<Guid>(type: "CHAR(36)", nullable: false, collation: "ascii_general_ci"),
                    FeriasId = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.UsuarioId);
                    table.UniqueConstraint("AK_usuarios_GuidStamp", x => x.GuidStamp);
                    table.ForeignKey(
                        name: "FK_usuarios_ferias_FeriasId",
                        column: x => x.FeriasId,
                        principalTable: "ferias",
                        principalColumn: "FeriasId");
                    table.ForeignKey(
                        name: "FK_usuarios_funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_cargos_FeriasId",
                table: "cargos",
                column: "FeriasId");

            migrationBuilder.CreateIndex(
                name: "IX_cargos_FuncionarioId",
                table: "cargos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ferias_FuncionarioId",
                table: "ferias",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ferias_LoginUsuarioId",
                table: "ferias",
                column: "LoginUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_CargoId",
                table: "funcionarios",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_FeriasId",
                table: "funcionarios",
                column: "FeriasId");

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_LoginUsuarioId",
                table: "funcionarios",
                column: "LoginUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_FeriasId",
                table: "usuarios",
                column: "FeriasId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_FuncionarioId",
                table: "usuarios",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_cargos_ferias_FeriasId",
                table: "cargos",
                column: "FeriasId",
                principalTable: "ferias",
                principalColumn: "FeriasId");

            migrationBuilder.AddForeignKey(
                name: "FK_cargos_funcionarios_FuncionarioId",
                table: "cargos",
                column: "FuncionarioId",
                principalTable: "funcionarios",
                principalColumn: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ferias_funcionarios_FuncionarioId",
                table: "ferias",
                column: "FuncionarioId",
                principalTable: "funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ferias_usuarios_LoginUsuarioId",
                table: "ferias",
                column: "LoginUsuarioId",
                principalTable: "usuarios",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_funcionarios_usuarios_LoginUsuarioId",
                table: "funcionarios",
                column: "LoginUsuarioId",
                principalTable: "usuarios",
                principalColumn: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cargos_ferias_FeriasId",
                table: "cargos");

            migrationBuilder.DropForeignKey(
                name: "FK_funcionarios_ferias_FeriasId",
                table: "funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_ferias_FeriasId",
                table: "usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_cargos_funcionarios_FuncionarioId",
                table: "cargos");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_funcionarios_FuncionarioId",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "AppLoggers");

            migrationBuilder.DropTable(
                name: "ferias");

            migrationBuilder.DropTable(
                name: "funcionarios");

            migrationBuilder.DropTable(
                name: "cargos");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
