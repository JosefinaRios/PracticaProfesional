using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaSupervisada.Migrations
{
    /// <inheritdoc />
    public partial class Reseñas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK2_Clientes",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Servicios");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Comentarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "NombreCliente",
                table: "Comentarios",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Clientes_ClienteId",
                table: "Comentarios",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Clientes_ClienteId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "NombreCliente",
                table: "Comentarios");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Servicios",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK2_Clientes",
                table: "Comentarios",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId");
        }
    }
}
