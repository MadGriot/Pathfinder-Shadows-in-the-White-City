
using PathfinderSecondEdition.Character;
using Stride.Engine;

namespace PathfinderSecondEdition.Grid
{
    public class GridObject
    {
        public GridPosition GridPosition { get; private set; }

        public List<Actor> Actors { get; set; }
        public Entity Cell { get; set; }


        public GridObject(GridPosition gridPosition, Entity cell)
        {
            GridPosition = gridPosition;
            Actors = new List<Actor>();
            Cell = cell;
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
