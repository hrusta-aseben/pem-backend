using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hakaton.Migrations
{
    /// <inheritdoc />
    public partial class tipp2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnici_Tip_TipId",
                table: "Korisnici");

            migrationBuilder.AlterColumn<int>(
                name: "TipId",
                table: "Korisnici",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnici_Tip_TipId",
                table: "Korisnici",
                column: "TipId",
                principalTable: "Tip",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnici_Tip_TipId",
                table: "Korisnici");

            migrationBuilder.AlterColumn<int>(
                name: "TipId",
                table: "Korisnici",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnici_Tip_TipId",
                table: "Korisnici",
                column: "TipId",
                principalTable: "Tip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
