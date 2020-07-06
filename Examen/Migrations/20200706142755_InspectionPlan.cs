using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen.Migrations
{
    public partial class InspectionPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InspectionPlans",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Temperature = table.Column<int>(nullable: false),
                    Humidity = table.Column<int>(nullable: false),
                    Pressure = table.Column<int>(nullable: false),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionPlans_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionPlans_PersonId",
                table: "InspectionPlans",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionPlans");
        }
    }
}
