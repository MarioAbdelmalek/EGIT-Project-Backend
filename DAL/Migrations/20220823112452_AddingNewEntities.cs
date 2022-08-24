using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DAL.Migrations
{
    public partial class AddingNewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VMs",
                columns: table => new
                {
                    VMID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CpuCores = table.Column<int>(type: "integer", nullable: false),
                    RAM = table.Column<int>(type: "integer", nullable: false),
                    IP = table.Column<string>(type: "text", nullable: true),
                    Bandwidth = table.Column<int>(type: "integer", nullable: false),
                    ClientID = table.Column<int>(type: "integer", nullable: false),
                    NodeID = table.Column<int>(type: "integer", nullable: false),
                    LunID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VMs", x => x.VMID);
                    table.ForeignKey(
                        name: "FK_VMs_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VMs_Luns_LunID",
                        column: x => x.LunID,
                        principalTable: "Luns",
                        principalColumn: "LunID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VMs_Nodes_NodeID",
                        column: x => x.NodeID,
                        principalTable: "Nodes",
                        principalColumn: "NodeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vpns",
                columns: table => new
                {
                    VpnID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    ClientID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vpns", x => x.VpnID);
                    table.ForeignKey(
                        name: "FK_Vpns_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VMs_ClientID",
                table: "VMs",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_VMs_LunID",
                table: "VMs",
                column: "LunID");

            migrationBuilder.CreateIndex(
                name: "IX_VMs_NodeID",
                table: "VMs",
                column: "NodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Vpns_ClientID",
                table: "Vpns",
                column: "ClientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VMs");

            migrationBuilder.DropTable(
                name: "Vpns");
        }
    }
}
