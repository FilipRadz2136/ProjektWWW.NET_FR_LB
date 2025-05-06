using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektWWW.NET_FR_LB.Migrations
{
    /// <inheritdoc />
    public partial class Migracja1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasloHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRejestracji = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Waluty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kraj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waluty", x => x.Id);
                });

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
                name: "Akcje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Akcja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Szczegoly = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UzytkownikId = table.Column<int>(type: "int", nullable: true)
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
                name: "AlertyKursow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzytkownikId = table.Column<int>(type: "int", nullable: false),
                    WalutaZId = table.Column<int>(type: "int", nullable: false),
                    WalutaDoId = table.Column<int>(type: "int", nullable: false),
                    ProgKursu = table.Column<double>(type: "float", nullable: false),
                    PowiadomGdyMniejszy = table.Column<bool>(type: "bit", nullable: false),
                    Aktywny = table.Column<bool>(type: "bit", nullable: false),
                    DataUtworzenia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertyKursow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertyKursow_Uzytkownicy_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AlertyKursow_Waluty_WalutaDoId",
                        column: x => x.WalutaDoId,
                        principalTable: "Waluty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AlertyKursow_Waluty_WalutaZId",
                        column: x => x.WalutaZId,
                        principalTable: "Waluty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HistoriaWymianUzytkownika",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzytkownikId = table.Column<int>(type: "int", nullable: false),
                    KwotaWejsciowa = table.Column<double>(type: "float", nullable: false),
                    WalutaZId = table.Column<int>(type: "int", nullable: false),
                    WalutaDoId = table.Column<int>(type: "int", nullable: false),
                    KwotaWynikowa = table.Column<double>(type: "float", nullable: false),
                    DataPrzeliczenia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaWymianUzytkownika", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoriaWymianUzytkownika_Uzytkownicy_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HistoriaWymianUzytkownika_Waluty_WalutaDoId",
                        column: x => x.WalutaDoId,
                        principalTable: "Waluty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HistoriaWymianUzytkownika_Waluty_WalutaZId",
                        column: x => x.WalutaZId,
                        principalTable: "Waluty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UlubioneKursiki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzytkownikId = table.Column<int>(type: "int", nullable: false),
                    WalutaZId = table.Column<int>(type: "int", nullable: false),
                    WalutaDoId = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UlubioneKursiki_Waluty_WalutaDoId",
                        column: x => x.WalutaDoId,
                        principalTable: "Waluty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UlubioneKursiki_Waluty_WalutaZId",
                        column: x => x.WalutaZId,
                        principalTable: "Waluty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KursyWalut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalutaZId = table.Column<int>(type: "int", nullable: false),
                    WalutaDoId = table.Column<int>(type: "int", nullable: false),
                    ZrodloId = table.Column<int>(type: "int", nullable: false),
                    Kurs = table.Column<double>(type: "float", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursyWalut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KursyWalut_Waluty_WalutaDoId",
                        column: x => x.WalutaDoId,
                        principalTable: "Waluty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KursyWalut_Waluty_WalutaZId",
                        column: x => x.WalutaZId,
                        principalTable: "Waluty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KursyWalut_ZrodlaKursow_ZrodloId",
                        column: x => x.ZrodloId,
                        principalTable: "ZrodlaKursow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Akcje_UzytkownikId",
                table: "Akcje",
                column: "UzytkownikId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertyKursow_UzytkownikId",
                table: "AlertyKursow",
                column: "UzytkownikId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertyKursow_WalutaDoId",
                table: "AlertyKursow",
                column: "WalutaDoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertyKursow_WalutaZId",
                table: "AlertyKursow",
                column: "WalutaZId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Akcje");

            migrationBuilder.DropTable(
                name: "AlertyKursow");

            migrationBuilder.DropTable(
                name: "HistoriaWymianUzytkownika");

            migrationBuilder.DropTable(
                name: "HistorieAktualizacji");

            migrationBuilder.DropTable(
                name: "KursyWalut");

            migrationBuilder.DropTable(
                name: "UlubioneKursiki");

            migrationBuilder.DropTable(
                name: "ZrodlaKursow");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Waluty");
        }
    }
}
