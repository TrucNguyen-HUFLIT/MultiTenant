using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiTenant.Data.Migrations
{
    public partial class CreateMultiTenantDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataConnectionString",
                table: "Tenants");

            migrationBuilder.RenameColumn(
                name: "TenantName",
                table: "Tenants",
                newName: "DbName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DbName",
                table: "Tenants",
                newName: "TenantName");

            migrationBuilder.AddColumn<string>(
                name: "DataConnectionString",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
