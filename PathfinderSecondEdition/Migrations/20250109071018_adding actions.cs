using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PathfinderSecondEdition.Migrations
{
    /// <inheritdoc />
    public partial class addingactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathfinderActions",
                table: "CharacterSheetModels",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 1,
                column: "PathfinderActions",
                value: null);

            migrationBuilder.UpdateData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 2,
                column: "PathfinderActions",
                value: null);

            migrationBuilder.UpdateData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 3,
                column: "PathfinderActions",
                value: null);

            migrationBuilder.UpdateData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 4,
                column: "PathfinderActions",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathfinderActions",
                table: "CharacterSheetModels");
        }
    }
}
