using UnityEngine;
using System.Collections;

public class DestroyEnemyOnKeyPress : MonoBehaviour
{
    [SerializeField] private float proximityDistance = 2.0f; // Distance to consider "close"
    [SerializeField] private Collider2D _nearestEnemy;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private bool _isFrozen = false;
    [SerializeField] private float KillingDuration;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Find the nearest enemy within proximity
        FindNearestEnemy();

        // Check if 'L' is pressed and a nearby enemy is found
        if (Input.GetKeyDown(KeyCode.P) && _nearestEnemy != null && !_isFrozen)
        {
            StartCoroutine(FreezeAndDestroy());
        }
    }

    private void FindNearestEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, proximityDistance);

        _nearestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    _nearestEnemy = collider;
                }
            }
        }
    }

    private IEnumerator FreezeAndDestroy()
    {
        _isFrozen = true;
        FreezeObject(gameObject, true);

        if (_nearestEnemy != null)
        {
            FreezeObject(_nearestEnemy.gameObject, true);
        }

        yield return new WaitForSeconds(KillingDuration);

        if (_nearestEnemy != null)
        {
            Destroy(_nearestEnemy.gameObject);
        }

        FreezeObject(gameObject, false);
        _isFrozen = false;
    }

    private void FreezeObject(GameObject obj, bool freeze)
    {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.constraints = freeze ? RigidbodyConstraints2D.FreezeAll : RigidbodyConstraints2D.None;
        }

        MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour>();
        foreach (var script in scripts)
        {
            if (script != this) // Ensure we don't disable this script
            {
                script.enabled = !freeze;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a circle in the editor to visualize the proximity distance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, proximityDistance);
    }
}
