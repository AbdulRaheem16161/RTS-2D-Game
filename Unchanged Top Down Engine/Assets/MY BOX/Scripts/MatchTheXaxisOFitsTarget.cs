using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MatchTheXaxisOFitsTarget : MonoBehaviour
{
    public AIDestinationSetter aiDestinationSetter;
    [SerializeField] private Transform targetToMatchYaxis;
    [SerializeField] private float yPositionOfTheTarget;
    [SerializeField] private float yPositionOfThisGameObj;
    [SerializeField] private float moveSpeed = 0.5f; // Adjustable speed

    // Update is called once per frame
    void Update()
    {
        if (aiDestinationSetter.target != null)
        {
            targetToMatchYaxis = aiDestinationSetter.target;
            yPositionOfTheTarget = Mathf.Floor(targetToMatchYaxis.position.y); // Ignore decimal value

            Vector3 currentPosition = transform.position;
            currentPosition.y = Mathf.MoveTowards(currentPosition.y, yPositionOfTheTarget, moveSpeed * Time.deltaTime);
            yPositionOfThisGameObj = currentPosition.y;
            transform.position = currentPosition; // Assign the entire Vector3
        }
    }
}
