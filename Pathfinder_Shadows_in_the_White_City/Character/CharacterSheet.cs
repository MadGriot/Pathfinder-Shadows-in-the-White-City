using PathfinderSecondEdition;
using PathfinderSecondEdition.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinder_Shadows_in_the_White_City.Character
{
    internal class CharacterSheet
    {
        private int CharacterId;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public int Strength { get; set; }
        public int StrengthModifier { get; set; }
        public int Dexterity { get; set; }
        public int DexterityModifier { get; set; }

        public int Constitution { get; set; }
        public int ConstitutionModifier { get; set; }
        public int Intelligence { get; set; }
        public int IntelligenceModifier { get; set; }
        public int Wisdom { get; set; }
        public int WisdomModifier { get; set; }
        public int Charisma { get; set; }
        public int CharismaModifier { get; set; }

        public CharacterSheet(int characterId)
        {
            CharacterSheetDbContext context = new CharacterSheetDbContext();
            CharacterId = characterId;
            CharacterSheetModel character = context.CharacterSheetModels
                .First(x => x.CharacterSheetModelId == characterId);
            AbilityScore abilityScore = context.AbilityScores
                .First(x => x.AbilityScoreId == characterId);
            FirstName = character.FirstName;
            LastName = character.LastName;
            CurrentHP = character.CurrentHP;
            MaxHP = character.MaxHP;
            Strength = abilityScore.Strength;
            StrengthModifier = Modifier.AttributeModifier(Strength);

            Dexterity = abilityScore.Dexterity;
            DexterityModifier = Modifier.AttributeModifier(Dexterity);

            Constitution = abilityScore.Constitution;
            ConstitutionModifier = Modifier.AttributeModifier(Constitution);

            Intelligence = abilityScore.Intelligence;
            IntelligenceModifier = Modifier.AttributeModifier(Intelligence);

            Wisdom = abilityScore.Wisdom;
            WisdomModifier = Modifier.AttributeModifier(Wisdom);

            Charisma = abilityScore.Charisma;
            CharismaModifier = Modifier.AttributeModifier(Charisma);
        }
    }
}
