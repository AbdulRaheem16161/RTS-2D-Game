using MoreMountains.Tools;
using UnityEngine;
using System.Collections;

namespace CustomNamespace
{
    public class WaitThenTrueThenFalse : AIDecision
    {
        public float waitTime = 3f; // Time to wait before returning true
        [SerializeField] private bool decisionMade = false;
        private Coroutine waitCoroutine;

        private IEnumerator WaitAndDecide()
        {
            yield return new WaitForSeconds(waitTime);
            decisionMade = true;
        }

        private void OnEnable()
        {
            decisionMade = false;
            waitCoroutine = StartCoroutine(WaitAndDecide());
        }

        private void OnDisable()
        {
            if (waitCoroutine != null)
            {
                StopCoroutine(waitCoroutine);
            }
            decisionMade = false;
        }

        public override bool Decide()
        {
            return decisionMade;
        }
    }
}
