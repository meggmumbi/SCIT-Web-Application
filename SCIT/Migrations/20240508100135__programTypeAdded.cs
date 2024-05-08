using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCIT.Migrations
{
    /// <inheritdoc />
    public partial class _programTypeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProgrammeType",
                table: "Programmes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgrammeType",
                table: "Programmes");
        }
    }
}
