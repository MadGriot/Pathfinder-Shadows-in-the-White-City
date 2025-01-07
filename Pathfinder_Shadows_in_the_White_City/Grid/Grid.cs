using Stride.Engine;
using Stride.Engine.Events;

namespace Pathfinder_Shadows_in_the_White_City.Grid
{
    public class Grid : SyncScript
    {
        public Entity Cell {  get; set; }
        private GridSystem GridSystem { get; set; }
        private EventReceiver BattleStartListner;
        private EventReceiver BattleEndListner;
        public override void Start()
        {
            BattleStartListner = new EventReceiver(LevelGrid.BattleStart);
            BattleEndListner = new EventReceiver(LevelGrid.BattleEnd);
            LevelGrid.CreateGridSystem(10, 10, 2f, Cell);
            GridSystem = LevelGrid.GridSystem;
        }

        public override void Update()
        {
            if (BattleStartListner.TryReceive())
            {
                LoadAllGridPositionVisuals();

            }
            if (BattleEndListner.TryReceive())
            {
                RemoveAllGridPositionVisuals();
                LevelGrid.ClearGridSystem();
            }

        }
        /// <summary>
        /// Loads a visual of all GridPositions.
        /// </summary>
        private void LoadAllGridPositionVisuals() => GridLooper(false);
        /// <summary>
        /// Removes all visuals on GridPositions.
        /// </summary>
        private void RemoveAllGridPositionVisuals() => GridLooper(true);

        private void GridLooper(bool remove)
        {
            for (int z = 0; z < GridSystem.Length; z++)
            {
                for (int x = 0; x < GridSystem.Width; x++)
                {
                    GridObject gridObject = GridSystem.GridObjects[x, z];
                    gridObject.Cell.Transform.Position = GridSystem.GetWorldPosition(gridObject.GridPosition);
                    if (remove)
                        Entity.Scene.Entities.Remove(gridObject.Cell);
                    else
                        Entity.Scene.Entities.Add(gridObject.Cell);
                }
            }
        }

    }
}
