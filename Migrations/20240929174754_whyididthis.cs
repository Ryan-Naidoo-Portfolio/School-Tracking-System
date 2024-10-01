using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_Data.Migrations
{
    /// <inheritdoc />
    public partial class whyididthis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateScan",
                table: "Child",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Present",
                table: "Child",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeIn",
                table: "Child",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeOut",
                table: "Child",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateScan",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "Present",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "TimeIn",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "TimeOut",
                table: "Child");
        }
    }
}
