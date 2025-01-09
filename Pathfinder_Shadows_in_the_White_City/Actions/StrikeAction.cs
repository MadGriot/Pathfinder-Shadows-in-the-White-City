using Pathfinder_Shadows_in_the_White_City.Character;
using Pathfinder_Shadows_in_the_White_City.Grid;
using Stride.Core.Mathematics;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinder_Shadows_in_the_White_City.Actions
{
    public class StrikeAction : BaseAction
    {
        public StrikeAction() { }
        public StrikeAction(Entity actor) : base(actor)
        {
        }

        public int MaxStrikeDistance { get; set; }
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
            }
        }

        public override List<GridPosition> GetValidActionGridPositionList()
        {
            throw new NotImplementedException();
        }
    }
}
