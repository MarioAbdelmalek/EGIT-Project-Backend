using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DAL.Migrations
{
    public partial class UpdatingEGITModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPowerUser",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RemainingCPUCores",
                table: "Nodes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RemainingRAM",
                table: "Nodes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCPUCores",
                table: "Nodes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalRAM",
                table: "Nodes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientName = table.Column<string>(type: "text", nullable: true),
                    ClientSector = table.Column<string>(type: "text", nullable: true),
                    Bandwidth = table.Column<int>(type: "integer", nullable: false),
                    PublicIps = table.Column<int>(type: "integer", nullable: false),
                    VPNClients = table.Column<int>(type: "integer", nullable: false),
                    CurrentVMs = table.Column<int>(type: "integer", nullable: false),
                    TotalVMs = table.Column<int>(type: "integer", nullable: false),
                    ISPID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropColumn(
                name: "IsPowerUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RemainingCPUCores",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "RemainingRAM",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "TotalCPUCores",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "TotalRAM",
                table: "Nodes");
        }
    }
}
