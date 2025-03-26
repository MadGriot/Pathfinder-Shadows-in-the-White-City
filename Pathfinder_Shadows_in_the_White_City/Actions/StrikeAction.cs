using Pathfinder_Shadows_in_the_White_City.Character;
using Pathfinder_Shadows_in_the_White_City.Grid;
using Stride.Core.Mathematics;
using Stride.Engine;
using System;
using System.Collections.Generic;

namespace Pathfinder_Shadows_in_the_White_City.Actions
{
    public class StrikeAction : BaseAction
    {
        public StrikeAction() { }
        public StrikeAction(Entity actor) : base(actor)
        {
        }
        private enum State
        {
            Moving,
            Attacking,
            Cooloff
        }
        private State state;
        public int MaxStrikeDistance { get; private set; } = 2;
        private float StateTimer;
        private Actor TargetActor;
        private bool CanStrike;
        public override void Start()
        {
            base.Start();
            Name = "Strike";
        }

        public override void Update()
        {
            if (!ActionSelectedListener.TryReceive())
                return;
            if (ActionSystem.SelectedAction.Equals(Actor.Get<StrikeAction>()))
            {
                DebugText.Print("Strike Action Selected.", new Int2(700, 300));

                if (!IsActive)
                {
                    return;
                }
                StateTimer -= (float)Game.UpdateTime.Total.TotalSeconds;
                switch (state)
                {
                    case State.Moving:
                        if (StateTimer <= 0f)
                        {
                            state = State.Attacking;
                            StateTimer = 0.1f;
                        }
                        break;
                    case State.Attacking:
                        if (StateTimer <= 0f)
                        {
                            state = State.Cooloff;
                            StateTimer = 0.5f;
                            Strike();
                            CanStrike = false;
                        }
                        break;
                    case State.Cooloff:
                        if (StateTimer <= 0f)
                        {
                            ActionComplete();
                        }
                        break;
                }
            }
        }
        private void Strike()
        {
            TargetActor.Damage(7);
        }

        public override List<GridPosition> GetValidActionGridPositionList()
        {
            GridPosition unitGridPosition = Actor.Get<Actor>().GridPosition;
            return GetValidActionGridPositionList(unitGridPosition);
        }
        public List<GridPosition> GetValidActionGridPositionList(GridPosition gridPosition)
        {
            List<GridPosition> validGridPositionList = new List<GridPosition>();
            GridPosition unitGridPosition = Actor.Get<Actor>().GridPosition;
            for (int x = -MaxStrikeDistance; x <= MaxStrikeDistance; x++)
            {
                for (int z = -MaxStrikeDistance; z <= MaxStrikeDistance; z++)
                {
                    GridPosition offsetGridPosition = new GridPosition(x, z);
                    GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                    if (!LevelGrid.GridSystem.IsValidGridPosition(testGridPosition))
                    {
                        continue;
                    }

                    int testDistance = Math.Abs(x) + Math.Abs(z);
                    if (testDistance > MaxStrikeDistance)
                    {
                        continue;
                    }
                    //validGridPositionList.Add(testGridPosition);
                    //continue;


                    if (!LevelGrid.GridSystem.HasAnyActorOnGridPosition(testGridPosition))
                    {
                        //Grid Position is empty, no Unit
                        continue;
                    }
                    Actor targetUnit = LevelGrid.GridSystem.GetFirstActorAtGridPosition(testGridPosition);

                    if (TargetActor.IsFriendly == Actor.Get<Actor>().IsFriendly)
                    {
                        //Both Units are friendly
                        continue;
                    }

                    validGridPositionList.Add(testGridPosition);
                }
            }
            return validGridPositionList;
        }


        //public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
        //{


        //    TargetActor = LevelGrid.GridSystem.GetFirstActorAtGridPosition(gridPosition);
        //    state = State.Moving;
        //    StateTimer = 1f;

        //    CanStrike = true;
        //}
    }
}
