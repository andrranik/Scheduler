using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scheduler.DataBase.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    LastRunTime = table.Column<DateTime>(nullable: false),
                    Interval = table.Column<float>(nullable: false),
                    IntervalType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkItems");
        }
    }
}
