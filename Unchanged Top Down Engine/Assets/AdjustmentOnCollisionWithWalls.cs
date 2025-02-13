using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class AdjustmentOnCollisionWithWalls : MonoBehaviour
{
    public string targetLayerName = "TargetLayer";
    public List<GameObject> Points;
    private string objName;
    private int pointNumber;
    public float reEnableTime = 5f; // Time in seconds before re-enabling

    private void Awake()
    {
        objName = gameObject.name;
        ExtractPointNumber();
    }

    private void ExtractPointNumber()
    {
        Match match = Regex.Match(objName, @"\d+");
        if (match.Success)
        {
            pointNumber = int.Parse(match.Value);
            Debug.Log($"Successfully parsed number: {pointNumber}");
        }
        else
        {
            Debug.LogError($"Failed to extract number from {objName}");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(targetLayerName))
        {
            Debug.Log("Trigger with correct layer (" + targetLayerName + ") detected: " + other.gameObject.name);
            StartCoroutine(DisableAndReEnablePoints());
        }
    }

    private IEnumerator DisableAndReEnablePoints()
    {
        List<GameObject> disabledObjects = new List<GameObject>();

        // Disable higher-numbered GameObjects
        foreach (GameObject point in Points)
        {
            Match match = Regex.Match(point.name, @"\d+");
            if (match.Success && int.TryParse(match.Value, out int otherPointNumber))
            {
                if (otherPointNumber > pointNumber)
                {
                    point.SetActive(false);
                    disabledObjects.Add(point);
                    Debug.Log($"Disabled: {point.name}");
                }
            }
        }

        // Wait for the specified time before re-enabling
        yield return new WaitForSeconds(reEnableTime);

        // Re-enable all previously disabled GameObjects
        foreach (GameObject point in disabledObjects)
        {
            point.SetActive(true);
            Debug.Log($"Re-enabled: {point.name}");
        }
    }
}
