using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaparaApp.API.Migrations
{
    /// <inheritdoc />
    public partial class add_product_definition_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductDefinitions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductDefinitions");
        }
    }
}
