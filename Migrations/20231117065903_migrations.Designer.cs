﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Practica02Backend.Data;

#nullable disable

namespace Practica02Backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231117065903_migrations")]
    partial class migrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Practica02Backend.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Perfiles");
                });

            modelBuilder.Entity("Practica02Backend.Models.PerfilesAtributos.Nivel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("nivelNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Niveles");
                });

            modelBuilder.Entity("Practica02Backend.Models.PerfilesAtributos.PerfilFrameworks", b =>
                {
                    b.Property<int>("perfilId")
                        .HasColumnType("int");

                    b.Property<string>("framework")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("anio")
                        .HasColumnType("int");

                    b.Property<int>("nivelId")
                        .HasColumnType("int");

                    b.HasKey("perfilId", "framework");

                    b.ToTable("PerfilFrameworks");
                });

            modelBuilder.Entity("Practica02Backend.Models.PerfilesAtributos.PerfilPasatiempos", b =>
                {
                    b.Property<int>("perfilId")
                        .HasColumnType("int");

                    b.Property<string>("pasatiempo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("perfilId", "pasatiempo");

                    b.ToTable("Pasatiempos");
                });

            modelBuilder.Entity("Practica02Backend.Models.PerfilesAtributos.PerfilFrameworks", b =>
                {
                    b.HasOne("Practica02Backend.Models.Perfil", null)
                        .WithMany("frameworks")
                        .HasForeignKey("perfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Practica02Backend.Models.PerfilesAtributos.PerfilPasatiempos", b =>
                {
                    b.HasOne("Practica02Backend.Models.Perfil", null)
                        .WithMany("pasatiempos")
                        .HasForeignKey("perfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Practica02Backend.Models.Perfil", b =>
                {
                    b.Navigation("frameworks");

                    b.Navigation("pasatiempos");
                });
#pragma warning restore 612, 618
        }
    }
}
