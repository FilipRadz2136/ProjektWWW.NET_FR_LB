using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektWWW.NET_FR_LB.Migrations
{
    /// <inheritdoc />
    public partial class migracjaDUZA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Akcje");

            migrationBuilder.DropTable(
                name: "HistoriaWymianUzytkownika");

            migrationBuilder.DropTable(
                name: "UlubioneKursiki");

            migrationBuilder.CreateTable(
                name: "Powiadomienia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzytkownikId = table.Column<int>(type: "int", nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDodania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Przeczytane = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powiadomienia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Powiadomienia_Uzytkownicy_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Powiadomienia_UzytkownikId",
                table: "Powiadomienia",
                column: "UzytkownikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Powiadomienia");

            migrationBuilder.CreateTable(
                name: "Akcje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzytkownikId = table.Column<int>(type: "int", nullable: true),
                    Akcja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Szczegoly = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Akcje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Akcje_Uzytkownicy_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HistoriaWymianUzytkownika",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzytkownikId = table.Column<int>(type: "int", nullable: false),
                    WalutaDoId = table.Column<int>(type: "int", nullable: false),
                    WalutaZId = table.Column<int>(type: "int", nullable: false),
                    DataPrzeliczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KwotaWejsciowa = table.Column<double>(type: "float", nullable: false),
                    KwotaWynikowa = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaWymianUzytkownika", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoriaWymianUzytkownika_Uzytkownicy_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoriaWymianUzytkownika_Waluty_WalutaDoId",
                        column: x => x.WalutaDoId,
                        principalTable: "Waluty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoriaWymianUzytkownika_Waluty_WalutaZId",
                        column: x => x.WalutaZId,
                        principalTable: "Waluty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UlubioneKursiki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzytkownikId = table.Column<int>(type: "int", nullable: false),
                    WalutaDoId = table.Column<int>(type: "int", nullable: false),
                    WalutaZId = table.Column<int>(type: "int", nullable: false),
                    DataDodania = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlubioneKursiki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UlubioneKursiki_Uzytkownicy_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UlubioneKursiki_Waluty_WalutaDoId",
                        column: x => x.WalutaDoId,
                        principalTable: "Waluty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UlubioneKursiki_Waluty_WalutaZId",
                        column: x => x.WalutaZId,
                        principalTable: "Waluty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Akcje_UzytkownikId",
                table: "Akcje",
                column: "UzytkownikId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaWymianUzytkownika_UzytkownikId",
                table: "HistoriaWymianUzytkownika",
                column: "UzytkownikId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaWymianUzytkownika_WalutaDoId",
                table: "HistoriaWymianUzytkownika",
                column: "WalutaDoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaWymianUzytkownika_WalutaZId",
                table: "HistoriaWymianUzytkownika",
                column: "WalutaZId");

            migrationBuilder.CreateIndex(
                name: "IX_UlubioneKursiki_UzytkownikId",
                table: "UlubioneKursiki",
                column: "UzytkownikId");

            migrationBuilder.CreateIndex(
                name: "IX_UlubioneKursiki_WalutaDoId",
                table: "UlubioneKursiki",
                column: "WalutaDoId");

            migrationBuilder.CreateIndex(
                name: "IX_UlubioneKursiki_WalutaZId",
                table: "UlubioneKursiki",
                column: "WalutaZId");
        }
    }
}
