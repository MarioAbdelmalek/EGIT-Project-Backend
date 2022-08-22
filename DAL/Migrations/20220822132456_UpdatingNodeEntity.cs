using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdatingNodeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalRAM",
                table: "Nodes",
                newName: "NodeTotalRAM");

            migrationBuilder.RenameColumn(
                name: "TotalCPUCores",
                table: "Nodes",
                newName: "NodeTotalCPUCores");

            migrationBuilder.RenameColumn(
                name: "RemainingRAM",
                table: "Nodes",
                newName: "NodeRemainingRAM");

            migrationBuilder.RenameColumn(
                name: "RemainingCPUCores",
                table: "Nodes",
                newName: "NodeRemainingCPUCores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NodeTotalRAM",
                table: "Nodes",
                newName: "TotalRAM");

            migrationBuilder.RenameColumn(
                name: "NodeTotalCPUCores",
                table: "Nodes",
                newName: "TotalCPUCores");

            migrationBuilder.RenameColumn(
                name: "NodeRemainingRAM",
                table: "Nodes",
                newName: "RemainingRAM");

            migrationBuilder.RenameColumn(
                name: "NodeRemainingCPUCores",
                table: "Nodes",
                newName: "RemainingCPUCores");
        }
    }
}
