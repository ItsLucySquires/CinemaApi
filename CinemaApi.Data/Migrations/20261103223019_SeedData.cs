using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScreenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Row = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_Screen_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cinema",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "123 Pike Place, Seattle, WA", "Seattle Cinema" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "456 Granville St, Vancouver, BC", "Vancouver Theater" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "789 Avenida Paseo de la Reforma, Mexico City", "Mexico City Multiplex" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "321 Calle 5 de Oriente, Puebla", "Puebla Cinema Hall" }
                });

            migrationBuilder.InsertData(
                table: "Film",
                columns: new[] { "Id", "AgeRating", "Duration", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "PG-13", new TimeSpan(0, 2, 20, 0, 0), new DateTime(2005, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Star Wars Episode III Revenge of the Sith" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "PG-13", new TimeSpan(0, 2, 28, 0, 0), new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "PG-13", new TimeSpan(0, 2, 49, 0, 0), new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Interstellar" }
                });

            migrationBuilder.InsertData(
                table: "Screen",
                columns: new[] { "Id", "CinemaId", "Name", "TypeDescription" },
                values: new object[,]
                {
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new Guid("11111111-1111-1111-1111-111111111111"), "Screen 1 - IMAX", "IMAX Theater" },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new Guid("11111111-1111-1111-1111-111111111111"), "Screen 2 - Standard", "Standard Theater" },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new Guid("22222222-2222-2222-2222-222222222222"), "Screen 1 - Premium", "Premium Theater with Reclining Seats" }
                });

            migrationBuilder.InsertData(
                table: "Showing",
                columns: new[] { "Id", "CinemaId", "EndTime", "FilmId", "StartTime" },
                values: new object[,]
                {
                    { new Guid("60000000-0000-0000-0000-000000000001"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 12, 20, 16, 20, 0, 0, DateTimeKind.Unspecified), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 12, 20, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("60000000-0000-0000-0000-000000000002"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 12, 20, 21, 20, 0, 0, DateTimeKind.Unspecified), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 12, 20, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("60000000-0000-0000-0000-000000000003"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 12, 20, 18, 28, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2024, 12, 20, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("60000000-0000-0000-0000-000000000004"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 12, 20, 22, 49, 0, 0, DateTimeKind.Unspecified), new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2024, 12, 20, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("60000000-0000-0000-0000-000000000005"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 12, 21, 17, 28, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2024, 12, 21, 15, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Seat",
                columns: new[] { "Id", "Number", "Row", "ScreenId" },
                values: new object[,]
                {
                    { new Guid("50000000-0000-0000-0000-000000000001"), 1, "A", new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("50000000-0000-0000-0000-000000000002"), 2, "A", new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("50000000-0000-0000-0000-000000000003"), 3, "A", new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("50000000-0000-0000-0000-000000000004"), 1, "B", new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("50000000-0000-0000-0000-000000000005"), 2, "B", new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("50000000-0000-0000-0000-000000000006"), 1, "A", new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") },
                    { new Guid("50000000-0000-0000-0000-000000000007"), 2, "A", new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") },
                    { new Guid("50000000-0000-0000-0000-000000000008"), 1, "A", new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff") },
                    { new Guid("50000000-0000-0000-0000-000000000009"), 2, "A", new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_ScreenId",
                table: "Seat",
                column: "ScreenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DeleteData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Screen",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "Screen",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"));

            migrationBuilder.DeleteData(
                table: "Screen",
                keyColumn: "Id",
                keyValue: new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "Showing",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Showing",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Showing",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Showing",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Showing",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));
        }
    }
}
