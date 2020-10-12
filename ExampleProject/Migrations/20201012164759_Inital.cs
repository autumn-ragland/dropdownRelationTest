using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleProject.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    sampleInteger = table.Column<int>(nullable: false),
                    sampleString = table.Column<string>(nullable: true),
                    sampleEnumType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ItemModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: true),
                    SampleModelid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_ItemModel_Samples_SampleModelid",
                        column: x => x.SampleModelid,
                        principalTable: "Samples",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemModel_SampleModelid",
                table: "ItemModel",
                column: "SampleModelid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemModel");

            migrationBuilder.DropTable(
                name: "Samples");
        }
    }
}
