using UnityEngine;

[ExecuteAlways]
public class LocalNGlobalTransform : MonoBehaviour
{
    [Header("Local Properties")]
    [SerializeField] private Vector3 localPosition;
    [SerializeField] private Vector3 localScale;
    [SerializeField] private Vector3 localRotation;

    [Header("World Properties")]
    [SerializeField] private Vector3 worldPosition;
    [SerializeField] private Vector3 worldScale;
    [SerializeField] private Vector3 worldRotation;

    void Update()
    {
        // Update local properties
        localPosition = transform.localPosition;
        localScale = transform.localScale;
        localRotation = transform.localEulerAngles;

        // Update world properties
        worldPosition = transform.position;
        worldScale = transform.lossyScale;
        worldRotation = transform.eulerAngles;
    }
}
