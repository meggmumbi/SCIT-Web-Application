using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCIT.Migrations
{
    /// <inheritdoc />
    public partial class _ApplicationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "ProgrammeApplications");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "ProgrammeApplications");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "ProgrammeApplications");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "ProgrammeApplications");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "ProgrammeApplications",
                newName: "Religion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Religion",
                table: "ProgrammeApplications",
                newName: "Region");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "ProgrammeApplications",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "ProgrammeApplications",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "ProgrammeApplications",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "ProgrammeApplications",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
