using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiTenant.Data.Migrations.MultiTenant
{
    public partial class CreateMultiTenantDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Accounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
