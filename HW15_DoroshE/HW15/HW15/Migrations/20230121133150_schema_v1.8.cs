using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW15.Migrations
{
    public partial class schema_v18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_CinemaHalls_CinemaGuid",
                table: "Halls");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Halls_HallGuid",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Movies_MovieGuid",
                table: "Showtimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Seats_SeatGuid",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Showtimes_ShowtimeGuid",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserGuid",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_CinemaHalls_CinemaGuid",
                table: "Halls",
                column: "CinemaGuid",
                principalTable: "CinemaHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Halls_HallGuid",
                table: "Seats",
                column: "HallGuid",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Movies_MovieGuid",
                table: "Showtimes",
                column: "MovieGuid",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Seats_SeatGuid",
                table: "Tickets",
                column: "SeatGuid",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Showtimes_ShowtimeGuid",
                table: "Tickets",
                column: "ShowtimeGuid",
                principalTable: "Showtimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UserGuid",
                table: "Tickets",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_CinemaHalls_CinemaGuid",
                table: "Halls");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Halls_HallGuid",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Movies_MovieGuid",
                table: "Showtimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Seats_SeatGuid",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Showtimes_ShowtimeGuid",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserGuid",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_CinemaHalls_CinemaGuid",
                table: "Halls",
                column: "CinemaGuid",
                principalTable: "CinemaHalls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Halls_HallGuid",
                table: "Seats",
                column: "HallGuid",
                principalTable: "Halls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Movies_MovieGuid",
                table: "Showtimes",
                column: "MovieGuid",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Seats_SeatGuid",
                table: "Tickets",
                column: "SeatGuid",
                principalTable: "Seats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Showtimes_ShowtimeGuid",
                table: "Tickets",
                column: "ShowtimeGuid",
                principalTable: "Showtimes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UserGuid",
                table: "Tickets",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
