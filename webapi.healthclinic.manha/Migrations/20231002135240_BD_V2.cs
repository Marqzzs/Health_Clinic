using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.healthclinic.manha.Migrations
{
    /// <inheritdoc />
    public partial class BD_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Medico",
                type: "VARCHAR(100)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Medico");
        }
    }
}
