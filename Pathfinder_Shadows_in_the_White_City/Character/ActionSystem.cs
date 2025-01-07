using Pathfinder_Shadows_in_the_White_City.Actions;
using Pathfinder_Shadows_in_the_White_City.Grid;
using System.Linq;

namespace Pathfinder_Shadows_in_the_White_City.Character
{
    public static class ActionSystem
    {
        public static Actor SelectedActor { get; set; }
        public static GridPosition GridPosition { get; set; }

        public static BaseAction SelectedAction { get; set; }

        public static void EndTurn()
        {
            Actor currentActor = LevelGrid.TurnOrder.Dequeue();
            currentActor.CurrentTurn = false;
            LevelGrid.TurnOrder.Enqueue(currentActor);
            SelectedActor = LevelGrid.TurnOrder.First();
            SelectedActor.CurrentTurn = true;
        }

    }
}
