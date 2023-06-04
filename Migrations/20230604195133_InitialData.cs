using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proyectoEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("6ae7acaa-9324-486f-976c-70b93b5a5e02"), null, "Actividades personales", 50 },
                    { new Guid("6ae7acaa-9324-486f-976c-70b93b5a5eed"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Puntos", "Titulo" },
                values: new object[,]
                {
                    { new Guid("8de7acaa-9324-486f-976c-70b93b5a5eed"), new Guid("6ae7acaa-9324-486f-976c-70b93b5a5eed"), null, new DateTime(2023, 6, 4, 14, 51, 33, 107, DateTimeKind.Local).AddTicks(3387), 1, 0, "Pago de servicios públicos" },
                    { new Guid("9ce7acaa-9324-486f-976c-70b93b5a5eed"), new Guid("6ae7acaa-9324-486f-976c-70b93b5a5e02"), null, new DateTime(2023, 6, 4, 14, 51, 33, 107, DateTimeKind.Local).AddTicks(3430), 0, 0, "Terminar serie en Netflix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("8de7acaa-9324-486f-976c-70b93b5a5eed"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("9ce7acaa-9324-486f-976c-70b93b5a5eed"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("6ae7acaa-9324-486f-976c-70b93b5a5e02"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("6ae7acaa-9324-486f-976c-70b93b5a5eed"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
