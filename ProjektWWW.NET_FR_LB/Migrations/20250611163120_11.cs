using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektWWW.NET_FR_LB.Migrations
{
    /// <inheritdoc />
    public partial class _11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komentarze_Uzytkownicy_UzytkownikId",
                table: "Komentarze");

            migrationBuilder.DropIndex(
                name: "IX_Komentarze_UzytkownikId",
                table: "Komentarze");

            migrationBuilder.DropColumn(
                name: "UzytkownikId",
                table: "Komentarze");

            migrationBuilder.AddColumn<string>(
                name: "Uzytkownik",
                table: "Komentarze",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uzytkownik",
                table: "Komentarze");

            migrationBuilder.AddColumn<int>(
                name: "UzytkownikId",
                table: "Komentarze",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Komentarze_UzytkownikId",
                table: "Komentarze",
                column: "UzytkownikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Komentarze_Uzytkownicy_UzytkownikId",
                table: "Komentarze",
                column: "UzytkownikId",
                principalTable: "Uzytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
