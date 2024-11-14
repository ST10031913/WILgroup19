using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShadowOfHisWings.Migrations
{
    public partial class AddImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Media");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Media",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Media",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Media");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Media",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
