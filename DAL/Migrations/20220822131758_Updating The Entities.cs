using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdatingTheEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NodeName",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "NodeType",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "LunType",
                table: "Luns");

            migrationBuilder.DropColumn(
                name: "ClusterName",
                table: "Clusters");

            migrationBuilder.DropColumn(
                name: "Bandwidth",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CurrentVMs",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PublicIps",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "TotalVMs",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "VPNClients",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "StorageTSpace",
                table: "Storages",
                newName: "StorageTotalRAM");

            migrationBuilder.RenameColumn(
                name: "StorageRSpace",
                table: "Storages",
                newName: "StorageRemainingRAM");

            migrationBuilder.RenameColumn(
                name: "LunTSpace",
                table: "Luns",
                newName: "LunTotalRAM");

            migrationBuilder.RenameColumn(
                name: "LunRSpace",
                table: "Luns",
                newName: "LunRemainingRAM");

            migrationBuilder.AddColumn<int>(
                name: "ClusterRemainingCPUCores",
                table: "Clusters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClusterRemainingRAM",
                table: "Clusters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClusterTotalCPUCores",
                table: "Clusters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClusterTotalRAM",
                table: "Clusters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfNodes",
                table: "Clusters",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClusterRemainingCPUCores",
                table: "Clusters");

            migrationBuilder.DropColumn(
                name: "ClusterRemainingRAM",
                table: "Clusters");

            migrationBuilder.DropColumn(
                name: "ClusterTotalCPUCores",
                table: "Clusters");

            migrationBuilder.DropColumn(
                name: "ClusterTotalRAM",
                table: "Clusters");

            migrationBuilder.DropColumn(
                name: "NumberOfNodes",
                table: "Clusters");

            migrationBuilder.RenameColumn(
                name: "StorageTotalRAM",
                table: "Storages",
                newName: "StorageTSpace");

            migrationBuilder.RenameColumn(
                name: "StorageRemainingRAM",
                table: "Storages",
                newName: "StorageRSpace");

            migrationBuilder.RenameColumn(
                name: "LunTotalRAM",
                table: "Luns",
                newName: "LunTSpace");

            migrationBuilder.RenameColumn(
                name: "LunRemainingRAM",
                table: "Luns",
                newName: "LunRSpace");

            migrationBuilder.AddColumn<string>(
                name: "NodeName",
                table: "Nodes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NodeType",
                table: "Nodes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LunType",
                table: "Luns",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClusterName",
                table: "Clusters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bandwidth",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentVMs",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PublicIps",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalVMs",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VPNClients",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
