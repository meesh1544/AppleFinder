using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppleFinder.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apples",
                columns: table => new
                {
                    ApplesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apples", x => x.ApplesID);
                });

            migrationBuilder.CreateTable(
                name: "Map",
                columns: table => new
                {
                    MapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.MapID);
                });

            migrationBuilder.CreateTable(
                name: "Orchard",
                columns: table => new
                {
                    OrchardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapID = table.Column<int>(type: "int", nullable: false),
                    ApplesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orchard", x => x.OrchardId);
                    table.ForeignKey(
                        name: "FK_Orchard_Apples_ApplesID",
                        column: x => x.ApplesID,
                        principalTable: "Apples",
                        principalColumn: "ApplesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orchard_Map_MapID",
                        column: x => x.MapID,
                        principalTable: "Map",
                        principalColumn: "MapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orchard_ApplesID",
                table: "Orchard",
                column: "ApplesID");

            migrationBuilder.CreateIndex(
                name: "IX_Orchard_MapID",
                table: "Orchard",
                column: "MapID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orchard");

            migrationBuilder.DropTable(
                name: "Apples");

            migrationBuilder.DropTable(
                name: "Map");
        }
    }
}
