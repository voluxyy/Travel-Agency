using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LasserreDetresTravelAgency.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVisited",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Favories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVisited",
                table: "Visits",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Favories",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
