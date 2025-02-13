using UnityEngine;
using MoreMountains.TopDownEngine;

namespace CustomNamespace
{
    public class AIActionMoveTowardsChild2D : AIActionMoveTowardsTarget2D
    {
        /// <summary>
        /// On PerformAction, override the target to follow the child and then move.
        /// </summary>
        public override void PerformAction()
        {
            AdjustTargetToChild();
            base.PerformAction();
        }

        /// <summary>
        /// Adjusts the brain's target to the child with the "point to follow" layer.
        /// </summary>
        protected virtual void AdjustTargetToChild()
        {
            if (_brain.Target == null) return;

            Transform playerTransform = _brain.Target;

            // Check if the target has a child with the "point to follow" layer
            foreach (Transform child in playerTransform)
            {
                if (child.gameObject.layer == LayerMask.NameToLayer("point to follow"))
                {
                    _brain.Target = child;
                    return;
                }
            }
        }
    }
}
