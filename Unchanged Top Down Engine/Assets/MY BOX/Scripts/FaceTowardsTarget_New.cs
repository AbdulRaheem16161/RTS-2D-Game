using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.TopDownEngine;
using Pathfinding;

namespace MoreMountains.TopDownEngine
{
    public class FaceTowardsTarget_New : AIActionMoveTowardsTarget2D
    {
        [SerializeField] public GameObject HisCurrentTarget;
        [SerializeField] private float HisXPosition;
        [SerializeField] private float HisCurrentTargetsXPosition;
        [SerializeField] private bool isFacingRight = true;
        [SerializeField] private Transform ModelTransform;
        public CharacterOrientation2D CharacterOrientation;
        public AIDestinationSetter destinationSetter;


        void Update()
        {
            // Check if destinationSetter and its target are not null before accessing their properties
            if (destinationSetter != null && destinationSetter.target != null)
            {
                HisCurrentTarget = destinationSetter.target.transform.parent?.gameObject;
            }
            else
            {
                HisCurrentTarget = null;  // Assign null to avoid errors
                return;  // Exit the method early to prevent further errors
            }

            // Check if the brain and target are not null
            if (_brain != null && _brain.Target != null && HisCurrentTarget != null)
            {
                // Update the serialized variables
                HisXPosition = transform.position.x;
                HisCurrentTargetsXPosition = HisCurrentTarget.transform.position.x;

                // Ensure ModelTransform is assigned
                if (ModelTransform == null)
                {
                    ModelTransform = transform;
                }

                // Check if the target is to the right or left of the object
                if (HisCurrentTargetsXPosition > HisXPosition)
                {
                    // Turn to face right by changing rotation.y to 0
                    ModelTransform.rotation = Quaternion.Euler(0, 0, 0);
                    isFacingRight = true;

                    if (CharacterOrientation != null)
                    {
                        CharacterOrientation.IsFacingRight = true;
                    }
                }
                else if (HisCurrentTargetsXPosition < HisXPosition)
                {
                    // Turn to face left by changing rotation.y to -180
                    ModelTransform.rotation = Quaternion.Euler(0, -180, 0);
                    isFacingRight = false;

                    if (CharacterOrientation != null)
                    {
                        CharacterOrientation.IsFacingRight = false;
                    }
                }
            }
        }

    }
}




