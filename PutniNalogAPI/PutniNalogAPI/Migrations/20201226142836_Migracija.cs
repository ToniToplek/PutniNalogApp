using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PutniNalogAPI.Migrations
{
    public partial class Migracija : Migration
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
                    Kilometraza = table.Column<int>(type: "int", nullable: false),
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
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacijes", x => x.IdLokacija);
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
                    KmPocetak = table.Column<int>(type: "int", nullable: false),
                    KmZavrsetak = table.Column<int>(type: "int", nullable: false),
                    IdAuto = table.Column<int>(type: "int", nullable: false),
                    AutiIdAuto = table.Column<int>(type: "int", nullable: true),
                    IdOdrediste = table.Column<int>(type: "int", nullable: false),
                    OdredisteIdLokacija = table.Column<int>(type: "int", nullable: true),
                    IdPolaziste = table.Column<int>(type: "int", nullable: false),
                    PolazisteIdLokacija = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_PutniNalogs_Lokacijes_OdredisteIdLokacija",
                        column: x => x.OdredisteIdLokacija,
                        principalTable: "Lokacijes",
                        principalColumn: "IdLokacija",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PutniNalogs_Lokacijes_PolazisteIdLokacija",
                        column: x => x.PolazisteIdLokacija,
                        principalTable: "Lokacijes",
                        principalColumn: "IdLokacija",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorisniciNalogs",
                columns: table => new
                {
                    idKorisniciNalog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idKorisnik = table.Column<int>(type: "int", nullable: false),
                    KorisnikIdKorisnik = table.Column<int>(type: "int", nullable: true),
                    idPutniNalog = table.Column<int>(type: "int", nullable: false),
                    PutniNalogIdPutniNalog = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisniciNalogs", x => x.idKorisniciNalog);
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
                name: "Troskovis",
                columns: table => new
                {
                    IdTrosak = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpisTrosak = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Iznos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdPutniNalog = table.Column<int>(type: "int", nullable: false),
                    PutniNalogIdPutniNalog = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Troskovis", x => x.IdTrosak);
                    table.ForeignKey(
                        name: "FK_Troskovis_PutniNalogs_PutniNalogIdPutniNalog",
                        column: x => x.PutniNalogIdPutniNalog,
                        principalTable: "PutniNalogs",
                        principalColumn: "IdPutniNalog",
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
                name: "IX_PutniNalogs_OdredisteIdLokacija",
                table: "PutniNalogs",
                column: "OdredisteIdLokacija");

            migrationBuilder.CreateIndex(
                name: "IX_PutniNalogs_PolazisteIdLokacija",
                table: "PutniNalogs",
                column: "PolazisteIdLokacija");

            migrationBuilder.CreateIndex(
                name: "IX_Troskovis_PutniNalogIdPutniNalog",
                table: "Troskovis",
                column: "PutniNalogIdPutniNalog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisniciNalogs");

            migrationBuilder.DropTable(
                name: "Troskovis");

            migrationBuilder.DropTable(
                name: "Korisnicis");

            migrationBuilder.DropTable(
                name: "PutniNalogs");

            migrationBuilder.DropTable(
                name: "Autis");

            migrationBuilder.DropTable(
                name: "Lokacijes");
        }
    }
}
