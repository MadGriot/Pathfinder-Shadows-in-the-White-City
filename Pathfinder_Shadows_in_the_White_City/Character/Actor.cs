using Stride.Core.Mathematics;
using Stride.Engine;
using Pathfinder_Shadows_in_the_White_City.Grid;
using Stride.Animations;
using Stride.Engine.Events;
using PathfinderSecondEdition.Mechanics;
using Stride.Input;
using SharpDX.MediaFoundation;
using Pathfinder_Shadows_in_the_White_City.Actions;

namespace Pathfinder_Shadows_in_the_White_City.Character
{
    public class Actor : SyncScript
    {
        private const int ACTION_POINTS_MAX = 3;
        internal int ActionPoints = ACTION_POINTS_MAX;
        public bool IsFriendly;
        public int CharacterSheetId;
        private AnimationComponent AnimationComponent;
        private PlayingAnimation CurrentAnimation;
        private EventReceiver BattleStartListner;
        private EventReceiver BattleEndListner;
        private EventReceiver ActionSelectedListner;
        internal CharacterSheet CharacterSheet;
        internal int initiative;
        internal bool CurrentTurn;

        public Entity actor { get; set; }
        public GridPosition GridPosition { get; private set; }

        public override void Start()
        {
            BattleStartListner = new EventReceiver(LevelGrid.BattleStart);
            BattleEndListner = new EventReceiver(LevelGrid.BattleEnd);
            ActionSelectedListner = new EventReceiver(ActionSystem.ActionSelected);
            AnimationComponent = Entity.Get<AnimationComponent>();
            CurrentAnimation = AnimationComponent.Play("Idle");
            CharacterSheet = new CharacterSheet(CharacterSheetId);
            ActionComponentToEntity.Add(CharacterSheet.PathfinderActions, actor);
            GridPosition = LevelGrid.GridSystem.GetGridPosition(actor.Transform.Position);
            LevelGrid.GridSystem.AddActorAtGridPosition(GridPosition, this);
        }

        public override void Update()
        {
            if (BattleStartListner.TryReceive())
            {
                if (!IsFriendly)
                    LevelGrid.EnemyActorList.Add(actor);
                else
                    LevelGrid.FriendlyActorList.Add(actor);
                initiative = Check.Perception(CharacterSheet.WisdomModifier, 0, 0);
                LevelGrid.AllActorsInBattle.Add(actor, initiative);
                DebugText.Print("Battle Has Started", new Int2(200, 400));
            }

            if (BattleEndListner.TryReceive())
            {
                DebugText.Print("Battle Has Ended", new Int2(200, 400));

            }
            if (!CurrentTurn) return;
            if (IsFriendly || ActionSystem.InGameMasterMode)
            {
                if (!ActionSelectedListner.TryReceive())
                    ActionSystem.ActionDecision.Broadcast();

            }
            DebugText.Print($"{CharacterSheet.FirstName}'s turn", new Int2(200, 600));
            DebugText.Print($"Selected Actor: {ActionSystem.SelectedActor.Get<Actor>().CharacterSheet.FirstName}", new Int2(700, 200));


        }
    }
}
