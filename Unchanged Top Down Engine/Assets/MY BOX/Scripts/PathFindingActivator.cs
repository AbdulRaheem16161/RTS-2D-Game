using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using Pathfinding;

public class PathFindingActivator : AIAction
{
    public AIPath pathfinderScript;
    public My_MakePathFinderTheParent MakePathFinderTheParent;
    public My_MakeWizardTheParent MakeWizardTheParent;

    [SerializeField] private bool a;

    // Initialization method to get the AIPath component
    public override void Initialization()
    {
        base.Initialization();
       // pathfinderScript = GetComponentInParent<AIPath>();
      //  stickchidtoparent = GetComponentInParent<My_StickChidToParent>();
       // stickparenttochild = GetComponentInParent<My_StickParentToChid>();
    }

    // Overriding PerformAction to enable AIPath when this action is active
    public override void PerformAction()
    {
        if (pathfinderScript != null)
        {
            a = true;
            pathfinderScript.enabled = true;
            MakePathFinderTheParent.enabled = true;
            MakeWizardTheParent.enabled = false;
        }
    }

    // Enable AIPath when entering the state
    public override void OnEnterState()
    {
        base.OnEnterState();
        if (pathfinderScript != null)
        {
            pathfinderScript.enabled = true;
        }
    }

    // Disable AIPath when exiting the state
    public override void OnExitState()
    {
        base.OnExitState();
        if (pathfinderScript != null)
        {
            pathfinderScript.enabled = false;
        }
    }
}
