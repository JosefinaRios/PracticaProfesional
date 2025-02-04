using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaSupervisada.Migrations
{
    /// <inheritdoc />
    public partial class Cambiosvehiculos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Año",
            //    table: "Vehiculos");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Vehiculos",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Inicio",
                table: "OrdenesServicio",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Entrega",
                table: "OrdenesServicio",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "Año",
            //    table: "Vehiculos",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Inicio",
                table: "OrdenesServicio",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Entrega",
                table: "OrdenesServicio",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);
        }
    }
}
