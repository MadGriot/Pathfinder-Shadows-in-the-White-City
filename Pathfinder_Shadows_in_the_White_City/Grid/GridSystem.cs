using Pathfinder_Shadows_in_the_White_City.Character;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Rendering;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Pathfinder_Shadows_in_the_White_City.Grid
{
    public class GridSystem
    {
        public int Length { get; private set; }
        public int Width { get; private set; }
        private float cellSize;
        public GridObject[,] GridObjects {  get; private set; }

        public GridSystem()
        {
            Length = 10;
            Width = 10;
            cellSize = 2;
            GridObjects = new GridObject[Width, Length];

            for (int z = 0; z < Length; z++)
            {
                for (int x = 0; x < Width; x++)
                {
                    GridPosition gridPosition = new GridPosition(x, z);
                    GridObjects[x, z] = new GridObject(gridPosition, null);
                }
            }
        }

        public GridSystem(int width, int length, float cellSize, Entity gridCell)
        {
            Length = length;
            Width = width;
            this.cellSize = cellSize;
            GridObjects = new GridObject[width, length];

            for (int z = 0; z < length; z++)
            {
                for (int x = 0; x < width; x ++)
                {
                    GridPosition gridPosition = new GridPosition(x, z);
                    GridObjects[x, z] = new GridObject(gridPosition, gridCell.Clone());
                }
            }
        }

        /// <summary>
        ///  Returns a Vector3 from a GridPosition.
        /// </summary>
        /// <param name="gridPosition"></param>
        /// <returns></returns>
        public Vector3 GetWorldPosition(GridPosition gridPosition) =>
            new Vector3(gridPosition.X, 0, gridPosition.Z) * cellSize;
     
        /// <summary>
        /// Returns a GridPosition from a Vector3.
        /// </summary>
        /// <param name="worldPosition"></param>
        /// <returns></returns>
        public GridPosition GetGridPosition(Vector3 worldPosition) =>
            new GridPosition(Convert.ToInt32(worldPosition.X / cellSize),
                Convert.ToInt32(worldPosition.Z / cellSize));

        /// <summary>
        /// Creates a visible debug Entity onto each cell in the grid.
        /// </summary>
        /// <param name="debugObject"></param>
        public void CreateDebugObjects(Entity debugObject)
        {
            for (int z = 0; z < Length; z++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Entity clone = debugObject.Clone();
                    clone.Transform.Position = new Vector3(
                        x * cellSize, 0 * cellSize, z * cellSize);
                    debugObject.Scene.Entities.Add(clone);
                }
            }
        }
        /// <summary>
        /// Visually hides all of the GridPositions in the Scene.
        /// </summary>
        /// <param name="blankMaterial"></param>
        public void HideAllGridPosition(Material blankMaterial)
        {
            for (int z = 0; z < Length; z++)
            {
                for (int x = 0; x < Width; x++)
                {
                    GridObjects[x, z].Cell.Get<ModelComponent>().Materials.Remove(0);
                    GridObjects[x, z].Cell.Get<ModelComponent>().Materials.Add(0, blankMaterial);
                }
            }
        }
        public void ShowGridPositionRange(GridPosition gridPosition, int range, GridVisualType gridVisualType)
        {
            List<GridPosition> gridPositionList = [];
            for (int z = -range; z < range; z++)
            {
                for (int x = -range; x < range; x++)
                {
                    GridPosition testGridPosition = gridPosition + new GridPosition(x, z);
                    if (!IsValidGridPosition(testGridPosition))
                    {
                        continue;
                    }
                    int testDistance = Math.Abs(x) + Math.Abs(z);
                    if (testDistance > range)
                    {
                        continue;
                    }
                    gridPositionList.Add(testGridPosition);
                }
            }
            ShowGridPositionList(gridPositionList, gridVisualType, LevelGrid.GridVisualTypeMaterials);
        }
        /// <summary>
        /// Visually shows the Grid Position List.
        /// </summary>
        /// <param name="gridPositionList"></param>
        /// <param name="gridVisualType"></param>
        /// <param name="materials"></param>
        public void ShowGridPositionList(List<GridPosition> gridPositionList, GridVisualType gridVisualType, List<Material> materials)
        {
            Material material = null;
            foreach (GridPosition gridPosition in gridPositionList)
            {
                material = materials.ElementAtOrDefault((int)gridVisualType);
                if (material != null)
                {
                    GridObjects[gridPosition.X, gridPosition.Z].Cell.Get<ModelComponent>().Materials.Remove(0);
                    GridObjects[gridPosition.X, gridPosition.Z].Cell.Get<ModelComponent>().Materials.Add(0, material);
                }
            }
        }

        /// <summary>
        /// Gets a GridObject from a GridPosition.
        /// </summary>
        /// <param name="gridPosition"></param>
        /// <returns></returns>
        public GridObject GetGridObject(GridPosition gridPosition) =>
            GridObjects[gridPosition.X, gridPosition.Z];

        /// <summary>
        /// Returns true if the GridPosition is within range, otherwise false.
        /// </summary>
        /// <param name="gridPosition"></param>
        /// <returns></returns>
        public bool IsValidGridPosition(GridPosition gridPosition)
        {
            return gridPosition.X >= 0 &&
                gridPosition.Z >= 0 &&
                gridPosition.X < Width &&
                gridPosition.Z < Length;
        }

        public void AddActorAtGridPosition(GridPosition gridPosition, Actor actor)
        {
            GridObject gridObject = GetGridObject(gridPosition);
            gridObject.Actors.Add(actor);
        }

        public void RemoveActorAtGridPosition(GridPosition gridPosition, Actor actor)
        {
            GridObject gridObject = GetGridObject(gridPosition);
            gridObject.Actors.Remove(actor);
        }

        /// <summary>
        /// Moves an Actor from a GridPosition to a GridPosition.
        /// </summary>
        /// <param name="fromGridPosition"></param>
        /// <param name="toGridPosition"></param>
        /// <param name="actor"></param>
        public void MoveActorToGridPosition(GridPosition fromGridPosition, GridPosition toGridPosition, Actor actor)
        {
            RemoveActorAtGridPosition(fromGridPosition, actor);
            AddActorAtGridPosition(toGridPosition, actor);
        }

        /// <summary>
        /// Checks if they're any Actors on the given GridPosition.
        /// </summary>
        /// <param name="gridPosition"></param>
        /// <returns></returns>
        public bool HasAnyActorOnGridPosition(GridPosition gridPosition)
        {
            GridObject gridObject = GetGridObject(gridPosition);
            return gridObject.HasAnyUnit();
        }

        public Actor GetFirstActorAtGridPosition(GridPosition gridPosition)
        {
            GridObject gridObject = GetGridObject(gridPosition);
            return gridObject.Actors.First();
        }
    }
}
