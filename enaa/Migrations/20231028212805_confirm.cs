using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace enaa.Migrations
{
    /// <inheritdoc />
    public partial class confirm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Confirmation",
                table: "Registration",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmation",
                table: "Registration");
        }
    }
}
