using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.Engine.Events;
using Pathfinder_Shadows_in_the_White_City.Actions;

namespace Pathfinder_Shadows_in_the_White_City.Character
{
    public class ActionUI : SyncScript
    {
        private EventReceiver ActionDecisionListner;

        public override void Start()
        {
            ActionDecisionListner = new EventReceiver(ActionSystem.ActionDecision);
        }

        public override void Update()
        {
            if (ActionSystem.InSelectionMode)
            {
                ActionSystem.ActionSelected.Broadcast();
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
                        ActionSystem.SelectedAction = ActionSystem.SelectedActor.StrideAction;
                    }
                    if (gamepad.IsButtonPressed(GamePadButton.RightShoulder))
                    {
                        ActionSystem.InSelectionMode = true;
                        ActionSystem.SelectedAction = ActionSystem.SelectedActor.StrikeAction;
                    }
                }
            }
        }
    }
}
