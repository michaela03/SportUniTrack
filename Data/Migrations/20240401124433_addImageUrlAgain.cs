using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportUniTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class addImageUrlAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Sport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Sport");
        }
    }
}
