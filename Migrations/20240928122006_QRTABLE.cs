using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_Data.Migrations
{
    /// <inheritdoc />
    public partial class QRTABLE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScannedAt",
                table: "QRCodes",
                newName: "TimeOut");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "QRCodes",
                newName: "TimeIn");

            migrationBuilder.AddColumn<string>(
                name: "DateScan",
                table: "QRCodes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FormClass",
                table: "QRCodes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Present",
                table: "QRCodes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SId",
                table: "QRCodes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateScan",
                table: "QRCodes");

            migrationBuilder.DropColumn(
                name: "FormClass",
                table: "QRCodes");

            migrationBuilder.DropColumn(
                name: "Present",
                table: "QRCodes");

            migrationBuilder.DropColumn(
                name: "SId",
                table: "QRCodes");

            migrationBuilder.RenameColumn(
                name: "TimeOut",
                table: "QRCodes",
                newName: "ScannedAt");

            migrationBuilder.RenameColumn(
                name: "TimeIn",
                table: "QRCodes",
                newName: "Data");
        }
    }
}
