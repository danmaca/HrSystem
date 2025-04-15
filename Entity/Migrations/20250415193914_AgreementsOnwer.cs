using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanM.HrSystem.Entity.Migrations
{
    /// <inheritdoc />
    public partial class AgreementsOnwer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerEmployeeId",
                table: "Agreement",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agreement_OwnerEmployeeId",
                table: "Agreement",
                column: "OwnerEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agreement_Employee_OwnerEmployeeId",
                table: "Agreement",
                column: "OwnerEmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agreement_Employee_OwnerEmployeeId",
                table: "Agreement");

            migrationBuilder.DropIndex(
                name: "IX_Agreement_OwnerEmployeeId",
                table: "Agreement");

            migrationBuilder.DropColumn(
                name: "OwnerEmployeeId",
                table: "Agreement");
        }
    }
}
