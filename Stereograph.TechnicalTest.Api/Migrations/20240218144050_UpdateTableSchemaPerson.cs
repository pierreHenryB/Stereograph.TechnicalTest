using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stereograph.TechnicalTest.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableSchemaPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "reference",
                table: "Persons",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reference",
                table: "Persons");
        }
    }
}
