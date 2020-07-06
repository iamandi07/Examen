using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen.Migrations
{
    public partial class Equipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    EquipementType = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    CalibrationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");
        }
    }
}
