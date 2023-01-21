using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW15.Migrations
{
    public partial class SchemaV12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Halls_CinemaHalls_CinemaHallId",
                table: "Halls");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Halls_HallId",
                table: "Showtimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Movies_MovieId",
                table: "Showtimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Seats_SeatId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Showtimes_ShowtimeId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Showtimes_HallId",
                table: "Showtimes");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "Showtimes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tickets",
                newName: "UserGuid");

            migrationBuilder.RenameColumn(
                name: "ShowtimeId",
                table: "Tickets",
                newName: "ShowtimeGuid");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "Tickets",
                newName: "SeatGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                newName: "IX_Tickets_UserGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ShowtimeId",
                table: "Tickets",
                newName: "IX_Tickets_ShowtimeGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets",
                newName: "IX_Tickets_SeatGuid");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Showtimes",
                newName: "MovieGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Showtimes_MovieId",
                table: "Showtimes",
                newName: "IX_Showtimes_MovieGuid");

            migrationBuilder.RenameColumn(
                name: "HallId",
                table: "Seats",
                newName: "HallGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_HallId",
                table: "Seats",
                newName: "IX_Seats_HallGuid");

            migrationBuilder.RenameColumn(
                name: "CinemaHallId",
                table: "Halls",
                newName: "CinemaGuid");

            migrationBuilder.RenameIndex(
                name: "IX_Halls_CinemaHallId",
                table: "Halls",
                newName: "IX_Halls_CinemaGuid");

            migrationBuilder.CreateTable(
                name: "HallShowtime",
                columns: table => new
                {
                    HallsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShowtimesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallShowtime", x => new { x.HallsId, x.ShowtimesId });
                    table.ForeignKey(
                        name: "FK_HallShowtime_Halls_HallsId",
                        column: x => x.HallsId,
                        principalTable: "Halls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HallShowtime_Showtimes_ShowtimesId",
                        column: x => x.ShowtimesId,
                        principalTable: "Showtimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HallShowtime_ShowtimesId",
                table: "HallShowtime",
                column: "ShowtimesId");

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
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.DropTable(
                name: "HallShowtime");

            migrationBuilder.RenameColumn(
                name: "UserGuid",
                table: "Tickets",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ShowtimeGuid",
                table: "Tickets",
                newName: "ShowtimeId");

            migrationBuilder.RenameColumn(
                name: "SeatGuid",
                table: "Tickets",
                newName: "SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UserGuid",
                table: "Tickets",
                newName: "IX_Tickets_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ShowtimeGuid",
                table: "Tickets",
                newName: "IX_Tickets_ShowtimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_SeatGuid",
                table: "Tickets",
                newName: "IX_Tickets_SeatId");

            migrationBuilder.RenameColumn(
                name: "MovieGuid",
                table: "Showtimes",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Showtimes_MovieGuid",
                table: "Showtimes",
                newName: "IX_Showtimes_MovieId");

            migrationBuilder.RenameColumn(
                name: "HallGuid",
                table: "Seats",
                newName: "HallId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_HallGuid",
                table: "Seats",
                newName: "IX_Seats_HallId");

            migrationBuilder.RenameColumn(
                name: "CinemaGuid",
                table: "Halls",
                newName: "CinemaHallId");

            migrationBuilder.RenameIndex(
                name: "IX_Halls_CinemaGuid",
                table: "Halls",
                newName: "IX_Halls_CinemaHallId");

            migrationBuilder.AddColumn<Guid>(
                name: "HallId",
                table: "Showtimes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Showtimes_HallId",
                table: "Showtimes",
                column: "HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_CinemaHalls_CinemaHallId",
                table: "Halls",
                column: "CinemaHallId",
                principalTable: "CinemaHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Halls_HallId",
                table: "Showtimes",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Showtimes_Movies_MovieId",
                table: "Showtimes",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Seats_SeatId",
                table: "Tickets",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Showtimes_ShowtimeId",
                table: "Tickets",
                column: "ShowtimeId",
                principalTable: "Showtimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
