using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;

public class My_AIDecisionSwitchToAttackOnTouch : AIDecision
{
    public string targetTag = "Target";

    [SerializeField] private bool _isColliding = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Entered trigger with target");
            _isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Exited trigger with target");
            _isColliding = false;
        }
    }


    public override bool Decide()
    {
        return _isColliding;
    }
}
