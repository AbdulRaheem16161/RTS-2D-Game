using UnityEngine;

public class ToggleYPositionOnCollision : MonoBehaviour
{
    [Tooltip("Assign the point to follow in the inspector.")]
    [SerializeField] private GameObject pointToFollow; // Reference to the point to follow
    [Tooltip("Assign the player object in the inspector.")]
    [SerializeField] private GameObject player; // Reference to the player object

    // Serialize the float values so they appear in the inspector
    [SerializeField] private float enemyXPosition; // Serialized float for the enemy's X position
    [SerializeField] private float playerXPosition; // Serialized float for the player's X position

    [SerializeField] private GameObject enemy; // Reference to the enemy object
    [SerializeField] private string TagOfItsEnemy;

    [SerializeField] private float DistanceFromItsSelf;

    private void Start()
    {
        FindNearestEnemy(); // Call the method to find the nearest enemy on start
    }

    private void Update()
    {
        FindNearestEnemy();

        if (enemy != null)
        {
            // Update the serialized positions of the enemy and player
            enemyXPosition = enemy.transform.position.x;
            playerXPosition = player.transform.position.x;

            // Check if the enemy is to the right or left of the player
            if (enemyXPosition > playerXPosition)
            {
                // Enemy is on the right of the player, change the Y position of the pointToFollow
                Vector3 newLocalPosition = pointToFollow.transform.localPosition;
                newLocalPosition.x = DistanceFromItsSelf;  // Change only the Y component
                pointToFollow.transform.localPosition = newLocalPosition;
            }
            else if (enemyXPosition < playerXPosition)
            {
                // Enemy is on the left of the player, change the Y position of the pointToFollow
                Vector3 newLocalPosition = pointToFollow.transform.localPosition;
                newLocalPosition.x = DistanceFromItsSelf * -1f;  // Change only the Y component
                pointToFollow.transform.localPosition = newLocalPosition;
            }
        }
    }

    // Method to find the nearest enemy based on the player's position
    private void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(TagOfItsEnemy); // Find all enemies with the "Enemy" tag
        if (enemies.Length == 0) return; // If no enemies are found, return

        float closestDistance = Mathf.Infinity; // Start with an infinitely large distance
        GameObject nearestEnemy = null;

        foreach (GameObject currentEnemy in enemies)
        {
            float distance = Vector3.Distance(currentEnemy.transform.position, player.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestEnemy = currentEnemy;
            }
        }

        // Assign the nearest enemy to the enemy variable
        enemy = nearestEnemy;
    }
}
