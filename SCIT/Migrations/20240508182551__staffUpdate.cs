using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCIT.Migrations
{
    /// <inheritdoc />
    public partial class _staffUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StaffName",
                table: "Staff",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Qualifications",
                table: "Staff",
                newName: "StaffType");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "Staff",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Staff",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Specializations",
                table: "Staff",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "StaffId",
                table: "Programmes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Specializations",
                table: "Staff");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Staff",
                newName: "StaffName");

            migrationBuilder.RenameColumn(
                name: "StaffType",
                table: "Staff",
                newName: "Qualifications");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "Staff",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StaffId",
                table: "Programmes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }
    }
}
