using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hakaton.Migrations
{
    /// <inheritdoc />
    public partial class Vizuelni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vizuelni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LekcijaId = table.Column<int>(type: "int", nullable: false),
                    LinkSlike = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vizuelni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vizuelni_Lekcija_LekcijaId",
                        column: x => x.LekcijaId,
                        principalTable: "Lekcija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vizuelni_LekcijaId",
                table: "Vizuelni",
                column: "LekcijaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vizuelni");
        }
    }
}
