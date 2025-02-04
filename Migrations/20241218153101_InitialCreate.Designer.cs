﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticaSupervisada.Models;

#nullable disable

namespace PracticaSupervisada.Migrations
{
    [DbContext(typeof(PracticaPtallerContext))]
    [Migration("20241218153101_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PracticaSupervisada.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PracticaSupervisada.Models.Comentario", b =>
                {
                    b.Property<int>("ComentarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComentarioId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.Property<string>("Mensaje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComentarioId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("PracticaSupervisada.Models.OrdenesServicio", b =>
                {
                    b.Property<int>("OrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdenId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Entrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Inicio")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("OrdenId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("OrdenesServicio", (string)null);
                });

            modelBuilder.Entity("PracticaSupervisada.Models.Servicio", b =>
                {
                    b.Property<int>("ServicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServicioId"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("Servicios")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Servicio");

                    b.HasKey("ServicioId");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("PracticaSupervisada.Models.Vehiculo", b =>
                {
                    b.Property<int>("VehiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehiculoId"));

                    b.Property<int>("Año")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehiculoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("PracticaSupervisada.Models.Comentario", b =>
                {
                    b.HasOne("PracticaSupervisada.Models.Cliente", "Cliente")
                        .WithMany("Comentarios")
                        .HasForeignKey("ClienteId")
                        .IsRequired()
                        .HasConstraintName("FK2_Clientes");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("PracticaSupervisada.Models.OrdenesServicio", b =>
                {
                    b.HasOne("PracticaSupervisada.Models.Cliente", "Cliente")
                        .WithMany("OrdenesServicios")
                        .HasForeignKey("ClienteId")
                        .IsRequired()
                        .HasConstraintName("FK1_Clientes");

                    b.HasOne("PracticaSupervisada.Models.Vehiculo", "Vehiculo")
                        .WithMany("OrdenesServicios")
                        .HasForeignKey("VehiculoId")
                        .IsRequired()
                        .HasConstraintName("FK_Vehiculos");

                    b.Navigation("Cliente");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("PracticaSupervisada.Models.Vehiculo", b =>
                {
                    b.HasOne("PracticaSupervisada.Models.Cliente", "Cliente")
                        .WithMany("Vehiculos")
                        .HasForeignKey("ClienteId")
                        .IsRequired()
                        .HasConstraintName("FK_Clientes");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("PracticaSupervisada.Models.Cliente", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("OrdenesServicios");

                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("PracticaSupervisada.Models.Vehiculo", b =>
                {
                    b.Navigation("OrdenesServicios");
                });
#pragma warning restore 612, 618
        }
    }
}
