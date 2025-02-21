using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_PRO.Migrations
{
    /// <inheritdoc />
    public partial class updatefile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Filepath",
                table: "Files",
                newName: "FilePath");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Files",
                newName: "Filepath");
        }
    }
}
