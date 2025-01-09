using System.Collections.Generic;
using Stride.Engine;
using Stride.Engine.Events;
using Pathfinder_Shadows_in_the_White_City.Character;
using System.Linq;
using Pathfinder_Shadows_in_the_White_City.Actions;
using Stride.Rendering;

namespace Pathfinder_Shadows_in_the_White_City.Grid
{
    public static class LevelGrid
    {
        public static GridSystem GridSystem { get; private set; }
        public static EventKey BattleStart { get; private set; } = new EventKey("Battle", "Start");
        public static EventKey BattleEnd { get; private set; } = new EventKey("Battle", "End");
        public static List<Entity> FriendlyActorList { get; private set; }
        public static List<Entity> EnemyActorList { get; private set; }
        public static List<Material> GridVisualTypeMaterials { get; private set; } = [];
        /// <summary>
        /// This Dictionary has the Actor as the Key, and initative as the value.
        /// </summary>
        public static Dictionary<Entity, int> AllActorsInBattle { get; private set; }
        public static Queue<Entity> TurnOrder {  get; set; }
        public static float MaxTime { get; set; } = 1;

        /// <summary>
        /// Creates a grid given the parameters; 'x' is width 'z' is length.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="z"></param>
        /// <param name="cellsize"></param>
        public static void CreateGridSystem(int x, int z, float cellsize, Entity cell)
        {
            GridSystem = new GridSystem(x, z, cellsize, cell);
            FriendlyActorList = new List<Entity>();
            EnemyActorList = new List<Entity>();
            AllActorsInBattle = new Dictionary<Entity, int>();
        }
        public static void ClearGridSystem()
        {
            FriendlyActorList.Clear();
            EnemyActorList.Clear();
            AllActorsInBattle.Clear();
            TurnOrder.Clear();
        }
        /// <summary>
        /// Completely removes the GridSystem from memory. Can be error prone!
        /// </summary>
        public static void DestroyGridSystem()
        {
            GridSystem = null;
            EnemyActorList = null;
            FriendlyActorList = null;
            AllActorsInBattle = null;
            TurnOrder = null;
        }
        /// <summary>
        /// Determines the Turn Order by Initiative. All actors will be in a Queue.
        /// </summary>
        public static void DetermineTurnOrder()
        {
            List<Entity> characters = AllActorsInBattle
               .OrderByDescending(x => x.Value)
               .Select(x => x.Key).ToList();
            TurnOrder = new Queue<Entity>(characters);
            TurnOrder.First().Get<Actor>().CurrentTurn = true;
            ActionSystem.SelectedActor = TurnOrder.First().Get<Actor>();
            ActionSystem.SelectedAction = ActionSystem.SelectedActor.StrideAction;
            //UpdateGridVisual();
        }

        public static void UpdateGridVisual()
        {
            GridSystem.HideAllGridPosition(GridVisualTypeMaterials[(int)GridVisualType.Blank]);
            Actor selectedActor = ActionSystem.SelectedActor;
            BaseAction selectedAction = ActionSystem.SelectedAction;

            GridVisualType gridVisualType;
            switch (selectedAction)
            {
                default:
                case StrideAction:
                    gridVisualType = GridVisualType.White;
                    break;
                case StrikeAction:
                    gridVisualType = GridVisualType.Red;

                    GridSystem.ShowGridPositionRange(selectedActor.GridPosition
                        , selectedActor.StrikeAction.MaxStrikeDistance, GridVisualType.Red);
                    break;
            }
            GridSystem.ShowGridPositionList(ActionSystem.SelectedAction
                .GetValidActionGridPositionList(), gridVisualType, GridVisualTypeMaterials);
        }
    }
}
