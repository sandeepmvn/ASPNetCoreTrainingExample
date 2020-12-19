using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDeptWebApplication.Models.Migrations
{
    public partial class remove_isactive_from_dept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Department");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Department",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
