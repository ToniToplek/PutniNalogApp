using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PutniNalogAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autis",
                columns: table => new
                {
                    IdAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistracijaAuta = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    MarkaAuta = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    NazivAuta = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Kilometraza = table.Column<int>(type: "int", nullable: true),
                    VrstaPrijevoza = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autis", x => x.IdAuto);
                });

            migrationBuilder.CreateTable(
                name: "Korisnicis",
                columns: table => new
                {
                    IdKorisnik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeKorisnik = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    PrezimeKorisnik = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnicis", x => x.IdKorisnik);
                });

            migrationBuilder.CreateTable(
                name: "Lokacijes",
                columns: table => new
                {
                    IdLokacija = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacijes", x => x.IdLokacija);
                });

            migrationBuilder.CreateTable(
                name: "Troskovis",
                columns: table => new
                {
                    IdTrosak = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpisTrosak = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Iznos = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Troskovis", x => x.IdTrosak);
                });

            migrationBuilder.CreateTable(
                name: "PutniNalogs",
                columns: table => new
                {
                    IdPutniNalog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazlogPutovanja = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    VrijemePolazak = table.Column<DateTime>(type: "datetime", nullable: false),
                    VrijemePovratak = table.Column<DateTime>(type: "datetime", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    KmPocetak = table.Column<int>(type: "int", nullable: true),
                    KmZavrsetak = table.Column<int>(type: "int", nullable: true),
                    AutiIdAuto = table.Column<int>(type: "int", nullable: true),
                    LokacijeIdLokacija = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PutniNalogs", x => x.IdPutniNalog);
                    table.ForeignKey(
                        name: "FK_PutniNalogs_Autis_AutiIdAuto",
                        column: x => x.AutiIdAuto,
                        principalTable: "Autis",
                        principalColumn: "IdAuto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PutniNalogs_Lokacijes_LokacijeIdLokacija",
                        column: x => x.LokacijeIdLokacija,
                        principalTable: "Lokacijes",
                        principalColumn: "IdLokacija",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorisniciNalogs",
                columns: table => new
                {
                    IdKorisniciNalog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikIdKorisnik = table.Column<int>(type: "int", nullable: true),
                    PutniNalogIdPutniNalog = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciNalogs", x => x.IdKorisniciNalog);
                    table.ForeignKey(
                        name: "FK_KorisniciNalogs_Korisnicis_KorisnikIdKorisnik",
                        column: x => x.KorisnikIdKorisnik,
                        principalTable: "Korisnicis",
                        principalColumn: "IdKorisnik",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KorisniciNalogs_PutniNalogs_PutniNalogIdPutniNalog",
                        column: x => x.PutniNalogIdPutniNalog,
                        principalTable: "PutniNalogs",
                        principalColumn: "IdPutniNalog",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrosakNalogs",
                columns: table => new
                {
                    IdTrosakNalog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrosakIdTrosak = table.Column<int>(type: "int", nullable: true),
                    PutniNalogIdPutniNalog = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrosakNalogs", x => x.IdTrosakNalog);
                    table.ForeignKey(
                        name: "FK_TrosakNalogs_PutniNalogs_PutniNalogIdPutniNalog",
                        column: x => x.PutniNalogIdPutniNalog,
                        principalTable: "PutniNalogs",
                        principalColumn: "IdPutniNalog",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrosakNalogs_Troskovis_TrosakIdTrosak",
                        column: x => x.TrosakIdTrosak,
                        principalTable: "Troskovis",
                        principalColumn: "IdTrosak",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciNalogs_KorisnikIdKorisnik",
                table: "KorisniciNalogs",
                column: "KorisnikIdKorisnik");

            migrationBuilder.CreateIndex(
                name: "IX_KorisniciNalogs_PutniNalogIdPutniNalog",
                table: "KorisniciNalogs",
                column: "PutniNalogIdPutniNalog");

            migrationBuilder.CreateIndex(
                name: "IX_PutniNalogs_AutiIdAuto",
                table: "PutniNalogs",
                column: "AutiIdAuto");

            migrationBuilder.CreateIndex(
                name: "IX_PutniNalogs_LokacijeIdLokacija",
                table: "PutniNalogs",
                column: "LokacijeIdLokacija");

            migrationBuilder.CreateIndex(
                name: "IX_TrosakNalogs_PutniNalogIdPutniNalog",
                table: "TrosakNalogs",
                column: "PutniNalogIdPutniNalog");

            migrationBuilder.CreateIndex(
                name: "IX_TrosakNalogs_TrosakIdTrosak",
                table: "TrosakNalogs",
                column: "TrosakIdTrosak");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisniciNalogs");

            migrationBuilder.DropTable(
                name: "TrosakNalogs");

            migrationBuilder.DropTable(
                name: "Korisnicis");

            migrationBuilder.DropTable(
                name: "PutniNalogs");

            migrationBuilder.DropTable(
                name: "Troskovis");

            migrationBuilder.DropTable(
                name: "Autis");

            migrationBuilder.DropTable(
                name: "Lokacijes");
        }
    }
}
