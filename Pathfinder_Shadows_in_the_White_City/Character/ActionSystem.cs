using Pathfinder_Shadows_in_the_White_City.Actions;
using Pathfinder_Shadows_in_the_White_City.Grid;
using Stride.Engine.Events;
using System.Linq;

namespace Pathfinder_Shadows_in_the_White_City.Character
{
    public static class ActionSystem
    {
        public static Actor SelectedActor { get; set; }

        public static BaseAction SelectedAction { get; set; }
        public static bool InGameMasterMode { get; set; }
        public static EventKey ActionDecision { get; private set; } = new EventKey("Action", "Decision");

        public static EventKey ActionSelected { get; private set; } = new EventKey("Action", "Selected");
        public static bool InSelectionMode { get; set; }
        public static void EndTurn()
        {
            Actor currentActor = LevelGrid.TurnOrder.Dequeue();
            currentActor.CurrentTurn = false;
            LevelGrid.TurnOrder.Enqueue(currentActor);
            SelectedActor = LevelGrid.TurnOrder.First();
            SelectedAction = SelectedActor.StrideAction;
            SelectedActor.CurrentTurn = true;
            LevelGrid.UpdateGridVisual();
        }

    }
}
