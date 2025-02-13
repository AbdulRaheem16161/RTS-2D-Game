using MoreMountains.Tools;
using System.Collections;
using UnityEngine;

namespace CustomNamespace
{
    public class My_AIActionStartWaitingCoroutine : AIAction
    {
       // public My_AIDecisionWaitBeforeNextAction AIDecisionWaitBeforeNextAction;

        [SerializeField] private bool a;

        // Implement the abstract method PerformAction() from AIAction
        public override void PerformAction()
        {
            a = true; // This can be used to control internal state or logic
           // AIDecisionWaitBeforeNextAction.StartTheCoroutine();
        }
    }
}
