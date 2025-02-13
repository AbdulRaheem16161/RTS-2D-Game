using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;

namespace CustomNamespace
{
    /// <summary>
    /// Requires a CharacterMovement ability. Makes the character move and face towards the target horizontally (left or right).
    /// It also adjusts the target to follow the child with the "point to follow" layer.
    /// </summary>
    [AddComponentMenu("TopDown Engine/Character/AI/Actions/AI Action Move Towards Target With Direction")]
    public class AIActionMoveTowardsTargetWithDirection : AIActionMoveTowardsTarget2D
    {
        protected CharacterMovement _characterMovement;
        protected CharacterOrientation2D _characterOrientation;
        protected bool _wasOrientationControlledByCharacterOrientation;
        [SerializeField] private GameObject PositionCheckerGameObj;
        [SerializeField] private GameObject targetGameObject;

        [Header("Inspector Debugging")]
        [Tooltip("The position of the target.")]
        public Vector3 targetPosition;

        [Tooltip("Is the target on the right of the character?")]
        public bool targetIsOnRight;

        [Tooltip("Is the target on the left of the character?")]
        public bool targetIsOnLeft;

        [Tooltip("Is the orientation controlled by DirectionTowardsThePlayer?")]
        public bool orientationControlledByDirectionTowardsThePlayer;

        [Tooltip("Is the orientation controlled by CharacterOrientation2D?")]
        public bool orientationControlledByCharacterOrientation;

        /// <summary>
        /// On init we grab our CharacterMovement and CharacterOrientation2D abilities.
        /// </summary>
        public override void Initialization()
        {
            if (!ShouldInitialize) return;
            base.Initialization();
            _characterMovement = this.gameObject.GetComponentInParent<Character>()?.FindAbility<CharacterMovement>();
            _characterOrientation = this.gameObject.GetComponentInParent<Character>()?.FindAbility<CharacterOrientation2D>();
        }

        /// <summary>
        /// On PerformAction we move, adjust the target and face the target horizontally.
        /// </summary>
        public override void PerformAction()
        {
            AdjustTargetToChild();
            MoveAndFaceTarget();
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
                    targetGameObject = child.gameObject; // just for debugging in the inspector
                    PositionCheckerGameObj = child.parent.gameObject;

                    return;
                }
            }
        }


        /// <summary>
        /// Moves the character towards the target if needed and controls the orientation.
        /// </summary>
        protected virtual void MoveAndFaceTarget()
        {
            if (_brain.Target == null)
            {
                return;
            }

            targetPosition = _brain.Target.position;

            // Check if the target is on the right or left
            targetIsOnRight = PositionCheckerGameObj.transform.position.x > this.transform.position.x;
            targetIsOnLeft = !targetIsOnRight;

            // Disable the orientation control by CharacterOrientation2D
            if (_characterOrientation != null)
            {
                orientationControlledByCharacterOrientation = _characterOrientation.enabled;
                _characterOrientation.enabled = false;
            }

            //// Control movement
            //if (targetIsOnRight)
            //{
            //    _characterMovement.SetHorizontalMovement(1f);
            //}
            //else
            //{
            //    _characterMovement.SetHorizontalMovement(-1f);
            //}

            //// Vertically move towards the target
            //if (this.transform.position.y < _brain.Target.position.y)
            //{
            //    _characterMovement.SetVerticalMovement(1f);
            //}
            //else
            //{
            //    _characterMovement.SetVerticalMovement(-1f);
            //}

          //  Enable the orientation control by DirectionTowardsThePlayer
            orientationControlledByDirectionTowardsThePlayer = true;
        }

        /// <summary>
        /// On exit state we stop our movement and restore orientation control.
        /// </summary>
        public override void OnExitState()
        {
            base.OnExitState();

            _characterMovement?.SetHorizontalMovement(0f);
            _characterMovement?.SetVerticalMovement(0f);

            // Restore the orientation control
            if (_characterOrientation != null)
            {
                _characterOrientation.enabled = orientationControlledByCharacterOrientation;
            }

            orientationControlledByDirectionTowardsThePlayer = false;
        }
    }
}
