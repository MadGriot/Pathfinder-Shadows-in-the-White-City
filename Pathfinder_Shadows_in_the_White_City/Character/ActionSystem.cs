using Pathfinder_Shadows_in_the_White_City.Actions;
using Pathfinder_Shadows_in_the_White_City.Grid;
using Stride.Engine;
using Stride.Engine.Events;
using System.Linq;
using System.Collections.Generic;

namespace Pathfinder_Shadows_in_the_White_City.Character
{
    public static class ActionSystem
    {
        public static Entity SelectedActor { get; set; }

        public static BaseAction SelectedAction { get; set; }
        public static bool InGameMasterMode { get; set; }
        public static EventKey ActionDecision { get; private set; } = new EventKey("Action", "Decision");

        public static EventKey ActionSelected { get; private set; } = new EventKey("Action", "Selected");
        public static bool InSelectionMode { get; set; }
        public static void EndTurn()
        {
            Entity currentActor = LevelGrid.TurnOrder.Dequeue();
            currentActor.Get<Actor>().CurrentTurn = false;
            LevelGrid.TurnOrder.Enqueue(currentActor);
            SelectedActor = LevelGrid.TurnOrder.First();
            SelectedActor.Get<Actor>().CurrentTurn = true;
        }

        public static bool GridNavigationValidation(GridPosition gridPosition)
        {
            if (SelectedAction.GetValidActionGridPositionList().Contains(gridPosition)) 
                return true;
            return false;
        }
    }
}
