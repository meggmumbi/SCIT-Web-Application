using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCIT.Migrations
{
    /// <inheritdoc />
    public partial class _ActivityImageUpload1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageData",
                table: "Activities",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Activities",
                newName: "ImageData");
        }
    }
}
