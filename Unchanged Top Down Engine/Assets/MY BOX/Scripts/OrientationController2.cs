using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using Pathfinding;

public class OrientationController2 : AIAction
{
    public CharacterOrientation2D characterorientation;
    public FaceTowardsTarget_New facetowardstarget;
    public My_Aim Aim;
    public AIDestinationSetter destinationSetter;


    // Start is called before the first frame update
    void Start()
    {
        characterorientation = gameObject.GetComponent<CharacterOrientation2D>();
        facetowardstarget = gameObject.GetComponent<FaceTowardsTarget_New>();
      //  Aim = gameObject.GetComponent<My_Aim>();
    }

    public override void PerformAction()
    {
        // Logic to control orientation and facing target
        if (facetowardstarget != null && characterorientation != null)
        {
            characterorientation.enabled = false;  // Enable CharacterOrientation2D
            facetowardstarget.enabled = true;   // Disable FaceTowardsTarget
            Aim.enabled = true;
        }

        destinationSetter.FindNearestTarget();
    }
}
