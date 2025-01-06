using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PathfinderSecondEdition.Configurations
{
    internal class AbilityScoreConfiguration : IEntityTypeConfiguration<AbilityScore>
    {
        public void Configure(EntityTypeBuilder<AbilityScore> builder)
        {
            builder.HasData(
                new AbilityScore
                {
                    AbilityScoreId = 1,
                    CharacterSheetId = 1,
                    Strength = 10,
                    Constitution = 10,
                    Dexterity = 10,
                    Wisdom = 10,
                    Intelligence = 10,
                    Charisma = 10,
                },
                new AbilityScore
                {
                    AbilityScoreId = 2,
                    CharacterSheetId = 2,
                    Strength = 10,
                    Constitution = 10,
                    Dexterity = 10,
                    Wisdom = 10,
                    Intelligence = 10,
                    Charisma = 10,
                },
                new AbilityScore
                {
                    AbilityScoreId = 3,
                    CharacterSheetId = 3,
                    Strength = 10,
                    Constitution = 10,
                    Dexterity = 10,
                    Wisdom = 10,
                    Intelligence = 10,
                    Charisma = 10,
                },
                new AbilityScore
                {
                    AbilityScoreId = 4,
                    CharacterSheetId = 4,
                    Strength = 10,
                    Constitution = 10,
                    Dexterity = 10,
                    Wisdom = 10,
                    Intelligence = 10,
                    Charisma = 10,
                }
            );
        }
    }
}
