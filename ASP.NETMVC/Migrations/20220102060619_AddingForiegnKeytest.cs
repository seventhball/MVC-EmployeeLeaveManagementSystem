using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETMVC.Migrations
{
    public partial class AddingForiegnKeytest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmpId",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "EmployeeleaveId",
                table: "AppliedEmpLeaves",
                newName: "EmployeeLeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeaves_EmployeeId",
                table: "EmployeeLeaves",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeaves_Employees_EmployeeId",
                table: "EmployeeLeaves",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeaves_Employees_EmployeeId",
                table: "EmployeeLeaves");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeLeaves_EmployeeId",
                table: "EmployeeLeaves");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "EmpId");

            migrationBuilder.RenameColumn(
                name: "EmployeeLeaveId",
                table: "AppliedEmpLeaves",
                newName: "EmployeeleaveId");
        }
    }
}
