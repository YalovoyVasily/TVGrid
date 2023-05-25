using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVGrid.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAdvertisement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementProgram");

            migrationBuilder.DropTable(
                name: "Advertisement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisementProgram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementID = table.Column<int>(type: "int", nullable: false),
                    ProgramID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertisementProgram_Advertisement_AdvertisementID",
                        column: x => x.AdvertisementID,
                        principalTable: "Advertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertisementProgram_Program_ProgramID",
                        column: x => x.ProgramID,
                        principalTable: "Program",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementProgram_AdvertisementID",
                table: "AdvertisementProgram",
                column: "AdvertisementID");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementProgram_ProgramID",
                table: "AdvertisementProgram",
                column: "ProgramID");
        }
    }
}
