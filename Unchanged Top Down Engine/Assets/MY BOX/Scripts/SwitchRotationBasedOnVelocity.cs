using UnityEngine;

public class SwitchRotationBasedOnVelocity : MonoBehaviour
{
    [Header("Serialized Values")]
    [SerializeField] private float rotationAngleRight = 0f;
    [SerializeField] private float rotationAngleLeft = -180f;
    [SerializeField] private float directionThreshold = 0.1f;
    [SerializeField] public GameObject pathfinder;
    [SerializeField] private float velocity;
    [SerializeField] private bool a;

    private Vector2 previousPosition;
    private Vector2 currentVelocity;

    void Start()
    {
        // Initialize the previous position at the start
        previousPosition = pathfinder.transform.position;
    }

    void Update()
    {
        // Calculate the velocity by tracking position change
        currentVelocity = (Vector2)(pathfinder.transform.position - new Vector3(previousPosition.x, previousPosition.y, pathfinder.transform.position.z)) / Time.deltaTime;
        velocity = currentVelocity.x; // Track only the x velocity

        // Update the previous position for the next frame
        previousPosition = pathfinder.transform.position;

        // Check for the direction and set rotation accordingly
        if (velocity > directionThreshold)
        {
            transform.rotation = Quaternion.Euler(0, rotationAngleRight, 0);
            a = true;
        }
        else if (velocity < -directionThreshold)
        {
            transform.rotation = Quaternion.Euler(0, rotationAngleLeft, 0);
            a = false;
        }
    }
}
