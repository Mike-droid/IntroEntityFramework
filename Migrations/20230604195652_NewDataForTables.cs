using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoEF.Migrations
{
    /// <inheritdoc />
    public partial class NewDataForTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("6ae7acaa-9324-486f-976c-5ac93b5a5e02"), null, "Cosas trabajo", 100 });

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("8de7acaa-9324-486f-976c-70b93b5a5eed"),
                column: "FechaCreacion",
                value: new DateTime(2023, 6, 4, 14, 56, 52, 721, DateTimeKind.Local).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("9ce7acaa-9324-486f-976c-70b93b5a5eed"),
                column: "FechaCreacion",
                value: new DateTime(2023, 6, 4, 14, 56, 52, 721, DateTimeKind.Local).AddTicks(4448));

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Puntos", "Titulo" },
                values: new object[] { new Guid("9ce7acaa-1234-486f-976c-70b93b5a5eed"), new Guid("6ae7acaa-9324-486f-976c-5ac93b5a5e02"), null, new DateTime(2023, 6, 4, 14, 56, 52, 721, DateTimeKind.Local).AddTicks(4452), 2, 0, "Reparar bug de React.js" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("9ce7acaa-1234-486f-976c-70b93b5a5eed"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("6ae7acaa-9324-486f-976c-5ac93b5a5e02"));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("8de7acaa-9324-486f-976c-70b93b5a5eed"),
                column: "FechaCreacion",
                value: new DateTime(2023, 6, 4, 14, 51, 33, 107, DateTimeKind.Local).AddTicks(3387));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("9ce7acaa-9324-486f-976c-70b93b5a5eed"),
                column: "FechaCreacion",
                value: new DateTime(2023, 6, 4, 14, 51, 33, 107, DateTimeKind.Local).AddTicks(3430));
        }
    }
}
