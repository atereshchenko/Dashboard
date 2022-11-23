using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Dashboard.Migrations
{
	public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "csscolors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_csscolors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    link = table.Column<string>(type: "text", nullable: true),
                    link_name = table.Column<string>(type: "text", nullable: true),
                    turn_on = table.Column<bool>(type: "boolean", nullable: false),
                    text_color_id = table.Column<int>(type: "integer", nullable: false),
                    border_color_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiles", x => x.id);
                    table.ForeignKey(
                        name: "FK_tiles_csscolors_border_color_id",
                        column: x => x.border_color_id,
                        principalTable: "csscolors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tiles_csscolors_text_color_id",
                        column: x => x.text_color_id,
                        principalTable: "csscolors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    role_id = table.Column<int>(type: "integer", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "csscolors",
                columns: new[] { "id", "value" },
                values: new object[,]
                {
                    { 1, "primary" },
                    { 2, "secondary" },
                    { 3, "success" },
                    { 4, "danger" },
                    { 5, "warning" },
                    { 6, "light" },
                    { 7, "dark" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "tiles",
                columns: new[] { "id", "border_color_id", "description", "link", "link_name", "name", "number", "text_color_id", "turn_on" },
                values: new object[,]
                {
                    { 1, 2, "описание плитки", "http://localhost", "Перейти", "Плитка 1", 1, 1, true },
                    { 2, 2, "описание плитки", "http://localhost", "Перейти", "Плитка 2", 2, 1, true },
                    { 3, 2, "описание плитки", "http://localhost", "Перейти", "Плитка 3", 3, 1, true },
                    { 4, 2, "описание плитки", "http://localhost", "Перейти", "Плитка 4", 4, 1, true },
                    { 5, 2, "описание плитки", "http://localhost", "Перейти", "Плитка 5", 5, 1, true }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "is_active", "name", "password", "role_id" },
                values: new object[] { 1, "admin@dashboard.com", true, "Администратор", "92AB2C1C8F150F5EDFBA5DB5F640FB47", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_tiles_border_color_id",
                table: "tiles",
                column: "border_color_id");

            migrationBuilder.CreateIndex(
                name: "IX_tiles_text_color_id",
                table: "tiles",
                column: "text_color_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                table: "users",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tiles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "csscolors");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
