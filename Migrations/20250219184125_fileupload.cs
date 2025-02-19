using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_PRO.Migrations
{
    /// <inheritdoc />
    public partial class fileupload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "filepath",
                table: "Subject",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "filepath",
                table: "Subject");
        }
    }
}
