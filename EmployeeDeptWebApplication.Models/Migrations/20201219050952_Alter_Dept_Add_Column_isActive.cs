using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDeptWebApplication.Models.Migrations
{
    public partial class Alter_Dept_Add_Column_isActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Department",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Department");
        }
    }
}
