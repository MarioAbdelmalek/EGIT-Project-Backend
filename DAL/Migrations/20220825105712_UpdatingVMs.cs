using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdatingVMs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CpuCores",
                table: "VMs",
                newName: "CPUCores");

            migrationBuilder.AddColumn<int>(
                name: "Storage",
                table: "VMs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Storage",
                table: "VMs");

            migrationBuilder.RenameColumn(
                name: "CPUCores",
                table: "VMs",
                newName: "CpuCores");
        }
    }
}
