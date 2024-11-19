using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShadowOfHisWings.Migrations
{
    public partial class AddContactEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Contacts",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Contacts",
                newName: "SubmittedOn");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contacts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Contacts",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "SubmittedOn",
                table: "Contacts",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Contacts",
                newName: "Surname");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
