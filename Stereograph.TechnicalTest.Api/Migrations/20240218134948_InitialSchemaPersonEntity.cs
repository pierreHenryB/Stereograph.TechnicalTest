using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stereograph.TechnicalTest.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchemaPersonEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstName = table.Column<string>(type: "nvarchar", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar", nullable: true),
                    email = table.Column<string>(type: "nvarchar", nullable: true),
                    address = table.Column<string>(type: "nvarchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
