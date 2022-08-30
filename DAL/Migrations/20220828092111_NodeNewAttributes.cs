using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class NodeNewAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NodeName",
                table: "Nodes",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NodeName",
                table: "Nodes");
        }
    }
}
