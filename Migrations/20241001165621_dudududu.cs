using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_Data.Migrations
{
    /// <inheritdoc />
    public partial class dudududu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "pID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "tID",
                table: "Account");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "aID",
                table: "Account",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pID",
                table: "Account",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tID",
                table: "Account",
                type: "TEXT",
                nullable: true);
        }
    }
}
