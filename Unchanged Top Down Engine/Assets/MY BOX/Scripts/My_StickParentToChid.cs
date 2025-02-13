using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_MakeWizardTheParent : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject PathFinder;
    [SerializeField] private bool a;

    void Update()
    {
        a = true;

        if (Prefab != null && PathFinder != null)
        {
            
            if (Prefab.transform.parent == PathFinder.transform)
            {
                Prefab.transform.parent = null;
            }
            else if (Prefab.transform.parent == null)
            {
                PathFinder.transform.parent = Prefab.transform;
                PathFinder.transform.localPosition = Vector3.zero;
            }
        }
    }
}
