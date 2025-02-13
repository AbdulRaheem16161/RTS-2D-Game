using UnityEngine;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;

public class GunRangeCone : AIDecision
{
    public float rayLength = 35f;
    public int X = 12;
    public int Y = -5;
    public int Z = 0;
    public int numberOfRays = 10;
    public LayerMask detectionLayer;
    public LayerMask blockingLayer;

    [SerializeField] private bool _targetDetected;
    [SerializeField] private Vector3 rayOrigin = Vector3.zero;
    [SerializeField] private Vector3 offset;
    [SerializeField] protected bool a, b, c, d, PlayerDetected;

    [SerializeField] public string ItsEnemyTag1;
    [SerializeField] public string ItsEnemyTag2;

    // Stores detected enemies
    public List<GameObject> detectedEnemies = new List<GameObject>();
    [SerializeField] public GameObject NearestEnemy;

    private float RaysDirection;  // Direction the rays should face

    void Start()
    {
        NearestEnemy = null;
    }

    void Update()
    {
        // Determine direction based on which way the object is facing
        if (transform.right.x < 0)
        {
            RaysDirection = -1f; // Facing left
        }
        else
        {
            RaysDirection = 1f;  // Facing right
        }


        rayOrigin = transform.position + offset;
        PlayerDetected = _targetDetected;
        a = true;
    }

    public override bool Decide()
    {
        b = true;
        _targetDetected = false;
        detectedEnemies.Clear(); // Clear the list before detecting new enemies

        for (int i = 0; i < numberOfRays; i++)
        {
            c = true;
            Vector2 direction = new Vector2(X, Y + i).normalized; // Adjusted for 2D

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, direction * rayLength * RaysDirection, rayLength, detectionLayer | blockingLayer);

            if (hit.collider != null)
            {
                d = true;

                // Check if the hit object is an enemy
                if (hit.collider.CompareTag(ItsEnemyTag1) || hit.collider.CompareTag(ItsEnemyTag2))
                {
                    detectedEnemies.Add(hit.collider.gameObject); // Add to detected enemies list
                    _targetDetected = true;
                }
            }
        }

        // Find the nearest enemy
        if (detectedEnemies.Count > 0)
        {
            float closestDistance = Mathf.Infinity;
            NearestEnemy = null;

            foreach (GameObject enemy in detectedEnemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    NearestEnemy = enemy;
                }
            }
        }

        return _targetDetected;
    }

    // Add Gizmos to visualize rays in the Scene view
    private void OnDrawGizmos()
    {
        // Set the ray origin
        rayOrigin = transform.position + offset;

        // Draw each ray in the Scene view
        for (int i = 0; i < numberOfRays; i++)
        {
            Vector2 direction = new Vector2(X, Y + i).normalized;
            Gizmos.color = Color.blue; // Set the ray color
            Gizmos.DrawRay(rayOrigin, direction * rayLength * RaysDirection); // Draw the ray
        }
    }
}
