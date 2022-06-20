using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CINEMA.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CinemaRoom",
                columns: table => new
                {
                    CinemaRoomID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(nullable: true),
                    seats = table.Column<int>(maxLength: 100, nullable: false),
                    lastModified_18118032 = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaRoom", x => x.CinemaRoomID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    lastModified_18118032 = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(nullable: true),
                    lastModified_18118032 = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleID);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    FilmID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(maxLength: 200, nullable: true),
                    genreID = table.Column<int>(nullable: false),
                    cinemaRoomId = table.Column<int>(nullable: false),
                    ticketPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    duration = table.Column<string>(nullable: false),
                    start = table.Column<DateTime>(type: "DateTime", nullable: false),
                    end = table.Column<DateTime>(type: "DateTime", nullable: false),
                    lastModified_18118032 = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.FilmID);
                    table.ForeignKey(
                        name: "FK_Film_CinemaRoom_cinemaRoomId",
                        column: x => x.cinemaRoomId,
                        principalTable: "CinemaRoom",
                        principalColumn: "CinemaRoomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Film_Genre_genreID",
                        column: x => x.genreID,
                        principalTable: "Genre",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: false),
                    lastName = table.Column<string>(nullable: false),
                    roleID = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: true),
                    lastModified_18118032 = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_UserRole_roleID",
                        column: x => x.roleID,
                        principalTable: "UserRole",
                        principalColumn: "UserRoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(nullable: false),
                    filmId = table.Column<int>(nullable: false),
                    numberOfTickets = table.Column<int>(nullable: false),
                    lastModified_18118032 = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservations_Film_filmId",
                        column: x => x.filmId,
                        principalTable: "Film",
                        principalColumn: "FilmID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_User_userID",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CinemaRoom",
                columns: new[] { "CinemaRoomID", "lastModified_18118032", "number", "seats" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 6, 17, 31, 28, 569, DateTimeKind.Local).AddTicks(6381), "1", 100 },
                    { 2, new DateTime(2022, 6, 6, 17, 31, 28, 573, DateTimeKind.Local).AddTicks(7822), "2", 120 },
                    { 3, new DateTime(2022, 6, 6, 17, 31, 28, 573, DateTimeKind.Local).AddTicks(7894), "3", 80 }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreID", "Name", "lastModified_18118032" },
                values: new object[,]
                {
                    { 1, "Fantasy", new DateTime(2022, 6, 6, 17, 31, 28, 580, DateTimeKind.Local).AddTicks(774) },
                    { 2, "Comedy", new DateTime(2022, 6, 6, 17, 31, 28, 580, DateTimeKind.Local).AddTicks(1411) },
                    { 3, "Mystery", new DateTime(2022, 6, 6, 17, 31, 28, 580, DateTimeKind.Local).AddTicks(1457) },
                    { 4, "Thriller", new DateTime(2022, 6, 6, 17, 31, 28, 580, DateTimeKind.Local).AddTicks(1465) },
                    { 5, "Romance", new DateTime(2022, 6, 6, 17, 31, 28, 580, DateTimeKind.Local).AddTicks(1472) }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleID", "lastModified_18118032", "role" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 6, 17, 31, 28, 582, DateTimeKind.Local).AddTicks(306), "Admin" },
                    { 2, new DateTime(2022, 6, 6, 17, 31, 28, 582, DateTimeKind.Local).AddTicks(901), "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaRoom_number",
                table: "CinemaRoom",
                column: "number",
                unique: true,
                filter: "[number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Film_cinemaRoomId",
                table: "Film",
                column: "cinemaRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Film_genreID",
                table: "Film",
                column: "genreID");

            migrationBuilder.CreateIndex(
                name: "IX_Film_name",
                table: "Film",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_filmId",
                table: "Reservations",
                column: "filmId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_userID",
                table: "Reservations",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_User_roleID",
                table: "User",
                column: "roleID");

            migrationBuilder.CreateIndex(
                name: "IX_User_username",
                table: "User",
                column: "username",
                unique: true,
                filter: "[username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_role",
                table: "UserRole",
                column: "role",
                unique: true,
                filter: "[role] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CinemaRoom");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
