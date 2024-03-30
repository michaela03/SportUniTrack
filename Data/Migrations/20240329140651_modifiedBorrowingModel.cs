using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportUniTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifiedBorrowingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrowing_ApplicationUser_UserId",
                table: "Borrowing");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrowing_Equipment_EquipmentId",
                table: "Borrowing");

            migrationBuilder.DropIndex(
                name: "IX_Borrowing_EquipmentId",
                table: "Borrowing");

            migrationBuilder.DropIndex(
                name: "IX_Borrowing_UserId",
                table: "Borrowing");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Borrowing",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Borrowing",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_EquipmentId",
                table: "Borrowing",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_UserId",
                table: "Borrowing",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowing_ApplicationUser_UserId",
                table: "Borrowing",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowing_Equipment_EquipmentId",
                table: "Borrowing",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
