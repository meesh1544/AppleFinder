using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppleFinder.Migrations
{
    public partial class AppleFinder : Migration
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
                name: "Membership",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(name: "First Name", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(name: "Last Name", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.ID);
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

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "ID", "Address", "Cell", "City", "Email", "First Name", "Last Name", "State", "Zip" },
                values: new object[] { 1, "19878 Maple Glade Ln", "231-357-1640", "Lake Ann", "mbeckett@nmc.edu", "Michelle", "Beckett", "MI", "49970" });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "ID", "Address", "Cell", "City", "Email", "First Name", "Last Name", "State", "Zip" },
                values: new object[] { 2, "1887 Forest Ln", "765-441-0032", "Nowhere", "hhenderson@gmail.com", "Harry", "Henderson", "Ak", "45987" });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "ID", "Address", "Cell", "City", "Email", "First Name", "Last Name", "State", "Zip" },
                values: new object[] { 3, "1887 Hop Ln", "887-995-2201", "Carrot", "bbunny43@gmail.com", "Bugs", "Bunny", "WY", "49684" });

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
                name: "Membership");

            migrationBuilder.DropTable(
                name: "Orchard");

            migrationBuilder.DropTable(
                name: "Apples");

            migrationBuilder.DropTable(
                name: "Map");
        }
    }
}
