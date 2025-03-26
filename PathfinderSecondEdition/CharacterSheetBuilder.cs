
using PathfinderSecondEdition.Actions;

namespace PathfinderSecondEdition
{
    public class CharacterSheetBuilder
    {
        private readonly CharacterSheet characterSheet = new();

        public CharacterSheetBuilder AddFirstName(string firstName)
        {
            characterSheet.FirstName = firstName;
            return this;
        }
        public CharacterSheetBuilder AddLastName(string firstName)
        {
            characterSheet.LastName = firstName;
            return this;
        }
        public CharacterSheetBuilder AddHP(int currentHP, int maxHP)
        {
            characterSheet.CurrentHP = currentHP;
            characterSheet.MaxHP = maxHP;
            return this;
        }
        public CharacterSheetBuilder AddSpeed(int speed)
        {
            characterSheet.Speed = speed;
            return this;
        }
        public CharacterSheetBuilder AddActions(List<PathfinderAction> actions)
        {
            characterSheet.PathfinderActions.AddRange(actions);
            return this;
        }
        public CharacterSheet Build()
        {
            return characterSheet;
        }
    }
}
