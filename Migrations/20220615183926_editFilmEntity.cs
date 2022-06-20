using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CINEMA.API.Migrations
{
    public partial class editFilmEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "end",
                table: "Film");

            migrationBuilder.UpdateData(
                table: "CinemaRoom",
                keyColumn: "CinemaRoomID",
                keyValue: 1,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 15, 21, 39, 25, 963, DateTimeKind.Local).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "CinemaRoom",
                keyColumn: "CinemaRoomID",
                keyValue: 2,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 15, 21, 39, 25, 969, DateTimeKind.Local).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "CinemaRoom",
                keyColumn: "CinemaRoomID",
                keyValue: 3,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 15, 21, 39, 25, 969, DateTimeKind.Local).AddTicks(6728));

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "GenreID",
                keyValue: 1,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 15, 21, 39, 25, 976, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "GenreID",
                keyValue: 2,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 15, 21, 39, 25, 976, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "GenreID",
                keyValue: 3,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 15, 21, 39, 25, 976, DateTimeKind.Local).AddTicks(3812));

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "GenreID",
                keyValue: 4,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 15, 21, 39, 25, 976, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "GenreID",
                keyValue: 5,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 15, 21, 39, 25, 976, DateTimeKind.Local).AddTicks(3826));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleID",
                keyValue: 1,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 15, 21, 39, 25, 978, DateTimeKind.Local).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleID",
                keyValue: 2,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 15, 21, 39, 25, 978, DateTimeKind.Local).AddTicks(3687));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "end",
                table: "Film",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CinemaRoom",
                keyColumn: "CinemaRoomID",
                keyValue: 1,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 6, 17, 31, 28, 569, DateTimeKind.Local).AddTicks(6381));

            migrationBuilder.UpdateData(
                table: "CinemaRoom",
                keyColumn: "CinemaRoomID",
                keyValue: 2,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 6, 17, 31, 28, 573, DateTimeKind.Local).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "CinemaRoom",
                keyColumn: "CinemaRoomID",
                keyValue: 3,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 6, 17, 31, 28, 573, DateTimeKind.Local).AddTicks(7894));

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "GenreID",
                keyValue: 1,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 6, 17, 31, 28, 580, DateTimeKind.Local).AddTicks(774));

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "GenreID",
                keyValue: 2,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 6, 17, 31, 28, 580, DateTimeKind.Local).AddTicks(1411));

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "GenreID",
                keyValue: 3,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 6, 17, 31, 28, 580, DateTimeKind.Local).AddTicks(1457));

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "GenreID",
                keyValue: 4,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 6, 17, 31, 28, 580, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "GenreID",
                keyValue: 5,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 6, 17, 31, 28, 580, DateTimeKind.Local).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleID",
                keyValue: 1,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 6, 17, 31, 28, 582, DateTimeKind.Local).AddTicks(306));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleID",
                keyValue: 2,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 6, 17, 31, 28, 582, DateTimeKind.Local).AddTicks(901));
        }
    }
}
