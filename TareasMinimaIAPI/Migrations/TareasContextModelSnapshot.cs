﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TareasMinimaIAPI;

#nullable disable

namespace TareasMinimaIAPI.Migrations
{
    [DbContext(typeof(TareasContext))]
    partial class TareasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TareasMinimaIAPI.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("dee61528-3227-436a-b19a-280e06686c85"),
                            Descripcion = "Actividades de Trabajo y/o escuela",
                            Nombre = "Actividades Pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("dee61528-3227-436a-b19a-280e06686c02"),
                            Descripcion = "Actividades de Carácter Personal",
                            Nombre = "Actividades Personales",
                            Peso = 50
                        });
                });

            modelBuilder.Entity("TareasMinimaIAPI.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("a50f2609-7f0c-46cc-8352-d2b40065a9f0"),
                            CategoriaId = new Guid("dee61528-3227-436a-b19a-280e06686c85"),
                            Descripcion = "Pagar servicios de Agua y Luz",
                            FechaCreacion = new DateTime(2024, 6, 12, 17, 52, 15, 111, DateTimeKind.Local).AddTicks(6455),
                            PrioridadTarea = 1,
                            Titulo = "Pago de servicios"
                        },
                        new
                        {
                            TareaId = new Guid("a50f2609-7f0c-46cc-8352-d2b40065a910"),
                            CategoriaId = new Guid("dee61528-3227-436a-b19a-280e06686c02"),
                            Descripcion = "Terminar de ver en Neflix",
                            FechaCreacion = new DateTime(2024, 6, 12, 17, 52, 15, 111, DateTimeKind.Local).AddTicks(6473),
                            PrioridadTarea = 0,
                            Titulo = "Terminar de ver Película Eso"
                        });
                });

            modelBuilder.Entity("TareasMinimaIAPI.Models.Tarea", b =>
                {
                    b.HasOne("TareasMinimaIAPI.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("TareasMinimaIAPI.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
