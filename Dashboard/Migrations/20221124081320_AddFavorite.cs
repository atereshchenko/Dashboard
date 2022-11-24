using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashboard.Migrations
{
    public partial class AddFavorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "favorite",
                table: "tiles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "tiles",
                keyColumn: "id",
                keyValue: 1,
                column: "favorite",
                value: true);

            migrationBuilder.UpdateData(
                table: "tiles",
                keyColumn: "id",
                keyValue: 2,
                column: "favorite",
                value: true);

            migrationBuilder.UpdateData(
                table: "tiles",
                keyColumn: "id",
                keyValue: 3,
                column: "favorite",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "favorite",
                table: "tiles");
        }
    }
}
