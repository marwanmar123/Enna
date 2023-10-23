﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace enaa.Migrations
{
    /// <inheritdoc />
    public partial class gnder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Registration",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Registration");
        }
    }
}
