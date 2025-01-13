using System.Collections.Generic;
using Stride.Core.Mathematics;
using Stride.Engine;
using Pathfinder_Shadows_in_the_White_City.Character;
using Pathfinder_Shadows_in_the_White_City.Grid;
using Stride.Physics;
using Stride.Engine.Events;
using System;

namespace Pathfinder_Shadows_in_the_White_City.Actions
{
    public class StrideAction : BaseAction
    {
        private Vector3 TargetPosition;
        private float CurrentYawOrientation;
        private float YawOrientation = 0;

        EventReceiver<GridPosition> RecieveGridSelection = new EventReceiver<GridPosition>(ActionSystem.GridSelection);
        public StrideAction() { }
        public StrideAction(Entity actor) : base(actor)
        {
        }

        public override void Start()
        {
            base.Start();
            Name = "Stride";
            TargetPosition = Actor.Transform.WorldMatrix.TranslationVector;
            CurrentYawOrientation = Actor.Transform.Rotation.YawPitchRoll.X;
        }
        public override void Update()
        {

            if (!ActionSelectedListener.TryReceive())
                return;
            if (ActionSystem.SelectedAction.Equals(Actor.Get<StrideAction>()))
            {
                DebugText.Print("Stride Action Selected.", new Int2(700, 300));
                DebugText.Print($"{TargetPosition.ToString()}", new Int2(700, 400));
                DebugText.Print($"{Actor.Transform.Rotation.ToString()}", new Int2(700, 500));
                DebugText.Print($"{CurrentYawOrientation.ToString()}", new Int2(700, 600));
                if (RecieveGridSelection.TryReceive(out GridPosition gridPosition))
                {
                    ActionStart();
                    TargetPosition = LevelGrid.GridSystem.GetWorldPosition(gridPosition);
                }
                if (!IsActive)
                {
                    return;
                }
  
                float stoppingDistance = 0.1f;
                if (Vector3.Distance(Actor.Transform.Position, TargetPosition) > stoppingDistance)
                {
                    float moveSpeed = 4f;
                    Vector3 moveDirection = Vector3.Normalize(TargetPosition - Actor.Transform.Position);
                    YawOrientation = (float)Math.Atan2(-moveDirection.Z, moveDirection.X) + MathUtil.PiOverTwo;
                    Actor.Get<CharacterComponent>().Orientation = Quaternion.RotationYawPitchRoll(YawOrientation, 0, 0);

                    Actor.Transform.Rotation = Quaternion.RotationYawPitchRoll(YawOrientation, 0, 0);
                    Actor.Get<CharacterComponent>().SetVelocity(moveDirection * moveSpeed);
                }
                else
                {
                    Actor.Get<CharacterComponent>().SetVelocity(Vector3.Zero);
                    Actor.Get<CharacterComponent>().Orientation = Quaternion.RotationYawPitchRoll(YawOrientation, 0, 0);
                    TargetPosition = Actor.Transform.WorldMatrix.TranslationVector;
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
