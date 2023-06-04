using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoEF.Migrations
{
    /// <inheritdoc />
    public partial class ColumnPuntosTableTarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Puntos",
                table: "Tarea",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Puntos",
                table: "Tarea");
        }
    }
}
