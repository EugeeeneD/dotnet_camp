using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW15.Migrations
{
    public partial class schema_v15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Showtimes_ShowtimeGuid",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Showtimes_ShowtimeGuid",
                table: "Tickets",
                column: "ShowtimeGuid",
                principalTable: "Showtimes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Showtimes_ShowtimeGuid",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Showtimes_ShowtimeGuid",
                table: "Tickets",
                column: "ShowtimeGuid",
                principalTable: "Showtimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
