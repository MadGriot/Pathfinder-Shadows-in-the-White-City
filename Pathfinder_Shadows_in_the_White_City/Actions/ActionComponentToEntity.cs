using PathfinderSecondEdition.Actions;
using Stride.Engine;
using System.Collections.Generic;

namespace Pathfinder_Shadows_in_the_White_City.Actions
{
    public static class ActionComponentToEntity
    {
        /// <summary>
        /// Adds Entity Components derived that inherents from the Base action class.
        /// </summary>
        /// <param name="pathfinderActions"></param>
        /// <param name="entity"></param>
        public static void Add(List<PathfinderAction> pathfinderActions, Entity entity)
        {
            foreach (PathfinderAction action in pathfinderActions)
            {
                switch (action)
                {
                    default:
                    case PathfinderAction.Stride:
                        entity.Add(new StrideAction(entity));
                        break;
                    case PathfinderAction.Strike:
                        entity.Add(new StrikeAction(entity));
                        break;
                }
            }

        }
    }
}
