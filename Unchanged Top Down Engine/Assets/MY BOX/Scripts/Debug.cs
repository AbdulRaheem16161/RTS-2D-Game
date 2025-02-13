//using UnityEngine;
//using System.Collections.Generic;

//public class RespawnManager : MonoBehaviour
//{
//    public List<GameObject> prefabs; // List of prefabs
//    public List<GameObject> pathfinders; // List of pathfinders
//    public List<Transform> spawnPoints; // Spawn points for prefabs and pathfinders

//    void Update()
//    {
//        // Loop through keys 1 to 9
//        for (int i = 1; i <= 9; i++)
//        {
//            if (Input.GetKeyDown(i.ToString()))
//            {
//                int index = i - 1; // Convert key to 0-based index

//                // Ensure index is within bounds
//                if (index < prefabs.Count && index < pathfinders.Count && index < spawnPoints.Count)
//                {
//                    // Instantiate prefab and pathfinder
//                    GameObject newPrefab = Instantiate(prefabs[index], spawnPoints[index].position, spawnPoints[index].rotation);
//                    GameObject newPathfinder = Instantiate(pathfinders[index], spawnPoints[index].position, spawnPoints[index].rotation);

//                    // Link prefab to pathfinder
//                    var pathFindingActivator = newPrefab.GetComponent<PathFindingActivator>();
//                    var makePathFinderTheParent1 = newPathfinder.GetComponent<My_MakePathFinderTheParent>();
//                    var makeWizardTheParent1 = newPathfinder.GetComponent<My_MakeWizardTheParent>();

//                    pathFindingActivator.MakePathFinderTheParent = makePathFinderTheParent1;
//                    pathFindingActivator.MakeWizardTheParent = makeWizardTheParent1;


//                    var pathFindingDeactivator = newPrefab.GetComponent<PathFindingDeactivator>();
//                    var makePathFinderTheParent2 = newPrefab.GetComponent<My_MakePathFinderTheParent>();
//                    var makeWizardTheParent2 = newPrefab.GetComponent<My_MakeWizardTheParent>();

//                    pathFindingDeactivator.MakePathFinderTheParent = makePathFinderTheParent2;
//                    pathFindingDeactivator.MakeWizardTheParent = makeWizardTheParent2;

//                    newPathfinder.Prefab = newPrefab;
//                    newPathfinder.PathFinder = newPathfinder;
//                }
//                else
//                {
//                    Debug.LogWarning("Prefab, pathfinder, or spawn point missing for key: " + i);
//                }
//            }
//        }
//    }
//}
