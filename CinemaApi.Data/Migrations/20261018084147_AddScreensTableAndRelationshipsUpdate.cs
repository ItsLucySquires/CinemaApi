using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddScreensTableAndRelationshipsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Screen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screen_Cinema_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Showing_CinemaId",
                table: "Showing",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Showing_FilmId",
                table: "Showing",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Screen_CinemaId",
                table: "Screen",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Showing_Cinema_CinemaId",
                table: "Showing",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Showing_Film_FilmId",
                table: "Showing",
                column: "FilmId",
                principalTable: "Film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Showing_Cinema_CinemaId",
                table: "Showing");

            migrationBuilder.DropForeignKey(
                name: "FK_Showing_Film_FilmId",
                table: "Showing");

            migrationBuilder.DropTable(
                name: "Screen");

            migrationBuilder.DropIndex(
                name: "IX_Showing_CinemaId",
                table: "Showing");

            migrationBuilder.DropIndex(
                name: "IX_Showing_FilmId",
                table: "Showing");
        }
    }
}
