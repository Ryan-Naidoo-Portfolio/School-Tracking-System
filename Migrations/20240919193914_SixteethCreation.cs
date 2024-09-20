using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_Data.Migrations
{
    /// <inheritdoc />
    public partial class SixteethCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Account_Username",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "FormClass",
                table: "Attendance");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Teacher",
                newName: "tSurname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teacher",
                newName: "tName");

            migrationBuilder.RenameColumn(
                name: "FormClass",
                table: "Teacher",
                newName: "tFormClass");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teacher",
                newName: "tID");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Parents",
                newName: "sID");

            migrationBuilder.RenameColumn(
                name: "SpousePhoneNumber",
                table: "Parents",
                newName: "pSpousePhoneNumber");

            migrationBuilder.RenameColumn(
                name: "SpouseName",
                table: "Parents",
                newName: "pSurname");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Parents",
                newName: "pPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Parents",
                newName: "pSpouseName");

            migrationBuilder.RenameColumn(
                name: "EmergencyContactPhoneNumber",
                table: "Parents",
                newName: "pEmergencyPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "EmergencyContactName",
                table: "Parents",
                newName: "pName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Parents",
                newName: "pID");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Child",
                newName: "sSurname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Child",
                newName: "sQrcode");

            migrationBuilder.RenameColumn(
                name: "FormClass",
                table: "Child",
                newName: "sName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Child",
                newName: "sID");

            migrationBuilder.RenameColumn(
                name: "TimeOut",
                table: "Attendance",
                newName: "sID");

            migrationBuilder.RenameColumn(
                name: "TimeIn",
                table: "Attendance",
                newName: "atTimeOut");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Attendance",
                newName: "atTimeIn");

            migrationBuilder.RenameColumn(
                name: "Present",
                table: "Attendance",
                newName: "atPresent");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Attendance",
                newName: "atDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Attendance",
                newName: "atID");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Admin",
                newName: "acID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Admin",
                newName: "aSurname");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admin",
                newName: "aID");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Account",
                newName: "tID");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Account",
                newName: "pID");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Account",
                newName: "acUsername");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Account",
                newName: "acID");

            migrationBuilder.AddColumn<string>(
                name: "acID",
                table: "Teacher",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "acID",
                table: "Parents",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pEmergencyContactName",
                table: "Parents",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "atID",
                table: "Child",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pID",
                table: "Child",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sFormClass",
                table: "Child",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "aName",
                table: "Admin",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "aID",
                table: "Account",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "acPassword",
                table: "Account",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "acPosition",
                table: "Account",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Account_acUsername",
                table: "Account",
                column: "acUsername",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Account_acUsername",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "acID",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "acID",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "pEmergencyContactName",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "atID",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "pID",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "sFormClass",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "aName",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "aID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "acPassword",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "acPosition",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "tSurname",
                table: "Teacher",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "tName",
                table: "Teacher",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "tFormClass",
                table: "Teacher",
                newName: "FormClass");

            migrationBuilder.RenameColumn(
                name: "tID",
                table: "Teacher",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "sID",
                table: "Parents",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "pSurname",
                table: "Parents",
                newName: "SpouseName");

            migrationBuilder.RenameColumn(
                name: "pSpousePhoneNumber",
                table: "Parents",
                newName: "SpousePhoneNumber");

            migrationBuilder.RenameColumn(
                name: "pSpouseName",
                table: "Parents",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "pPhoneNumber",
                table: "Parents",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "pName",
                table: "Parents",
                newName: "EmergencyContactName");

            migrationBuilder.RenameColumn(
                name: "pEmergencyPhoneNumber",
                table: "Parents",
                newName: "EmergencyContactPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "pID",
                table: "Parents",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "sSurname",
                table: "Child",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "sQrcode",
                table: "Child",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "sName",
                table: "Child",
                newName: "FormClass");

            migrationBuilder.RenameColumn(
                name: "sID",
                table: "Child",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "sID",
                table: "Attendance",
                newName: "TimeOut");

            migrationBuilder.RenameColumn(
                name: "atTimeOut",
                table: "Attendance",
                newName: "TimeIn");

            migrationBuilder.RenameColumn(
                name: "atTimeIn",
                table: "Attendance",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "atPresent",
                table: "Attendance",
                newName: "Present");

            migrationBuilder.RenameColumn(
                name: "atDate",
                table: "Attendance",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "atID",
                table: "Attendance",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "acID",
                table: "Admin",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "aSurname",
                table: "Admin",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "aID",
                table: "Admin",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tID",
                table: "Account",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "pID",
                table: "Account",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "acUsername",
                table: "Account",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "acID",
                table: "Account",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Attendance",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FormClass",
                table: "Attendance",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Account_Username",
                table: "Account",
                column: "Username",
                unique: true);
        }
    }
}
