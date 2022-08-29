using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdatingVMs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "StorageTotalRAM",
                table: "Storages",
                newName: "StorageTotalSpace");

            migrationBuilder.RenameColumn(
                name: "StorageRemainingRAM",
                table: "Storages",
                newName: "StorageRemainingSpace");

            migrationBuilder.RenameColumn(
                name: "LunTotalRAM",
                table: "Luns",
                newName: "LunTotalSpace");

            migrationBuilder.RenameColumn(
                name: "LunRemainingRAM",
                table: "Luns",
                newName: "LunRemainingSpace");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "StorageTotalSpace",
                table: "Storages",
                newName: "StorageTotalRAM");

            migrationBuilder.RenameColumn(
                name: "StorageRemainingSpace",
                table: "Storages",
                newName: "StorageRemainingRAM");

            migrationBuilder.RenameColumn(
                name: "LunTotalSpace",
                table: "Luns",
                newName: "LunTotalRAM");

            migrationBuilder.RenameColumn(
                name: "LunRemainingSpace",
                table: "Luns",
                newName: "LunRemainingRAM");
        }
    }
}
