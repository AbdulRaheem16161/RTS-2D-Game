//using UnityEngine;
//using MoreMountains.TopDownEngine;
//using MoreMountains.Tools;  // Add this line to reference the MoreMountains.Tools namespace

//namespace MoreMountains.TopDownEngine
//{
//    public class GunAimAtTarget : WeaponAim2D
//    {
//        [SerializeField] private AIBrain _aiBrain;
//        [SerializeField] private Transform _target;
//        [SerializeField] private bool _initialized = false;

//        // Called when the gun becomes a child of the AI object in the scene
//        private void OnTransformParentChanged()
//        {
//            // Ensure we only attempt to get AIBrain once the gun is a child of the AI
//            if (transform.parent != null && !_initialized)
//            {
//                _aiBrain = transform.parent.GetComponentInParent<AIBrain>(); // Get the AIBrain from the parent AI
//                _initialized = true;
//            }
//        }

//        // Called by WeaponAim2D to update the aim based on the target
//        public override void GetScriptAim()
//        {
//            // Ensure that we have successfully initialized and found AIBrain
//            if (_aiBrain != null && _aiBrain.Target != null)
//            {
//                _target = _aiBrain.Target;

//                // Get direction from the gun to the target
//                Vector3 direction = _target.position - transform.position;

//                // Apply the angle to the weapon's rotation
//                _currentAim = direction.normalized;
//                _currentAimAbsolute = direction.normalized;
//                _direction = -(transform.position - _currentAim);

//                // Optional: Adjust rotation logic based on character orientation
//                if (_hasOrientation2D)
//                {
//                    if (_weapon.Owner.Orientation2D.IsFacingRight)
//                    {
//                        _currentAim = _direction;
//                    }
//                    else
//                    {
//                        _currentAim = -_direction;
//                    }
//                }
//            }
//        }

//        // Ensure that we update the parent change detection on initialization
//        private void Start()
//        {
//            OnTransformParentChanged();
//        }
//    }
//}
