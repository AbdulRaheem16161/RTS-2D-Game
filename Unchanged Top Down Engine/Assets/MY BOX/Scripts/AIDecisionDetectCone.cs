using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;

public class AIDecisionDetectCone : AIDecision
{
    public float rayLength = 5f;        
    public int X = 1;                 
    public int Y = 1;                  
    public int Z = 1;                  
    public int numberOfRays = 10;       
    public LayerMask detectionLayer;  
    public LayerMask blockingLayer;    

    [SerializeField] private bool _targetDetected;     

    [SerializeField] private float RotationOfGameObj;  
    [SerializeField] private float RaysDirection;
    [SerializeField] private Vector3 rayOrigin = Vector3.zero;   
    [SerializeField] private Vector3 offset;
    [SerializeField] protected bool a;
    [SerializeField] protected bool b;
    [SerializeField] protected bool c;
    [SerializeField] protected bool d;
    [SerializeField] protected bool PlayerDetected;

    [SerializeField] public string ItsEnemyTag1;
    [SerializeField] public string ItsEnemyTag2;


    void Update()
    {
        RotationOfGameObj = gameObject.transform.localRotation.eulerAngles.y;

        if (RotationOfGameObj == 180f)
        {
            RaysDirection = -1f;   
        }
        else if (RotationOfGameObj == 0f)
        {
            RaysDirection = 1f;
        }

        rayOrigin = transform.position + offset;

        PlayerDetected = _targetDetected;
        a = true;
    }

    public override bool Decide()
    {
        b = true;
        _targetDetected = false;  

        for (int i = 0; i < numberOfRays; i++)
        {
            c = true;
            Vector3 direction = new Vector3(X, Y + i, Z).normalized;

            Debug.DrawRay(rayOrigin, direction * rayLength * RaysDirection, Color.red);

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, direction * RaysDirection, rayLength, detectionLayer | blockingLayer);

            if (hit.collider != null)
            {
                d = true;

                if (hit.collider.CompareTag(ItsEnemyTag1) || hit.collider.CompareTag(ItsEnemyTag2))
                {
                    _targetDetected = true;
                    return true;  
                }
            }
        }

        return false;  
    }
}
