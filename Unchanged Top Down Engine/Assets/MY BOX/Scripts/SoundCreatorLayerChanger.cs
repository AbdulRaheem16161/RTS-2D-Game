using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCreatorLayerChanger : MonoBehaviour
{
    [Header("Layer Settings")]
    [SerializeField] private int ShootingLayer;  // Serialized int for walking layer
    [SerializeField] private int runningLayer;  // Serialized int for running layer
    [SerializeField] private int walkingLayer;  // Serialized int for walking layer

    public void ChangeToShootingLayer()
    {
        gameObject.layer = ShootingLayer;
    }

    public void ChangeToRunningLayer()
    {
        gameObject.layer = runningLayer;  // Set the layer to running layer
    }

    public void ChangeToWalkingLayer()
    {
        gameObject.layer = walkingLayer;  // Set the layer to walking layer
    }

    public void RemoveLayer()
    {
        gameObject.layer = 0;  // Reset the layer to "Default" (layer 0)
    }
}
