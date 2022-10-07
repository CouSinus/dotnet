using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISeries.Migrations
{
    public partial class CreationBDSeriesV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fk_not_utl",
                table: "t_j_notation_not",
                newName: "Utilisateur");

            migrationBuilder.RenameColumn(
                name: "fk_not_ser",
                table: "t_j_notation_not",
                newName: "Serie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Utilisateur",
                table: "t_j_notation_not",
                newName: "fk_not_utl");

            migrationBuilder.RenameColumn(
                name: "Serie",
                table: "t_j_notation_not",
                newName: "fk_not_ser");
        }
    }
}
