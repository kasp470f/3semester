using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class dd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartcipantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    runnerNamber = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participants", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "participants");
        }
    }
}
