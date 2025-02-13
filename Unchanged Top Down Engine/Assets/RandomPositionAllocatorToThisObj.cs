using System.Collections;
using UnityEngine;

public class RandomPositionAllocatorToThisObj : MonoBehaviour
{
    [SerializeField] private float areaWidth = 5f;  // Width of the square area
    [SerializeField] private float areaHeight = 5f; // Height of the square area
    [SerializeField] private Vector2 areaCenter = Vector2.zero; // Fixed center of the area

    [SerializeField] private int minInterval = 2; // Minimum time before switching
    [SerializeField] private int maxInterval = 5; // Maximum time before switching

    void Start()
    {
        StartCoroutine(SwitchPositionRoutine());
    }

    IEnumerator SwitchPositionRoutine()
    {
        while (true)
        {
            float switchInterval = Random.Range(minInterval, maxInterval + 1); // Random interval between min and max
            yield return new WaitForSeconds(switchInterval);
            SwitchPosition();
        }
    }

    void SwitchPosition()
    {
        float halfWidth = areaWidth / 2;
        float halfHeight = areaHeight / 2;

        float randomX = Random.Range(areaCenter.x - halfWidth, areaCenter.x + halfWidth);
        float randomY = Random.Range(areaCenter.y - halfHeight, areaCenter.y + halfHeight);

        transform.position = new Vector3(randomX, randomY, transform.position.z);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector3(areaCenter.x, areaCenter.y, 0), new Vector3(areaWidth, areaHeight, 0));
    }
}
