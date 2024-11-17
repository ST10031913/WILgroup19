using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShadowOfHisWings.Migrations
{
    public partial class UploadMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Media",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Media");
        }
    }
}
