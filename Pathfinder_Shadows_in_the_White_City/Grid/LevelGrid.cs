using System.Collections.Generic;
using Stride.Engine;
using Stride.Engine.Events;
using Pathfinder_Shadows_in_the_White_City.Character;
using System.Linq;

namespace Pathfinder_Shadows_in_the_White_City.Grid
{
    public static class LevelGrid
    {
        public static GridSystem GridSystem { get; private set; }
        public static EventKey BattleStart { get; private set; } = new EventKey("Battle", "Start");
        public static EventKey BattleEnd { get; private set; } = new EventKey("Battle", "End");
        public static List<Actor> FriendlyActorList { get; private set; }
        public static List<Actor> EnemyActorList { get; private set; }
        /// <summary>
        /// This Dictionary has the Actor as the Key, and initative as the value.
        /// </summary>
        public static Dictionary<Actor, int> AllActorsInBattle { get; private set; }
        public static Queue<Actor> TurnOrder {  get; set; }
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
            FriendlyActorList = new List<Actor>();
            EnemyActorList = new List<Actor>();
            AllActorsInBattle = new Dictionary<Actor, int>();
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
            List<Actor> characters = AllActorsInBattle
               .OrderByDescending(x => x.Value)
               .Select(x => x.Key).ToList();
            TurnOrder = new Queue<Actor>(characters);
            TurnOrder.First().CurrentTurn = true;
        }
    }
}
