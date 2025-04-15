using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanM.HrSystem.Entity.Migrations
{
    /// <inheritdoc />
    public partial class AgreementsValid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "ValidFrom",
                table: "Agreement",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "ValidTo",
                table: "Agreement",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "Agreement");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "Agreement");
        }
    }
}
