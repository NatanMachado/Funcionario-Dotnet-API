﻿// <auto-generated />
using System;
using FuncionarioApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Funcionario_API.Data.Migrations
{
    [DbContext(typeof(DBFuncionarioContext))]
    partial class DBFuncionarioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FuncionarioApi.Models.Entity.Funcionario", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<DateTime?>("Admissao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("admissao");

                    b.Property<string>("Documento")
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)")
                        .HasColumnName("documento");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.Property<bool>("PlanoDental")
                        .HasColumnType("boolean")
                        .HasColumnName("plano_dentral");

                    b.Property<bool>("PlanoSaude")
                        .HasColumnType("boolean")
                        .HasColumnName("plano_saude");

                    b.Property<decimal>("SalarioBruto")
                        .HasColumnType("numeric")
                        .HasColumnName("salario_bruto");

                    b.Property<string>("Setor")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("setor");

                    b.Property<string>("Sobrenome")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("sobrenome");

                    b.Property<bool>("ValeTransporte")
                        .HasColumnType("boolean")
                        .HasColumnName("vale_transporte");

                    b.HasKey("Id");

                    b.ToTable("Funcionario");
                });
#pragma warning restore 612, 618
        }
    }
}
