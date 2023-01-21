using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW15.Migrations
{
    public partial class schema_v17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Movies_MovieGuid",
                table: "Showtimes");

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Movies_MovieGuid",
                table: "Showtimes",
                column: "MovieGuid",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Movies_MovieGuid",
                table: "Showtimes");

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Movies_MovieGuid",
                table: "Showtimes",
                column: "MovieGuid",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
