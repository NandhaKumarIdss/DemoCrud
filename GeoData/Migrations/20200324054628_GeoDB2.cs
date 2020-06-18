using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoData.Migrations
{
    public partial class GeoDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries_Info",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    CountryName = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries_Info", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "StateInfo",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateCode = table.Column<string>(type: "varchar(100)", nullable: false),
                    StateName = table.Column<string>(type: "varchar(100)", nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateInfo", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_StateInfo_Countries_Info_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries_Info",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityInfo",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityCode = table.Column<string>(type: "varchar(100)", nullable: false),
                    CityName = table.Column<string>(type: "varchar(100)", nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    StateId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityInfo", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_CityInfo_StateInfo_StateId",
                        column: x => x.StateId,
                        principalTable: "StateInfo",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityInfo_StateInfo_StateId1",
                        column: x => x.StateId1,
                        principalTable: "StateInfo",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityInfo_StateId",
                table: "CityInfo",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CityInfo_StateId1",
                table: "CityInfo",
                column: "StateId1",
                unique: true,
                filter: "[StateId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StateInfo_CountryId",
                table: "StateInfo",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityInfo");

            migrationBuilder.DropTable(
                name: "StateInfo");

            migrationBuilder.DropTable(
                name: "Countries_Info");
        }
    }
}
