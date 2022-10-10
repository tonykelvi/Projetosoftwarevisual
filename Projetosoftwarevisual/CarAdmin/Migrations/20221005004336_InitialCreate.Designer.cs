﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trabalho;

#nullable disable

namespace caradm.Migrations
{
    [DbContext(typeof(BaseUsuarios))]
    [Migration("20221005004336_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Trabalho.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("carro")
                        .HasColumnType("TEXT");

                    b.Property<string>("cliente")
                        .HasColumnType("TEXT");

                    b.Property<string>("datadev")
                        .HasColumnType("TEXT");

                    b.Property<string>("dataempr")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<int?>("telefone")
                        .HasColumnType("INTEGER");

                    b.Property<string>("vendedor")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}