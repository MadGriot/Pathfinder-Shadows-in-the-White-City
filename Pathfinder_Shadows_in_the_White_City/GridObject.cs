using System.Collections.Generic;
using Pathfinder_Shadows_in_the_White_City.Character;

namespace Pathfinder_Shadows_in_the_White_City.Grid
{
    public class GridObject
    {
        private GridPosition GridPosition;

        public List<Actor> Actors { get; set; }


        public GridObject(GridPosition gridPosition)
        {
            GridPosition = gridPosition;
            Actors = new List<Actor>();
        }

        public override string ToString()
        {
            string actorString = "";
            foreach (Actor actor in Actors)
            {
                actorString += actor + "\n";
            }
            return GridPosition.ToString() + "\n" + actorString;
        }

        public bool HasAnyUnit() => Actors.Count > 0;
    }
}
