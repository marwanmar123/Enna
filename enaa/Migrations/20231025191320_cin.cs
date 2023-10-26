using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace enaa.Migrations
{
    /// <inheritdoc />
    public partial class cin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cin",
                table: "Registration",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Registration",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cin",
                table: "Registration");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Registration");
        }
    }
}
