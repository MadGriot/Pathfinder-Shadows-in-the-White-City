using PathfinderSecondEdition;
using PathfinderSecondEdition.Actions;

namespace PathfinderSecondEditionTest
{
    public class CharacterSheetBuilderTest
    {
        [Fact]
        public void TestAddFirstAndLastName()
        {
            CharacterSheet characterSheet = new CharacterSheetBuilder()
                 .AddFirstName("Jafaru")
                 .AddLastName("Samba")
                 .Build();

            Assert.Equal("Samba", characterSheet.LastName);
            Assert.Equal("Jafaru", characterSheet.FirstName);
        }

        [Fact]
        public void TestAddHP()
        {
            CharacterSheet characterSheet = new CharacterSheetBuilder()
                 .AddHP(6, 8)
                 .Build();

            Assert.Equal(6, characterSheet.CurrentHP);
            Assert.Equal(8, characterSheet.MaxHP);
        }

        [Fact]
        public void TestAddSpeed()
        {
            CharacterSheet characterSheet = new CharacterSheetBuilder()
                 .AddSpeed(25)
                 .Build();

            Assert.Equal(25, characterSheet.Speed);
        }

        [Fact]
        public void TestAddActions()
        {
            CharacterSheet characterSheet = new CharacterSheetBuilder()
                 .AddActions(new List<PathfinderAction> { PathfinderAction.Stride, PathfinderAction.Strike})
                 .Build();

            Assert.Equal(PathfinderAction.Stride, characterSheet.PathfinderActions.First());
        }

        [Fact]
        public void TestAbilityScore()
        {
            CharacterSheet characterSheet = new CharacterSheetBuilder()
                 .AddAbilityScore(10, 10, 10, 10, 10, 10)
                 .Build();

            Assert.Equal(10, characterSheet.Constitution);
        }
    }
}