using Stride.Engine;

namespace PathfinderSecondEdition.Grid
{
    public class GridMediator
    {
        public event Action<GridSystem> GridSystemCreated;
        public void CreateGridSystem(int width, int length, float cellSize, Entity gridCell)
        {
            GridSystem gridSystem =  new GridSystem(width, length, cellSize, gridCell);

            GridSystemCreated?.Invoke(gridSystem);
        }
    }
}
