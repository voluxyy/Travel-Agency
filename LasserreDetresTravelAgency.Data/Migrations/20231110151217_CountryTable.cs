using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LasserreDetresTravelAgency.Data.Migrations
{
    /// <inheritdoc />
    public partial class CountryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Destinations");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Destinations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_CountryId",
                table: "Destinations",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Countries_CountryId",
                table: "Destinations",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Countries_CountryId",
                table: "Destinations");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_CountryId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Destinations");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Destinations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
