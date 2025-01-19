using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.Engine.Events;
using Pathfinder_Shadows_in_the_White_City.Actions;
using Pathfinder_Shadows_in_the_White_City.Grid;

namespace Pathfinder_Shadows_in_the_White_City.Character
{
    public class ActionUI : SyncScript
    {
        private EventReceiver ActionDecisionListner;
        private GridPosition currentGridPosition;

        public override void Start()
        {
            ActionDecisionListner = new EventReceiver(ActionSystem.ActionDecision);
        }

        public override void Update()
        {
            if (ActionSystem.InSelectionMode)
            {
                DebugText.Print("In Combat Choose the position and press A", new Int2(700, 100));
                ActionSystem.ActionSelected.Broadcast();

                foreach (IGamePadDevice gamePad in Input.GamePads)
                {
                    if (gamePad.IsButtonPressed(GamePadButton.PadLeft))
                    {
                        NavigateGridPosition(new GridPosition(1, 0));
                    }
                    if (gamePad.IsButtonPressed(GamePadButton.PadRight))
                    {
                        NavigateGridPosition(new GridPosition(-1, 0));
                    }
                    if (gamePad.IsButtonPressed(GamePadButton.PadUp))
                    {
                        NavigateGridPosition(new GridPosition(0, 1));
                    }
                    if (gamePad.IsButtonPressed(GamePadButton.PadDown))
                    {
                        NavigateGridPosition(new GridPosition(0, -1));
                    }

                    if (gamePad.IsButtonPressed(GamePadButton.A))
                    {
                        ActionSystem.SelectedActor.Get<StrideAction>().TargetPosition = 
                            LevelGrid.GridSystem.GetWorldPosition(currentGridPosition);
                        ActionSystem.SelectedActor.Get<StrideAction>().ActionStart();
                    }
                }
            }
            if (ActionDecisionListner.TryReceive())
            {
                DebugText.Print("In Combat Press A to End Turn", new Int2(700, 300));
                DebugText.Print("In Combat Press LB to Stride", new Int2(700, 350));
                DebugText.Print("In Combat Press RB to Strike", new Int2(700, 400));
                foreach (IGamePadDevice gamepad in Input.GamePads)
                {
                    if (gamepad.IsButtonPressed(GamePadButton.A))
                    {
                        ActionSystem.EndTurn();
                    }
                    if (gamepad.IsButtonPressed(GamePadButton.LeftShoulder))
                    {
                        ActionSystem.InSelectionMode = true;
                        ActionSystem.SelectedAction = ActionSystem.SelectedActor.Get<StrideAction>();
                        LevelGrid.UpdateGridVisual();
                        currentGridPosition = ActionSystem.SelectedActor.Get<Actor>().GridPosition;
                        currentGridPosition += new GridPosition(0, 1);
                    }
                    if (gamepad.IsButtonPressed(GamePadButton.RightShoulder))
                    {
                        ActionSystem.InSelectionMode = true;
                        ActionSystem.SelectedAction = ActionSystem.SelectedActor.Get<StrikeAction>();
                    }
                }
            }


        }
        private void NavigateGridPosition(GridPosition gridPosition)
        {
            GridPosition newGridPosition = currentGridPosition + gridPosition;
            if (ActionSystem.GridNavigationValidation(newGridPosition))
            {
                LevelGrid.UpdateGridVisual();
                currentGridPosition = newGridPosition;
                LevelGrid.HighlightGridPosition(currentGridPosition, GridVisualType.Blue);
            }
        }
    }
}
