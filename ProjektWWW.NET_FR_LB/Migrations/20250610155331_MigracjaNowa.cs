using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektWWW.NET_FR_LB.Migrations
{
    /// <inheritdoc />
    public partial class MigracjaNowa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorieAktualizacji");

            migrationBuilder.DropTable(
                name: "KursyWalut");

            migrationBuilder.DropTable(
                name: "ZrodlaKursow");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZrodlaKursow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZrodlaKursow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistorieAktualizacji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZrodloId = table.Column<int>(type: "int", nullable: false),
                    DataAktualizacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LiczbaPobranychKursow = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorieAktualizacji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorieAktualizacji_ZrodlaKursow_ZrodloId",
                        column: x => x.ZrodloId,
                        principalTable: "ZrodlaKursow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KursyWalut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalutaDoId = table.Column<int>(type: "int", nullable: false),
                    WalutaZId = table.Column<int>(type: "int", nullable: false),
                    ZrodloId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kurs = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursyWalut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KursyWalut_Waluty_WalutaDoId",
                        column: x => x.WalutaDoId,
                        principalTable: "Waluty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KursyWalut_Waluty_WalutaZId",
                        column: x => x.WalutaZId,
                        principalTable: "Waluty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KursyWalut_ZrodlaKursow_ZrodloId",
                        column: x => x.ZrodloId,
                        principalTable: "ZrodlaKursow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorieAktualizacji_ZrodloId",
                table: "HistorieAktualizacji",
                column: "ZrodloId");

            migrationBuilder.CreateIndex(
                name: "IX_KursyWalut_WalutaDoId",
                table: "KursyWalut",
                column: "WalutaDoId");

            migrationBuilder.CreateIndex(
                name: "IX_KursyWalut_WalutaZId",
                table: "KursyWalut",
                column: "WalutaZId");

            migrationBuilder.CreateIndex(
                name: "IX_KursyWalut_ZrodloId",
                table: "KursyWalut",
                column: "ZrodloId");
        }
    }
}
