using PathfinderSecondEdition.Actions;
using PathfinderSecondEdition;
using Stride.Engine;

namespace PathfinderSecondEditionTest
{
    public class ActionComponentToEntityTest
    {
        [Fact]
        public void TestAddActions()
        {
            CharacterSheet characterSheet = new CharacterSheetBuilder()
                 .AddActions(new List<PathfinderAction> { PathfinderAction.Stride, PathfinderAction.Strike })
                 .Build();

            Entity actor = new Entity();
            ActionComponentToEntity.AddComponent(characterSheet.PathfinderActions, actor);
            Assert.Equal("Stride", actor.Get<StrideAction>().Name);
            Assert.Equal("Strike", actor.Get<StrikeAction>().Name);
            
        }
    }
}
