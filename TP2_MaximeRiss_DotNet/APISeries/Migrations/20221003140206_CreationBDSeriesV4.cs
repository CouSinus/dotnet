using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISeries.Migrations
{
    public partial class CreationBDSeriesV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_notes_film",
                table: "t_j_notation_not");

            migrationBuilder.DropForeignKey(
                name: "fk_notes_utilisateur",
                table: "t_j_notation_not");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "t_j_notation_not",
                newName: "t_j_notation_not",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "t_e_utilisateur_utl",
                newName: "t_e_utilisateur_utl",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "t_e_serie_ser",
                newName: "t_e_serie_ser",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "Utilisateur",
                schema: "public",
                table: "t_j_notation_not",
                newName: "fk_not_utl");

            migrationBuilder.RenameColumn(
                name: "Serie",
                schema: "public",
                table: "t_j_notation_not",
                newName: "fk_not_ser");

            migrationBuilder.AddForeignKey(
                name: "fk_not_ser",
                schema: "public",
                table: "t_j_notation_not",
                column: "ser_id",
                principalSchema: "public",
                principalTable: "t_e_serie_ser",
                principalColumn: "ser_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_not_utl",
                schema: "public",
                table: "t_j_notation_not",
                column: "utl_id",
                principalSchema: "public",
                principalTable: "t_e_utilisateur_utl",
                principalColumn: "utl_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_not_ser",
                schema: "public",
                table: "t_j_notation_not");

            migrationBuilder.DropForeignKey(
                name: "fk_not_utl",
                schema: "public",
                table: "t_j_notation_not");

            migrationBuilder.RenameTable(
                name: "t_j_notation_not",
                schema: "public",
                newName: "t_j_notation_not");

            migrationBuilder.RenameTable(
                name: "t_e_utilisateur_utl",
                schema: "public",
                newName: "t_e_utilisateur_utl");

            migrationBuilder.RenameTable(
                name: "t_e_serie_ser",
                schema: "public",
                newName: "t_e_serie_ser");

            migrationBuilder.RenameColumn(
                name: "fk_not_utl",
                table: "t_j_notation_not",
                newName: "Utilisateur");

            migrationBuilder.RenameColumn(
                name: "fk_not_ser",
                table: "t_j_notation_not",
                newName: "Serie");

            migrationBuilder.AddForeignKey(
                name: "fk_notes_film",
                table: "t_j_notation_not",
                column: "ser_id",
                principalTable: "t_e_serie_ser",
                principalColumn: "ser_id");

            migrationBuilder.AddForeignKey(
                name: "fk_notes_utilisateur",
                table: "t_j_notation_not",
                column: "utl_id",
                principalTable: "t_e_utilisateur_utl",
                principalColumn: "utl_id");
        }
    }
}
