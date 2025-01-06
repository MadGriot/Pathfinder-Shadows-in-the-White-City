using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PathfinderSecondEdition.Migrations
{
    /// <inheritdoc />
    public partial class seeding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CharacterSheetModels",
                columns: new[] { "CharacterSheetModelId", "CurrentHP", "FirstName", "LastName", "Level", "MaxHP" },
                values: new object[,]
                {
                    { 1, 15, "Konjit", "Munaye", 1, 15 },
                    { 2, 22, "Kanandi", "Oladoyinbo", 1, 22 },
                    { 3, 14, "Cris", "Marcellus", 1, 14 },
                    { 4, 0, "Unkown", "Person", 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "AbilityScores",
                columns: new[] { "AbilityScoreId", "CharacterSheetModelId", "Charisma", "Constitution", "Dexterity", "Intelligence", "Strength", "Wisdom" },
                values: new object[,]
                {
                    { 1, 1, 10, 10, 10, 10, 10, 10 },
                    { 2, 2, 10, 10, 10, 10, 10, 10 },
                    { 3, 3, 10, 10, 10, 10, 10, 10 },
                    { 4, 4, 10, 10, 10, 10, 10, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AbilityScores",
                keyColumn: "AbilityScoreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AbilityScores",
                keyColumn: "AbilityScoreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AbilityScores",
                keyColumn: "AbilityScoreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AbilityScores",
                keyColumn: "AbilityScoreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 4);
        }
    }
}
