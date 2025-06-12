using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektWWW.NET_FR_LB.Migrations
{
    /// <inheritdoc />
    public partial class _323232 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Haslo",
                table: "Uzytkownicy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Haslo",
                table: "Uzytkownicy");
        }
    }
}
