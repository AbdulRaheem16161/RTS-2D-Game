using UnityEngine;
using System.Collections;
using System.Linq;


namespace Pathfinding
{
    /// <summary>
    /// Sets the destination of an AI to the position of the nearest object with a specified tag.
    /// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
    /// This component will then make the AI move towards the <see cref="target"/> set on this component.
    ///
    /// See: <see cref="Pathfinding.IAstarAI.destination"/>
    ///
    /// [Open online documentation to see images]
    /// </summary>
    [UniqueComponent(tag = "ai.destination")]
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
    public class AIDestinationSetter : VersionedMonoBehaviour
    {
        /// <summary>The object that the AI should move to</summary>
        IAstarAI ai;
        [SerializeField] public string pointToFollowTag1;
        [SerializeField] public string pointToFollowTag2;
        public GameObject PointToReach;
        public Transform target;

        void OnEnable()
        {
            ai = GetComponent<IAstarAI>();
            if (ai != null) ai.onSearchPath += Update;
        }

        void OnDisable()
        {
            if (ai != null) ai.onSearchPath -= Update;
        }

        /// <summary>Updates the AI's destination every frame to the nearest object with the specified tag</summary>
        void Update()
        {
            if (target != null && ai != null)
            {
                ai.destination = target.position;
            }
        }

        public void FindNearestTarget()
        {
            GameObject[] objectsWithTag1 = GameObject.FindGameObjectsWithTag(pointToFollowTag1);
            GameObject[] objectsWithTag2 = GameObject.FindGameObjectsWithTag(pointToFollowTag2);

            // Combine both arrays
            GameObject[] targetObjects = objectsWithTag1.Concat(objectsWithTag2).ToArray();

            float closestDistance = Mathf.Infinity;
            target = null;

            foreach (GameObject obj in targetObjects)
            {
                float distance = Vector3.Distance(transform.position, obj.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    target = obj.transform;
                }
            }
        }

        public void SetTargetToPointToBeReached()
        {
            target = PointToReach.transform;
        }

    }
}
