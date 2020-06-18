using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoData.Migrations
{
    public partial class GeoDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityInfo_StateInfo_StateId1",
                table: "CityInfo");

            migrationBuilder.DropIndex(
                name: "IX_CityInfo_StateId1",
                table: "CityInfo");

            migrationBuilder.DropColumn(
                name: "StateId1",
                table: "CityInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateId1",
                table: "CityInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CityInfo_StateId1",
                table: "CityInfo",
                column: "StateId1",
                unique: true,
                filter: "[StateId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CityInfo_StateInfo_StateId1",
                table: "CityInfo",
                column: "StateId1",
                principalTable: "StateInfo",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
