using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CINEMA.API.Migrations
{
    public partial class updateUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CinemaRoom",
                keyColumn: "CinemaRoomID",
                keyValue: 1,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 16, 15, 43, 11, 53, DateTimeKind.Local).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "CinemaRoom",
                keyColumn: "CinemaRoomID",
                keyValue: 2,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 16, 15, 43, 11, 95, DateTimeKind.Local).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "CinemaRoom",
                keyColumn: "CinemaRoomID",
                keyValue: 3,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 16, 15, 43, 11, 95, DateTimeKind.Local).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "GenreID",
                keyValue: 1,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 16, 15, 43, 11, 105, DateTimeKind.Local).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "GenreID",
                keyValue: 2,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 16, 15, 43, 11, 105, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "GenreID",
                keyValue: 3,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 16, 15, 43, 11, 105, DateTimeKind.Local).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "GenreID",
                keyValue: 4,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 16, 15, 43, 11, 105, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "Genre",
                keyColumn: "GenreID",
                keyValue: 5,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 16, 15, 43, 11, 105, DateTimeKind.Local).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleID",
                keyValue: 1,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 16, 15, 43, 11, 109, DateTimeKind.Local).AddTicks(5981));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleID",
                keyValue: 2,
                column: "lastModified_18118032",
                value: new DateTime(2022, 6, 16, 15, 43, 11, 109, DateTimeKind.Local).AddTicks(6948));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
