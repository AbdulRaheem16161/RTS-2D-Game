using UnityEngine;
using MoreMountains.TopDownEngine;
using Pathfinding;

public class My_Aim : MonoBehaviour
{
    [SerializeField] private GameObject hisCurrentTarget;
    public GunRangeCone gunrangecone;

    void Update()
    {
        // First check if gunrangecone exists
        if (gunrangecone == null)
        {
            Debug.LogWarning("GunRangeCone is not assigned!");
            return;
        }

        // Then check for nearest enemy
        if (gunrangecone.NearestEnemy != null)
        {
            Transform targetTransform = null;
            foreach (Transform child in gunrangecone.NearestEnemy.transform)
            {
                if (child.CompareTag("PointToBeShot"))
                {
                    targetTransform = child;
                    break;
                }
            }
            if (targetTransform != null)
            {
                hisCurrentTarget = targetTransform.gameObject;
                Vector3 direction = hisCurrentTarget.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}