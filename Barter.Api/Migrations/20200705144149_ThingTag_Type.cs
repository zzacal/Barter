using Microsoft.EntityFrameworkCore.Migrations;

namespace Barter.Api.Migrations
{
    public partial class ThingTag_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: false),
                    ThingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Title);
                    table.ForeignKey(
                        name: "FK_Tag_Thing_ThingId",
                        column: x => x.ThingId,
                        principalTable: "Thing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ThingId",
                table: "Tag",
                column: "ThingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
