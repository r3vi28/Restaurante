﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurante.Server.Context;

#nullable disable

namespace Restaurante.Server.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230218060322_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Restaurante.Server.Models.AsignacionMesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Hora")
                        .HasColumnType("datetime2");

                    b.Property<int>("MesaId")
                        .HasColumnType("int");

                    b.Property<int>("MesaStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MesaId");

                    b.ToTable("AsignacionMesas");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CajeroId")
                        .HasColumnType("int");

                    b.Property<int>("CajeroNombreId")
                        .HasColumnType("int");

                    b.Property<float>("CostoTotal")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MetodoPagoId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CajeroNombreId");

                    b.HasIndex("MetodoPagoId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Tamaño")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("Restaurante.Server.Models.MesaStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AsignacionMesaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AsignacionMesaId");

                    b.ToTable("MesaStatuses");
                });

            modelBuilder.Entity("Restaurante.Server.Models.MetodoPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MetodoPagos");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DeliveryTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PedidoStatusId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PedidoStatusId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Restaurante.Server.Models.PedidoStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PedidoStatuses");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FacturaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("int");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.Property<int?>("ReporteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacturaId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ReporteId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Reporte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductosMasVendidosId")
                        .HasColumnType("int");

                    b.Property<float>("VentasTotales")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Reportes");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Reservacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Hora")
                        .HasColumnType("time");

                    b.Property<int>("MesaId")
                        .HasColumnType("int");

                    b.Property<int>("NumeroPersonas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("MesaId");

                    b.ToTable("Reservaciones");
                });

            modelBuilder.Entity("Restaurante.Server.Models.RolUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PermisoParaCrear")
                        .HasColumnType("bit");

                    b.Property<bool>("PermisoParaEditar")
                        .HasColumnType("bit");

                    b.Property<bool>("PermisoParaEliminar")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("RolUsuarios");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioRolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioRolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Restaurante.Server.Models.AsignacionMesa", b =>
                {
                    b.HasOne("Restaurante.Server.Models.Mesa", "Mesa")
                        .WithMany()
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Factura", b =>
                {
                    b.HasOne("Restaurante.Server.Models.Usuario", "CajeroNombre")
                        .WithMany()
                        .HasForeignKey("CajeroNombreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurante.Server.Models.MetodoPago", "MetodoPago")
                        .WithMany()
                        .HasForeignKey("MetodoPagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CajeroNombre");

                    b.Navigation("MetodoPago");
                });

            modelBuilder.Entity("Restaurante.Server.Models.MesaStatus", b =>
                {
                    b.HasOne("Restaurante.Server.Models.AsignacionMesa", null)
                        .WithMany("MesaStatus")
                        .HasForeignKey("AsignacionMesaId");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Pedido", b =>
                {
                    b.HasOne("Restaurante.Server.Models.PedidoStatus", "Status")
                        .WithMany()
                        .HasForeignKey("PedidoStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Producto", b =>
                {
                    b.HasOne("Restaurante.Server.Models.Factura", null)
                        .WithMany("Productos")
                        .HasForeignKey("FacturaId");

                    b.HasOne("Restaurante.Server.Models.Pedido", null)
                        .WithMany("Productos")
                        .HasForeignKey("PedidoId");

                    b.HasOne("Restaurante.Server.Models.Reporte", null)
                        .WithMany("ProductosMasVendidos")
                        .HasForeignKey("ReporteId");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Reservacion", b =>
                {
                    b.HasOne("Restaurante.Server.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restaurante.Server.Models.Mesa", "MesaElegida")
                        .WithMany()
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("MesaElegida");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Usuario", b =>
                {
                    b.HasOne("Restaurante.Server.Models.RolUsuario", "UsuarioRol")
                        .WithMany()
                        .HasForeignKey("UsuarioRolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioRol");
                });

            modelBuilder.Entity("Restaurante.Server.Models.AsignacionMesa", b =>
                {
                    b.Navigation("MesaStatus");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Factura", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Pedido", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Restaurante.Server.Models.Reporte", b =>
                {
                    b.Navigation("ProductosMasVendidos");
                });
#pragma warning restore 612, 618
        }
    }
}
