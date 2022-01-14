using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETMVC.Migrations
{
    public partial class updateForeignKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppliedEmpLeaves_EmployeeLeaveId",
                table: "AppliedEmpLeaves",
                column: "EmployeeLeaveId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppliedEmpLeaves_EmployeeLeaves_EmployeeLeaveId",
                table: "AppliedEmpLeaves",
                column: "EmployeeLeaveId",
                principalTable: "EmployeeLeaves",
                principalColumn: "EmployeeLeaveId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppliedEmpLeaves_EmployeeLeaves_EmployeeLeaveId",
                table: "AppliedEmpLeaves");

            migrationBuilder.DropIndex(
                name: "IX_AppliedEmpLeaves_EmployeeLeaveId",
                table: "AppliedEmpLeaves");
        }
    }
}
