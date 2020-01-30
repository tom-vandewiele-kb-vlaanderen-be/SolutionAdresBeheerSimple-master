using Microsoft.EntityFrameworkCore.Migrations;

namespace AdresBeheerRepository.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gemeenten",
                columns: table => new
                {
                    NIScode = table.Column<int>(nullable: false),
                    versieNr = table.Column<int>(nullable: false),
                    gemeentenaam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gemeenten", x => x.NIScode);
                });

            migrationBuilder.CreateTable(
                name: "straten",
                columns: table => new
                {
                    straatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    straatnaam = table.Column<string>(nullable: false),
                    versieNr = table.Column<int>(nullable: false),
                    gemeenteNIScode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_straten", x => x.straatID);
                    table.ForeignKey(
                        name: "FK_straten_gemeenten_gemeenteNIScode",
                        column: x => x.gemeenteNIScode,
                        principalTable: "gemeenten",
                        principalColumn: "NIScode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adressen",
                columns: table => new
                {
                    adresID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    huisnummer = table.Column<string>(nullable: false),
                    busnummer = table.Column<string>(nullable: true),
                    appartementnummer = table.Column<string>(nullable: true),
                    adresLabel = table.Column<string>(nullable: true),
                    versieNr = table.Column<int>(nullable: false),
                    straatID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adressen", x => x.adresID);
                    table.ForeignKey(
                        name: "FK_adressen_straten_straatID",
                        column: x => x.straatID,
                        principalTable: "straten",
                        principalColumn: "straatID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_adressen_straatID",
                table: "adressen",
                column: "straatID");

            migrationBuilder.CreateIndex(
                name: "IX_straten_gemeenteNIScode",
                table: "straten",
                column: "gemeenteNIScode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adressen");

            migrationBuilder.DropTable(
                name: "straten");

            migrationBuilder.DropTable(
                name: "gemeenten");
        }
    }
}
