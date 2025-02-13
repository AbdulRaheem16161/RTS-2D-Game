using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;

[AddComponentMenu("TopDown Engine/Character/AI/Decisions/Custom AIDecision Detect and Follow Child")]
public class AIDecisionFollowChildTarget : AIDecisionDetectTargetRadius2D
{
    [SerializeField] public LayerMask ChildLayer; // The layer for the "Point to Follow" objects.

    protected override bool FindUnobscuredTarget()
    {
        // If no potential targets, return false
        if (_potentialTargets.Count == 0)
        {
            _lastReturnValue = false;
            return false;
        }

        // Iterate over potential targets to find a valid "Point to Follow" child
        foreach (Transform target in _potentialTargets)
        {
            // Check if the target has a child with the "Point to Follow" layer
            Transform childToFollow = GetChildWithLayer(target, ChildLayer);
            if (childToFollow != null)
            {
                // Set the brain's target to the child
                _brain.Target = childToFollow;
                _lastReturnValue = true;
                return true;
            }
        }

        // If no valid child is found, return false
        _lastReturnValue = false;
        return false;
    }

    private Transform GetChildWithLayer(Transform parent, LayerMask layer)
    {
        foreach (Transform child in parent)
        {
            if ((1 << child.gameObject.layer & layer) != 0) // Check if child is on the specified layer
            {
                return child;
            }
        }
        return null; // Return null if no child matches the layer
    }
}
