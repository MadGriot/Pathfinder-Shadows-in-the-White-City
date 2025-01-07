using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Pathfinder_Shadows_in_the_White_City.Grid;

namespace Pathfinder_Shadows_in_the_White_City.Actions
{
    public abstract class BaseAction : SyncScript
    {
        protected int ActionPointCost { get; set; } = 1;
        public string Name { get; protected set; } = "Action";

        public override void Start()
        {
            // Initialization of the script.
        }

        public override void Update()
        {
            // Do stuff every new frame
        }

        //public virtual bool IsValidActionGridPosition(GridPosition gridPosition)
        //{
        //    List<GridPosition> validGridPositionList = GetValidActionGridPositionList();
        //    return validGridPositionList.Contains(gridPosition);
        //}    
        //public abstract void TakeAction(GridPosition gridPosition, Action onActionComplete);
        //public abstract List<GridPosition> GetValidActionGridPositionList();
    }
}
