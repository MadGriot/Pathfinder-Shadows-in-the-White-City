using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Pathfinder_Shadows_in_the_White_City.Character;
using Pathfinder_Shadows_in_the_White_City.Grid;

namespace Pathfinder_Shadows_in_the_White_City.Actions
{
    public class StrideAction : BaseAction
    {
        public StrideAction() { }
        public StrideAction(Entity actor) : base(actor)
        {
        }

        public override void Start()
        {
            base.Start();
            Name = "Strike";
        }
        public override void Update()
        {

            if (!ActionSelectedListener.TryReceive())
                return;
            if (ActionSystem.SelectedAction.Equals(Actor.Get<StrideAction>()))
            {
                DebugText.Print("Stride Action Selected.", new Int2(700, 300));
            }
        }

        public override List<GridPosition> GetValidActionGridPositionList()
        {
            List<GridPosition> validGridPositionList = new List<GridPosition>();
            int maxMoveDistance = ActionSystem.SelectedActor.CharacterSheet.Speed / 5;
            GridPosition actorGridPosition = ActionSystem.SelectedActor.GridPosition;
            for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
            {
                for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
                {
                    GridPosition offsetGridPosition = new GridPosition(x, z);
                    GridPosition testGridPosition = actorGridPosition + offsetGridPosition;

                    if (!LevelGrid.GridSystem.IsValidGridPosition(testGridPosition))
                        continue;
                    if (actorGridPosition.Equals(testGridPosition))
                        continue;
                    if (LevelGrid.GridSystem.HasAnyActorOnGridPosition(testGridPosition))
                        continue;
                   validGridPositionList.Add(offsetGridPosition);
                }
            }
            return validGridPositionList;
        }
    }
}
