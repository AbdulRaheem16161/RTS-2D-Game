//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using MoreMountains.TopDownEngine;

//public class FaceTowardsTarget : AIActionMoveTowardsTarget2D
//{
//    [SerializeField] GameObject PlayerGameObj;
//    [SerializeField] private float wizardXposion;
//    [SerializeField] private float playerXposition;
//    [SerializeField] public bool isFacingRight = true;

//    [SerializeField] private Transform ModelTransform;

//    void Update()
//    {
//        if (_brain.Target != null)
//        {
//            PlayerGameObj = _brain.Target.parent.gameObject;

//            // Update the serialized variables
//            wizardXposion = transform.position.x;
//            playerXposition = PlayerGameObj.transform.position.x;

//            // Check if the target is to the right or left of the object
//            if (playerXposition > wizardXposion && !isFacingRight)
//            {
//                // Flip the body (child) to face right only if already facing left
//                ModelTransform.localScale = new Vector3(1, 1, 1); // Flip the sprite to face right
//                isFacingRight = true;
//            }
//            else if (playerXposition < wizardXposion && isFacingRight)
//            {
//                // Flip the body (child) to face left only if already facing right
//                ModelTransform.localScale = new Vector3(-1, 1, 1); // Flip the sprite to face left
//                isFacingRight = false;
//            }
//        }
//    }
//}
