using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SriptForDubugging : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) // Checks if the O key is pressed
        {
            Debug.Log("Key O pressed");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
    }
}
