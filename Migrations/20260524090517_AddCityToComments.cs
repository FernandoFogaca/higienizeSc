using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HigienizeMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddCityToComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Comments");
        }
    }
}
