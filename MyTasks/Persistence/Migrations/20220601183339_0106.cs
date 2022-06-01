using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTasks.Data.Migrations
{
    public partial class _0106 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Tasks");

            migrationBuilder.AddColumn<DateTime>(
                name: "Term",
                table: "Tasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Term",
                table: "Tasks");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Tasks",
                type: "datetime2",
                nullable: true);
        }
    }
}
