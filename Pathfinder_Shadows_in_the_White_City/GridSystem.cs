using Stride.Engine;

namespace Pathfinder_Shadows_in_the_White_City.Grid
{
    public class GridSystem : SyncScript
    {
        public int Length { get; private set; }
        public int Width { get; private set; }
        private float cellSize;
        private GridObject[,] gridObjects;

        public GridSystem()
        {
            Length = 10;
            Width = 10;
            cellSize = 2;
            gridObjects = new GridObject[Width, Length];

            for (int z = 0; z < Length; z++)
            {
                for (int x = 0; x < Width; x++)
                {
                    GridPosition gridPosition = new GridPosition(x, z);
                    gridObjects[x, z] = new GridObject(gridPosition);
                }
            }
        }

        public GridSystem(int width, int length, float cellSize)
        {
            Length = length;
            Width = width;
            this.cellSize = cellSize;
            gridObjects = new GridObject[width, length];

            for (int z = 0; z < length; z++)
            {
                for (int x = 0; x < width; x ++)
                {
                    GridPosition gridPosition = new GridPosition(x, z);
                    gridObjects[x, z] = new GridObject(gridPosition);
                }
            }
        }
        public override void Start()
        {
            // Initialization of the script.
        }

        public override void Update()
        {
            // Do stuff every new frame
        }
    }
}
