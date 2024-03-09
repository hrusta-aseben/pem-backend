using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hakaton.Migrations
{
    /// <inheritdoc />
    public partial class bodovi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bodovi",
                table: "Pitanje",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bodovi",
                table: "Pitanje");
        }
    }
}
