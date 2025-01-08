using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PathfinderSecondEdition.Migrations
{
    /// <inheritdoc />
    public partial class addingSpeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "CharacterSheetModels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 1,
                column: "Speed",
                value: 30);

            migrationBuilder.UpdateData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 2,
                column: "Speed",
                value: 25);

            migrationBuilder.UpdateData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 3,
                column: "Speed",
                value: 25);

            migrationBuilder.UpdateData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 4,
                column: "Speed",
                value: 25);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Speed",
                table: "CharacterSheetModels");
        }
    }
}
