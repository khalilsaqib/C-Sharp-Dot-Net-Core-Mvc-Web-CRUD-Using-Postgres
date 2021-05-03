using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.NetPostgresCrud.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "varchar(100)",
                table: "Employees",
                newName: "OfficeLocation");

            migrationBuilder.RenameColumn(
                name: "nvarchar(250)",
                table: "Employees",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "varchar(10)",
                table: "Employees",
                newName: "EmpCode");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "OfficeLocation",
                table: "Employees",
                newName: "varchar(100)");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Employees",
                newName: "nvarchar(250)");

            migrationBuilder.RenameColumn(
                name: "EmpCode",
                table: "Employees",
                newName: "varchar(10)");
        }
    }
}
