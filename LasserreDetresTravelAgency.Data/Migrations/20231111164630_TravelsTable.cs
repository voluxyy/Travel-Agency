using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LasserreDetresTravelAgency.Data.Migrations
{
    /// <inheritdoc />
    public partial class TravelsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Events_EventId",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_EventId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Destinations");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Events",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    DestinationId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travels_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Travels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_DestinationId",
                table: "Events",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_DestinationId",
                table: "Travels",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_UserId",
                table: "Travels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Destinations_DestinationId",
                table: "Events",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Destinations_DestinationId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Events_DestinationId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Destinations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_EventId",
                table: "Destinations",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Events_EventId",
                table: "Destinations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
