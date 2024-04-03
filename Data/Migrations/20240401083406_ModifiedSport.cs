using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportUniTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedSport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sport_Sport_SportId",
                table: "Sport");

            migrationBuilder.DropIndex(
                name: "IX_Sport_SportId",
                table: "Sport");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "Sport");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Sport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rules",
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

            migrationBuilder.DropColumn(
                name: "Rules",
                table: "Sport");

            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "Sport",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sport_SportId",
                table: "Sport",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sport_Sport_SportId",
                table: "Sport",
                column: "SportId",
                principalTable: "Sport",
                principalColumn: "Id");
        }
    }
}
