using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektWWW.NET_FR_LB.Migrations
{
    /// <inheritdoc />
    public partial class migracjaNaKomentarzeZdjecia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NazwaPliku",
                table: "Komentarze",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NazwaPliku",
                table: "Komentarze");
        }
    }
}
