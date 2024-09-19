using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_Data.Migrations
{
    /// <inheritdoc />
    public partial class ThirteenCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormClass",
                table: "Attendance",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Attendance",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Attendance",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormClass",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Attendance");
        }
    }
}
