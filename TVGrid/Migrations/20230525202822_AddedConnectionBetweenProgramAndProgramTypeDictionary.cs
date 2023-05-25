using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVGrid.Migrations
{
    /// <inheritdoc />
    public partial class AddedConnectionBetweenProgramAndProgramTypeDictionary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Program_ProgramTypeDictionary_ProgramTypeDictionaryId",
                table: "Program");

            migrationBuilder.RenameColumn(
                name: "ProgramTypeDictionaryId",
                table: "Program",
                newName: "ProgramTypeDictionaryID");

            migrationBuilder.RenameIndex(
                name: "IX_Program_ProgramTypeDictionaryId",
                table: "Program",
                newName: "IX_Program_ProgramTypeDictionaryID");

            migrationBuilder.AlterColumn<int>(
                name: "ProgramTypeDictionaryID",
                table: "Program",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Program_ProgramTypeDictionary_ProgramTypeDictionaryID",
                table: "Program",
                column: "ProgramTypeDictionaryID",
                principalTable: "ProgramTypeDictionary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Program_ProgramTypeDictionary_ProgramTypeDictionaryID",
                table: "Program");

            migrationBuilder.RenameColumn(
                name: "ProgramTypeDictionaryID",
                table: "Program",
                newName: "ProgramTypeDictionaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Program_ProgramTypeDictionaryID",
                table: "Program",
                newName: "IX_Program_ProgramTypeDictionaryId");

            migrationBuilder.AlterColumn<int>(
                name: "ProgramTypeDictionaryId",
                table: "Program",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Program_ProgramTypeDictionary_ProgramTypeDictionaryId",
                table: "Program",
                column: "ProgramTypeDictionaryId",
                principalTable: "ProgramTypeDictionary",
                principalColumn: "Id");
        }
    }
}
