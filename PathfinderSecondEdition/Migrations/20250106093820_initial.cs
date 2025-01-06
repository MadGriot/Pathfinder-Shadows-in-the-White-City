using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PathfinderSecondEdition.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterSheetModels",
                columns: table => new
                {
                    CharacterSheetModelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentHP = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxHP = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheetModels", x => x.CharacterSheetModelId);
                });

            migrationBuilder.CreateTable(
                name: "AbilityScores",
                columns: table => new
                {
                    AbilityScoreId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Strength = table.Column<int>(type: "INTEGER", nullable: false),
                    Dexterity = table.Column<int>(type: "INTEGER", nullable: false),
                    Constitution = table.Column<int>(type: "INTEGER", nullable: false),
                    Intelligence = table.Column<int>(type: "INTEGER", nullable: false),
                    Wisdom = table.Column<int>(type: "INTEGER", nullable: false),
                    Charisma = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterSheetModelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityScores", x => x.AbilityScoreId);
                    table.ForeignKey(
                        name: "FK_AbilityScores_CharacterSheetModels_CharacterSheetModelId",
                        column: x => x.CharacterSheetModelId,
                        principalTable: "CharacterSheetModels",
                        principalColumn: "CharacterSheetModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbilityScores_CharacterSheetModelId",
                table: "AbilityScores",
                column: "CharacterSheetModelId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityScores");

            migrationBuilder.DropTable(
                name: "CharacterSheetModels");
        }
    }
}
