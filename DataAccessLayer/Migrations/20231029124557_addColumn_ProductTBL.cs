using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addColumn_ProductTBL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl1",
                table: "BannerPictures");

            migrationBuilder.RenameColumn(
                name: "PictureUrl2",
                table: "BannerPictures",
                newName: "PictureUrl");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "BannerPictures",
                newName: "PictureUrl2");

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl1",
                table: "BannerPictures",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
