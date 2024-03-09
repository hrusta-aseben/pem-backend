using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hakaton.Migrations
{
    /// <inheritdoc />
    public partial class odgovori : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pitanje_Test_TestId",
                table: "Pitanje");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "Pitanje",
                newName: "LekcijaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pitanje_TestId",
                table: "Pitanje",
                newName: "IX_Pitanje_LekcijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pitanje_Lekcija_LekcijaId",
                table: "Pitanje",
                column: "LekcijaId",
                principalTable: "Lekcija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pitanje_Lekcija_LekcijaId",
                table: "Pitanje");

            migrationBuilder.RenameColumn(
                name: "LekcijaId",
                table: "Pitanje",
                newName: "TestId");

            migrationBuilder.RenameIndex(
                name: "IX_Pitanje_LekcijaId",
                table: "Pitanje",
                newName: "IX_Pitanje_TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pitanje_Test_TestId",
                table: "Pitanje",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
