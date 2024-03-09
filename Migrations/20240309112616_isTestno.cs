using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hakaton.Migrations
{
    /// <inheritdoc />
    public partial class isTestno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isTestno",
                table: "Pitanje",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isTestno",
                table: "Pitanje");
        }
    }
}
