using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealState.Migrations
{
    public partial class TransactionTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Transactions",
                newName: "Date");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Transactions",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Transactions",
                newName: "DateTime");
        }
    }
}
