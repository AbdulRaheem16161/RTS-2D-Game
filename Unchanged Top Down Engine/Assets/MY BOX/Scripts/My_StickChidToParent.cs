using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_MakePathFinderTheParent : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject PathFinder;
    [SerializeField] private bool a;
    [SerializeField] private Vector3 positionOffset; // Offset for local position

    void Update()
    {
        a = true;

        if (Prefab != null && PathFinder != null)
        {
            if (PathFinder.transform.parent == Prefab.transform)
            {
                PathFinder.transform.parent = null;
            }
            else if (PathFinder.transform.parent == null)
            {
                Prefab.transform.parent = PathFinder.transform;
                Prefab.transform.localPosition = positionOffset; // Apply offset
            }
        }
    }
}
