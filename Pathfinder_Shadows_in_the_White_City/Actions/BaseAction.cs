using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Pathfinder_Shadows_in_the_White_City.Grid;
using Stride.Engine.Events;
using Pathfinder_Shadows_in_the_White_City.Character;

namespace Pathfinder_Shadows_in_the_White_City.Actions
{
    public abstract class BaseAction : SyncScript
    {
        public Entity Actor { get; set; }
        protected int ActionPointCost { get; set; } = 1;
        public string Name { get; protected set; } = "Action";
        protected EventReceiver ActionSelectedListener { get; set; }

        public BaseAction()
        {

        }
        public BaseAction(Entity actor)
        {
            Actor = actor;
        }
        public override void Start()
        {
            ActionSelectedListener = new EventReceiver(ActionSystem.ActionSelected);
        }

        public override void Update()
        {
            if (!ActionSelectedListener.TryReceive())
                return;
        }

        public abstract List<GridPosition> GetValidActionGridPositionList();
    }
}
