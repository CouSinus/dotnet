using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APISeries.Migrations
{
    public partial class CreationBDSeriesV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Utilisateur",
                table: "t_j_notation_not",
                newName: "fk_not_utl");

            migrationBuilder.RenameColumn(
                name: "Serie",
                table: "t_j_notation_not",
                newName: "fk_not_ser");

            migrationBuilder.AlterColumn<DateTime>(
                name: "utl_datecreation",
                table: "t_e_utilisateur_utl",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "utl_prenom",
                table: "t_e_utilisateur_utl",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "utl_prenom",
                table: "t_e_utilisateur_utl");

            migrationBuilder.RenameColumn(
                name: "fk_not_utl",
                table: "t_j_notation_not",
                newName: "Utilisateur");

            migrationBuilder.RenameColumn(
                name: "fk_not_ser",
                table: "t_j_notation_not",
                newName: "Serie");

            migrationBuilder.AlterColumn<DateTime>(
                name: "utl_datecreation",
                table: "t_e_utilisateur_utl",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
