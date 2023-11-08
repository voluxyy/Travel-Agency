using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LasserreDetresTravelAgency.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Capital = table.Column<bool>(type: "INTEGER", nullable: false),
                    ToDo = table.Column<string>(type: "TEXT", nullable: false),
                    IsVisited = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateVisited = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Rate = table.Column<int>(type: "INTEGER", nullable: true),
                    Commentary = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destinations");
        }
    }
}
