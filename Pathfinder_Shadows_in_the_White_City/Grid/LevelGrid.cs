using System;
using System.Collections.Generic;
using System.Linq;
using Stride.Engine;
using Stride.Engine.Events;
using Pathfinder_Shadows_in_the_White_City.Character;

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
        }

    }
}
