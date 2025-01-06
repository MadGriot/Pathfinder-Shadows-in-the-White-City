using Stride.Core.Mathematics;
using Stride.Engine;
using Pathfinder_Shadows_in_the_White_City.Grid;
using Stride.Animations;
using Stride.Engine.Events;
using PathfinderSecondEdition.Mechanics;


namespace Pathfinder_Shadows_in_the_White_City.Character
{
    public class Actor : SyncScript
    {
        private const int ACTION_POINTS_MAX = 3;
        public bool IsFriendly;
        public int CharacterSheetId;
        private AnimationComponent AnimationComponent;
        private PlayingAnimation CurrentAnimation;
        private EventReceiver BattleStartListner;
        private EventReceiver BattleEndListner;
        internal CharacterSheet CharacterSheet;
        internal int initiative;

        public Entity actor { get; set; }
        public GridPosition GridPosition { get; private set; }

        public override void Start()
        {
            BattleStartListner = new EventReceiver(LevelGrid.BattleStart);
            BattleEndListner = new EventReceiver(LevelGrid.BattleEnd);
            AnimationComponent = Entity.Get<AnimationComponent>();
            CurrentAnimation = AnimationComponent.Play("Idle");
            CharacterSheet = new CharacterSheet(CharacterSheetId);
        }

        public override void Update()
        {
            if (BattleStartListner.TryReceive())
            {
                if (!IsFriendly)
                    LevelGrid.EnemyActorList.Add(this);
                else
                    LevelGrid.FriendlyActorList.Add(this);
                initiative = Check.Perception(CharacterSheet.WisdomModifier, 0, 0);
                LevelGrid.AllActorsInBattle.Add(this, initiative);
                DebugText.Print("Battle Has Started", new Int2(200, 400));
            }

            if (BattleEndListner.TryReceive())
            {
                DebugText.Print("Battle Has Ended", new Int2(200, 400));

            }
        }
    }
}
