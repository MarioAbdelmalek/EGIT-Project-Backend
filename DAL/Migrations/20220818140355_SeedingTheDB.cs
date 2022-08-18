using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SeedingTheDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LunStorage",
                table: "Luns",
                newName: "LunTSpace");

            migrationBuilder.AddColumn<int>(
                name: "LunRSpace",
                table: "Luns",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LunType",
                table: "Luns",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "FirstName", "HomeAddress", "IsAdmin", "IsPowerUser", "LastName", "PassportNumber", "Password", "PhoneNumber", "UserName" },
                values: new object[] { 1, "mario.abdelmalek7@gmail.com", "Mario", "20 El Nozha Street", true, true, "Abdelmalek", "0933478", "Abdelmalek_2000", "01273615172", "Mario_Abdelmalek" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "LunRSpace",
                table: "Luns");

            migrationBuilder.DropColumn(
                name: "LunType",
                table: "Luns");

            migrationBuilder.RenameColumn(
                name: "LunTSpace",
                table: "Luns",
                newName: "LunStorage");
        }
    }
}
