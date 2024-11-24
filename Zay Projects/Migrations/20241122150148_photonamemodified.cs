using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zay_Projects.Migrations
{
    /// <inheritdoc />
    public partial class photonamemodified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "Products",
                newName: "PhotoName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoName",
                table: "Products",
                newName: "ImgUrl");
        }
    }
}
