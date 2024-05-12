using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCIT.Migrations
{
    /// <inheritdoc />
    public partial class _ActivityImageUpload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Activities",
                type: "bytea",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Activities");
        }
    }
}
