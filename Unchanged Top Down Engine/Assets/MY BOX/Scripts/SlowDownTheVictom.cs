//using System;
//using UnityEngine;
//using MoreMountains.TopDownEngine;

//namespace MoreMountains.TopDownEngine
//{
//    public GameObject projectile;

//    /// <summary>
//    /// A custom projectile that slows down the player on hit.
//    /// </summary>
//    [AddComponentMenu("TopDown Engine/Weapons/SlowDownProjectile")]
//    public class SlowDownTheVictim : Projectile
//    {
//        private void OnCollisionEnter(Collision collision)
//        {
//            HandleCollisionOrTrigger(collision.gameObject);
//        }

//        private void OnTriggerEnter(Collider other)
//        {
//            HandleCollisionOrTrigger(other.gameObject);
//        }

//        /// <summary>
//        /// Handles the logic when the projectile collides with or triggers an object.
//        /// </summary>
//        /// <param name="hitObject">The object that was hit or triggered.</param>
//        private void HandleCollisionOrTrigger(GameObject hitObject)
//        {
//            if (hitObject.CompareTag("Player"))
//            {
//                hitObject.characterSpeedControl = hitObject.GetComponent<CharacterSpeedControl>();
//                if (characterSpeedControl != null)
//                {
//                    characterSpeedControl.SlowDownSpeed();
//                }
//            }
//        }
//    }
//}
