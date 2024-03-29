﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Safety.Infra.Data.Context;

#nullable disable

namespace Safety.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Safety.Domain.Entities.AppLogger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Exception")
                        .HasColumnType("longtext");

                    b.Property<string>("Level")
                        .HasColumnType("longtext");

                    b.Property<string>("Message")
                        .HasColumnType("longtext");

                    b.Property<string>("Properties")
                        .HasColumnType("longtext");

                    b.Property<string>("Template")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("AppLoggers");
                });

            modelBuilder.Entity("Safety.Domain.Entities.Cargo", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    b.Property<string>("CadastradoPor")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("Cadastro")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Edicao")
                        .HasColumnType("DATETIME");

                    b.Property<string>("EditadoPor")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int?>("FeriasId")
                        .HasColumnType("INT");

                    b.Property<int?>("FuncionarioId")
                        .HasColumnType("INT");

                    b.Property<Guid>("GuidStamp")
                        .HasColumnType("CHAR(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<decimal>("VersionStamp")
                        .HasColumnType("DECIMAL");

                    b.HasKey("CargoId");

                    b.HasAlternateKey("GuidStamp");

                    b.HasIndex("FeriasId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("cargos", (string)null);
                });

            modelBuilder.Entity("Safety.Domain.Entities.Ferias", b =>
                {
                    b.Property<int>("FeriasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    b.Property<string>("AbonoPecuniario")
                        .IsRequired()
                        .HasColumnType("CHAR(1)");

                    b.Property<string>("CadastradoPor")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("Cadastro")
                        .HasColumnType("DATETIME");

                    b.Property<string>("DecimoTerceiro")
                        .IsRequired()
                        .HasColumnType("CHAR(1)");

                    b.Property<int>("Dependentes")
                        .HasColumnType("INT");

                    b.Property<int>("DiasFerias")
                        .HasColumnType("INT");

                    b.Property<DateTime>("Edicao")
                        .HasColumnType("DATETIME");

                    b.Property<string>("EditadoPor")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INT");

                    b.Property<Guid>("GuidStamp")
                        .HasColumnType("CHAR(36)");

                    b.Property<decimal>("INSS")
                        .HasColumnType("DECIMAL(20,2)");

                    b.Property<decimal>("IRRF")
                        .HasColumnType("DECIMAL(20,2)");

                    b.Property<int?>("LoginUsuarioId")
                        .HasColumnType("INT");

                    b.Property<decimal>("SalarioLiquido")
                        .HasColumnType("DECIMAL(20,2)");

                    b.Property<decimal>("ValorHoraExtra")
                        .HasColumnType("DECIMAL(20,2)");

                    b.Property<decimal>("VersionStamp")
                        .HasColumnType("DECIMAL(20,2)");

                    b.HasKey("FeriasId");

                    b.HasAlternateKey("GuidStamp");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("LoginUsuarioId");

                    b.ToTable("ferias", (string)null);
                });

            modelBuilder.Entity("Safety.Domain.Entities.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    b.Property<string>("Ativo")
                        .IsRequired()
                        .HasColumnType("CHAR(1)");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.Property<string>("CadastradoPor")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("Cadastro")
                        .HasColumnType("DATETIME");

                    b.Property<int>("CargoId")
                        .HasColumnType("INT");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("Edicao")
                        .HasColumnType("DATETIME");

                    b.Property<string>("EditadoPor")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("Educacao")
                        .HasColumnType("INT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<int>("FeriasId")
                        .HasColumnType("INT");

                    b.Property<int>("Genero")
                        .HasColumnType("INT");

                    b.Property<Guid>("GuidStamp")
                        .HasColumnType("CHAR(36)");

                    b.Property<int?>("LoginUsuarioId")
                        .HasColumnType("INT");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<int>("QuantidadeHoraMes")
                        .HasColumnType("INT");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("VARCHAR(45)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("DECIMAL(20,2)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<decimal>("ValorPorHora")
                        .HasColumnType("DECIMAL(20,2)");

                    b.Property<decimal>("VersionStamp")
                        .HasColumnType("DECIMAL");

                    b.HasKey("FuncionarioId");

                    b.HasAlternateKey("GuidStamp");

                    b.HasIndex("CargoId");

                    b.HasIndex("FeriasId");

                    b.HasIndex("LoginUsuarioId");

                    b.ToTable("funcionarios", (string)null);
                });

            modelBuilder.Entity("Safety.Domain.Entities.Login", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    b.Property<string>("CadastradoPor")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("Cadastro")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("Edicao")
                        .HasColumnType("DATETIME");

                    b.Property<string>("EditadoPor")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int?>("FeriasId")
                        .HasColumnType("INT");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INT");

                    b.Property<Guid>("GuidStamp")
                        .HasColumnType("CHAR(36)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<decimal>("VersionStamp")
                        .HasColumnType("DECIMAL");

                    b.HasKey("UsuarioId");

                    b.HasAlternateKey("GuidStamp");

                    b.HasIndex("FeriasId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("usuarios", (string)null);
                });

            modelBuilder.Entity("Safety.Domain.Entities.Cargo", b =>
                {
                    b.HasOne("Safety.Domain.Entities.Ferias", null)
                        .WithMany("Cargos")
                        .HasForeignKey("FeriasId");

                    b.HasOne("Safety.Domain.Entities.Funcionario", null)
                        .WithMany("Cargos")
                        .HasForeignKey("FuncionarioId");
                });

            modelBuilder.Entity("Safety.Domain.Entities.Ferias", b =>
                {
                    b.HasOne("Safety.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany("Feriass")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Safety.Domain.Entities.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginUsuarioId");

                    b.Navigation("Funcionario");

                    b.Navigation("Login");
                });

            modelBuilder.Entity("Safety.Domain.Entities.Funcionario", b =>
                {
                    b.HasOne("Safety.Domain.Entities.Cargo", "Cargo")
                        .WithMany("Funcionarios")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Safety.Domain.Entities.Ferias", "Ferias")
                        .WithMany("Funcionarios")
                        .HasForeignKey("FeriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Safety.Domain.Entities.Login", "Login")
                        .WithMany("Funcionarios")
                        .HasForeignKey("LoginUsuarioId");

                    b.Navigation("Cargo");

                    b.Navigation("Ferias");

                    b.Navigation("Login");
                });

            modelBuilder.Entity("Safety.Domain.Entities.Login", b =>
                {
                    b.HasOne("Safety.Domain.Entities.Ferias", null)
                        .WithMany("Logins")
                        .HasForeignKey("FeriasId");

                    b.HasOne("Safety.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany("Logins")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("Safety.Domain.Entities.Cargo", b =>
                {
                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("Safety.Domain.Entities.Ferias", b =>
                {
                    b.Navigation("Cargos");

                    b.Navigation("Funcionarios");

                    b.Navigation("Logins");
                });

            modelBuilder.Entity("Safety.Domain.Entities.Funcionario", b =>
                {
                    b.Navigation("Cargos");

                    b.Navigation("Feriass");

                    b.Navigation("Logins");
                });

            modelBuilder.Entity("Safety.Domain.Entities.Login", b =>
                {
                    b.Navigation("Funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}
