using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiTenant.Data.Migrations
{
    public partial class CreateMultiTenantDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubDomain",
                table: "Tenants",
                newName: "URL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "URL",
                table: "Tenants",
                newName: "SubDomain");
        }
    }
}
