using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportUniTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacherRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('teacherRoleId', 'преподавател', 'преподавател')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
