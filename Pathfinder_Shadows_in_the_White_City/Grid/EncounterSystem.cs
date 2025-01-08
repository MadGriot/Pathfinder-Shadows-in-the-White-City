using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.Engine.Events;
using Pathfinder_Shadows_in_the_White_City.Character;

namespace Pathfinder_Shadows_in_the_White_City.Grid
{
    public class EncounterSystem : SyncScript
    {
        private EventReceiver BattleStartListner;
        private EventReceiver BattleEndListner;
        private bool EncounterSetup;
        private bool InEncounter;
        public bool InGameMasterMode { get; set; }
        private float timer = 0;
        private float deltaTime;
        private Vector2 index = new Vector2();

        public override void Start()
        {
            BattleStartListner = new EventReceiver(LevelGrid.BattleStart);
            BattleEndListner = new EventReceiver(LevelGrid.BattleEnd);
            ActionSystem.InGameMasterMode = InGameMasterMode;
        }

        public override void Update()
        {
            if (BattleStartListner.TryReceive())
            {
                EncounterSetup = true;
            }
 
            if (EncounterSetup)
            {
                deltaTime = (float)Game.UpdateTime.Elapsed.TotalSeconds;
                timer += deltaTime;
                if (timer > LevelGrid.MaxTime)
                {
                    LevelGrid.DetermineTurnOrder();
                    EncounterSetup = false;
                    InEncounter = true;
                }
  
            }
            if (InEncounter)
            {
                deltaTime = (float)Game.UpdateTime.Elapsed.TotalSeconds;
                timer += deltaTime;


            }
            else
                DebugText.Print("Not in Combat", new Int2(700, 300));


            if (BattleEndListner.TryReceive())
            {
                InEncounter = false;
                timer = 0;
            }

        }
    }
}
