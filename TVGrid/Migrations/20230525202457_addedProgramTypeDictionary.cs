using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVGrid.Migrations
{
    /// <inheritdoc />
    public partial class addedProgramTypeDictionary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgramTypeDictionaryId",
                table: "Program",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProgramTypeDictionary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramTypeDictionary", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Program_ProgramTypeDictionaryId",
                table: "Program",
                column: "ProgramTypeDictionaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Program_ProgramTypeDictionary_ProgramTypeDictionaryId",
                table: "Program",
                column: "ProgramTypeDictionaryId",
                principalTable: "ProgramTypeDictionary",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Program_ProgramTypeDictionary_ProgramTypeDictionaryId",
                table: "Program");

            migrationBuilder.DropTable(
                name: "ProgramTypeDictionary");

            migrationBuilder.DropIndex(
                name: "IX_Program_ProgramTypeDictionaryId",
                table: "Program");

            migrationBuilder.DropColumn(
                name: "ProgramTypeDictionaryId",
                table: "Program");
        }
    }
}
