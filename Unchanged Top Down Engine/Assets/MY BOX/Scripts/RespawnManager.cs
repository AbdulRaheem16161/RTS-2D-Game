using UnityEngine;
using System.Collections.Generic;
using Pathfinding;  // For A* Pathfinding's AIPath
using MoreMountains.TopDownEngine;


public class RespawnManager : MonoBehaviour
{
    public List<GameObject> prefabs;  // List of prefab objects
    public List<GameObject> pathfinders;  // List of pathfinding objects
    public List<GameObject> PointsToBeReached; // List of destination objects
    public List<Transform> spawnPoints;  // List of spawn points

    void Update()
    {
        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown((KeyCode)(48 + i))) // More reliable numeric key detection
            {
                int index = i - 1; // Convert key to 0-based index

                if (index < prefabs.Count && index < pathfinders.Count && index < spawnPoints.Count && index < PointsToBeReached.Count)
                {
                    // Instantiate objects
                    GameObject newPrefab = Instantiate(prefabs[index], spawnPoints[index].position, spawnPoints[index].rotation);
                    GameObject newPathfinder = Instantiate(pathfinders[index], spawnPoints[index].position, spawnPoints[index].rotation);
                    GameObject newPointToBeReached = Instantiate(PointsToBeReached[index], PointsToBeReached[index].transform.position, PointsToBeReached[index].transform.rotation);

                    // Get components
                    var pathFindingActivator = newPrefab.GetComponent<PathFindingActivator>();
                    var pathFindingDeactivator = newPrefab.GetComponent<PathFindingDeactivator>();
                    var faceTowardsTarget = newPrefab.GetComponent<FaceTowardsTarget_New>();
                    var orientationController1 = newPrefab.GetComponent<OrientationController1>();
                    var orientationController2 = newPrefab.GetComponent<OrientationController2>();
                    var switchRotationBasedOnVelocity = newPrefab.GetComponentInChildren<SwitchRotationBasedOnVelocity>();
                    var makePathFinderTheParent = newPathfinder.GetComponent<My_MakePathFinderTheParent>();
                    var makeWizardTheParent = newPathfinder.GetComponent<My_MakeWizardTheParent>();
                    var pathfinderScript = newPathfinder.GetComponent<AIPath>();
                    var destinationSetter = newPathfinder.GetComponent<AIDestinationSetter>();
                    var randomPositionAllocator = newPointToBeReached.GetComponent<RandomPositionAllocatorToThisObj>();

                    if (pathFindingActivator != null)
                    {
                        pathFindingActivator.MakePathFinderTheParent = makePathFinderTheParent;
                        pathFindingActivator.MakeWizardTheParent = makeWizardTheParent;
                        pathFindingActivator.pathfinderScript = pathfinderScript;
                    }

                    if (pathFindingDeactivator != null)
                    {
                        pathFindingDeactivator.MakePathFinderTheParent = makePathFinderTheParent;
                        pathFindingDeactivator.MakeWizardTheParent = makeWizardTheParent;
                        pathFindingDeactivator.pathfinderScript = pathfinderScript;
                    }

                    if (faceTowardsTarget != null)
                    {
                        faceTowardsTarget.destinationSetter = destinationSetter;
                    }

                    if (orientationController1 != null)
                    {
                        orientationController1.destinationSetter = destinationSetter;
                    }

                    if (orientationController2 != null)
                    {
                        orientationController2.destinationSetter = destinationSetter;
                    }

                    if (destinationSetter != null && randomPositionAllocator != null)
                    {
                        destinationSetter.PointToReach = newPointToBeReached;
                    }

                    if (makePathFinderTheParent != null)
                    {
                        makePathFinderTheParent.Prefab = newPrefab;
                        makePathFinderTheParent.PathFinder = newPathfinder;
                    }

                    if (makeWizardTheParent != null)
                    {
                        makeWizardTheParent.Prefab = newPrefab;
                        makeWizardTheParent.PathFinder = newPathfinder;
                    }

                    if (switchRotationBasedOnVelocity != null)
                    {
                        switchRotationBasedOnVelocity.pathfinder = newPathfinder;
                    }
                }
                else
                {
                    Debug.LogWarning($"Prefab, pathfinder, or spawn point missing for key: {i}");
                }
            }
        }
    }

    



}
