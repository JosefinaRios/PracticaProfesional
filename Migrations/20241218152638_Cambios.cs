using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaSupervisada.Migrations
{
    /// <inheritdoc />
    public partial class Cambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Clientes",
            //    columns: table => new
            //    {
            //        ClienteId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        Apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        Direccion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Clientes", x => x.ClienteId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Servicios",
            //    columns: table => new
            //    {
            //        ServicioId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Servicio = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Precio = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Servicios", x => x.ServicioId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Comentarios",
            //    columns: table => new
            //    {
            //        ComentarioId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Fecha = table.Column<DateOnly>(type: "date", nullable: false),
            //        ClienteId = table.Column<int>(type: "int", nullable: false),
            //        Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Comentarios", x => x.ComentarioId);
            //        table.ForeignKey(
            //            name: "FK2_Clientes",
            //            column: x => x.ClienteId,
            //            principalTable: "Clientes",
            //            principalColumn: "ClienteId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Vehiculos",
            //    columns: table => new
            //    {
            //        VehiculoId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Marca = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Año = table.Column<int>(type: "int", nullable: false),
            //        Color = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
            //        ClienteId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Vehiculos", x => x.VehiculoId);
            //        table.ForeignKey(
            //            name: "FK_Clientes",
            //            column: x => x.ClienteId,
            //            principalTable: "Clientes",
            //            principalColumn: "ClienteId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrdenesServicio",
            //    columns: table => new
            //    {
            //        OrdenId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Inicio = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        Entrega = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        Total = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
            //        ClienteId = table.Column<int>(type: "int", nullable: false),
            //        VehiculoId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrdenesServicio", x => x.OrdenId);
            //        table.ForeignKey(
            //            name: "FK1_Clientes",
            //            column: x => x.ClienteId,
            //            principalTable: "Clientes",
            //            principalColumn: "ClienteId");
            //        table.ForeignKey(
            //            name: "FK_Vehiculos",
            //            column: x => x.VehiculoId,
            //            principalTable: "Vehiculos",
            //            principalColumn: "VehiculoId");
            //    });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Comentarios_ClienteId",
        //        table: "Comentarios",
        //        column: "ClienteId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_OrdenesServicio_ClienteId",
        //        table: "OrdenesServicio",
        //        column: "ClienteId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_OrdenesServicio_VehiculoId",
        //        table: "OrdenesServicio",
        //        column: "VehiculoId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Vehiculos_ClienteId",
        //        table: "Vehiculos",
        //        column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Comentarios");

            //migrationBuilder.DropTable(
            //    name: "OrdenesServicio");

            //migrationBuilder.DropTable(
            //    name: "Servicios");

            //migrationBuilder.DropTable(
            //    name: "Vehiculos");

            //migrationBuilder.DropTable(
            //    name: "Clientes");
        }
    }
}
