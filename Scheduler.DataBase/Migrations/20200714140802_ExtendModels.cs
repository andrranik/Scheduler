using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scheduler.DataBase.Migrations
{
    public partial class ExtendModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "WorkItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastRunTime",
                table: "WorkItems",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "IntervalType",
                table: "WorkItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "Interval",
                table: "WorkItems",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "ExecutionType",
                table: "WorkItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExecutionType",
                table: "WorkItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastRunTime",
                table: "WorkItems",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IntervalType",
                table: "WorkItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Interval",
                table: "WorkItems",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "WorkItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
