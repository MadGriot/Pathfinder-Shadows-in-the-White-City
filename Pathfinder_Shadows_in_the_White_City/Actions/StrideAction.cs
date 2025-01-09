using System.Collections.Generic;
using Stride.Core.Mathematics;
using Stride.Engine;
using Pathfinder_Shadows_in_the_White_City.Character;
using Pathfinder_Shadows_in_the_White_City.Grid;
using Stride.Physics;
using Stride.Engine.Events;

namespace Pathfinder_Shadows_in_the_White_City.Actions
{
    public class StrideAction : BaseAction
    {
        private Vector3 TargetPosition;

        EventReceiver<GridPosition> RecieveGridSelection = new EventReceiver<GridPosition>(ActionSystem.GridSelection);
        public StrideAction() { }
        public StrideAction(Entity actor) : base(actor)
        {
        }

        public override void Start()
        {
            base.Start();
            Name = "Strike";
            TargetPosition = Actor.Transform.WorldMatrix.TranslationVector;
        }
        public override void Update()
        {

            if (!ActionSelectedListener.TryReceive())
                return;
            if (ActionSystem.SelectedAction.Equals(Actor.Get<StrideAction>()))
            {
                DebugText.Print("Stride Action Selected.", new Int2(700, 300));
                DebugText.Print($"{TargetPosition.ToString()}", new Int2(700, 400));
                if (RecieveGridSelection.TryReceive(out GridPosition gridPosition))
                {
                    ActionStart();
                    TargetPosition = LevelGrid.GridSystem.GetWorldPosition(gridPosition);
                }
                if (!IsActive)
                {
                    return;
                }
                float stoppingDistance = .1f;
                if (Vector3.Distance(Actor.Transform.WorldMatrix.TranslationVector, TargetPosition) > stoppingDistance)
                {
                    Vector3 moveDirection = Vector3.Normalize(TargetPosition - Actor.Transform.WorldMatrix.TranslationVector);
                    float moveSpeed = 4f;
                    Actor.Get<CharacterComponent>().SetVelocity(moveDirection * moveSpeed);
                }
                else
                {
                    Actor.Get<CharacterComponent>().SetVelocity(Vector3.Zero);
                    ActionComplete();

                }
            }

        }

        public override List<GridPosition> GetValidActionGridPositionList()
        {
            List<GridPosition> validGridPositionList = new List<GridPosition>();
            int maxMoveDistance = ActionSystem.SelectedActor.Get<Actor>().CharacterSheet.Speed / 5;
            GridPosition actorGridPosition = ActionSystem.SelectedActor.Get<Actor>().GridPosition;
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
                   validGridPositionList.Add(testGridPosition);
                }
            }
            return validGridPositionList;
        }
    }
}
