using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecisiveApp.Migrations
{
    /// <inheritdoc />
    public partial class Tenant_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    storagequota = table.Column<int>(type: "int", nullable: false),
                    workstationquota = table.Column<int>(type: "int", nullable: false),
                    virtualmachinequota = table.Column<int>(type: "int", nullable: false),
                    serverquota = table.Column<int>(type: "int", nullable: false),
                    M365seats = table.Column<int>(type: "int", nullable: false),
                    GWseats = table.Column<int>(type: "int", nullable: false),
                    ABWorkstations = table.Column<int>(type: "int", nullable: false),
                    ABServers = table.Column<int>(type: "int", nullable: false),
                    ABVirtualmachines = table.Column<int>(type: "int", nullable: false),
                    ADSecurity = table.Column<int>(type: "int", nullable: false),
                    ADEmailSecurity = table.Column<int>(type: "int", nullable: false),
                    CloudStorage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
