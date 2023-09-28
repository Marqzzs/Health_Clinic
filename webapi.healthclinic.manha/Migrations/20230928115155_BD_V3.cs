using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.healthclinic.manha.Migrations
{
    /// <inheritdoc />
    public partial class BD_V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Paciente",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Paciente");
        }
    }
}
