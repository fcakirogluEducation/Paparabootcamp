using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TokenAuth.Repository.Migrations
{
    /// <inheritdoc />
    public partial class add_age_for_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");
        }
    }
}
