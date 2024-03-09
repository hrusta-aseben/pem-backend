using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hakaton.Migrations
{
    /// <inheritdoc />
    public partial class tip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipId",
                table: "Korisnici",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_TipId",
                table: "Korisnici",
                column: "TipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnici_Tip_TipId",
                table: "Korisnici",
                column: "TipId",
                principalTable: "Tip",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnici_Tip_TipId",
                table: "Korisnici");

            migrationBuilder.DropTable(
                name: "Tip");

            migrationBuilder.DropIndex(
                name: "IX_Korisnici_TipId",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "TipId",
                table: "Korisnici");
        }
    }
}
