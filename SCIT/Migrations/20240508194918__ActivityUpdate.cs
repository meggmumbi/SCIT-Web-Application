using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCIT.Migrations
{
    /// <inheritdoc />
    public partial class _ActivityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Activities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Activities",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
