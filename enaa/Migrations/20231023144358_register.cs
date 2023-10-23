using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace enaa.Migrations
{
    /// <inheritdoc />
    public partial class register : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrancheBac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NiveauAcad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiliereAcad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutreFiliereAcad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DernierDip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etablissement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnneeDiplome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<bool>(type: "bit", nullable: true),
                    SiOuiExperience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registration");
        }
    }
}
