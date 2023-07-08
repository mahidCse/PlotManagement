using Microsoft.EntityFrameworkCore.Migrations;

namespace RealState.Migrations
{
    public partial class TableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Plots");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Blocks");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Blocks",
                newName: "Thana");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Thana",
                table: "Blocks",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Plots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Blocks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
